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
 *  Original FileName :  CardDesigner.cs
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
using FlashCardMaster.Painters;
using System.Diagnostics;

namespace FlashCardMaster.Dialogs
{
    public partial class CardDesigner : Form
    {
	   public void Localize() {
		  this.groupBox1.Text = i18n.Language.Properties;
		  this.label5.Text = i18n.Language.Type;
		  this.label4.Text = i18n.Language.Sides;
		  this.label3.Text = i18n.Language.Position;
		  this.ckBack.Text = i18n.Language.Back;
		  this.ckFront.Text = i18n.Language.Front;
		  this.label1.Text = i18n.Language.Name;
		  this.label2.Text = i18n.Language.Show;
		  this.rdbFront.Text = i18n.Language.Front;
		  this.rdbBack.Text = i18n.Language.Back;
		  this.btOk.Text = i18n.Language.Close;
		  this.clName.Text = i18n.Language.Name;
		  this.Text = i18n.Language.DesignCard;
	   }

	   CardDeck deck = new CardDeck();
	   Card decoy = new Card();
	   CardElementSides currentSide = CardElementSides.Front;

	   internal class EnumerationHolder<T>{

		  string text;
		  T value;

		  public string Text {
			 get { return text; }
			 set { text = value; }
		  }

		  public T Value {
			 get { return this.value; }
			 set { this.value = value; }
		  }

		  public EnumerationHolder(string text, T value){
			 this.text = text;
			 this.value = value;
		  }

		  public override string ToString() {
			 return text;
		  }
	   }

	   public CardDeck Deck {
		  get { return deck; }
	   }

	   public CardDesigner() 
		  :this(new CardDeck()) {}

	   public CardDesigner(CardDeck deck) {
		  InitializeComponent();

		  Utilities.Utility.SetIcon(this);
		  Localize();

		  FlashCardMaster.Utilities.Utility.SetFormSize(this, .50f, .45f);
          this.splitContainer1.Panel2MinSize = 207;
          this.splitContainer1.SplitterDistance = this.splitContainer1.Width - 207;
          this.splitContainer2.Panel2MinSize = 194;
          this.splitContainer2.SplitterDistance = this.splitContainer2.Height - 194;
		  this.CenterToParent();

		  this.pnlCard.Font = User.Settings.AppInstance.PreferredFont.GetFont();

		  this.deck = deck;

		  PopulateComboBoxes();

		  groupBox1.Enabled = false;

		  rdbFront.Checked = true;
		  UpdateList();
		  this.lvElements.ItemReordered += new EventHandler(lvElements_ItemReordered);
          UpdateUpDownButtonState();

		  this.FormClosing += new FormClosingEventHandler(CardDesigner_FormClosing);

		  this.lvElements.Focus();

          UpdateDecoy();
	   }

	   void CardDesigner_FormClosing(object sender, FormClosingEventArgs e) {
		  if (this.WindowState == FormWindowState.Normal) {
			 FlashCardMaster.User.Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
		  }
          if (e.CloseReason == CloseReason.UserClosing) {
              e.Cancel = !ValidateElementType();
          }
	   }

	   void lvElements_ItemReordered(object sender, EventArgs e) {
		  UpdateElementOrder();
	   }

	   void UpdateElementOrder(){
		  // This appears to work. But, does it really?
		  for (int i = 0; i < lvElements.Items.Count; i++) {
			 CardElementStyle elementStyle = lvElements.Items[i].Tag as CardElementStyle;
			 elementStyle.Index = i;
			 Debug.WriteLine(string.Format("{0}: {1}", i, elementStyle.Name));
		  }
		  this.deck.SortStyles();
	   }

	   private void UpdateDecoy() {
		  Card newDecoy = new Card();
		  foreach (CardElementStyle style in this.deck.Styles) {
			 newDecoy.Add(style, style.Name);
		  }
		  this.decoy = newDecoy;
		  this.pnlCard.Side = currentSide;
		  this.pnlCard.Card = this.decoy;
	   }

