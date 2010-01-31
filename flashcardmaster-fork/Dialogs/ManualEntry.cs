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
 *  Original FileName :  ManualEntry.cs
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
using FlashCardMaster.Painters;
using LibFlashcard.Model;
using LibFlashcard.WikiText;

namespace FlashCardMaster.Dialogs
{
    public partial class ManualEntry : Form
    {
	   public void Localize() {
		  this.colCardName.Text = i18n.Language.Cards;
		  this.columnHeader1.Text = i18n.Language.Fields;
		  this.btClose.Text = i18n.Language.Close;
		  this.Text = i18n.Language.EditCards;
	   }

	   Card currentCard = new Card();
	   CardDeck deck;
	   object cardPaintersLock = new object();

	   public ManualEntry(CardDeck deck) 
		  :this(deck, null){}

	   public ManualEntry(CardDeck deck, Card selected) {
		  InitializeComponent();
		  Utilities.Utility.SetIcon(this); 
		  Localize();
		  FlashCardMaster.Utilities.Utility.SetFormSize(this, .5f, .45f);
		  txtEdit.Size = new Size(10, 10); // The control won't shrink to fit, so set size really small
		  this.CenterToParent();

		  this.pnlCard.Font = User.Settings.AppInstance.PreferredFont.GetFont();
		  this.deck = deck;
		  UpdateList();

		  pnlCard.NoCardMessage = i18n.Language.EditorNoCardsMessage;

          int cardIndex = 0;
          int elementIndex = 0;

		  if (selected != null) {
			 if (lvCards.Items.Count > 0) {
				foreach (ListViewItem item in lvCards.Items) {
				    if (item.Tag == selected) {
                       cardIndex = item.Index;
                       for (int i = 0; i < selected.Elements.Count; i++) {
                           if (selected.Elements[i].Style.Type == CardElementType.Key) {
                               elementIndex = i;
                               break;
                           }
                       }
                       break;
				    }
				}
			 }
		  }


          lvCards.SelectedItems.Clear();
          if (lvCards.Items.Count > 0) {
              lvCards.Items[cardIndex].Selected = true;
              lvCards.Items[cardIndex].EnsureVisible();
          }

          lvElements.SelectedItems.Clear();
          if (lvElements.Items.Count > 0) {
              lvElements.Items[elementIndex].Selected = true;
              lvElements.Items[elementIndex].EnsureVisible();
          }
		  

		  this.FormClosing += new FormClosingEventHandler(ManualEntry_FormClosing);
	   }

	   void ManualEntry_FormClosing(object sender, FormClosingEventArgs e) {
		  if (this.WindowState == FormWindowState.Normal) {
			 FlashCardMaster.User.Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
		  }
	   }

	   private void UpdateList() {
		  int preferredWidth;
		  foreach (Card cd in deck.Cards) {
			 lvCards.Items.Add(CardToListView(cd));
		  }
		  lvCards.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
		  preferredWidth = lvCards.Width - SystemInformation.VerticalScrollBarWidth - 4;
		  if (lvCards.Columns[0].Width < preferredWidth) {
			 lvCards.Columns[0].Width = preferredWidth;
		  }

		  foreach (CardElementStyle style in deck.Styles) {
              ListViewItem item = new ListViewItem();
              item.Text = style.Name;
              item.Tag = style;
              lvElements.Items.Add(item);
		  }
		  lvElements.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
		  preferredWidth = lvElements.Width - SystemInformation.VerticalScrollBarWidth - 4;
		  if (lvElements.Columns[0].Width < preferredWidth) {
			 lvElements.Columns[0].Width = preferredWidth;
		  }
	   }

	   private void RefreshList() {
		  for (int i = 0; i < lvCards.Items.Count; i++) {
			 CardToListView(lvCards.Items[i], lvCards.Items[i].Tag as Card);
		  }
	   }

	   bool suppressUpdate = false;
	   private void lvCards_SelectedIndexChanged(object sender, EventArgs e) {
		  if (!suppressUpdate) { UpdateSelection(); }
	   }

