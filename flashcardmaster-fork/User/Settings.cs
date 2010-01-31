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
 *  Original FileName :  Settings.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using FlashCardMaster.Utilities;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace FlashCardMaster.User
{
    [Serializable]
    public sealed class Settings
    {
        static object objectLock = new object();

        public static void Save() {
            Utility.Serialize<ApplicationSettings>(Settings.AppInstance, Utility.DEFAULT_SETTINGS_FILE);
            if (winSettings != null) { winSettings.Serialize(Utility.WINDOW_SETTINGS_FILE); }
        }

        static ApplicationSettings appSettings;

        public static ApplicationSettings AppInstance {
            get {
                lock (objectLock) {
                    if (appSettings == null) {
                        if (File.Exists(Utility.DEFAULT_SETTINGS_FILE)) {
                            appSettings = Utility.DeSerialize<ApplicationSettings>(Utility.DEFAULT_SETTINGS_FILE);
                        } else {
                            appSettings = new ApplicationSettings();
                        }
                    }
                }
                return appSettings;
            }
        }

        static object winObjectLock = new object();
        static WindowSettings winSettings;

        public static WindowSettings WinSettings {
            get {
                lock (winObjectLock) {
                    if (winSettings == null) {
                        winSettings = WindowSettings.DeSerialize(Utility.WINDOW_SETTINGS_FILE);
                    }
                }
                return winSettings;
            }
        }

        // Note: Properties of this class are NOT multi-thread safe
        public class ApplicationSettings
        {
            internal ApplicationSettings() { }

            char csvSeperator = ',';

            decimal reviewFrontDelay = 2.5M;
            decimal reviewBackDelay = 2.5M;

            bool reviewAnimate = true;
            FontInfo preferredFont = new FontInfo(Utility.DEFAULT_FONT);
            FontInfo printFont = new FontInfo(Utility.DEFAULT_FONT);
            string preferredPrinterName = "";
            bool keepStylesInHtml = true;
            bool renderingBreakWords = false;

            bool saveBackups = true;
            int backupInterval = 300000; // 5 mins

            bool printerLiesAboutDuplex = false;
            string preferredPaperName = "";
            bool printerPageLandscape = true;
            bool preserveNewLinesInCsv = true;

            Margins printPageMargin = new Margins(50, 50, 50, 50);

            public bool PreserveNewLinesInCsv {
                get { return preserveNewLinesInCsv; }
                set { preserveNewLinesInCsv = value; }
            }

            /// <summary>
            /// This is the margin of a page (in 1/10 of an inch).
            /// </summary>
            public Margins PrintPageMargin {
                get { return printPageMargin; }
                set { printPageMargin = value; }
            }

            public bool PrinterPageLandscape {
                get { return printerPageLandscape; }
                set { printerPageLandscape = value; }
            }

            public bool PrinterLiesAboutDuplex {
                get { return printerLiesAboutDuplex; }
                set { printerLiesAboutDuplex = value; }
            }

            public string PrinterPreferredPaperName {
                get { return preferredPaperName; }
                set { preferredPaperName = value; }
            }

            public string PreferredPrinterName {
                get { return preferredPrinterName; }
                set { preferredPrinterName = value; }
            }

            public FontInfo PrintFont {
                get { return printFont; }
                set { printFont = value; }
            }



            public bool SaveBackups {
                get { return saveBackups; }
                set { saveBackups = value; }
            }

            public int BackupInterval {
                get { return backupInterval; }
                set { backupInterval = value; }
            }

            public bool RenderingBreakWords {
                get { return renderingBreakWords; }
                set { renderingBreakWords = value; }
            }

            public bool KeepStylesInHtml {
                get { return keepStylesInHtml; }
                set { keepStylesInHtml = value; }
            }

            public FontInfo PreferredFont {
                get { return preferredFont; }
                set { preferredFont = value; }
            }

            ActivityHistory history = new ActivityHistory(Utility.RECENT_ITEMS_COUNT);

            public ActivityHistory History {
                get { return history; }
                set { history = value; }
            }

            public bool ReviewAnimate {
                get { return reviewAnimate; }
                set { reviewAnimate = value; }
            }

            public char CsvSeperator {
                get { return this.csvSeperator; }
                set { this.csvSeperator = value; }
            }

            public decimal ReviewFrontDelay {
                get { return this.reviewFrontDelay; }
                set { this.reviewFrontDelay = value; }
            }

            public decimal ReviewBackDelay {
                get { return this.reviewBackDelay; }
                set { this.reviewBackDelay = value; }
            }

        }

        public class WindowSettings
        {
            Dictionary<string, Size> windowSizes = new Dictionary<string, Size>();

            public Dictionary<string, Size> WindowSizes {
                get { return windowSizes; }
                set { windowSizes = value; }
            }

            public Size GetWindowSize(string window) {
                if (window != null) {
                    Size value;
                    if (windowSizes.TryGetValue(window, out value)) {
                        return value;
                    }
                }
                return Size.Empty;
            }

            public void SaveWindowSize(string window, Size size) {
                if (window != null) {
                    if (windowSizes.ContainsKey(window)) {
                        windowSizes[window] = size;
                    } else {
                        windowSizes.Add(window, size);
                    }
                }
                DictionarySerializer<string, Size> ds = new DictionarySerializer<string, Size>();
            }

            public void Serialize(string fileName) {
                WindowSettings instance = this;
                string tempFile = Path.GetTempFileName();
                using (System.IO.FileStream fs = new System.IO.FileStream(tempFile, System.IO.FileMode.Create, System.IO.FileAccess.Write)) {
                    DictionarySerializer<string, Size> ds = new DictionarySerializer<string, Size>();
                    ds.Serialize(instance.WindowSizes, fs);
                    fs.Flush();
                }
                File.Copy(tempFile, fileName, true);
                File.Delete(tempFile);
            }

            public static WindowSettings DeSerialize(string fileName) {
                WindowSettings winS = new WindowSettings();
                if (File.Exists(fileName)) {
                    using (System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
                        DictionarySerializer<string, Size> ds = new DictionarySerializer<string, Size>();
                        winS.WindowSizes = ds.Deserialize(fs);
                    }
                }
                return winS;
            }
        }

        public struct FontInfo
        {
            public string FontFamily;
            public GraphicsUnit GraphicsUnit;
            public float Size;
            public FontStyle Style;

            public FontInfo(Font f) {
                FontFamily = f.FontFamily.Name;
                GraphicsUnit = f.Unit;
                Size = f.Size;
                Style = f.Style;
            }

            public Font GetFont() {
                return new Font(FontFamily, Size, Style, GraphicsUnit);
            }
        }
    }
}
