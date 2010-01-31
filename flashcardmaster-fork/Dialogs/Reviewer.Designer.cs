namespace FlashCardMaster.Dialogs
{
    partial class Reviewer
    {
	   /// <summary>
	   /// Required designer variable.
	   /// </summary>
	   private System.ComponentModel.IContainer components = null;

	   /// <summary>
	   /// Clean up any resources being used.
	   /// </summary>
	   /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
           this.components = new System.ComponentModel.Container();
           this.ckAnimate = new System.Windows.Forms.CheckBox();
           this.ckTimed = new System.Windows.Forms.CheckBox();
           this.btFlip = new System.Windows.Forms.Button();
           this.btNext = new System.Windows.Forms.Button();
           this.btPrev = new System.Windows.Forms.Button();
           this.panel2 = new System.Windows.Forms.Panel();
           this.rdbNo = new System.Windows.Forms.RadioButton();
           this.rdbYes = new System.Windows.Forms.RadioButton();
           this.rdbMaybe = new System.Windows.Forms.RadioButton();
           this.ttProvider = new System.Windows.Forms.ToolTip(this.components);
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.pnlCard = new FlashCardMaster.Utilities.CardPanel();
           this.lblAeroAnimate = new VistaControls.ThemeText.ThemedLabel();
           this.panel2.SuspendLayout();
           this.tableLayoutPanel1.SuspendLayout();
           this.SuspendLayout();
           // 
           // ckAnimate
           // 
           this.ckAnimate.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.ckAnimate.AutoSize = true;
           this.ckAnimate.FlatStyle = System.Windows.Forms.FlatStyle.System;
           this.ckAnimate.Location = new System.Drawing.Point(83, 6);
           this.ckAnimate.Name = "ckAnimate";
           this.ckAnimate.Size = new System.Drawing.Size(70, 18);
           this.ckAnimate.TabIndex = 0;
           this.ckAnimate.Text = "Animate";
           this.ckAnimate.UseVisualStyleBackColor = true;
           this.ckAnimate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.ckAnimate.CheckedChanged += new System.EventHandler(this.ckAnimate_CheckedChanged);
           // 
           // ckTimed
           // 
           this.ckTimed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.ckTimed.Appearance = System.Windows.Forms.Appearance.Button;
           this.ckTimed.FlatAppearance.BorderSize = 0;
           this.ckTimed.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HighlightText;
           this.ckTimed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.ckTimed.Image = global::FlashCardMaster.Properties.Resources.appointment_new;
           this.ckTimed.Location = new System.Drawing.Point(87, 249);
           this.ckTimed.Name = "ckTimed";
           this.ckTimed.Size = new System.Drawing.Size(24, 24);
           this.ckTimed.TabIndex = 4;
           this.ckTimed.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
           this.ckTimed.UseVisualStyleBackColor = true;
           this.ckTimed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.ckTimed.CheckedChanged += new System.EventHandler(this.ckTimed_CheckedChanged);
           // 
           // btFlip
           // 
           this.btFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btFlip.FlatAppearance.BorderSize = 0;
           this.btFlip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btFlip.Image = global::FlashCardMaster.Properties.Resources.rotate_right;
           this.btFlip.Location = new System.Drawing.Point(60, 249);
           this.btFlip.Name = "btFlip";
           this.btFlip.Size = new System.Drawing.Size(24, 24);
           this.btFlip.TabIndex = 3;
           this.btFlip.UseVisualStyleBackColor = true;
           this.btFlip.Click += new System.EventHandler(this.btFlip_Click);
           this.btFlip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           // 
           // btNext
           // 
           this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btNext.FlatAppearance.BorderSize = 0;
           this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btNext.Image = global::FlashCardMaster.Properties.Resources.go_next;
           this.btNext.Location = new System.Drawing.Point(36, 249);
           this.btNext.Name = "btNext";
           this.btNext.Size = new System.Drawing.Size(24, 24);
           this.btNext.TabIndex = 2;
           this.btNext.UseVisualStyleBackColor = true;
           this.btNext.Click += new System.EventHandler(this.btNext_Click);
           this.btNext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           // 
           // btPrev
           // 
           this.btPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btPrev.FlatAppearance.BorderSize = 0;
           this.btPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btPrev.Image = global::FlashCardMaster.Properties.Resources.go_previous;
           this.btPrev.Location = new System.Drawing.Point(12, 249);
           this.btPrev.Name = "btPrev";
           this.btPrev.Size = new System.Drawing.Size(24, 24);
           this.btPrev.TabIndex = 1;
           this.btPrev.UseVisualStyleBackColor = true;
           this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
           this.btPrev.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           // 
           // panel2
           // 
           this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.panel2.Controls.Add(this.rdbNo);
           this.panel2.Controls.Add(this.rdbYes);
           this.panel2.Controls.Add(this.rdbMaybe);
           this.panel2.Location = new System.Drawing.Point(3, 3);
           this.panel2.Name = "panel2";
           this.panel2.Size = new System.Drawing.Size(74, 24);
           this.panel2.TabIndex = 0;
           // 
           // rdbNo
           // 
           this.rdbNo.Appearance = System.Windows.Forms.Appearance.Button;
           this.rdbNo.FlatAppearance.BorderSize = 0;
           this.rdbNo.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HighlightText;
           this.rdbNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.rdbNo.Image = global::FlashCardMaster.Properties.Resources.face_sad;
           this.rdbNo.Location = new System.Drawing.Point(0, 0);
           this.rdbNo.Name = "rdbNo";
           this.rdbNo.Size = new System.Drawing.Size(24, 24);
           this.rdbNo.TabIndex = 0;
           this.rdbNo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
           this.rdbNo.UseVisualStyleBackColor = true;
           this.rdbNo.Click += new System.EventHandler(this.rdbYesNoMaybe_Click);
           this.rdbNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.rdbNo.CheckedChanged += new System.EventHandler(this.rdbNo_CheckedChanged);
           // 
           // rdbYes
           // 
           this.rdbYes.Appearance = System.Windows.Forms.Appearance.Button;
           this.rdbYes.FlatAppearance.BorderSize = 0;
           this.rdbYes.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HighlightText;
           this.rdbYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.rdbYes.Image = global::FlashCardMaster.Properties.Resources.face_smile;
           this.rdbYes.Location = new System.Drawing.Point(48, 0);
           this.rdbYes.Name = "rdbYes";
           this.rdbYes.Size = new System.Drawing.Size(24, 24);
           this.rdbYes.TabIndex = 2;
           this.rdbYes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
           this.rdbYes.UseVisualStyleBackColor = true;
           this.rdbYes.Click += new System.EventHandler(this.rdbYesNoMaybe_Click);
           this.rdbYes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.rdbYes.CheckedChanged += new System.EventHandler(this.rdbYes_CheckedChanged);
           // 
           // rdbMaybe
           // 
           this.rdbMaybe.Appearance = System.Windows.Forms.Appearance.Button;
           this.rdbMaybe.FlatAppearance.BorderSize = 0;
           this.rdbMaybe.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.HighlightText;
           this.rdbMaybe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.rdbMaybe.Image = global::FlashCardMaster.Properties.Resources.face_plain;
           this.rdbMaybe.Location = new System.Drawing.Point(24, 0);
           this.rdbMaybe.Name = "rdbMaybe";
           this.rdbMaybe.Size = new System.Drawing.Size(24, 24);
           this.rdbMaybe.TabIndex = 1;
           this.rdbMaybe.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
           this.rdbMaybe.UseVisualStyleBackColor = true;
           this.rdbMaybe.Click += new System.EventHandler(this.rdbYesNoMaybe_Click);
           this.rdbMaybe.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.rdbMaybe.CheckedChanged += new System.EventHandler(this.rdbMaybe_CheckedChanged);
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.ColumnCount = 2;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
           this.tableLayoutPanel1.Controls.Add(this.ckAnimate, 1, 0);
           this.tableLayoutPanel1.Location = new System.Drawing.Point(253, 247);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 1;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 30);
           this.tableLayoutPanel1.TabIndex = 5;
           // 
           // pnlCard
           // 
           this.pnlCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.pnlCard.BackColor = System.Drawing.SystemColors.Window;
           this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.pnlCard.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.pnlCard.ForeColor = System.Drawing.SystemColors.WindowText;
           this.pnlCard.Location = new System.Drawing.Point(12, 12);
           this.pnlCard.Name = "pnlCard";
           this.pnlCard.NoCardMessage = "\'\'\'{empty}\'\'\'";
           this.pnlCard.Padding = new System.Windows.Forms.Padding(5);
           this.pnlCard.Size = new System.Drawing.Size(400, 228);
           this.pnlCard.SuspendPaint = false;
           this.pnlCard.TabIndex = 0;
           // 
           // lblAeroAnimate
           // 
           this.lblAeroAnimate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
           this.lblAeroAnimate.Location = new System.Drawing.Point(351, 250);
           this.lblAeroAnimate.Name = "lblAeroAnimate";
           this.lblAeroAnimate.Size = new System.Drawing.Size(61, 23);
           this.lblAeroAnimate.TabIndex = 7;
           this.lblAeroAnimate.Text = "Animate";
           this.lblAeroAnimate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           this.lblAeroAnimate.TextAlignVertical = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
           this.lblAeroAnimate.Visible = false;
           this.lblAeroAnimate.Click += new System.EventHandler(this.lblAeroAnimate_Click);
           this.lblAeroAnimate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblAeroAnimate_MouseClick);
           // 
           // Reviewer
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(424, 283);
           this.Controls.Add(this.lblAeroAnimate);
           this.Controls.Add(this.tableLayoutPanel1);
           this.Controls.Add(this.ckTimed);
           this.Controls.Add(this.btFlip);
           this.Controls.Add(this.btNext);
           this.Controls.Add(this.btPrev);
           this.Controls.Add(this.pnlCard);
           this.KeyPreview = true;
           this.MinimumSize = new System.Drawing.Size(325, 195);
           this.Name = "Reviewer";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "Reviewer";
           this.SizeChanged += new System.EventHandler(this.Reviewer_SizeChanged);
           this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Reviewer_KeyUp);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reviewer_FormClosing);
           this.panel2.ResumeLayout(false);
           this.tableLayoutPanel1.ResumeLayout(false);
           this.tableLayoutPanel1.PerformLayout();
           this.ResumeLayout(false);

	   }

	   #endregion

	   private FlashCardMaster.Utilities.CardPanel pnlCard;
	   private System.Windows.Forms.Button btPrev;
	   private System.Windows.Forms.Button btNext;
	   private System.Windows.Forms.Button btFlip;
	   private System.Windows.Forms.CheckBox ckAnimate;
	   private System.Windows.Forms.CheckBox ckTimed;
	   private System.Windows.Forms.Panel panel2;
	   private System.Windows.Forms.ToolTip ttProvider;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	   private System.Windows.Forms.RadioButton rdbNo;
	   private System.Windows.Forms.RadioButton rdbYes;
        private System.Windows.Forms.RadioButton rdbMaybe;
        private VistaControls.ThemeText.ThemedLabel lblAeroAnimate;
    }
}