	   private void lvElements_SelectedIndexChanged(object sender, EventArgs e) {
		  if (!suppressUpdate) { UpdateSelection(); }
	   }

	   CardElement[] currentElements;
	   private void UpdateSelection() {
		  currentElements = null;
		  if(lvElements.SelectedItems.Count == 1){
			 if (lvCards.SelectedItems.Count > 1) {
				txtEdit.Text = i18n.Language.EditMultipleItems;
				pnlCard.SetManualMode(true, null);
				CardElement[] selected = new CardElement[lvCards.SelectedIndices.Count];
				for (int i = 0; i < selected.Length; i++) {
				    selected[i] = this.deck.Cards[lvCards.SelectedIndices[i]].Elements[lvElements.SelectedIndices[0]];
				}
				currentElements = selected;
			 } else if (lvCards.SelectedItems.Count == 1) {
				CardElement element = this.deck.Cards[lvCards.SelectedIndices[0]].Elements[lvElements.SelectedIndices[0]];
				txtEdit.Text = element.Text;
				UpdatePainter(element);
				currentElements = new CardElement[] { element };
			 }
			 pnlCard.Invalidate();
		  }
		  SetEditState();
	   }

	   void SetEditState() {
		  if (((lvCards.SelectedItems == null) || (lvCards.SelectedItems.Count <= 0))
		   || ((lvElements.SelectedItems == null) || (lvElements.SelectedItems.Count <= 0))) {
			 txtEdit.Text = "";
			 txtEdit.Enabled = false;
			 if (deck.Cards.Count <= 0) {
				pnlCard.NoCardMessage = i18n.Language.EditorNoCardsMessage;
			 } else {
				pnlCard.NoCardMessage = "Select one or more '''Cards''' and a '''Field''' to edit";
			 }
			 pnlCard.SetManualMode(false);
			 pnlCard.Card = null;
			 pnlCard.Invalidate();
		  } else {
			 txtEdit.Enabled = true;
		  }
	   }

	   private void txtEdit_TextChanged(object sender, EventArgs e) {
		  if (currentElements != null) {
			 for (int i = 0; i < currentElements.Length; i++) {
				currentElements[i].Text = txtEdit.Text;
				UpdatePainter(currentElements[i]);
			 }
			 RefreshList();
		  }
	   }

	   private void UpdatePainter(CardElement element) {
		  TextGroupPainter painter = new TextGroupPainter(element.Text, SystemColors.WindowText, null, pnlCard.ClientRectangle, User.Settings.AppInstance.PreferredFont.GetFont(), CardElementPositions.Center);
		  pnlCard.SetManualMode(true, new TextGroupPainter[] { painter });
	   }

	   private ListViewItem CardToListView(Card card) {
		  ListViewItem item = new ListViewItem();
		  CardToListView(item, card);
		  return item;
	   }

	   private void CardToListView(ListViewItem item, Card card) {
		  item.Text = LibFlashcard.WikiText.WikiMarkupParser.RemoveMarkup(card.ToString());
		  if (item.Tag == null) { item.Tag = card; }
	   }

	   private void btAdd_Click(object sender, EventArgs e) {
		  lvCards.BeginUpdate();
		  Card card = new Card(this.deck.Styles);
		  this.deck.Cards.Add(card);
		  
		  lvCards.SelectedItems.Clear();
		  ListViewItem item = CardToListView(card);
		  lvCards.Items.Add(item);
		  item.Selected = true;
		  lvCards.EnsureVisible(item.Index);
		  txtEdit.SelectAll();
		  lvCards.EndUpdate();
		  txtEdit.SelectAll();
		  txtEdit.Focus();
	   }

	   private void btRemove_Click(object sender, EventArgs e) {
		  suppressUpdate = true;
		  for (int i = lvCards.SelectedItems.Count - 1; i >= 0; i--) {
			 this.deck.Cards.Remove(lvCards.SelectedItems[i].Tag as Card);
			 this.lvCards.Items.Remove(lvCards.SelectedItems[i]);
		  }
		  suppressUpdate = false;
		  SetEditState();
	   }

