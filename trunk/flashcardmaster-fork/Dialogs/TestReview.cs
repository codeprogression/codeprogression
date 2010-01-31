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
 *  Original FileName :  TestReview.cs
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
using System.Xml;

namespace FlashCardMaster.Dialogs
{
    public partial class TestReview : Form
    {
	   public void Localize() {
/*		  this.label1.Text = set by client!;
 */
		  this.btOK.Text = i18n.Language.OK;
		  this.Text = i18n.Language.TestResults;
		  this.btSave.Text = i18n.Language.Save;
	   }

	   public TestReview() {
		  InitializeComponent();
		  Utility.SetIcon(this);
		  Localize();
		  FlashCardMaster.Utilities.Utility.SetFormSize(this, .44f, .41f);
		  this.CenterToParent();

		  this.FormClosing += new FormClosingEventHandler(TestReview_FormClosing);
	   }

	   void TestReview_FormClosing(object sender, FormClosingEventArgs e) {
		  if (this.WindowState == FormWindowState.Normal) {
			 FlashCardMaster.User.Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
		  }
	   }

	   public string TestSummary {
		  get { return label1.Text; }
		  set { label1.Text = value; }
	   }

	   public void Add(QuizQuestion question) {
		  TestReviewItem item = new TestReviewItem();
		  item.Question = WikiMarkupParser.RemoveMarkup(question.Question, false);

		  item.Choice1 = WikiMarkupParser.RemoveMarkup(question.Choices[0], false);
		  item.Choice2 = WikiMarkupParser.RemoveMarkup(question.Choices[1], false);
		  item.Choice3 = WikiMarkupParser.RemoveMarkup(question.Choices[2], false);
		  item.Choice4 = WikiMarkupParser.RemoveMarkup(question.Choices[3], false);

		  item.AnswerIndex = question.AnswerIndex;
		  item.ResponseIndex = question.ResposeIndex;

		  this.flowLayoutPanel1.Controls.Add(item);

		  item.Index = this.flowLayoutPanel1.Controls.Count.ToString();
	   }

	   private void btSave_Click(object sender, EventArgs e) {
		  using (SaveFileDialog dlgSave = new SaveFileDialog()) {
			 dlgSave.Filter = "*.html (XHTML File)|*.html";
			 dlgSave.FileName = "Test Results";
			 if (dlgSave.ShowDialog(this) == DialogResult.OK) {
				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Encoding = Encoding.UTF8;
				settings.Indent = true;
				XmlWriter writer = XmlWriter.Create(dlgSave.FileName, settings);
				writer.WriteStartElement("html", "http://www.w3.org/1999/xhtml");
				writer.WriteStartElement("head");
				    writer.WriteElementString("title", "Test Results");
				    writer.WriteStartElement("style");
					   writer.WriteAttributeString("type", "text/css");
					   writer.WriteString(Properties.Resources.TestReviewCSS);
				    writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteStartElement("body");
				writer.WriteElementString("h1", "Test Results");
                writer.WriteStartElement("div");
                writer.WriteAttributeString("id", "contents");
				writer.WriteElementString("p", this.label1.Text);
				writer.WriteStartElement("div");
				writer.WriteAttributeString("id", "results");
                int buttonCount = 0;
				foreach (TestReviewItem item in flowLayoutPanel1.Controls) {
                    string[] str = new string[] { item.Choice1, item.Choice2, item.Choice3, item.Choice4 };
                    bool correct = (item.ResponseIndex == item.AnswerIndex);

                    writer.WriteStartElement("form");
				    writer.WriteStartElement("dl");
                       writer.WriteAttributeString("class", correct ? "correct" : "incorrect");

					   writer.WriteStartElement("dt");   
					   writer.WriteAttributeString("class", correct ? "correct" : "incorrect");

                       writer.WriteString(item.Question);
                       writer.WriteEndElement();
                        
					   for (int i = 0; i < str.Length; i++) {
						  writer.WriteStartElement("dd");
                          bool userChoice = (item.AnswerIndex == i);
						  if (correct) {
							 if (item.AnswerIndex == i) {
								writer.WriteAttributeString("class", "correctAnswer");
							 }
						  } else {
							 if (item.AnswerIndex == i) {
								writer.WriteAttributeString("class", "correctAnswer");
							 }
							 if (item.ResponseIndex == i) {
								writer.WriteAttributeString("class", "incorrectAnswer");
							 }
						  }
                          writer.WriteStartElement("input");
                          writer.WriteAttributeString("type", "radio");
                          writer.WriteAttributeString("name", "radiobutton" + buttonCount);
                          buttonCount++;
                          writer.WriteAttributeString("disabled", "disabled");
                          if (userChoice) { writer.WriteAttributeString("checked", "checked"); }
                          writer.WriteEndElement(); // input
						  
                            writer.WriteString(str[i]);
						  writer.WriteEndElement(); // dd
					   }
				    writer.WriteEndElement(); // dl
                    writer.WriteEndElement(); // form
				}
				writer.WriteEndElement(); // div
                writer.WriteEndElement(); // div

                writer.WriteStartElement("div");
                writer.WriteAttributeString("id", "footer");
                writer.WriteStartElement("p");
				writer.WriteString("Test taken using ");
                 writer.WriteStartElement("a");
                  writer.WriteAttributeString("href", "http://flashcardmaster.sourceforge.net/");
                  writer.WriteString("Flash Card Master");
                 writer.WriteEndElement(); // a
                 writer.WriteString(string.Format(" on {0} at {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
                writer.WriteEndElement(); // p
                writer.WriteEndElement(); // div
                writer.WriteEndElement(); // body
				writer.WriteEndElement(); // html

				writer.Flush();
				writer.Close();
			 }
		  }
	   }
    }
}