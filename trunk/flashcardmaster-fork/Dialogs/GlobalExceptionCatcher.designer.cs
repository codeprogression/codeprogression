namespace FlashCardMaster.Dialogs
{
    partial class GlobalExceptionCatcher
    {
	   /// <summary>
	   /// Required designer variable.
	   /// </summary>
	   private System.ComponentModel.IContainer components = null;

	   /// <summary>
	   /// Clean up any resources being used.
	   /// </summary>
	   /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	   protected override void Dispose(bool disposing) {
		  if (disposing && (components != null)) {
			 components.Dispose();
		  }
		  base.Dispose(disposing);
	   }

	   #region Windows Form Designer generated code

	   /// <summary>
	   /// Required method for Designer support - do not modify
	   /// the contents of this method with the code editor.
	   /// </summary>
	   private void InitializeComponent() {
		  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalExceptionCatcher));
		  this.ctClose = new System.Windows.Forms.Button();
		  this.label5 = new System.Windows.Forms.Label();
		  this.label3 = new System.Windows.Forms.Label();
		  this.ctPreview = new System.Windows.Forms.TextBox();
		  this.ctExplanation = new System.Windows.Forms.Label();
		  this.ctSend = new System.Windows.Forms.Button();
		  this.ctUserDesc = new System.Windows.Forms.TextBox();
		  this.ctRestart = new System.Windows.Forms.CheckBox();
		  this.ctContainer = new System.Windows.Forms.SplitContainer();
		  this.ctDetails = new System.Windows.Forms.Button();
		  this.ctContainer.Panel1.SuspendLayout();
		  this.ctContainer.Panel2.SuspendLayout();
		  this.ctContainer.SuspendLayout();
		  this.SuspendLayout();
		  // 
		  // ctClose
		  // 
		  this.ctClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		  this.ctClose.DialogResult = System.Windows.Forms.DialogResult.OK;
		  this.ctClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
		  this.ctClose.Location = new System.Drawing.Point(409, 341);
		  this.ctClose.Name = "ctClose";
		  this.ctClose.Size = new System.Drawing.Size(75, 23);
		  this.ctClose.TabIndex = 17;
		  this.ctClose.Text = "Close";
		  this.ctClose.Click += new System.EventHandler(this.btnClose_Click);
		  // 
		  // label5
		  // 
		  this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
		  this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
		  this.label5.Location = new System.Drawing.Point(12, 79);
		  this.label5.Name = "label5";
		  this.label5.Size = new System.Drawing.Size(553, 13);
		  this.label5.TabIndex = 16;
		  this.label5.Text = "(Optional) Enter any relevant details (such as actions that resulted in the error" +
			 "):";
		  // 
		  // label3
		  // 
		  this.label3.AutoSize = true;
		  this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
		  this.label3.Location = new System.Drawing.Point(12, 43);
		  this.label3.Name = "label3";
		  this.label3.Size = new System.Drawing.Size(0, 13);
		  this.label3.TabIndex = 14;
		  // 
		  // ctPreview
		  // 
		  this.ctPreview.Dock = System.Windows.Forms.DockStyle.Fill;
		  this.ctPreview.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.ctPreview.Location = new System.Drawing.Point(0, 0);
		  this.ctPreview.Multiline = true;
		  this.ctPreview.Name = "ctPreview";
		  this.ctPreview.ReadOnly = true;
		  this.ctPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		  this.ctPreview.Size = new System.Drawing.Size(553, 157);
		  this.ctPreview.TabIndex = 11;
		  // 
		  // ctExplanation
		  // 
		  this.ctExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
		  this.ctExplanation.FlatStyle = System.Windows.Forms.FlatStyle.System;
		  this.ctExplanation.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.ctExplanation.Location = new System.Drawing.Point(12, 9);
		  this.ctExplanation.Name = "ctExplanation";
		  this.ctExplanation.Size = new System.Drawing.Size(553, 58);
		  this.ctExplanation.TabIndex = 10;
		  this.ctExplanation.Text = resources.GetString("ctExplanation.Text");
		  // 
		  // ctSend
		  // 
		  this.ctSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
		  this.ctSend.Location = new System.Drawing.Point(490, 341);
		  this.ctSend.Name = "ctSend";
		  this.ctSend.Size = new System.Drawing.Size(75, 23);
		  this.ctSend.TabIndex = 19;
		  this.ctSend.Text = "Send";
		  this.ctSend.UseVisualStyleBackColor = true;
		  this.ctSend.Click += new System.EventHandler(this.ctSend_Click);
		  // 
		  // ctUserDesc
		  // 
		  this.ctUserDesc.Dock = System.Windows.Forms.DockStyle.Fill;
		  this.ctUserDesc.Location = new System.Drawing.Point(0, 0);
		  this.ctUserDesc.Multiline = true;
		  this.ctUserDesc.Name = "ctUserDesc";
		  this.ctUserDesc.Size = new System.Drawing.Size(553, 240);
		  this.ctUserDesc.TabIndex = 20;
		  this.ctUserDesc.TextChanged += new System.EventHandler(this.ctUserDesc_TextChanged);
		  // 
		  // ctRestart
		  // 
		  this.ctRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		  this.ctRestart.AutoSize = true;
		  this.ctRestart.Checked = true;
		  this.ctRestart.CheckState = System.Windows.Forms.CheckState.Checked;
		  this.ctRestart.Location = new System.Drawing.Point(45, 346);
		  this.ctRestart.Name = "ctRestart";
		  this.ctRestart.Size = new System.Drawing.Size(115, 17);
		  this.ctRestart.TabIndex = 21;
		  this.ctRestart.Text = "Restart Application";
		  this.ctRestart.UseVisualStyleBackColor = true;
		  // 
		  // ctContainer
		  // 
		  this.ctContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				    | System.Windows.Forms.AnchorStyles.Left)
				    | System.Windows.Forms.AnchorStyles.Right)));
		  this.ctContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
		  this.ctContainer.Location = new System.Drawing.Point(12, 95);
		  this.ctContainer.Name = "ctContainer";
		  this.ctContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
		  // 
		  // ctContainer.Panel1
		  // 
		  this.ctContainer.Panel1.Controls.Add(this.ctUserDesc);
		  // 
		  // ctContainer.Panel2
		  // 
		  this.ctContainer.Panel2.Controls.Add(this.ctPreview);
		  this.ctContainer.Panel2Collapsed = true;
		  this.ctContainer.Size = new System.Drawing.Size(553, 240);
		  this.ctContainer.SplitterDistance = 79;
		  this.ctContainer.TabIndex = 22;
		  // 
		  // ctDetails
		  // 
		  this.ctDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
		  this.ctDetails.FlatAppearance.BorderSize = 0;
		  this.ctDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		  this.ctDetails.Location = new System.Drawing.Point(12, 342);
		  this.ctDetails.Name = "ctDetails";
		  this.ctDetails.Size = new System.Drawing.Size(24, 21);
		  this.ctDetails.TabIndex = 23;
		  this.ctDetails.Text = "+";
		  this.ctDetails.UseVisualStyleBackColor = true;
		  this.ctDetails.Click += new System.EventHandler(this.ctDetails_Click);
		  // 
		  // GlobalExceptionCatcher
		  // 
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.ClientSize = new System.Drawing.Size(577, 373);
		  this.Controls.Add(this.ctDetails);
		  this.Controls.Add(this.ctContainer);
		  this.Controls.Add(this.ctRestart);
		  this.Controls.Add(this.ctSend);
		  this.Controls.Add(this.ctClose);
		  this.Controls.Add(this.label5);
		  this.Controls.Add(this.label3);
		  this.Controls.Add(this.ctExplanation);
		  this.Name = "GlobalExceptionCatcher";
		  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		  this.Text = "GlobalExceptionCatcher";
		  this.ctContainer.Panel1.ResumeLayout(false);
		  this.ctContainer.Panel1.PerformLayout();
		  this.ctContainer.Panel2.ResumeLayout(false);
		  this.ctContainer.Panel2.PerformLayout();
		  this.ctContainer.ResumeLayout(false);
		  this.ResumeLayout(false);
		  this.PerformLayout();

	   }

	   #endregion

	   private System.Windows.Forms.Button ctClose;
	   private System.Windows.Forms.Label label5;
	   private System.Windows.Forms.Label label3;
	   private System.Windows.Forms.TextBox ctPreview;
	   private System.Windows.Forms.Label ctExplanation;
	   private System.Windows.Forms.Button ctSend;
	   private System.Windows.Forms.TextBox ctUserDesc;
	   private System.Windows.Forms.CheckBox ctRestart;
	   private System.Windows.Forms.SplitContainer ctContainer;
	   private System.Windows.Forms.Button ctDetails;
    }
}