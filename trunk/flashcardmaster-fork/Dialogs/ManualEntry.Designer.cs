namespace FlashCardMaster.Dialogs
{
    partial class ManualEntry
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
           this.lvElements = new DragNDrop.DragAndDropListView();
           this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
           this.txtEdit = new System.Windows.Forms.TextBox();
           this.btItalic = new System.Windows.Forms.Button();
           this.btUnderline = new System.Windows.Forms.Button();
           this.btStrike = new System.Windows.Forms.Button();
           this.btBold = new System.Windows.Forms.Button();
           this.btRemove = new System.Windows.Forms.Button();
           this.btAdd = new System.Windows.Forms.Button();
           this.btClose = new System.Windows.Forms.Button();
           this.RootContainer = new System.Windows.Forms.SplitContainer();
           this.CardFieldEditContainer = new System.Windows.Forms.SplitContainer();
           this.lvCards = new DragNDrop.DragAndDropListView();
           this.colCardName = new System.Windows.Forms.ColumnHeader();
           this.FieldEditContainer = new System.Windows.Forms.SplitContainer();
           this.panel1 = new System.Windows.Forms.Panel();
           this.EditTable = new System.Windows.Forms.TableLayoutPanel();
           this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
           this.pnlCard = new FlashCardMaster.Utilities.CardPanel();
           this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
           this.RootContainer.Panel1.SuspendLayout();
           this.RootContainer.Panel2.SuspendLayout();
           this.RootContainer.SuspendLayout();
           this.CardFieldEditContainer.Panel1.SuspendLayout();
           this.CardFieldEditContainer.Panel2.SuspendLayout();
           this.CardFieldEditContainer.SuspendLayout();
           this.FieldEditContainer.Panel1.SuspendLayout();
           this.FieldEditContainer.Panel2.SuspendLayout();
           this.FieldEditContainer.SuspendLayout();
           this.panel1.SuspendLayout();
           this.EditTable.SuspendLayout();
           this.flowLayoutPanel1.SuspendLayout();
           this.flowLayoutPanel2.SuspendLayout();
           this.SuspendLayout();
           // 
           // lvElements
           // 
           this.lvElements.AllowDrop = true;
           this.lvElements.AllowReorder = true;
           this.lvElements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
           this.lvElements.Dock = System.Windows.Forms.DockStyle.Fill;
           this.lvElements.FullRowSelect = true;
           this.lvElements.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.lvElements.HideSelection = false;
           this.lvElements.LineColor = System.Drawing.SystemColors.WindowText;
           this.lvElements.Location = new System.Drawing.Point(0, 0);
           this.lvElements.MultiSelect = false;
           this.lvElements.Name = "lvElements";
           this.lvElements.ShowGroups = false;
           this.lvElements.Size = new System.Drawing.Size(160, 144);
           this.lvElements.TabIndex = 16;
           this.lvElements.UseCompatibleStateImageBehavior = false;
           this.lvElements.View = System.Windows.Forms.View.Details;
           this.lvElements.SelectedIndexChanged += new System.EventHandler(this.lvElements_SelectedIndexChanged);
           this.lvElements.ItemReordered += new System.EventHandler(this.lvElements_ItemReordered);
           this.lvElements.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // columnHeader1
           // 
           this.columnHeader1.Text = "Fields";
           this.columnHeader1.Width = 117;
           // 
           // txtEdit
           // 
           this.txtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.txtEdit.HideSelection = false;
           this.txtEdit.Location = new System.Drawing.Point(0, 35);
           this.txtEdit.Margin = new System.Windows.Forms.Padding(0);
           this.txtEdit.Multiline = true;
           this.txtEdit.Name = "txtEdit";
           this.txtEdit.Size = new System.Drawing.Size(176, 109);
           this.txtEdit.TabIndex = 18;
           this.txtEdit.TextChanged += new System.EventHandler(this.txtEdit_TextChanged);
           this.txtEdit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btItalic
           // 
           this.btItalic.AutoSize = true;
           this.btItalic.FlatAppearance.BorderSize = 0;
           this.btItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btItalic.Image = global::FlashCardMaster.Properties.Resources.format_text_italic;
           this.btItalic.Location = new System.Drawing.Point(33, 3);
           this.btItalic.Name = "btItalic";
           this.btItalic.Size = new System.Drawing.Size(24, 23);
           this.btItalic.TabIndex = 24;
           this.btItalic.UseVisualStyleBackColor = true;
           this.btItalic.Click += new System.EventHandler(this.btItalic_Click);
           this.btItalic.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btUnderline
           // 
           this.btUnderline.AutoSize = true;
           this.btUnderline.FlatAppearance.BorderSize = 0;
           this.btUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btUnderline.Image = global::FlashCardMaster.Properties.Resources.format_text_underline;
           this.btUnderline.Location = new System.Drawing.Point(63, 3);
           this.btUnderline.Name = "btUnderline";
           this.btUnderline.Size = new System.Drawing.Size(24, 23);
           this.btUnderline.TabIndex = 23;
           this.btUnderline.UseVisualStyleBackColor = true;
           this.btUnderline.Click += new System.EventHandler(this.btUnderline_Click);
           this.btUnderline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btStrike
           // 
           this.btStrike.AutoSize = true;
           this.btStrike.FlatAppearance.BorderSize = 0;
           this.btStrike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btStrike.Image = global::FlashCardMaster.Properties.Resources.format_text_strikethrough;
           this.btStrike.Location = new System.Drawing.Point(93, 3);
           this.btStrike.Name = "btStrike";
           this.btStrike.Size = new System.Drawing.Size(24, 23);
           this.btStrike.TabIndex = 22;
           this.btStrike.UseVisualStyleBackColor = true;
           this.btStrike.Click += new System.EventHandler(this.btStrike_Click);
           this.btStrike.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btBold
           // 
           this.btBold.AutoSize = true;
           this.btBold.FlatAppearance.BorderSize = 0;
           this.btBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btBold.Image = global::FlashCardMaster.Properties.Resources.format_text_bold;
           this.btBold.Location = new System.Drawing.Point(3, 3);
           this.btBold.Name = "btBold";
           this.btBold.Size = new System.Drawing.Size(24, 23);
           this.btBold.TabIndex = 21;
           this.btBold.UseVisualStyleBackColor = true;
           this.btBold.Click += new System.EventHandler(this.btBold_Click);
           this.btBold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btRemove
           // 
           this.btRemove.AutoSize = true;
           this.btRemove.FlatAppearance.BorderSize = 0;
           this.btRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btRemove.Image = global::FlashCardMaster.Properties.Resources.list_remove;
           this.btRemove.Location = new System.Drawing.Point(3, 32);
           this.btRemove.Name = "btRemove";
           this.btRemove.Size = new System.Drawing.Size(24, 23);
           this.btRemove.TabIndex = 20;
           this.btRemove.UseVisualStyleBackColor = true;
           this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
           this.btRemove.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btAdd
           // 
           this.btAdd.AutoSize = true;
           this.btAdd.FlatAppearance.BorderSize = 0;
           this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
           this.btAdd.Image = global::FlashCardMaster.Properties.Resources.list_add;
           this.btAdd.Location = new System.Drawing.Point(3, 3);
           this.btAdd.Name = "btAdd";
           this.btAdd.Size = new System.Drawing.Size(24, 23);
           this.btAdd.TabIndex = 19;
           this.btAdd.UseVisualStyleBackColor = true;
           this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
           this.btAdd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // btClose
           // 
           this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btClose.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.btClose.Location = new System.Drawing.Point(453, 296);
           this.btClose.Name = "btClose";
           this.btClose.Size = new System.Drawing.Size(75, 23);
           this.btClose.TabIndex = 25;
           this.btClose.Text = "Close";
           this.btClose.UseVisualStyleBackColor = true;
           // 
           // RootContainer
           // 
           this.RootContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.RootContainer.Location = new System.Drawing.Point(34, 12);
           this.RootContainer.Name = "RootContainer";
           this.RootContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
           // 
           // RootContainer.Panel1
           // 
           this.RootContainer.Panel1.Controls.Add(this.CardFieldEditContainer);
           // 
           // RootContainer.Panel2
           // 
           this.RootContainer.Panel2.Controls.Add(this.pnlCard);
           this.RootContainer.Size = new System.Drawing.Size(494, 279);
           this.RootContainer.SplitterDistance = 144;
           this.RootContainer.TabIndex = 26;
           // 
           // CardFieldEditContainer
           // 
           this.CardFieldEditContainer.Dock = System.Windows.Forms.DockStyle.Fill;
           this.CardFieldEditContainer.Location = new System.Drawing.Point(0, 0);
           this.CardFieldEditContainer.Name = "CardFieldEditContainer";
           // 
           // CardFieldEditContainer.Panel1
           // 
           this.CardFieldEditContainer.Panel1.Controls.Add(this.lvCards);
           this.CardFieldEditContainer.Panel1MinSize = 0;
           // 
           // CardFieldEditContainer.Panel2
           // 
           this.CardFieldEditContainer.Panel2.Controls.Add(this.FieldEditContainer);
           this.CardFieldEditContainer.Size = new System.Drawing.Size(494, 144);
           this.CardFieldEditContainer.SplitterDistance = 150;
           this.CardFieldEditContainer.TabIndex = 0;
           // 
           // lvCards
           // 
           this.lvCards.AllowDrop = true;
           this.lvCards.AllowReorder = true;
           this.lvCards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCardName});
           this.lvCards.Dock = System.Windows.Forms.DockStyle.Fill;
           this.lvCards.FullRowSelect = true;
           this.lvCards.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
           this.lvCards.HideSelection = false;
           this.lvCards.LineColor = System.Drawing.SystemColors.WindowText;
           this.lvCards.Location = new System.Drawing.Point(0, 0);
           this.lvCards.Name = "lvCards";
           this.lvCards.ShowGroups = false;
           this.lvCards.Size = new System.Drawing.Size(150, 144);
           this.lvCards.TabIndex = 13;
           this.lvCards.UseCompatibleStateImageBehavior = false;
           this.lvCards.View = System.Windows.Forms.View.Details;
           this.lvCards.SelectedIndexChanged += new System.EventHandler(this.lvCards_SelectedIndexChanged);
           this.lvCards.ItemReordered += new System.EventHandler(this.lvCards_ItemReordered);
           this.lvCards.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           // 
           // colCardName
           // 
           this.colCardName.Text = "Cards";
           this.colCardName.Width = 111;
           // 
           // FieldEditContainer
           // 
           this.FieldEditContainer.Dock = System.Windows.Forms.DockStyle.Fill;
           this.FieldEditContainer.Location = new System.Drawing.Point(0, 0);
           this.FieldEditContainer.Name = "FieldEditContainer";
           // 
           // FieldEditContainer.Panel1
           // 
           this.FieldEditContainer.Panel1.Controls.Add(this.lvElements);
           this.FieldEditContainer.Panel1MinSize = 0;
           // 
           // FieldEditContainer.Panel2
           // 
           this.FieldEditContainer.Panel2.Controls.Add(this.panel1);
           this.FieldEditContainer.Size = new System.Drawing.Size(340, 144);
           this.FieldEditContainer.SplitterDistance = 160;
           this.FieldEditContainer.TabIndex = 0;
           // 
           // panel1
           // 
           this.panel1.Controls.Add(this.EditTable);
           this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.panel1.Location = new System.Drawing.Point(0, 0);
           this.panel1.Name = "panel1";
           this.panel1.Size = new System.Drawing.Size(176, 144);
           this.panel1.TabIndex = 27;
           // 
           // EditTable
           // 
           this.EditTable.ColumnCount = 1;
           this.EditTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
           this.EditTable.Controls.Add(this.flowLayoutPanel1, 0, 0);
           this.EditTable.Controls.Add(this.txtEdit, 0, 1);
           this.EditTable.Dock = System.Windows.Forms.DockStyle.Fill;
           this.EditTable.Location = new System.Drawing.Point(0, 0);
           this.EditTable.Name = "EditTable";
           this.EditTable.RowCount = 2;
           this.EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.EditTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
           this.EditTable.Size = new System.Drawing.Size(176, 144);
           this.EditTable.TabIndex = 0;
           // 
           // flowLayoutPanel1
           // 
           this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
           this.flowLayoutPanel1.AutoSize = true;
           this.flowLayoutPanel1.Controls.Add(this.btBold);
           this.flowLayoutPanel1.Controls.Add(this.btItalic);
           this.flowLayoutPanel1.Controls.Add(this.btUnderline);
           this.flowLayoutPanel1.Controls.Add(this.btStrike);
           this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
           this.flowLayoutPanel1.Name = "flowLayoutPanel1";
           this.flowLayoutPanel1.Size = new System.Drawing.Size(120, 29);
           this.flowLayoutPanel1.TabIndex = 27;
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
           this.pnlCard.NoCardMessage = "{empty}";
           this.pnlCard.Padding = new System.Windows.Forms.Padding(5);
           this.pnlCard.Size = new System.Drawing.Size(494, 131);
           this.pnlCard.SuspendPaint = false;
           this.pnlCard.TabIndex = 15;
           // 
           // flowLayoutPanel2
           // 
           this.flowLayoutPanel2.AutoSize = true;
           this.flowLayoutPanel2.Controls.Add(this.btAdd);
           this.flowLayoutPanel2.Controls.Add(this.btRemove);
           this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
           this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 12);
           this.flowLayoutPanel2.Name = "flowLayoutPanel2";
           this.flowLayoutPanel2.Size = new System.Drawing.Size(30, 58);
           this.flowLayoutPanel2.TabIndex = 27;
           // 
           // ManualEntry
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(540, 331);
           this.Controls.Add(this.flowLayoutPanel2);
           this.Controls.Add(this.RootContainer);
           this.Controls.Add(this.btClose);
           this.MinimumSize = new System.Drawing.Size(418, 237);
           this.Name = "ManualEntry";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Edit Cards";
           this.Load += new System.EventHandler(this.ManualEntry_Load);
           this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ManualEntry_KeyUp);
           this.RootContainer.Panel1.ResumeLayout(false);
           this.RootContainer.Panel2.ResumeLayout(false);
           this.RootContainer.ResumeLayout(false);
           this.CardFieldEditContainer.Panel1.ResumeLayout(false);
           this.CardFieldEditContainer.Panel2.ResumeLayout(false);
           this.CardFieldEditContainer.ResumeLayout(false);
           this.FieldEditContainer.Panel1.ResumeLayout(false);
           this.FieldEditContainer.Panel2.ResumeLayout(false);
           this.FieldEditContainer.ResumeLayout(false);
           this.panel1.ResumeLayout(false);
           this.EditTable.ResumeLayout(false);
           this.EditTable.PerformLayout();
           this.flowLayoutPanel1.ResumeLayout(false);
           this.flowLayoutPanel1.PerformLayout();
           this.flowLayoutPanel2.ResumeLayout(false);
           this.flowLayoutPanel2.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

	   }

	   #endregion

	   private DragNDrop.DragAndDropListView lvCards;
	   private System.Windows.Forms.ColumnHeader colCardName;
	   private FlashCardMaster.Utilities.CardPanel pnlCard;
       private DragNDrop.DragAndDropListView lvElements;
	   private System.Windows.Forms.ColumnHeader columnHeader1;
	   private System.Windows.Forms.TextBox txtEdit;
	   private System.Windows.Forms.Button btAdd;
	   private System.Windows.Forms.Button btRemove;
	   private System.Windows.Forms.Button btBold;
	   private System.Windows.Forms.Button btStrike;
	   private System.Windows.Forms.Button btUnderline;
	   private System.Windows.Forms.Button btItalic;
	   private System.Windows.Forms.Button btClose;
	   private System.Windows.Forms.SplitContainer RootContainer;
	   private System.Windows.Forms.SplitContainer CardFieldEditContainer;
	   private System.Windows.Forms.SplitContainer FieldEditContainer;
	   private System.Windows.Forms.Panel panel1;
	   private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	   private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
	   private System.Windows.Forms.TableLayoutPanel EditTable;
    }
}