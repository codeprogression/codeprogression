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
 *  Original FileName :  BatchEntry.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibFlashcard.Model;
using FlashCardMaster.User;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace FlashCardMaster.Dialogs
{
    public partial class BatchEntry : Form
    {

	   public void Localize() {
		  this.btCancel.Text = i18n.Language.Cancel;
		  this.btOk.Text = i18n.Language.OK;
		  this.label2.Text = i18n.Language.LineBreakHint;
		  this.Text = i18n.Language.BatchEntry;
	   }

	   char seperator = Settings.AppInstance.CsvSeperator;
	   CardDeck deck;

	   Card[] cards;

	   public Card[] Cards {
		  get { return cards; }
	   }

	   public CardDeck Deck {
		  get { return deck; }
	   }

	   public event EventHandler DataParsed;

	   protected void OnDataParsed() {
		  if (DataParsed != null) {
			 DataParsed(this, new EventArgs());
		  }
	   }

	   public BatchEntry(CardDeck deck) {
		  InitializeComponent();
		  Utilities.Utility.SetIcon(this);
		  Localize();

		  FlashCardMaster.Utilities.Utility.SetFormSize(this, .5f, .45f);

		  this.deck = deck;

		  string instruction = "";
          for (int i = 0; i < deck.Styles.Count; i++) {
              CardElementStyle style = deck.Styles[i];
              instruction += string.Format(i18n.Language.fBatchEditInstructionField, style.Name);
              if (i != deck.Styles.Count - 1) {
                  instruction += seperator + " ";
              }
          }
		  instruction = string.Format(i18n.Language.BatchEditInstruction, instruction);
		  label1.Text = instruction;

		  this.FormClosing += new FormClosingEventHandler(BatchEntry_FormClosing);
		  this.Load += new EventHandler(BatchEntry_Load);
	   }

	   void BatchEntry_Load(object sender, EventArgs e) {
		  this.CenterToParent();
	   }

	   void BatchEntry_FormClosing(object sender, FormClosingEventArgs e) {
		  if (this.WindowState == FormWindowState.Normal) {
			 Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
		  }
	   }

	   private Card[] Parse(Stream stream) {
		  List<Card> cards = new List<Card>();
		  using (CsvReader csv = new CsvReader(new StreamReader(stream), false, Settings.AppInstance.CsvSeperator)) {
			 csv.SupportsMultiline = true;

			 int fieldCount = csv.FieldCount;

			 if (fieldCount != this.deck.Styles.Count) {
				throw new MissingFieldException(i18n.Language.BatchEditMismatchException);
			 }
			 
			 while (csv.ReadNextRecord()) {
				Card card = new Card();
				for (int i = 0; i < fieldCount; i++) {
				    card.Add(this.deck.Styles[i], csv[i]);
				}
				cards.Add(card);
			 }
		  }
		  return cards.ToArray();
	   }

	   private void btOk_Click(object sender, EventArgs e) {
          try {
			 using (Stream sr = new MemoryStream(Encoding.UTF8.GetBytes(txInput.Text))) {
				this.cards = Parse(sr);
			 }
		  } catch (Exception ex) {
			 MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			 return;
		  }

		  OnDataParsed();
		  this.Close();
	   }

	   private void btCancel_Click(object sender, EventArgs e) {
		  this.Close();
	   }

       private void txInput_TextChanged(object sender, EventArgs e) {
           this.btOk.Enabled = !string.IsNullOrEmpty(txInput.Text);
       }
    }
}