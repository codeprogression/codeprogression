/*************************************************************************
 *  Flash Card Master
 *  Copyleft (C) 2006 Nithin Philips
 *
 *  This program is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU General Public License
 *  as published by the Free Software Foundation; either version 2
 *  of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation,Inc.,59 Temple Place - Suite 330,Boston,MA 02111-1307, USA.
 *
 *  Author            :  Nithin Philips <spikiermonkey@users.sourceforge.net>
 *  Original FileName :  CardDeckPrinter.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using FlashCardMaster.Painters;
using System.IO;
using LibFlashcard.Model;
using FlashCardMaster.Dialogs;

namespace FlashCardMaster.Utilities
{
    public class CardDeckPrinter
    {
        Form owner;
        string documentTitle;
        CardDeck deck;
        LibFlashcard.Utilities.BiDirectionalEnumerator<KeyValuePair<CardElementSides, Card>> cardEnumerator;
        bool[] ranges;
        int[] selected;
        bool manualDuplex = false;

//        static PageSettings pageSettings = new PageSettings();
        static PrinterSettings printerSettings = new PrinterSettings();
        static bool printerInited = false;


        public bool CanDuplex {
            get { return printerSettings.CanDuplex; }
        }

        /// <summary>
        /// If true, pages are printed in AABB order and user is prompted to flip the paper halfway through.
        /// </summary>
        public bool ManualDuplex {
            get { return manualDuplex; }
            set { manualDuplex = value; }
        }

        public static void InitPrinter() {
            printerInited = true;
            printerSettings.DefaultPageSettings.Margins = User.Settings.AppInstance.PrintPageMargin;
            printerSettings.DefaultPageSettings.Landscape = User.Settings.AppInstance.PrinterPageLandscape;

            int paperIndex = -1;
            for (int i = 0; i < printerSettings.PaperSizes.Count; i++) {
                if (!string.IsNullOrEmpty(User.Settings.AppInstance.PrinterPreferredPaperName) && (printerSettings.PaperSizes[i].PaperName == User.Settings.AppInstance.PrinterPreferredPaperName)) {
                    paperIndex = i;
                    break;
                }else if (printerSettings.PaperSizes[i].PaperName.IndexOf("Index Card", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                    paperIndex = i;
                } else if (printerSettings.PaperSizes[i].PaperName.IndexOf("A7", StringComparison.InvariantCultureIgnoreCase) >= 0) {
                    paperIndex = i;
                }
            }
            if (paperIndex != -1) {
                printerSettings.DefaultPageSettings.PaperSize = printerSettings.PaperSizes[paperIndex];
            }
        }

        public CardDeckPrinter(CardDeck deck, int[] selected, string title, Form owner) {
            if (!printerInited) { InitPrinter(); }

            this.deck = deck;
            this.documentTitle = title;
            this.owner = owner;
            this.selected = selected;

            int min = 1;
            int max = deck.Cards.Count;

            if (max == 0) { min = 0; }

            printerSettings.MinimumPage = min;
            printerSettings.MaximumPage = max;

            printerSettings.FromPage = min;
            printerSettings.ToPage = max;

            if (printerSettings.CanDuplex) {
                printerSettings.Duplex = Duplex.Vertical;
                Console.WriteLine("Can Duplex");
            }

            this.ranges = new bool[deck.Cards.Count];
        }

        public static void ShowSetup(IWin32Window owner) {
            PageSetupDialog pageSetupDialog = null;
            try {
                if (!printerInited) { InitPrinter(); }
                pageSetupDialog = new PageSetupDialog();
                pageSetupDialog.PrinterSettings = printerSettings;
                pageSetupDialog.PageSettings = printerSettings.DefaultPageSettings;

                pageSetupDialog.AllowOrientation = true;
                pageSetupDialog.AllowMargins = true;
                pageSetupDialog.AllowPrinter = true;

                if (pageSetupDialog.ShowDialog(owner) == DialogResult.OK) {
                    // printerSettings.DefaultPageSettings = pageSetupDialog.PageSettings;
                    printerSettings = pageSetupDialog.PrinterSettings;

                    SaveUserSettings(printerSettings);
                }
            } catch (InvalidPrinterException) {
                MessageBox.Show(owner, i18n.Language.InvalidPrinterError, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } finally {
                if (pageSetupDialog != null) { pageSetupDialog.Dispose(); }
            }
        }

        public void ShowPreview() {
            using (PrintPreviewDialog dlg = new PrintPreviewDialog()) {
                using (PrintDocument doc = GetPrintDoc()) {
                    doc.DefaultPageSettings = printerSettings.DefaultPageSettings;
                    dlg.Document = doc;
                    dlg.ShowDialog(owner);
                }
            }
        }

        PrintDocument doc;
        public void Print() {
            using (PrintDialog dlgPrint = new PrintDialog()) {
                dlgPrint.AllowCurrentPage = false;
                dlgPrint.AllowSomePages = true;
                dlgPrint.AllowPrintToFile = true;
                if (selected.Length > 0) {
                    dlgPrint.AllowSelection = true;
                }
                dlgPrint.Document = GetPrintDoc();
                dlgPrint.PrinterSettings = printerSettings;
                dlgPrint.UseEXDialog = true;

                if (dlgPrint.ShowDialog(owner) == DialogResult.OK) {
                    UpdatePrinterSettings(dlgPrint.PrinterSettings);
                    doc = dlgPrint.Document;
                    if (doc == null) {
                        doc = GetPrintDoc();
                    }
                    doc.PrinterSettings = dlgPrint.PrinterSettings;
                    doc.DefaultPageSettings = dlgPrint.PrinterSettings.DefaultPageSettings;

                    SaveUserSettings(printerSettings);

                    doc.Print();
                }
            }
        }

        private static void SaveUserSettings(PrinterSettings printerSettings) {
            User.Settings.AppInstance.PreferredPrinterName = printerSettings.PrinterName;
            User.Settings.AppInstance.PrintPageMargin = printerSettings.DefaultPageSettings.Margins;
            User.Settings.AppInstance.PrinterPreferredPaperName = printerSettings.DefaultPageSettings.PaperSize.PaperName;
            User.Settings.AppInstance.PrinterPageLandscape = printerSettings.DefaultPageSettings.Landscape;
        }

        private void UpdatePrinterSettings(PrinterSettings settings) {
            if (User.Settings.AppInstance.PrinterLiesAboutDuplex || !settings.CanDuplex) {
                if (MessageBox.Show(owner, i18n.Language.PrinterCannotDuplex, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                    // Print AABB
                    this.manualDuplex = true;
                } else {
                    // Print ABAB
                    this.manualDuplex = false;
                }
                settings.Duplex = Duplex.Default;
            } else {
                settings.Duplex = Duplex.Vertical;
            }
        }

        private PrintDocument GetPrintDoc() {
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = Path.GetFileNameWithoutExtension(documentTitle);
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDoc.BeginPrint += new PrintEventHandler(printDoc_BeginPrint);
            return printDoc;
        }

        void printDoc_BeginPrint(object sender, PrintEventArgs e) {
            if (!manualDuplexPhaseTwo) {
                List<KeyValuePair<CardElementSides, Card>> cards;

                if (printerSettings.PrintRange == PrintRange.Selection) {
                    cards = new List<KeyValuePair<CardElementSides, Card>>(selected.Length * 2);
                    for (int i = 0; i < selected.Length; i++) {
                        PrepareCard(cards, deck.Cards[selected[i]]);
                    }
                } else if (printerSettings.PrintRange == PrintRange.SomePages) {
                    cards = new List<KeyValuePair<CardElementSides, Card>>();
                    for (int i = printerSettings.FromPage - 1; i < printerSettings.ToPage; i++) {
                        PrepareCard(cards, deck.Cards[i]);
                    }
                } else {
                    cards = new List<KeyValuePair<CardElementSides, Card>>(deck.Cards.Count * 2);
                    for (int i = 0; i < deck.Cards.Count; i++) {
                        PrepareCard(cards, deck.Cards[i]);
                    }
                }

                if (manualDuplex) {
                    int count = cards.Count;
                    for (int i = 0; i < count; i++) {
                        cards.Add(new KeyValuePair<CardElementSides, Card>(CardElementSides.Back, cards[i].Value));
                    }
                }

                cardEnumerator = new LibFlashcard.Utilities.BiDirectionalEnumerator<KeyValuePair<CardElementSides, Card>>(cards, LibFlashcard.Utilities.EnumerationOrder.Normal);
            }
        }

        private void PrepareCard(List<KeyValuePair<CardElementSides, Card>> list, Card card) {
            list.Add(new KeyValuePair<CardElementSides, Card>(CardElementSides.Front, card));
            if (!this.manualDuplex) {
                list.Add(new KeyValuePair<CardElementSides, Card>(CardElementSides.Back, card));
            }
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e) {
            using (Graphics g = e.Graphics) {
                if (cardEnumerator.MoveNext()) {
                    PrinterBounds pb = new PrinterBounds(e);
                    Rectangle pageBounds = pb.Bounds;

                    //				Console.WriteLine("{0} => {1}", pageBounds, ScaleRectangle(g, pageBounds));
                    //				Console.WriteLine("{0} => {1}", User.Settings.Instance.PreferredFont.GetFont(), ScaleFont(g, User.Settings.Instance.PreferredFont.GetFont()));

                    TextGroupPainter[] painters = CardPanel.CardToPainters(
                                                        cardEnumerator.Current.Value,
                                                        cardEnumerator.Current.Key,
                                                        ScaleRectangle(g, pageBounds),
                                                        ScaleFont(g, User.Settings.AppInstance.PrintFont.GetFont()));

                    foreach (TextGroupPainter painter in painters) {
                        painter.Paint(g);
                    }

                    if (manualDuplex) {
                        if ((cardEnumerator.CurrentIndex + 1) == (cardEnumerator.Count / 2)) {
                            owner.BeginInvoke((MethodInvoker)delegate() {
                                // The call must be invoked async to prevent spooling.
                                DoManualDuplex();
                            });
                            e.HasMorePages = false; // Some printer keep spooling if we just pause here.
                            return;
                        }
                    }

                    e.HasMorePages = cardEnumerator.CanMoveNext();
                }
            }
        }

        bool manualDuplexPhaseTwo = false;
        void DoManualDuplex() {
            using (PrinterFlipPrompt prompt = new PrinterFlipPrompt()) {
                if (prompt.ShowDialog(owner) == DialogResult.OK) {
                    manualDuplexPhaseTwo = true;
                    doc.Print(); // print part two
                }
            }
        }

        public static Point ScalePoint(Graphics g, ref Point p) {
            return new Point(
              (int)Math.Ceiling(p.X / 100f * g.DpiX),
              (int)Math.Ceiling(p.Y / 100f * g.DpiY));
        }

        public static Rectangle ScaleRectangle(Graphics g, Rectangle r) {
            return new Rectangle(
              (int)Math.Ceiling(r.X / 100f * g.DpiX),
              (int)Math.Ceiling(r.Y / 100f * g.DpiY),
              (int)Math.Ceiling(r.Width / 100f * g.DpiX),
              (int)Math.Ceiling(r.Height / 100f * g.DpiY));
        }

        public static Rectangle UnScaleRectangle(Graphics g, Rectangle r) {
            return new Rectangle(
              (int)Math.Ceiling(r.X / g.DpiX * 100f),
              (int)Math.Ceiling(r.Y / g.DpiY * 100f),
              (int)Math.Ceiling(r.Width / g.DpiX * 100f),
              (int)Math.Ceiling(r.Height / g.DpiY * 100f));
        }

        public static Font ScaleFont(Graphics g, Font font) {
            return new Font(
              font.FontFamily, font.SizeInPoints / 72f *
              g.DpiY, font.Style, GraphicsUnit.Pixel,
              font.GdiCharSet, font.GdiVerticalFont);
        }
    }
}
