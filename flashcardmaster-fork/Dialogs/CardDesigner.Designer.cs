namespace FlashCardMaster.Dialogs
{
    partial class CardDesigner
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
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
           this.btBackground = new System.Windows.Forms.Button();
           this.label4 = new System.Windows.Forms.Label();
           this.cmbType = new System.Windows.Forms.ComboBox();
           this.ckFront = new System.Windows.Forms.CheckBox();
           this.ckBack = new System.Windows.Forms.CheckBox();
           this.label5 = new System.Windows.Forms.Label();
           this.cmbPositions = new System.Windows.Forms.ComboBox();
           this.tbName = new System.Windows.Forms.TextBox();
           this.label3 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.label6 = new System.Windows.Forms.Label();
           this.label7 = new System.Windows.Forms.Label();
           this.btForeColor = new System.Windows.Forms.Button();
           this.btBackgroundAlpha = new System.Windows.Forms.Button();
           this.btColorAlpha = new System.Windows.Forms.Button();
           this.label2 = new System.Windows.Forms.Label();
           this.rdbFront = new System.Windows.Forms.RadioButton();
           this.rdbBack = new System.Windows.Forms.RadioButton();
           this.btOk = new System.Windows.Forms.Button();
           this.btAddElement = new System.Windows.Forms.Button();
           this.btRemoveElement = new System.Windows.Forms.Button();
           this.ctError = new System.Windows.Forms.ErrorProvider(this.components);
           this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
           this.btMoveDown = new System.Windows.Forms.Button();
           this.btMoveUp = new System.Windows.Forms.Button();
           this.splitContainer1 = new System.Windows.Forms.SplitContainer();
           this.pnlCard = new FlashCardMaster.Utilities.CardPanel();
           this.splitContainer2 = new System.Windows.Forms.SplitContainer();
           this.lvElements = new DragNDrop.DragAndDropListView();
           this.clName = new System.Windows.Forms.ColumnHeader();
           this.groupBox1.SuspendLayout();
           this.tableLayoutPanel1.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.ctError)).BeginInit();
           this.tableLayoutPanel2.SuspendLayout();
           this.splitContainer1.Panel1.SuspendLayout();
           this.splitContainer1.Panel2.SuspendLayout();
           this.splitContainer1.SuspendLayout();
           this.splitContainer2.Panel1.SuspendLayout();
           this.splitContainer2.Panel2.SuspendLayout();
           this.splitContainer2.SuspendLayout();
           this.SuspendLayout();
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this.tableLayoutPanel1);
           this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.groupBox1.Location = new System.Drawing.Point(0, 0);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(203, 194);
           this.groupBox1.TabIndex = 6;
           this.groupBox1.TabStop = false;
           this.groupBox1.Text = "Properties";
           // 
           // tableLayoutPanel1
           // 
           this.tableLayoutPanel1.ColumnCount = 3;
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel1.Controls.Add(this.btBackground, 1, 6);
           this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
           this.tableLayoutPanel1.Controls.Add(this.cmbType, 1, 4);
           this.tableLayoutPanel1.Controls.Add(this.ckFront, 1, 2);
           this.tableLayoutPanel1.Controls.Add(this.ckBack, 2, 2);
           this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
           this.tableLayoutPanel1.Controls.Add(this.cmbPositions, 1, 3);
           this.tableLayoutPanel1.Controls.Add(this.tbName, 0, 1);
           this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
           this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
           this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
           this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
           this.tableLayoutPanel1.Controls.Add(this.btForeColor, 1, 5);
           this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
           this.tableLayoutPanel1.Name = "tableLayoutPanel1";
           this.tableLayoutPanel1.RowCount = 7;
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.tableLayoutPanel1.Size = new System.Drawing.Size(197, 175);
           this.tableLayoutPanel1.TabIndex = 7;
           // 
           // btBackground
           // 
           this.btBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.SetColumnSpan(this.btBackground, 2);
           this.btBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btBackground.Location = new System.Drawing.Point(74, 148);
           this.btBackground.Name = "btBackground";
           this.btBackground.Size = new System.Drawing.Size(120, 23);
           this.btBackground.TabIndex = 10;
           this.btBackground.Text = "Default";
           this.btBackground.UseVisualStyleBackColor = true;
           this.btBackground.Click += new System.EventHandler(this.btBackground_Click);
           // 
           // label4
           // 
           this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label4.AutoSize = true;
           this.label4.Location = new System.Drawing.Point(35, 44);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(33, 13);
           this.label4.TabIndex = 0;
           this.label4.Text = "Sides";
           // 
           // cmbType
           // 
           this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.SetColumnSpan(this.cmbType, 2);
           this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.cmbType.FormattingEnabled = true;
           this.cmbType.Location = new System.Drawing.Point(74, 92);
           this.cmbType.Name = "cmbType";
           this.cmbType.Size = new System.Drawing.Size(120, 21);
           this.cmbType.TabIndex = 6;
           this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
           this.cmbType.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // ckFront
           // 
           this.ckFront.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.ckFront.AutoSize = true;
           this.ckFront.Location = new System.Drawing.Point(74, 42);
           this.ckFront.Name = "ckFront";
           this.ckFront.Size = new System.Drawing.Size(50, 17);
           this.ckFront.TabIndex = 1;
           this.ckFront.Text = "Front";
           this.ckFront.UseVisualStyleBackColor = true;
           this.ckFront.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           this.ckFront.CheckedChanged += new System.EventHandler(this.ckSides_CheckedChanged);
           // 
           // ckBack
           // 
           this.ckBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.ckBack.AutoSize = true;
           this.ckBack.Location = new System.Drawing.Point(130, 42);
           this.ckBack.Name = "ckBack";
           this.ckBack.Size = new System.Drawing.Size(51, 17);
           this.ckBack.TabIndex = 2;
           this.ckBack.Text = "Back";
           this.ckBack.UseVisualStyleBackColor = true;
           this.ckBack.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           this.ckBack.CheckedChanged += new System.EventHandler(this.ckSides_CheckedChanged);
           // 
           // label5
           // 
           this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label5.AutoSize = true;
           this.label5.Location = new System.Drawing.Point(37, 96);
           this.label5.Name = "label5";
           this.label5.Size = new System.Drawing.Size(31, 13);
           this.label5.TabIndex = 5;
           this.label5.Text = "Type";
           // 
           // cmbPositions
           // 
           this.cmbPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.SetColumnSpan(this.cmbPositions, 2);
           this.cmbPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
           this.cmbPositions.FormattingEnabled = true;
           this.cmbPositions.Location = new System.Drawing.Point(74, 65);
           this.cmbPositions.Name = "cmbPositions";
           this.cmbPositions.Size = new System.Drawing.Size(120, 21);
           this.cmbPositions.TabIndex = 4;
           this.cmbPositions.SelectedIndexChanged += new System.EventHandler(this.cmbPositions_SelectedIndexChanged);
           this.cmbPositions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // tbName
           // 
           this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.SetColumnSpan(this.tbName, 3);
           this.ctError.SetIconPadding(this.tbName, 3);
           this.tbName.Location = new System.Drawing.Point(3, 16);
           this.tbName.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
           this.tbName.Name = "tbName";
           this.tbName.Size = new System.Drawing.Size(174, 20);
           this.tbName.TabIndex = 1;
           this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
           // 
           // label3
           // 
           this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label3.AutoSize = true;
           this.label3.Location = new System.Drawing.Point(24, 69);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(44, 13);
           this.label3.TabIndex = 3;
           this.label3.Text = "Position";
           // 
           // label1
           // 
           this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(3, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(65, 13);
           this.label1.TabIndex = 0;
           this.label1.Text = "Name";
           // 
           // label6
           // 
           this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label6.AutoSize = true;
           this.label6.Location = new System.Drawing.Point(37, 124);
           this.label6.Name = "label6";
           this.label6.Size = new System.Drawing.Size(31, 13);
           this.label6.TabIndex = 7;
           this.label6.Text = "Color";
           // 
           // label7
           // 
           this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
           this.label7.AutoSize = true;
           this.label7.Location = new System.Drawing.Point(3, 153);
           this.label7.Name = "label7";
           this.label7.Size = new System.Drawing.Size(65, 13);
           this.label7.TabIndex = 8;
           this.label7.Text = "Background";
           // 
           // btForeColor
           // 
           this.btForeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel1.SetColumnSpan(this.btForeColor, 2);
           this.btForeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btForeColor.Location = new System.Drawing.Point(74, 119);
           this.btForeColor.Name = "btForeColor";
           this.btForeColor.Size = new System.Drawing.Size(120, 23);
           this.btForeColor.TabIndex = 9;
           this.btForeColor.Text = "Default";
           this.btForeColor.UseVisualStyleBackColor = true;
           this.btForeColor.Click += new System.EventHandler(this.btForeColor_Click);
           // 
           // btBackgroundAlpha
           // 
           this.btBackgroundAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btBackgroundAlpha.Location = new System.Drawing.Point(44, 326);
           this.btBackgroundAlpha.Name = "btBackgroundAlpha";
           this.btBackgroundAlpha.Size = new System.Drawing.Size(26, 23);
           this.btBackgroundAlpha.TabIndex = 12;
           this.btBackgroundAlpha.Text = "▼";
           this.btBackgroundAlpha.UseVisualStyleBackColor = true;
           this.btBackgroundAlpha.Visible = false;
           this.btBackgroundAlpha.Click += new System.EventHandler(this.btBackgroundAlpha_Click);
           // 
           // btColorAlpha
           // 
           this.btColorAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.btColorAlpha.Location = new System.Drawing.Point(12, 326);
           this.btColorAlpha.Name = "btColorAlpha";
           this.btColorAlpha.Size = new System.Drawing.Size(26, 23);
           this.btColorAlpha.TabIndex = 11;
           this.btColorAlpha.Text = "▼";
           this.btColorAlpha.UseVisualStyleBackColor = true;
           this.btColorAlpha.Visible = false;
           this.btColorAlpha.Click += new System.EventHandler(this.btColorAlpha_Click);
           // 
           // label2
           // 
           this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(3, 5);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(37, 13);
           this.label2.TabIndex = 0;
           this.label2.Text = "Show:";
           this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
           // 
           // rdbFront
           // 
           this.rdbFront.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.rdbFront.AutoSize = true;
           this.rdbFront.Checked = true;
           this.rdbFront.Location = new System.Drawing.Point(46, 3);
           this.rdbFront.Name = "rdbFront";
           this.rdbFront.Size = new System.Drawing.Size(49, 17);
           this.rdbFront.TabIndex = 1;
           this.rdbFront.TabStop = true;
           this.rdbFront.Text = "Front";
           this.rdbFront.UseVisualStyleBackColor = true;
           this.rdbFront.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           this.rdbFront.CheckedChanged += new System.EventHandler(this.rdbFront_CheckedChanged);
           // 
           // rdbBack
           // 
           this.rdbBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.rdbBack.AutoSize = true;
           this.rdbBack.Location = new System.Drawing.Point(101, 3);
           this.rdbBack.Name = "rdbBack";
           this.rdbBack.Size = new System.Drawing.Size(50, 17);
           this.rdbBack.TabIndex = 2;
           this.rdbBack.TabStop = true;
           this.rdbBack.Text = "Back";
           this.rdbBack.UseVisualStyleBackColor = true;
           this.rdbBack.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // btOk
           // 
           this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.btOk.Location = new System.Drawing.Point(575, 326);
           this.btOk.Name = "btOk";
           this.btOk.Size = new System.Drawing.Size(75, 23);
           this.btOk.TabIndex = 0;
           this.btOk.Text = "Close";
           this.btOk.UseVisualStyleBackColor = true;
           this.btOk.Click += new System.EventHandler(this.btOk_Click);
           this.btOk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // btAddElement
           // 
           this.btAddElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.btAddElement.FlatAppearance.BorderSize = 0;
           this.btAddElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btAddElement.Image = global::FlashCardMaster.Properties.Resources.list_add;
           this.btAddElement.Location = new System.Drawing.Point(626, 8);
           this.btAddElement.Name = "btAddElement";
           this.btAddElement.Size = new System.Drawing.Size(24, 23);
           this.btAddElement.TabIndex = 3;
           this.btAddElement.UseVisualStyleBackColor = true;
           this.btAddElement.Click += new System.EventHandler(this.btAddElement_Click);
           this.btAddElement.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // btRemoveElement
           // 
           this.btRemoveElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.btRemoveElement.FlatAppearance.BorderSize = 0;
           this.btRemoveElement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btRemoveElement.Image = global::FlashCardMaster.Properties.Resources.list_remove;
           this.btRemoveElement.Location = new System.Drawing.Point(602, 8);
           this.btRemoveElement.Name = "btRemoveElement";
           this.btRemoveElement.Size = new System.Drawing.Size(24, 23);
           this.btRemoveElement.TabIndex = 2;
           this.btRemoveElement.UseVisualStyleBackColor = true;
           this.btRemoveElement.Click += new System.EventHandler(this.btRemoveElement_Click);
           this.btRemoveElement.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // ctError
           // 
           this.ctError.ContainerControl = this;
           // 
           // tableLayoutPanel2
           // 
           this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.tableLayoutPanel2.ColumnCount = 3;
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.tableLayoutPanel2.Controls.Add(this.rdbBack, 2, 0);
           this.tableLayoutPanel2.Controls.Add(this.rdbFront, 1, 0);
           this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
           this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
           this.tableLayoutPanel2.Name = "tableLayoutPanel2";
           this.tableLayoutPanel2.RowCount = 1;
           this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
           this.tableLayoutPanel2.Size = new System.Drawing.Size(431, 23);
           this.tableLayoutPanel2.TabIndex = 7;
           // 
           // btMoveDown
           // 
           this.btMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.btMoveDown.FlatAppearance.BorderSize = 0;
           this.btMoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btMoveDown.Image = global::FlashCardMaster.Properties.Resources.go_down;
           this.btMoveDown.Location = new System.Drawing.Point(572, 8);
           this.btMoveDown.Name = "btMoveDown";
           this.btMoveDown.Size = new System.Drawing.Size(24, 23);
           this.btMoveDown.TabIndex = 9;
           this.btMoveDown.UseVisualStyleBackColor = true;
           this.btMoveDown.Click += new System.EventHandler(this.btMoveDown_Click);
           // 
           // btMoveUp
           // 
           this.btMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
           this.btMoveUp.FlatAppearance.BorderSize = 0;
           this.btMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btMoveUp.Image = global::FlashCardMaster.Properties.Resources.go_up;
           this.btMoveUp.Location = new System.Drawing.Point(548, 8);
           this.btMoveUp.Name = "btMoveUp";
           this.btMoveUp.Size = new System.Drawing.Size(24, 23);
           this.btMoveUp.TabIndex = 8;
           this.btMoveUp.UseVisualStyleBackColor = true;
           this.btMoveUp.Click += new System.EventHandler(this.btMoveUp_Click);
           // 
           // splitContainer1
           // 
           this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
           this.splitContainer1.Location = new System.Drawing.Point(12, 37);
           this.splitContainer1.Name = "splitContainer1";
           // 
           // splitContainer1.Panel1
           // 
           this.splitContainer1.Panel1.Controls.Add(this.pnlCard);
           // 
           // splitContainer1.Panel2
           // 
           this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
           this.splitContainer1.Size = new System.Drawing.Size(638, 280);
           this.splitContainer1.SplitterDistance = 431;
           this.splitContainer1.TabIndex = 10;
           // 
           // pnlCard
           // 
           this.pnlCard.BackColor = System.Drawing.SystemColors.Window;
           this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
           this.pnlCard.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.pnlCard.ForeColor = System.Drawing.SystemColors.WindowText;
           this.pnlCard.Location = new System.Drawing.Point(0, 0);
           this.pnlCard.Name = "pnlCard";
           this.pnlCard.NoCardMessage = "";
           this.pnlCard.Padding = new System.Windows.Forms.Padding(5);
           this.pnlCard.Size = new System.Drawing.Size(431, 280);
           this.pnlCard.SuspendPaint = false;
           this.pnlCard.TabIndex = 1;
           // 
           // splitContainer2
           // 
           this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
           this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
           this.splitContainer2.IsSplitterFixed = true;
           this.splitContainer2.Location = new System.Drawing.Point(0, 0);
           this.splitContainer2.Name = "splitContainer2";
           this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
           // 
           // splitContainer2.Panel1
           // 
           this.splitContainer2.Panel1.Controls.Add(this.lvElements);
           // 
           // splitContainer2.Panel2
           // 
           this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
           this.splitContainer2.Size = new System.Drawing.Size(203, 280);
           this.splitContainer2.SplitterDistance = 82;
           this.splitContainer2.TabIndex = 0;
           // 
           // lvElements
           // 
           this.lvElements.AllowDrop = true;
           this.lvElements.AllowReorder = true;
           this.lvElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clName});
           this.lvElements.Dock = System.Windows.Forms.DockStyle.Fill;
           this.lvElements.FullRowSelect = true;
           this.lvElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
           this.lvElements.HideSelection = false;
           this.lvElements.LineColor = System.Drawing.SystemColors.WindowText;
           this.lvElements.Location = new System.Drawing.Point(0, 0);
           this.lvElements.MultiSelect = false;
           this.lvElements.Name = "lvElements";
           this.lvElements.Size = new System.Drawing.Size(203, 82);
           this.lvElements.TabIndex = 4;
           this.lvElements.UseCompatibleStateImageBehavior = false;
           this.lvElements.View = System.Windows.Forms.View.Details;
           this.lvElements.SelectedIndexChanged += new System.EventHandler(this.lstCardList_SelectedIndexChanged);
           this.lvElements.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           // 
           // clName
           // 
           this.clName.Text = "Name";
           this.clName.Width = 167;
           // 
           // CardDesigner
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(664, 357);
           this.Controls.Add(this.btBackgroundAlpha);
           this.Controls.Add(this.splitContainer1);
           this.Controls.Add(this.btMoveDown);
           this.Controls.Add(this.btMoveUp);
           this.Controls.Add(this.tableLayoutPanel2);
           this.Controls.Add(this.btAddElement);
           this.Controls.Add(this.btRemoveElement);
           this.Controls.Add(this.btOk);
           this.Controls.Add(this.btColorAlpha);
           this.MinimumSize = new System.Drawing.Size(403, 274);
           this.Name = "CardDesigner";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Design Card";
           this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CardDesigner_KeyUp);
           this.groupBox1.ResumeLayout(false);
           this.tableLayoutPanel1.ResumeLayout(false);
           this.tableLayoutPanel1.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.ctError)).EndInit();
           this.tableLayoutPanel2.ResumeLayout(false);
           this.tableLayoutPanel2.PerformLayout();
           this.splitContainer1.Panel1.ResumeLayout(false);
           this.splitContainer1.Panel2.ResumeLayout(false);
           this.splitContainer1.ResumeLayout(false);
           this.splitContainer2.Panel1.ResumeLayout(false);
           this.splitContainer2.Panel2.ResumeLayout(false);
           this.splitContainer2.ResumeLayout(false);
           this.ResumeLayout(false);

	   }

	   #endregion

	   private FlashCardMaster.Utilities.CardPanel pnlCard;
	   private System.Windows.Forms.GroupBox groupBox1;
	   private System.Windows.Forms.CheckBox ckBack;
	   private System.Windows.Forms.CheckBox ckFront;
	   private System.Windows.Forms.Label label1;
	   private System.Windows.Forms.TextBox tbName;
	   private System.Windows.Forms.Label label2;
	   private System.Windows.Forms.RadioButton rdbFront;
	   private System.Windows.Forms.RadioButton rdbBack;
	   private System.Windows.Forms.Label label4;
	   private System.Windows.Forms.ComboBox cmbPositions;
	   private System.Windows.Forms.Label label3;
	   private System.Windows.Forms.Button btOk;
	   private DragNDrop.DragAndDropListView lvElements;
	   private System.Windows.Forms.ColumnHeader clName;
	   private System.Windows.Forms.ComboBox cmbType;
	   private System.Windows.Forms.Label label5;
	   private System.Windows.Forms.Button btAddElement;
	   private System.Windows.Forms.Button btRemoveElement;
	   private System.Windows.Forms.ErrorProvider ctError;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	   private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	   private System.Windows.Forms.Button btMoveDown;
	   private System.Windows.Forms.Button btMoveUp;
       private System.Windows.Forms.Label label7;
       private System.Windows.Forms.Label label6;
       private System.Windows.Forms.SplitContainer splitContainer1;
       private System.Windows.Forms.SplitContainer splitContainer2;
       private System.Windows.Forms.Button btForeColor;
       private System.Windows.Forms.Button btBackground;
       private System.Windows.Forms.Button btBackgroundAlpha;
       private System.Windows.Forms.Button btColorAlpha;
    }
}