	   private void UpdateList() {
		  this.lvElements.Items.Clear();
		  foreach (CardElementStyle style in this.deck.Styles) {
			 ListViewItem item = new ListViewItem(style.Name);
			 item.Tag = style;
			 this.lvElements.Items.Add(item);
		  }
	   }

	   private void btAddElement_Click(object sender, EventArgs e) {
		  // Ensure that the field name is unique
		  string fieldName = i18n.Language.New;
		  for (int i = 1; i <= 1000; i++) {
			 if (ValidateName(fieldName) != NameValidationErrorReason.None) {
				fieldName = i18n.Language.New + i;
			 }else{
                break;
			 }
		  }
		  CardElementStyle style = new CardElementStyle(this.deck.Styles.Count, fieldName);
		  style.Position = CardElementPositions.Top | CardElementPositions.Left;
		  this.deck.AddStyle(style);
		  UpdateList();
		  UpdateDecoy();
		  lvElements.Items[lvElements.Items.Count - 1].Selected = true;
		  lvElements.Focus();
	   }

	   private void btRemoveElement_Click(object sender, EventArgs e) {
		  EndEdit();
		  if (lvElements.SelectedItems.Count <= 0) { return; }

		  if (this.deck.Cards.Count > 0) {
			 if (MessageBox.Show(i18n.Language.DesignerDataLossWarning, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No) {
				return;
			 }
		  }

		  for (int i = lvElements.SelectedItems.Count - 1; i >= 0; i--) {
			 ListViewItem selItem = lvElements.SelectedItems[i];
			 this.deck.RemoveStyle(selItem.Tag as CardElementStyle);
			 selItem.Remove();
		  }
		  UpdateDecoy();
	   }
	   

	   private void rdbFront_CheckedChanged(object sender, EventArgs e) {
		  if (rdbFront.Checked) {
			 currentSide = CardElementSides.Front;
		  } else {
			 currentSide = CardElementSides.Back;
		  }
		  UpdateDecoy();
	   }

	   private void lstCardList_SelectedIndexChanged(object sender, EventArgs e) {
		  UpdateUpDownButtonState();
		  if (lvElements.SelectedItems.Count == 1) {
			 editingList = lvElements.SelectedItems[0];
			 BeginEdit(editingList.Tag as CardElementStyle);
		  } else {
			 EndEdit();
		  }
	   }


	   CardElementStyle editingStyle = null;
	   ListViewItem editingList = null;

	   private void BeginEdit(CardElementStyle style) {
		  this.editingStyle = null;

		  this.tbName.Text = style.Name;
		  this.ckFront.Checked = ((style.Side & CardElementSides.Front) == CardElementSides.Front);
		  this.ckBack.Checked = ((style.Side & CardElementSides.Back) == CardElementSides.Back);
          SetColor(btForeColor, style.ForeColor);
          SetColor(btBackground, style.BackColor);
		  SelectComboItem<CardElementPositions>(style.Position, this.cmbPositions);
		  SelectComboItem<CardElementType>(style.Type, this.cmbType);
		  this.editingStyle = style;

		  groupBox1.Enabled = true;	
	   }

	   private bool SelectComboItem<T>(T value, ComboBox control) {
		  for (int i = 0; i < control.Items.Count; i++) {
			 EnumerationHolder<T> holder = control.Items[i] as EnumerationHolder<T>;
			 if (value.Equals(holder.Value)) {
				control.SelectedIndex = i;
				Debug.WriteLine(String.Format("Success: {0} == {1}, at {2}", holder.Value, value, i));
				return true;
			 }
		  }
		  return false;
	   }

	   private void EndEdit() {
		  editingStyle = null;
          groupBox1.Enabled = false;
//          HideTrackbar();
	   }

	   private void PopulateComboBoxes() {
		  cmbPositions.Items.Clear();
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.TopLeft, CardElementPositions.Top | CardElementPositions.Left));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.TopCenter, CardElementPositions.Top | CardElementPositions.HorizontalCenter));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.TopRight, CardElementPositions.Top | CardElementPositions.Right));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.CenterLeft, CardElementPositions.Left | CardElementPositions.VerticalCenter));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.Center, CardElementPositions.Center));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.CenterRight, CardElementPositions.Right | CardElementPositions.VerticalCenter));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.BottomLeft, CardElementPositions.Bottom | CardElementPositions.Left));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.BottomCenter, CardElementPositions.Bottom | CardElementPositions.HorizontalCenter));
		  cmbPositions.Items.Add(new EnumerationHolder<CardElementPositions>(i18n.Language.BottomRight, CardElementPositions.Bottom | CardElementPositions.Right));
		  cmbPositions.SelectedIndex = 0;

		  cmbType.Items.Clear();
		  cmbType.Items.Add(new EnumerationHolder<CardElementType>(i18n.Language.Other, CardElementType.Other));
		  cmbType.Items.Add(new EnumerationHolder<CardElementType>(i18n.Language.Key, CardElementType.Key));
		  cmbType.Items.Add(new EnumerationHolder<CardElementType>(i18n.Language.Answer, CardElementType.Answer));
		  cmbType.SelectedIndex = 0;
	   }

	   private void cmbPositions_SelectedIndexChanged(object sender, EventArgs e) {
		  if (editingStyle != null) {
			 EnumerationHolder<CardElementPositions> holder = cmbPositions.SelectedItem as EnumerationHolder<CardElementPositions>;
			 editingStyle.Position = holder.Value;
			 UpdateDecoy();
			 Debug.Assert(editingStyle.Position != CardElementPositions.None);
			 UpdateDecoy();
		  }
	   }


	   private void cmbType_SelectedIndexChanged(object sender, EventArgs e) {
		  if (editingStyle != null) {
			 EnumerationHolder<CardElementType> holder = cmbType.SelectedItem as EnumerationHolder<CardElementType>;
			 editingStyle.Type = holder.Value;
			 UpdateDecoy();
		  }
	   }

	   private void ckSides_CheckedChanged(object sender, EventArgs e) {
		  if (editingStyle != null) {
			 CardElementSides side = 0;
			 if (ckFront.Checked) { side |= CardElementSides.Front; }
			 if (ckBack.Checked) { side |= CardElementSides.Back; }
			 editingStyle.Side = side;
			 UpdateDecoy();
		  }
	   }

       enum NameValidationErrorReason{
           None,
           Empty,
           NotUnique,
           ContainsSpace
       }

	   private void tbName_TextChanged(object sender, EventArgs e) {
		  if (editingStyle != null) {
              NameValidationErrorReason reason = ValidateName(tbName.Text);
              switch (reason) {
                  case NameValidationErrorReason.None:
                      editingStyle.Name = tbName.Text;
                      editingList.Text = editingStyle.Name;
                      ctError.SetError(tbName, string.Empty);
                      break;
                  case NameValidationErrorReason.Empty:
                      // show some message
                      ctError.SetIconAlignment(tbName, ErrorIconAlignment.MiddleRight);
                      ctError.SetError(tbName, i18n.Language.FieldNameEmptyError);
                      break;
                  case NameValidationErrorReason.NotUnique:
                      // show some message
                      ctError.SetIconAlignment(tbName, ErrorIconAlignment.MiddleRight);
                      ctError.SetError(tbName, i18n.Language.FieldNameNotUnique);
                      break;
                  case NameValidationErrorReason.ContainsSpace:
                      // show some message
                      ctError.SetIconAlignment(tbName, ErrorIconAlignment.MiddleRight);
                      ctError.SetError(tbName, i18n.Language.FieldNameContainsSpace);
                      break;
                  default:
                      throw new InvalidEnumArgumentException("reason", (int)reason, typeof(NameValidationErrorReason));
              }
			  UpdateDecoy();
		  }
	   }

	   private void CardDesigner_KeyUp(object sender, KeyEventArgs e) {
		  switch (e.KeyCode) {
			 case Keys.Insert:
				btAddElement.PerformClick();
				break;
			 case Keys.Delete:
				btRemoveElement.PerformClick();
				break;
		  }
		  
		  if (e.Control) {
			 switch (e.KeyCode) {
				case Keys.Q:
				    btMoveUp.PerformClick();
				    break;
				case Keys.A:
				    btMoveDown.PerformClick();
				    break;
			 }
		  }
	   }

	   void UpdateUpDownButtonState() {
		  bool upState = false;
		  bool downState = false;

		  if ((lvElements.SelectedIndices != null) && (lvElements.SelectedIndices.Count == 1)) {
			 int currentIndex = lvElements.SelectedIndices[0];

			 if (currentIndex - 1 >= 0) {
				upState = true;
			 }

			 if (currentIndex + 1 < lvElements.Items.Count) {
				downState = true;
			 }
		  }
		  btMoveUp.SuspendLayout();
		  btMoveUp.Enabled = upState;
		  btMoveDown.Enabled = downState;
		  btMoveUp.ResumeLayout();
	   }

	   private void btMoveUp_Click(object sender, EventArgs e) {
		  lvElements.BeginUpdate();
		  if ((lvElements.SelectedIndices != null) && (lvElements.SelectedIndices.Count == 1)) {
			 int currentIndex = lvElements.SelectedIndices[0];
			 int targetIndex = currentIndex - 1;

			 if (targetIndex >= 0) {
				ListViewItem tmp = lvElements.Items[currentIndex];
				lvElements.Items.RemoveAt(currentIndex);
				lvElements.Items.Insert(targetIndex, tmp);
				UpdateElementOrder();
			 }
		  }
		  lvElements.EndUpdate();
	   }

	   private void btMoveDown_Click(object sender, EventArgs e) {
		  lvElements.BeginUpdate();
		  if ((lvElements.SelectedIndices != null) && (lvElements.SelectedIndices.Count == 1)) {
			 int currentIndex = lvElements.SelectedIndices[0];
			 int targetIndex = currentIndex + 1;

			 if (targetIndex < lvElements.Items.Count) {
				ListViewItem tmp = lvElements.Items[currentIndex];
				lvElements.Items.RemoveAt(currentIndex);
				lvElements.Items.Insert(targetIndex, tmp);
				UpdateElementOrder();
			 }
		  }
		  lvElements.EndUpdate();
	   }

       private void btForeColor_Click(object sender, EventArgs e) {
           Color newColor = GetColor(btForeColor.BackColor);
           editingStyle.ForeColor = newColor;
           SetColor(btForeColor, newColor);
       }

       private void btBackground_Click(object sender, EventArgs e) {
           Color newColor = GetColor(btBackground.BackColor);
           editingStyle.BackColor = newColor;
           SetColor(btBackground, newColor);
       }

       private void SetColor(Control control, Color color) {
           control.BackColor = color;
           control.Text = color.IsNamedColor ? color.Name : Utilities.Utility.ColorToRgb(color);
           UpdateDecoy();
       }


       private Color GetColor(Color color) {
           using (ColorDialog dlgColor = new ColorDialog()) {
               dlgColor.AllowFullOpen = true;
               dlgColor.AnyColor = true;
               dlgColor.Color = color;
               if (dlgColor.ShowDialog(this) == DialogResult.OK) {
                   return dlgColor.Color;
               } else {
                   return color;
               }
           }
       }


       private void btOk_Click(object sender, EventArgs e) {
           if (!ValidateElementType()) {
               this.DialogResult = DialogResult.None;
           }else{
               this.DialogResult = DialogResult.OK;
           }
       }

       /// <summary>
       /// Ensures that the name user entered is valid.
       /// </summary>
       private NameValidationErrorReason ValidateName(string name) {
           if (string.IsNullOrEmpty(name)) { return NameValidationErrorReason.Empty; }

           if (name.Contains(" ")) { return NameValidationErrorReason.ContainsSpace; }

           foreach (CardElementStyle style in deck.Styles) {
               if (style.Name == name) { return NameValidationErrorReason.NotUnique; }
           }

           return NameValidationErrorReason.None;
       }

       /// <summary>
       /// Checks if there are multiple elements marked as Key or Answer.
       /// </summary>
       /// <returns>true if there are no errors or if the user has decided to ignore the warning. Otherwise false.</returns>
       private bool ValidateElementType() {
           string answerField = "", keyField  = "";
           foreach (CardElementStyle style in deck.Styles) {
               if (style.Type == CardElementType.Answer) {
                   if (!string.IsNullOrEmpty(answerField)) {
                       if (MessageBox.Show(string.Format(i18n.Language.MultipleAnswerTypeError, answerField, style.Name), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                           return false;
                       } else {
                           return true;
                       }
                   }
                   answerField = style.Name;
               } else if (style.Type == CardElementType.Key) {
                   if (!string.IsNullOrEmpty(keyField)) {
                       if (MessageBox.Show(string.Format(i18n.Language.MultipleKeyTypeError, keyField, style.Name), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                           return false;
                       } else {
                           return true;
                       }
                   }
                   keyField = style.Name;
               }
           }
           return true;
       }

       // bool btColorAlpha_ClickSwitch = false, btBackgroundAlpha_ClickSwitch = false;

       private void btColorAlpha_Click(object sender, EventArgs e) {
           return;
           //if (btColorAlpha_ClickSwitch) {
           //    HideTrackbar();
           //} else {
           //    ShowTrackbarOnControl(btColorAlpha, editingStyle.ForeColor.A,
           //        delegate(int value) { editingStyle.ForeColor = Color.FromArgb(value, editingStyle.ForeColor.R, editingStyle.ForeColor.G, editingStyle.ForeColor.B); UpdateDecoy(); });
           //}
           //btColorAlpha_ClickSwitch = !btColorAlpha_ClickSwitch;
       }

       private void btBackgroundAlpha_Click(object sender, EventArgs e) {
           return;
           //if (btBackgroundAlpha_ClickSwitch) {
           //    HideTrackbar();
           //} else {
           //    ShowTrackbarOnControl(btBackgroundAlpha, editingStyle.BackColor.A,
           //        delegate(int value) { editingStyle.BackColor = Color.FromArgb(value, editingStyle.BackColor.R, editingStyle.BackColor.G, editingStyle.BackColor.B); UpdateDecoy(); });
           //}
           //btBackgroundAlpha_ClickSwitch = !btBackgroundAlpha_ClickSwitch;
       }

       

        /*
       TrackBar track;
       private void CreateTrackbar() {
           track = new TrackBar();
           track.Minimum = 0;
           track.Maximum = 255;
           track.TickFrequency = 12;
           track.BackColor = SystemColors.ControlDark;
           track.TickStyle = TickStyle.None;
           track.Size = new Size(groupBox1.Width - 20, 10);
           track.Leave += new EventHandler(track_Leave);
           track.KeyUp += new KeyEventHandler(track_KeyUp);
           this.Controls.Add(track);
       }

       delegate void ValueChangedDelegate(int value);

       private void ShowTrackbarOnControl(Control control, int value, ValueChangedDelegate listener) {
           if (track == null) {
               CreateTrackbar();
           } else {
               track.Hide();
           }
           Point buttonLoc = FindActualLocation(control, 7);
           track.Location = new Point(buttonLoc.X + control.Width - track.Width, buttonLoc.Y + control.Height);
           track.ValueChanged += delegate(object sender, EventArgs e) {
               listener(track.Value);
           };
           track.Show();
           track.BringToFront();
           track.Focus();
       }

       private void HideTrackbar() {
           if (track != null) {
               track.Hide();
           }
       }

       void track_KeyUp(object sender, KeyEventArgs e) {
           if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape) {
               HideTrackbar();
           }
       }

       Point FindActualLocation(Control control, int depth) {
           Control ctrl = control;
           int x = 0;
           int y = 0;

           for (int i = 0; i < depth; i++) {
               x += ctrl.Left;
               y += ctrl.Top;
               ctrl = ctrl.Parent;
               if (ctrl == null) {
                   break;
               }
           }

           return new Point(x, y);
       }

       void track_Leave(object sender, EventArgs e) {
           HideTrackbar();
       }
         */
    }
}