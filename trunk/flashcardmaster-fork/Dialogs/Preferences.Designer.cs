namespace FlashCardMaster.Dialogs
{
    partial class Preferences
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
           this.components = new System.ComponentModel.Container();
           this.tabControl1 = new System.Windows.Forms.TabControl();
           this.tabPage1 = new System.Windows.Forms.TabPage();
           this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
           this.label9 = new System.Windows.Forms.Label();
           this.label8 = new System.Windows.Forms.Label();
           this.lblFontInfo = new System.Windows.Forms.Label();
           this.btChooseFont = new System.Windows.Forms.Button();
           this.btAssociate = new System.Windows.Forms.Button();
           this.lblPrintFontInfo = new System.Windows.Forms.Label();
           this.btChoosePrintFont = new System.Windows.Forms.Button();
           this.tabPage2 = new System.Windows.Forms.TabPage();
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.label7 = new System.Windows.Forms.Label();
           this.numBack = new System.Windows.Forms.NumericUpDown();
           this.label4 = new System.Windows.Forms.Label();
           this.label6 = new System.Windows.Forms.Label();
           this.numFront = new System.Windows.Forms.NumericUpDown();
           this.label5 = new System.Windows.Forms.Label();
           this.label3 = new System.Windows.Forms.Label();
           this.tabPage3 = new System.Windows.Forms.TabPage();
           this.ckKeepStyles = new System.Windows.Forms.CheckBox();
           this.tabPage4 = new System.Windows.Forms.TabPage();
           this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
           this.ckManualDuplex = new System.Windows.Forms.CheckBox();
           this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
           this.label13 = new System.Windows.Forms.Label();
           this.numBackupFrequency = new System.Windows.Forms.NumericUpDown();
           this.label12 = new System.Windows.Forms.Label();
           this.ckHqLayout = new System.Windows.Forms.CheckBox();
           this.ckEnableBackup = new System.Windows.Forms.CheckBox();
           this.btOk = new System.Windows.Forms.Button();
           this.btCancel = new System.Windows.Forms.Button();
           this.ctError = new System.Windows.Forms.ErrorProvider(this.components);
           this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
           this.label1 = new System.Windows.Forms.Label();
           this.tbSeperatorChar = new System.Windows.Forms.TextBox();
           this.label2 = new System.Windows.Forms.Label();
           this.tabControl1.SuspendLayout();
           this.tabPage1.SuspendLayout();
           this.tableLayoutPanel2.SuspendLayout();
           this.tabPage2.SuspendLayout();
           this.tableLayoutPanel1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numBack)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.numFront)).BeginInit();
           this.tabPage3.SuspendLayout();
           this.tabPage4.SuspendLayout();
           this.tableLayoutPanel4.SuspendLayout();
           this.tableLayoutPanel3.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numBackupFrequency)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this.ctError)).BeginInit();
           this.tableLayoutPanel5.SuspendLayout();
           this.SuspendLayout();
           // 
           // tabControl1
           // 
           this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tabControl1.Controls.Add(this.tabPage1);
           this.tabControl1.Controls.Add(this.tabPage2);
           this.tabControl1.Controls.Add(this.tabPage3);
           this.tabControl1.Controls.Add(this.tabPage4);
           this.tabControl1.Location = new System.Drawing.Point(12, 12);
           this.tabControl1.Name = "tabControl1";
           this.tabControl1.SelectedIndex = 0;
           this.tabControl1.Size = new System.Drawing.Size(448, 287);
           this.tabControl1.TabIndex = 0;
           // 
           // tabPage1
           // 
           this.tabPage1.Controls.Add(this.tableLayoutPanel2);
           this.tabPage1.Location = new System.Drawing.Point(4, 22);
           this.tabPage1.Name = "tabPage1";
           this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage1.Size = new System.Drawing.Size(440, 261);
           this.tabPage1.TabIndex = 0;
           this.tabPage1.Text = "General";
           this.tabPage1.UseVisualStyleBackColor = true;
           // 
           // tableLayoutPanel2
           // 
           this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel2.AutoSize = true;
           this.tableLayoutPanel2.ColumnCount = 3;
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
           this.tableLayoutPanel2.Controls.Add(this.label8, 0, 4);
           this.tableLayoutPanel2.Controls.Add(this.lblFontInfo, 1, 4);
           this.tableLayoutPanel2.Controls.Add(this.btChooseFont, 2, 4);
           this.tableLayoutPanel2.Controls.Add(this.lblPrintFontInfo, 1, 5);
           this.tableLayoutPanel2.Controls.Add(this.btChoosePrintFont, 2, 5);
           this.tableLayoutPanel2.Controls.Add(this.btAssociate, 1, 6);
           this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
           this.tableLayoutPanel2.Name = "tableLayoutPanel2";
           this.tableLayoutPanel2.RowCount = 6;
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
           this.tableLayoutPanel2.Size = new System.Drawing.Size(440, 113);
           this.tableLayoutPanel2.TabIndex = 8;
           // 
           // label9
           // 
           this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label9.AutoSize = true;
           this.label9.Location = new System.Drawing.Point(3, 37);
           this.label9.Name = "label9";
           this.label9.Size = new System.Drawing.Size(55, 13);
           this.label9.TabIndex = 8;
           this.label9.Text = "Print Font:";
           // 
           // label8
           // 
           this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label8.AutoSize = true;
           this.label8.Location = new System.Drawing.Point(27, 8);
           this.label8.Name = "label8";
           this.label8.Size = new System.Drawing.Size(31, 13);
           this.label8.TabIndex = 4;
           this.label8.Text = "Font:";
           // 
           // lblFontInfo
           // 
           this.lblFontInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.lblFontInfo.AutoSize = true;
           this.lblFontInfo.BackColor = System.Drawing.Color.Transparent;
           this.lblFontInfo.Location = new System.Drawing.Point(64, 8);
           this.lblFontInfo.Name = "lblFontInfo";
           this.lblFontInfo.Size = new System.Drawing.Size(106, 13);
           this.lblFontInfo.TabIndex = 7;
           this.lblFontInfo.Text = "Some Font, Bold, 9pt";
           this.lblFontInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // btChooseFont
           // 
           this.btChooseFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.btChooseFont.Location = new System.Drawing.Point(176, 3);
           this.btChooseFont.Name = "btChooseFont";
           this.btChooseFont.Size = new System.Drawing.Size(27, 23);
           this.btChooseFont.TabIndex = 6;
           this.btChooseFont.Text = "...";
           this.btChooseFont.UseVisualStyleBackColor = true;
           this.btChooseFont.Click += new System.EventHandler(this.btChooseFont_Click);
           // 
           // btAssociate
           // 
           this.btAssociate.AutoSize = true;
           this.tableLayoutPanel2.SetColumnSpan(this.btAssociate, 3);
           this.btAssociate.Location = new System.Drawing.Point(10, 84);
           this.btAssociate.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
           this.btAssociate.Name = "btAssociate";
           this.btAssociate.Size = new System.Drawing.Size(122, 23);
           this.btAssociate.TabIndex = 3;
           this.btAssociate.Text = "Associate Filetypes";
           this.btAssociate.UseVisualStyleBackColor = true;
           this.btAssociate.Click += new System.EventHandler(this.btAssociate_Click);
           // 
           // lblPrintFontInfo
           // 
           this.lblPrintFontInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.lblPrintFontInfo.AutoSize = true;
           this.lblPrintFontInfo.BackColor = System.Drawing.Color.Transparent;
           this.lblPrintFontInfo.Location = new System.Drawing.Point(64, 37);
           this.lblPrintFontInfo.Name = "lblPrintFontInfo";
           this.lblPrintFontInfo.Size = new System.Drawing.Size(106, 13);
           this.lblPrintFontInfo.TabIndex = 9;
           this.lblPrintFontInfo.Text = "Some Font, Bold, 9pt";
           this.lblPrintFontInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
           // 
           // btChoosePrintFont
           // 
           this.btChoosePrintFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.btChoosePrintFont.Location = new System.Drawing.Point(176, 32);
           this.btChoosePrintFont.Name = "btChoosePrintFont";
           this.btChoosePrintFont.Size = new System.Drawing.Size(27, 23);
           this.btChoosePrintFont.TabIndex = 10;
           this.btChoosePrintFont.Text = "...";
           this.btChoosePrintFont.UseVisualStyleBackColor = true;
           this.btChoosePrintFont.Click += new System.EventHandler(this.btChoosePrintFont_Click);
           // 
           // tabPage2
           // 
           this.tabPage2.Controls.Add(this.tableLayoutPanel1);
           this.tabPage2.Controls.Add(this.label3);
           this.tabPage2.Location = new System.Drawing.Point(4, 22);
           this.tabPage2.Name = "tabPage2";
           this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage2.Size = new System.Drawing.Size(440, 261);
           this.tabPage2.TabIndex = 1;
           this.tabPage2.Text = "Review";
           this.tabPage2.UseVisualStyleBackColor = true;
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.ColumnCount = 3;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
           this.tableLayoutPanel1.Controls.Add(this.numBack, 1, 1);
           this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
           this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
           this.tableLayoutPanel1.Controls.Add(this.numFront, 1, 0);
           this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
           this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 27);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 2;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel1.Size = new System.Drawing.Size(411, 57);
           this.tableLayoutPanel1.TabIndex = 9;
           // 
           // label7
           // 
           this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(212, 36);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(47, 13);
           this.label7.TabIndex = 6;
           this.label7.Text = "seconds";
           // 
           // numBack
           // 
           this.numBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.numBack.DecimalPlaces = 2;
           this.numBack.Location = new System.Drawing.Point(126, 32);
           this.numBack.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
           this.numBack.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numBack.Name = "numBack";
           this.numBack.Size = new System.Drawing.Size(80, 20);
           this.numBack.TabIndex = 8;
           this.numBack.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
           // 
           // label4
           // 
           this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(25, 7);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(95, 13);
           this.label4.TabIndex = 1;
           this.label4.Text = "Show front side for";
           // 
           // label6
           // 
           this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(212, 7);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(47, 13);
           this.label6.TabIndex = 4;
           this.label6.Text = "seconds";
           // 
           // numFront
           // 
           this.numFront.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.numFront.DecimalPlaces = 2;
           this.numFront.Location = new System.Drawing.Point(126, 4);
           this.numFront.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
           this.numFront.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numFront.Name = "numFront";
           this.numFront.Size = new System.Drawing.Size(80, 20);
           this.numFront.TabIndex = 7;
           this.numFront.ThousandsSeparator = true;
           this.numFront.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
           // 
           // label5
           // 
           this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(3, 36);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(117, 13);
           this.label5.TabIndex = 2;
           this.label5.Text = "and show back side for";
           // 
           // label3
           // 
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(10, 11);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(81, 13);
           this.label3.TabIndex = 0;
           this.label3.Text = "Review Delays:";
           // 
           // tabPage3
           // 
           this.tabPage3.Controls.Add(this.ckKeepStyles);
           this.tabPage3.Location = new System.Drawing.Point(4, 22);
           this.tabPage3.Name = "tabPage3";
           this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage3.Size = new System.Drawing.Size(440, 261);
           this.tabPage3.TabIndex = 2;
           this.tabPage3.Text = "HTML Export";
           this.tabPage3.UseVisualStyleBackColor = true;
           // 
           // ckKeepStyles
           // 
           this.ckKeepStyles.AutoSize = true;
           this.ckKeepStyles.Location = new System.Drawing.Point(15, 16);
           this.ckKeepStyles.Name = "ckKeepStyles";
           this.ckKeepStyles.Size = new System.Drawing.Size(223, 17);
           this.ckKeepStyles.TabIndex = 0;
           this.ckKeepStyles.Text = "Keep text styles when exporting to HTML.";
           this.ckKeepStyles.UseVisualStyleBackColor = true;
           // 
           // tabPage4
           // 
           this.tabPage4.Controls.Add(this.tableLayoutPanel4);
           this.tabPage4.Location = new System.Drawing.Point(4, 22);
           this.tabPage4.Name = "tabPage4";
           this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
           this.tabPage4.Size = new System.Drawing.Size(440, 261);
           this.tabPage4.TabIndex = 3;
           this.tabPage4.Text = "Advanced";
           this.tabPage4.UseVisualStyleBackColor = true;
           // 
           // tableLayoutPanel4
           // 
           this.tableLayoutPanel4.AutoSize = true;
           this.tableLayoutPanel4.ColumnCount = 1;
           this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel4.Controls.Add(this.label2, 0, 5);
           this.tableLayoutPanel4.Controls.Add(this.ckManualDuplex, 0, 0);
           this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 3);
           this.tableLayoutPanel4.Controls.Add(this.ckHqLayout, 0, 1);
           this.tableLayoutPanel4.Controls.Add(this.ckEnableBackup, 0, 2);
           this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 4);
           this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
           this.tableLayoutPanel4.Name = "tableLayoutPanel4";
           this.tableLayoutPanel4.RowCount = 6;
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel4.Size = new System.Drawing.Size(434, 255);
           this.tableLayoutPanel4.TabIndex = 11;
           // 
           // ckManualDuplex
           // 
           this.ckManualDuplex.AutoSize = true;
           this.ckManualDuplex.Location = new System.Drawing.Point(3, 3);
           this.ckManualDuplex.Name = "ckManualDuplex";
           this.ckManualDuplex.Size = new System.Drawing.Size(388, 17);
           this.ckManualDuplex.TabIndex = 1;
           this.ckManualDuplex.Text = "Manually duplex when printing (Allows you to print on both sides of the page).";
           this.ckManualDuplex.UseVisualStyleBackColor = true;
           // 
           // tableLayoutPanel3
           // 
           this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel3.ColumnCount = 3;
           this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel3.Controls.Add(this.label13, 2, 0);
           this.tableLayoutPanel3.Controls.Add(this.numBackupFrequency, 1, 0);
           this.tableLayoutPanel3.Controls.Add(this.label12, 0, 0);
           this.tableLayoutPanel3.Location = new System.Drawing.Point(25, 72);
           this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
           this.tableLayoutPanel3.Name = "tableLayoutPanel3";
           this.tableLayoutPanel3.RowCount = 1;
           this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
           this.tableLayoutPanel3.Size = new System.Drawing.Size(406, 30);
           this.tableLayoutPanel3.TabIndex = 10;
           // 
           // label13
           // 
           this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.label13.AutoSize = true;
           this.label13.Location = new System.Drawing.Point(132, 8);
           this.label13.Name = "label13";
           this.label13.Size = new System.Drawing.Size(47, 13);
           this.label13.TabIndex = 4;
           this.label13.Text = "seconds";
           // 
           // numBackupFrequency
           // 
           this.numBackupFrequency.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.numBackupFrequency.Location = new System.Drawing.Point(46, 5);
           this.numBackupFrequency.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
           this.numBackupFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
           this.numBackupFrequency.Name = "numBackupFrequency";
           this.numBackupFrequency.Size = new System.Drawing.Size(80, 20);
           this.numBackupFrequency.TabIndex = 7;
           this.numBackupFrequency.ThousandsSeparator = true;
           this.numBackupFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
           // 
           // label12
           // 
           this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label12.AutoSize = true;
           this.label12.Location = new System.Drawing.Point(3, 8);
           this.label12.Name = "label12";
           this.label12.Size = new System.Drawing.Size(37, 13);
           this.label12.TabIndex = 1;
           this.label12.Text = "Delay:";
           // 
           // ckHqLayout
           // 
           this.ckHqLayout.AutoSize = true;
           this.ckHqLayout.Location = new System.Drawing.Point(3, 26);
           this.ckHqLayout.Name = "ckHqLayout";
           this.ckHqLayout.Size = new System.Drawing.Size(167, 17);
           this.ckHqLayout.TabIndex = 2;
           this.ckHqLayout.Text = "High quality text layout (Slow).";
           this.ckHqLayout.UseVisualStyleBackColor = true;
           // 
           // ckEnableBackup
           // 
           this.ckEnableBackup.AutoSize = true;
           this.ckEnableBackup.Location = new System.Drawing.Point(3, 49);
           this.ckEnableBackup.Name = "ckEnableBackup";
           this.ckEnableBackup.Size = new System.Drawing.Size(221, 17);
           this.ckEnableBackup.TabIndex = 3;
           this.ckEnableBackup.Text = "Automatically save backups of open files.";
           this.ckEnableBackup.UseVisualStyleBackColor = true;
           this.ckEnableBackup.CheckedChanged += new System.EventHandler(this.ckEnableBackup_CheckedChanged);
           // 
           // btOk
           // 
           this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.btOk.Location = new System.Drawing.Point(381, 301);
           this.btOk.Name = "btOk";
           this.btOk.Size = new System.Drawing.Size(75, 23);
           this.btOk.TabIndex = 1;
           this.btOk.Text = "OK";
           this.btOk.UseVisualStyleBackColor = true;
           this.btOk.Click += new System.EventHandler(this.btOk_Click);
           // 
           // btCancel
           // 
           this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.btCancel.Location = new System.Drawing.Point(300, 301);
           this.btCancel.Name = "btCancel";
           this.btCancel.Size = new System.Drawing.Size(75, 23);
           this.btCancel.TabIndex = 2;
           this.btCancel.Text = "Cancel";
           this.btCancel.UseVisualStyleBackColor = true;
           // 
           // ctError
           // 
           this.ctError.ContainerControl = this;
           // 
           // tableLayoutPanel5
           // 
           this.tableLayoutPanel5.ColumnCount = 2;
           this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel5.Controls.Add(this.tbSeperatorChar, 1, 0);
           this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
           this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 108);
           this.tableLayoutPanel5.Name = "tableLayoutPanel5";
           this.tableLayoutPanel5.RowCount = 1;
           this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel5.Size = new System.Drawing.Size(428, 28);
           this.tableLayoutPanel5.TabIndex = 11;
           // 
           // label1
           // 
           this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(3, 7);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(77, 13);
           this.label1.TabIndex = 2;
           this.label1.Text = "CSV Seperator";
           // 
           // tbSeperatorChar
           // 
           this.tbSeperatorChar.Location = new System.Drawing.Point(86, 3);
           this.tbSeperatorChar.MaxLength = 1;
           this.tbSeperatorChar.Name = "tbSeperatorChar";
           this.tbSeperatorChar.Size = new System.Drawing.Size(117, 20);
           this.tbSeperatorChar.TabIndex = 3;
           this.tbSeperatorChar.TextChanged += new System.EventHandler(this.tbSeperatorChar_TextChanged);
           // 
           // label2
           // 
           this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel4.SetColumnSpan(this.label2, 3);
           this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
           this.label2.Location = new System.Drawing.Point(25, 144);
           this.label2.Margin = new System.Windows.Forms.Padding(25, 5, 3, 0);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(406, 111);
           this.label2.TabIndex = 12;
           this.label2.Text = "CSV seperator is used by the batch editor to sperate fields and also by \'Export a" +
               "s CSV\' method.";
           // 
           // Preferences
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(474, 334);
           this.Controls.Add(this.btCancel);
           this.Controls.Add(this.btOk);
           this.Controls.Add(this.tabControl1);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "Preferences";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Preferences";
           this.tabControl1.ResumeLayout(false);
           this.tabPage1.ResumeLayout(false);
           this.tabPage1.PerformLayout();
           this.tableLayoutPanel2.ResumeLayout(false);
           this.tableLayoutPanel2.PerformLayout();
           this.tabPage2.ResumeLayout(false);
           this.tabPage2.PerformLayout();
           this.tableLayoutPanel1.ResumeLayout(false);
           this.tableLayoutPanel1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numBack)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.numFront)).EndInit();
           this.tabPage3.ResumeLayout(false);
           this.tabPage3.PerformLayout();
           this.tabPage4.ResumeLayout(false);
           this.tabPage4.PerformLayout();
           this.tableLayoutPanel4.ResumeLayout(false);
           this.tableLayoutPanel4.PerformLayout();
           this.tableLayoutPanel3.ResumeLayout(false);
           this.tableLayoutPanel3.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.numBackupFrequency)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this.ctError)).EndInit();
           this.tableLayoutPanel5.ResumeLayout(false);
           this.tableLayoutPanel5.PerformLayout();
           this.ResumeLayout(false);

	   }

	   #endregion

	   private System.Windows.Forms.TabControl tabControl1;
	   private System.Windows.Forms.TabPage tabPage1;
	   private System.Windows.Forms.TabPage tabPage2;
	   private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
	   private System.Windows.Forms.Label label3;
	   private System.Windows.Forms.Label label5;
	   private System.Windows.Forms.Label label4;
	   private System.Windows.Forms.Label label7;
	   private System.Windows.Forms.Label label6;
	   private System.Windows.Forms.NumericUpDown numBack;
	   private System.Windows.Forms.NumericUpDown numFront;
	   private System.Windows.Forms.Button btAssociate;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	   private System.Windows.Forms.TabPage tabPage3;
	   private System.Windows.Forms.CheckBox ckKeepStyles;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	   private System.Windows.Forms.Label label8;
	   private System.Windows.Forms.Label lblFontInfo;
	   private System.Windows.Forms.Button btChooseFont;
	   private System.Windows.Forms.Label label9;
	   private System.Windows.Forms.Label lblPrintFontInfo;
	   private System.Windows.Forms.Button btChoosePrintFont;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox ckManualDuplex;
        private System.Windows.Forms.CheckBox ckHqLayout;
        private System.Windows.Forms.CheckBox ckEnableBackup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numBackupFrequency;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ErrorProvider ctError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbSeperatorChar;
        private System.Windows.Forms.Label label1;
    }
}