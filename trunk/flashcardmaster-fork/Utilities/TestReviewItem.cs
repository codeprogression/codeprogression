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
 *  Original FileName :  TestReviewItem.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlashCardMaster.Utilities
{
    public partial class TestReviewItem : UserControl
    {
	   public TestReviewItem() {
		  InitializeComponent();
	   }

	   private void UpdateView() {
		  label3.Font = label4.Font = label5.Font = label6.Font = this.Font;
		  label3.ForeColor = label4.ForeColor = label5.ForeColor = label6.ForeColor = this.ForeColor;

		  Label answer = null;
		  Label response = null;
		  if (answerIndex == 0) { answer = label3; } else if (answerIndex == 1) { answer = label4; } else if (answerIndex == 2) { answer = label5; } else if (answerIndex == 3) { answer = label6; }
		  if (responseIndex == 0) { response = label3; } else if (responseIndex == 1) { response = label4; } else if (responseIndex == 2) { response = label5; } else if (responseIndex == 3) { response = label6; }

		  Update(answer, response);
	   }

	   public void Update(Label answer, Label response) {
		  answer.Font = new Font(answer.Font, FontStyle.Bold);
		  if (answer == response) {
			 answer.ForeColor = Color.Green;
		  } else {
			 response.ForeColor = Color.Red;
		  }
	   }

	   int answerIndex = 0;
	   int responseIndex = 0;

	   public string Index {
		  get { return this.label1.Text;}
		  set { this.label1.Text = value; }
	   }

	   public int AnswerIndex {
		  get { return answerIndex; }
		  set { answerIndex = value; UpdateView(); }
	   }
	   
	   public int ResponseIndex {
		  get { return responseIndex; }
		  set { responseIndex = value; UpdateView(); }
	   }

	   public string Question {
		  get { return label2.Text; }
		  set { label2.Text = value; }
	   }

	   public string Choice1 {
		  get { return label3.Text; }
		  set { label3.Text = value; }
	   }
	   public string Choice2 {
		  get { return label4.Text; }
		  set { label4.Text = value; }
	   }
	   public string Choice3 {
		  get { return label5.Text; }
		  set { label5.Text = value; }
	   }
	   public string Choice4 {
		  get { return label6.Text; }
		  set { label6.Text = value; }
	   }
    }
}
