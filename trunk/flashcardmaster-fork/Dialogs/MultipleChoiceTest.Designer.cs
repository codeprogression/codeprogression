namespace FlashCardMaster.Dialogs
{
    partial class MultipleChoiceTest
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
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.rdChoice4 = new System.Windows.Forms.RadioButton();
           this.rdChoice3 = new System.Windows.Forms.RadioButton();
           this.rdChoice2 = new System.Windows.Forms.RadioButton();
           this.rdChoice1 = new System.Windows.Forms.RadioButton();
           this.btNext = new System.Windows.Forms.Button();
           this.btPrev = new System.Windows.Forms.Button();
           this.btClose = new System.Windows.Forms.Button();
           this.splitContainer1 = new System.Windows.Forms.SplitContainer();
           this.pnlCard = new FlashCardMaster.Utilities.CardPanel();
           this.tableLayoutPanel1.SuspendLayout();
           this.splitContainer1.Panel1.SuspendLayout();
           this.splitContainer1.Panel2.SuspendLayout();
           this.splitContainer1.SuspendLayout();
           this.SuspendLayout();
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.ColumnCount = 2;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.Controls.Add(this.rdChoice4, 1, 1);
           this.tableLayoutPanel1.Controls.Add(this.rdChoice3, 0, 1);
           this.tableLayoutPanel1.Controls.Add(this.rdChoice2, 1, 0);
           this.tableLayoutPanel1.Controls.Add(this.rdChoice1, 0, 0);
           this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 2;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.Size = new System.Drawing.Size(301, 130);
           this.tableLayoutPanel1.TabIndex = 1;
           // 
           // rdChoice4
           // 
           this.rdChoice4.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice4.Dock = System.Windows.Forms.DockStyle.Fill;
           this.rdChoice4.Location = new System.Drawing.Point(153, 68);
           this.rdChoice4.Name = "rdChoice4";
           this.rdChoice4.Padding = new System.Windows.Forms.Padding(2);
           this.rdChoice4.Size = new System.Drawing.Size(145, 59);
           this.rdChoice4.TabIndex = 3;
           this.rdChoice4.TabStop = true;
           this.rdChoice4.Text = "Choice 4";
           this.rdChoice4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice4.UseVisualStyleBackColor = true;
           this.rdChoice4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           this.rdChoice4.CheckedChanged += new System.EventHandler(this.rdChoice_CheckedChanged);
           // 
           // rdChoice3
           // 
           this.rdChoice3.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice3.Dock = System.Windows.Forms.DockStyle.Fill;
           this.rdChoice3.Location = new System.Drawing.Point(3, 68);
           this.rdChoice3.Name = "rdChoice3";
           this.rdChoice3.Padding = new System.Windows.Forms.Padding(2);
           this.rdChoice3.Size = new System.Drawing.Size(144, 59);
           this.rdChoice3.TabIndex = 2;
           this.rdChoice3.TabStop = true;
           this.rdChoice3.Text = "Choice 3";
           this.rdChoice3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice3.UseVisualStyleBackColor = true;
           this.rdChoice3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           this.rdChoice3.CheckedChanged += new System.EventHandler(this.rdChoice_CheckedChanged);
           // 
           // rdChoice2
           // 
           this.rdChoice2.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice2.Dock = System.Windows.Forms.DockStyle.Fill;
           this.rdChoice2.Location = new System.Drawing.Point(153, 3);
           this.rdChoice2.Name = "rdChoice2";
           this.rdChoice2.Padding = new System.Windows.Forms.Padding(2);
           this.rdChoice2.Size = new System.Drawing.Size(145, 59);
           this.rdChoice2.TabIndex = 1;
           this.rdChoice2.TabStop = true;
           this.rdChoice2.Text = "Choice 2";
           this.rdChoice2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice2.UseVisualStyleBackColor = true;
           this.rdChoice2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           this.rdChoice2.CheckedChanged += new System.EventHandler(this.rdChoice_CheckedChanged);
           // 
           // rdChoice1
           // 
           this.rdChoice1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.rdChoice1.Location = new System.Drawing.Point(3, 3);
           this.rdChoice1.Name = "rdChoice1";
           this.rdChoice1.Padding = new System.Windows.Forms.Padding(2);
           this.rdChoice1.Size = new System.Drawing.Size(144, 59);
           this.rdChoice1.TabIndex = 0;
           this.rdChoice1.TabStop = true;
           this.rdChoice1.Text = "Choice 1";
           this.rdChoice1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
           this.rdChoice1.UseVisualStyleBackColor = true;
           this.rdChoice1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           this.rdChoice1.CheckedChanged += new System.EventHandler(this.rdChoice_CheckedChanged);
           // 
           // btNext
           // 
           this.btNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btNext.FlatAppearance.BorderSize = 0;
           this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btNext.Image = global::FlashCardMaster.Properties.Resources.go_next;
           this.btNext.Location = new System.Drawing.Point(289, 367);
           this.btNext.Name = "btNext";
           this.btNext.Size = new System.Drawing.Size(24, 23);
           this.btNext.TabIndex = 4;
           this.btNext.UseVisualStyleBackColor = true;
           this.btNext.Click += new System.EventHandler(this.btNext_Click);
           this.btNext.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           // 
           // btPrev
           // 
           this.btPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btPrev.FlatAppearance.BorderSize = 0;
           this.btPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btPrev.Image = global::FlashCardMaster.Properties.Resources.go_previous;
           this.btPrev.Location = new System.Drawing.Point(259, 367);
           this.btPrev.Name = "btPrev";
           this.btPrev.Size = new System.Drawing.Size(24, 23);
           this.btPrev.TabIndex = 3;
           this.btPrev.UseVisualStyleBackColor = true;
           this.btPrev.Click += new System.EventHandler(this.btPrev_Click);
           this.btPrev.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           // 
           // btClose
           // 
           this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btClose.FlatAppearance.BorderSize = 0;
           this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btClose.Image = global::FlashCardMaster.Properties.Resources.emblem_unreadable;
           this.btClose.Location = new System.Drawing.Point(232, 367);
           this.btClose.Name = "btClose";
           this.btClose.Size = new System.Drawing.Size(24, 23);
           this.btClose.TabIndex = 5;
           this.btClose.UseVisualStyleBackColor = true;
           this.btClose.Click += new System.EventHandler(this.btClose_Click);
           this.btClose.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           // 
           // splitContainer1
           // 
           this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
           this.splitContainer1.Location = new System.Drawing.Point(12, 12);
           this.splitContainer1.Name = "splitContainer1";
           this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
           // 
           // splitContainer1.Panel1
           // 
           this.splitContainer1.Panel1.Controls.Add(this.pnlCard);
           // 
           // splitContainer1.Panel2
           // 
           this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
           this.splitContainer1.Size = new System.Drawing.Size(301, 349);
           this.splitContainer1.SplitterDistance = 214;
           this.splitContainer1.SplitterWidth = 5;
           this.splitContainer1.TabIndex = 6;
           // 
           // pnlCard
           // 
           this.pnlCard.BackColor = System.Drawing.Color.White;
           this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
           this.pnlCard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.pnlCard.ForeColor = System.Drawing.SystemColors.WindowText;
           this.pnlCard.Location = new System.Drawing.Point(0, 0);
           this.pnlCard.Name = "pnlCard";
           this.pnlCard.NoCardMessage = "{empty}";
           this.pnlCard.Padding = new System.Windows.Forms.Padding(5);
           this.pnlCard.Size = new System.Drawing.Size(301, 214);
           this.pnlCard.SuspendPaint = false;
           this.pnlCard.TabIndex = 0;
           // 
           // MultipleChoiceTest
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(325, 399);
           this.Controls.Add(this.splitContainer1);
           this.Controls.Add(this.btClose);
           this.Controls.Add(this.btNext);
           this.Controls.Add(this.btPrev);
           this.Name = "MultipleChoiceTest";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "Mutiple Choice Test";
           this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MultipleChoiceTest_KeyUp);
           this.tableLayoutPanel1.ResumeLayout(false);
           this.splitContainer1.Panel1.ResumeLayout(false);
           this.splitContainer1.Panel2.ResumeLayout(false);
           this.splitContainer1.ResumeLayout(false);
           this.ResumeLayout(false);

	   }

	   #endregion

	   private FlashCardMaster.Utilities.CardPanel pnlCard;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	   private System.Windows.Forms.RadioButton rdChoice4;
	   private System.Windows.Forms.RadioButton rdChoice3;
	   private System.Windows.Forms.RadioButton rdChoice2;
	   private System.Windows.Forms.RadioButton rdChoice1;
	   private System.Windows.Forms.Button btNext;
	   private System.Windows.Forms.Button btPrev;
	   private System.Windows.Forms.Button btClose;
	   private System.Windows.Forms.SplitContainer splitContainer1;
    }
}