	   private void btBold_Click(object sender, EventArgs e) {
		  Format(TextStyle.Bold);
	   }

	   private void btItalic_Click(object sender, EventArgs e) {
		  Format(TextStyle.Italic);
	   }

	   private void btUnderline_Click(object sender, EventArgs e) {
		  Format(TextStyle.Underline);
	   }

	   private void btStrike_Click(object sender, EventArgs e) {
		  Format(TextStyle.Strikethru);
	   }

	   private void Format(TextStyle style) {
		  Format(WikiMarkupParser.GetStartDelimiter(style), WikiMarkupParser.GetEndDelimiter(style));
	   }

	   private void Format(string before, string after) {
		  int lastIndex = 0;
		  int firstIndex = 0;

		  if (txtEdit.SelectionLength != 0) {
			 lastIndex = txtEdit.SelectionStart + txtEdit.SelectionLength;
			 firstIndex = txtEdit.SelectionStart;
		  } else if (txtEdit.Text != string.Empty) {
			 lastIndex = txtEdit.Text.Length;
			 firstIndex = 0;
		  } else {
			 return;
		  }

		  string result = txtEdit.Text;
		  result = result.Insert(lastIndex, after);
		  result = result.Insert(firstIndex, before);
		  txtEdit.Text = result;
		  txtEdit.Focus();
	   }

	   private void ManualEntry_KeyUp(object sender, KeyEventArgs e) {
		  switch (e.KeyCode) {
			 case Keys.Insert:
				btAdd.PerformClick();
				break;
		  }

		  if (e.Alt) {
			 switch (e.KeyCode) {
				case Keys.Up:
				    ChangeSelectedItem(lvElements, true);
				    break;
				case Keys.Down:
				    ChangeSelectedItem(lvElements, false);
				    break;
			 }
		  }

		  if (e.Control) {
			 switch (e.KeyCode) {
				case Keys.Up:
				    ChangeSelectedItem(lvCards, true);
				    break;
				case Keys.Down:
				    ChangeSelectedItem(lvCards, false);
				    break;
			 }
		  }
	   }

	   private void ChangeSelectedItem(ListView list, bool up) {
		  if (list.Items.Count <= 0) { return; }

		  list.BeginUpdate();
		  int selectedIndex = 0;

		  if (list.SelectedIndices.Count > 0) {
			 if (up) {
				// Select the top-most item
				selectedIndex = list.SelectedIndices[0];
				selectedIndex--;
			 } else {
				// Select the bottom-most item
				selectedIndex = list.SelectedIndices[list.SelectedIndices.Count - 1];
				selectedIndex++;
			 }
		  } else {
			 if (up) {
				// first
				selectedIndex = 0;
			 } else {
				// last
				selectedIndex = list.Items.Count - 1;
			 }
		  }

		  if ((selectedIndex >= 0) && (selectedIndex < list.Items.Count)) {
			 list.SelectedItems.Clear();
			 list.Items[selectedIndex].Selected = true;
			 list.EnsureVisible(selectedIndex);
		  }
		  list.EndUpdate();

		  txtEdit.SelectAll();
		  txtEdit.Focus();
	   }

	   private void ManualEntry_Load(object sender, EventArgs e) {
		  if (lvCards.SelectedItems.Count > 0) {
			 lvCards.EnsureVisible(lvCards.SelectedIndices[0]);
		  }
	   }

	   private void lvCards_ItemReordered(object sender, EventArgs e) {
		  for (int i = 0; i < lvCards.Items.Count; i++) {
             Card card = lvCards.Items[i].Tag as Card;
             card.Index = i;
		  }
          this.deck.SortCardsByIndex((LibFlashcard.Utilities.SortOrder)SortOrder.Ascending);
	   }

       private void lvElements_ItemReordered(object sender, EventArgs e) {
		  for (int i = 0; i < lvElements.Items.Count; i++) {
			 CardElementStyle elementStyle = lvElements.Items[i].Tag as CardElementStyle;
			 elementStyle.Index = i;
		  }
		  this.deck.SortStyles();
          UpdateSelection();
       }
    }
}