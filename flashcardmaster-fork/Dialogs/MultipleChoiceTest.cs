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
 *  Original FileName :  MultipleChoiceTest.cs
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
using FlashCardMaster.Utilities;
using LibFlashcard.WikiText;

namespace FlashCardMaster.Dialogs
{
    public partial class MultipleChoiceTest : Form
    {
	   public void Localize() {
/*		  this.rdChoice4.Text = "";
		  this.rdChoice3.Text = "";
		  this.rdChoice2.Text = "";
		  this.rdChoice1.Text = "";
 */
		  this.Text = i18n.Language.MutipleChoiceTest;
	   }

	   LibFlashcard.Utilities.BiDirectionalEnumerator<QuizQuestion> qEnumer;
	   RadioButton[] radioButtons;
	   public MultipleChoiceTest(Quiz quiz) {
		  InitializeComponent();
		  Utility.SetIcon(this);
		  Localize();
          FlashCardMaster.Utilities.Utility.SetFormSize(this, .25f, .60f);
		  this.CenterToParent();
          
          // Recall panel1's size;
          this.splitContainer1.SplitterDistance = (int)(this.splitContainer1.Height * (.60f));
          Size panelSize = FlashCardMaster.User.Settings.WinSettings.GetWindowSize(this.GetType().ToString() + ".splitContainer1.panel1");
          if (panelSize != Size.Empty) {
              this.splitContainer1.SplitterDistance = panelSize.Height;
          }

		  this.rdChoice1.Font
		  = this.rdChoice2.Font
		  = this.rdChoice3.Font
		  = this.rdChoice4.Font
		  = this.pnlCard.Font = User.Settings.AppInstance.PreferredFont.GetFont();
		  

		  this.radioButtons = new RadioButton[] { rdChoice1, rdChoice2, rdChoice3, rdChoice4 };

		  this.qEnumer = quiz.GetEnumerator(LibFlashcard.Utilities.EnumerationOrder.Random);

		  Next();

		  this.FormClosing += new FormClosingEventHandler(MultipleChoiceTest_FormClosing);

          if (VistaControls.OSSupport.IsVistaOrBetter && VistaControls.OSSupport.IsCompositionEnabled) {
              this.pnlCard.BorderStyle = BorderStyle.None;
              int bottomHeight = this.ClientSize.Height - this.splitContainer1.Bottom;
              this.BackColor = Color.Black;
              this.splitContainer1.BackColor = SystemColors.Control;
              this.splitContainer1.ForeColor = SystemColors.ControlText;
              this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
              VistaControls.DWM.DWMManager.EnableGlassFrame(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
              VistaControls.DWM.GlassHelper.HandleBackgroundPainting(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
              VistaControls.DWM.GlassHelper.HandleFormMovementOnGlass(this, new VistaControls.DWM.Margins(12, 12, 12, bottomHeight));
          }
	   }

	   void MultipleChoiceTest_FormClosing(object sender, FormClosingEventArgs e) {
		  if (this.WindowState == FormWindowState.Normal) {
			 FlashCardMaster.User.Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
             FlashCardMaster.User.Settings.WinSettings.SaveWindowSize(this.GetType().ToString() + ".splitContainer1.panel1", new Size(0, this.splitContainer1.SplitterDistance));
		  }
	   }

	   private void SaveAnswer(QuizQuestion question) {
		  for (int i = 0; i < radioButtons.Length; i++) {
			 if (radioButtons[i].Checked) {
				question.ResposeIndex = i;
				break;
			 }
		  }
	   }

	   private void Tally() {
		  qEnumer.Reset();
		  TestReview review = new TestReview();
		  int score = 0;
		  while (qEnumer.MoveNext()) {
			 review.Add(qEnumer.Current);
			 if (qEnumer.Current.AnswerIndex == qEnumer.Current.ResposeIndex) {
				score++;
			 }
		  }
		  review.TestSummary = string.Format(i18n.Language.fTestResults, score, qEnumer.Count, ((double)score / qEnumer.Count) * 100);
		  review.ShowDialog(this);
		  this.Close();
	   }

	   private void SetQuestion(QuizQuestion question) {
		  this.pnlCard.NoCardMessage = question.Question;

		  if (question.ResposeIndex != -1) {
			 radioButtons[question.ResposeIndex].Checked = true;
             btNext.Enabled = true;
		  } else {
			 for (int i = 0; i < radioButtons.Length; i++) {
				radioButtons[i].Checked = false;
			 }
             btNext.Enabled = false;
		  }

		  rdChoice1.Text = WikiMarkupParser.RemoveMarkup(question.Choices[0], true);
		  rdChoice2.Text = WikiMarkupParser.RemoveMarkup(question.Choices[1], true);
		  rdChoice3.Text = WikiMarkupParser.RemoveMarkup(question.Choices[2], true);
		  rdChoice4.Text = WikiMarkupParser.RemoveMarkup(question.Choices[3], true);

		  btPrev.Enabled = qEnumer.CanMovePrevious();
	   }

	   private void Prev() {
		  if (qEnumer.Current != null) { SaveAnswer(qEnumer.Current); }
		  if (qEnumer.MovePrevious()) {
			 SetQuestion(qEnumer.Current);
		  }
	   }

	   private bool Next() {
		  if (qEnumer.Current != null) { SaveAnswer(qEnumer.Current); }
		  if (qEnumer.MoveNext()) {
			 SetQuestion(qEnumer.Current);
			 return true;
		  } else {
			 return false;
		  }
	   }

	   private void btPrev_Click(object sender, EventArgs e) {
		  Prev();
	   }

	   private void btNext_Click(object sender, EventArgs e) {
		  if (!Next()) {
			 Tally();
		  }
	   }

	   private void rdChoice_CheckedChanged(object sender, EventArgs e) {

		  if (rdChoice1.Checked || rdChoice2.Checked || rdChoice3.Checked || rdChoice4.Checked) {
			 // some (1 is) checked
			 btNext.Enabled = true;
		  } else {
			 btNext.Enabled = false;
		  }

		  RadioButton radio = sender as RadioButton;
		  if (radio.Checked) {
			 radio.BackColor = Color.LawnGreen;
		  } else {
			 radio.BackColor = radio.Parent.BackColor;
		  }
	   }

	   private void btClose_Click(object sender, EventArgs e) {
		  // TODO: Maybe hook FormClosing
		  if(MessageBox.Show(i18n.Language.EndTestQuestion, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes){
			 this.Close();
		  }
	   }

       private void MultipleChoiceTest_KeyUp(object sender, KeyEventArgs e) {
           switch (e.KeyCode) {
               case Keys.Enter:
                   btNext.PerformClick();
                   break;
               case Keys.Back:
                   btPrev.PerformClick();
                   break;
               case Keys.Escape:
                   btClose.PerformClick();
                   break;
           }
       }
    }
}