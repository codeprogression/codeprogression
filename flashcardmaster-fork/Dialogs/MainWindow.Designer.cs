namespace FlashCardMaster.Dialogs
{
    partial class MainWindow
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
           this.menuMain = new System.Windows.Forms.MenuStrip();
           this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.newDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.saveDesignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
           this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
           this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
           this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
           this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
           this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
           this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.editCardsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
           this.designCardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.editCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
           this.reviewCardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
           this.localeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.englishUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.turkishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.हनदToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.മലയളToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.espanolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
           this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.tsMainTool = new System.Windows.Forms.ToolStrip();
           this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
           this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
           this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
           this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
           this.btManualEdit = new System.Windows.Forms.ToolStripButton();
           this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
           this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
           this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
           this.ddSearchOptions = new System.Windows.Forms.ToolStripDropDownButton();
           this.searchContext = new System.Windows.Forms.ContextMenuStrip(this.components);
           this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
           this.tsStatus = new System.Windows.Forms.StatusStrip();
           this.tbStatus = new System.Windows.Forms.ToolStripStatusLabel();
           this.cardListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
           this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
           this.backupTimer = new System.Windows.Forms.Timer(this.components);
           this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
           this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
           this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
           this.lvCards = new DragNDrop.DragAndDropListView();
           this.menuMain.SuspendLayout();
           this.tsMainTool.SuspendLayout();
           this.tsStatus.SuspendLayout();
           this.cardListContext.SuspendLayout();
           this.SuspendLayout();
           // 
           // menuMain
           // 
           this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
           this.menuMain.Location = new System.Drawing.Point(0, 0);
           this.menuMain.Name = "menuMain";
           this.menuMain.Size = new System.Drawing.Size(490, 24);
           this.menuMain.TabIndex = 0;
           // 
           // fileToolStripMenuItem
           // 
           this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDeckToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveDesignToolStripMenuItem,
            this.recentFilesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.importToolStripMenuItem,
            this.toolStripMenuItem8,
            this.printSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
           this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
           this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
           this.fileToolStripMenuItem.Text = "&File";
           // 
           // newDeckToolStripMenuItem
           // 
           this.newDeckToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.document_new;
           this.newDeckToolStripMenuItem.Name = "newDeckToolStripMenuItem";
           this.newDeckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
           this.newDeckToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.newDeckToolStripMenuItem.Text = "&New";
           this.newDeckToolStripMenuItem.Click += new System.EventHandler(this.newDeckToolStripMenuItem_Click);
           // 
           // openToolStripMenuItem
           // 
           this.openToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.document_open;
           this.openToolStripMenuItem.Name = "openToolStripMenuItem";
           this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
           this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.openToolStripMenuItem.Text = "&Open...";
           this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // saveDesignToolStripMenuItem
           // 
           this.saveDesignToolStripMenuItem.Name = "saveDesignToolStripMenuItem";
           this.saveDesignToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.saveDesignToolStripMenuItem.Text = "Open As &Design...";
           this.saveDesignToolStripMenuItem.Click += new System.EventHandler(this.saveDesignToolStripMenuItem_Click);
           // 
           // recentFilesToolStripMenuItem
           // 
           this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
           this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.recentFilesToolStripMenuItem.Text = "&Recent Files";
           // 
           // toolStripMenuItem3
           // 
           this.toolStripMenuItem3.Name = "toolStripMenuItem3";
           this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
           // 
           // saveToolStripMenuItem
           // 
           this.saveToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.document_save;
           this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
           this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
           this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.saveToolStripMenuItem.Text = "&Save";
           this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
           // 
           // saveAsToolStripMenuItem
           // 
           this.saveAsToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.document_save_as;
           this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
           this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                       | System.Windows.Forms.Keys.S)));
           this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.saveAsToolStripMenuItem.Text = "Save &As...";
           this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
           // 
           // toolStripMenuItem4
           // 
           this.toolStripMenuItem4.Name = "toolStripMenuItem4";
           this.toolStripMenuItem4.Size = new System.Drawing.Size(192, 6);
           // 
           // importToolStripMenuItem
           // 
           this.importToolStripMenuItem.Name = "importToolStripMenuItem";
           this.importToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.importToolStripMenuItem.Text = "&Import...";
           this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
           // 
           // toolStripMenuItem8
           // 
           this.toolStripMenuItem8.Name = "toolStripMenuItem8";
           this.toolStripMenuItem8.Size = new System.Drawing.Size(192, 6);
           // 
           // printSetupToolStripMenuItem
           // 
           this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
           this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.printSetupToolStripMenuItem.Text = "Pa&ge Setup...";
           this.printSetupToolStripMenuItem.Click += new System.EventHandler(this.printSetupToolStripMenuItem_Click);
           // 
           // printPreviewToolStripMenuItem
           // 
           this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
           this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.printPreviewToolStripMenuItem.Text = "Print Previe&w";
           this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
           // 
           // printToolStripMenuItem
           // 
           this.printToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.printer;
           this.printToolStripMenuItem.Name = "printToolStripMenuItem";
           this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
           this.printToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.printToolStripMenuItem.Text = "&Print...";
           this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
           // 
           // toolStripMenuItem1
           // 
           this.toolStripMenuItem1.Name = "toolStripMenuItem1";
           this.toolStripMenuItem1.Size = new System.Drawing.Size(192, 6);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
           this.exitToolStripMenuItem.Text = "E&xit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // editToolStripMenuItem
           // 
           this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem5,
            this.selectAllToolStripMenuItem,
            this.toolStripMenuItem7,
            this.checkAllToolStripMenuItem,
            this.toolStripMenuItem6,
            this.preferencesToolStripMenuItem});
           this.editToolStripMenuItem.Name = "editToolStripMenuItem";
           this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
           this.editToolStripMenuItem.Text = "&Edit";
           this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
           // 
           // cutToolStripMenuItem
           // 
           this.cutToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.edit_cut;
           this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
           this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
           this.cutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.cutToolStripMenuItem.Text = "Cu&t";
           this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
           // 
           // copyToolStripMenuItem
           // 
           this.copyToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.edit_copy;
           this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
           this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
           this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.copyToolStripMenuItem.Text = "&Copy";
           this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
           // 
           // pasteToolStripMenuItem
           // 
           this.pasteToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.edit_paste;
           this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
           this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
           this.pasteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.pasteToolStripMenuItem.Text = "&Paste";
           this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
           // 
           // deleteToolStripMenuItem
           // 
           this.deleteToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.edit_delete;
           this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
           this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
           this.deleteToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.deleteToolStripMenuItem.Text = "Dele&te";
           this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
           // 
           // toolStripMenuItem5
           // 
           this.toolStripMenuItem5.Name = "toolStripMenuItem5";
           this.toolStripMenuItem5.Size = new System.Drawing.Size(161, 6);
           // 
           // selectAllToolStripMenuItem
           // 
           this.selectAllToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.edit_select_all;
           this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
           this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
           this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.selectAllToolStripMenuItem.Text = "Select &All";
           this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
           // 
           // toolStripMenuItem7
           // 
           this.toolStripMenuItem7.Name = "toolStripMenuItem7";
           this.toolStripMenuItem7.Size = new System.Drawing.Size(161, 6);
           // 
           // checkAllToolStripMenuItem
           // 
           this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
           this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.checkAllToolStripMenuItem.Text = "Chec&k All";
           this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.checkAllToolStripMenuItem_Click);
           // 
           // toolStripMenuItem6
           // 
           this.toolStripMenuItem6.Name = "toolStripMenuItem6";
           this.toolStripMenuItem6.Size = new System.Drawing.Size(161, 6);
           // 
           // preferencesToolStripMenuItem
           // 
           this.preferencesToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.preferences_system;
           this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
           this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
           this.preferencesToolStripMenuItem.Text = "Pre&ferences";
           this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
           // 
           // toolsToolStripMenuItem
           // 
           this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCardsToolStripMenuItem1,
            this.designCardToolStripMenuItem,
            this.editCardsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.reviewCardsToolStripMenuItem,
            this.testToolStripMenuItem,
            this.toolStripMenuItem9,
            this.localeToolStripMenuItem});
           this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
           this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
           this.toolsToolStripMenuItem.Text = "&Tools";
           // 
           // editCardsToolStripMenuItem1
           // 
           this.editCardsToolStripMenuItem1.Image = global::FlashCardMaster.Properties.Resources.system_file_manager;
           this.editCardsToolStripMenuItem1.Name = "editCardsToolStripMenuItem1";
           this.editCardsToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
           this.editCardsToolStripMenuItem1.Text = "E&dit";
           this.editCardsToolStripMenuItem1.Click += new System.EventHandler(this.btManualEdit_Click);
           // 
           // designCardToolStripMenuItem
           // 
           this.designCardToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.applications_development;
           this.designCardToolStripMenuItem.Name = "designCardToolStripMenuItem";
           this.designCardToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
           this.designCardToolStripMenuItem.Text = "Desi&gn";
           this.designCardToolStripMenuItem.Click += new System.EventHandler(this.designCardToolStripMenuItem_Click);
           // 
           // editCardsToolStripMenuItem
           // 
           this.editCardsToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.utilities_terminal;
           this.editCardsToolStripMenuItem.Name = "editCardsToolStripMenuItem";
           this.editCardsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
           this.editCardsToolStripMenuItem.Text = "&Batch Add";
           this.editCardsToolStripMenuItem.Click += new System.EventHandler(this.editCardsToolStripMenuItem_Click);
           // 
           // toolStripMenuItem2
           // 
           this.toolStripMenuItem2.Name = "toolStripMenuItem2";
           this.toolStripMenuItem2.Size = new System.Drawing.Size(126, 6);
           // 
           // reviewCardsToolStripMenuItem
           // 
           this.reviewCardsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.randomToolStripMenuItem});
           this.reviewCardsToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.x_office_presentation;
           this.reviewCardsToolStripMenuItem.Name = "reviewCardsToolStripMenuItem";
           this.reviewCardsToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
           this.reviewCardsToolStripMenuItem.Text = "Re&view";
           // 
           // normalToolStripMenuItem
           // 
           this.normalToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.media_playback_start;
           this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
           this.normalToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
           this.normalToolStripMenuItem.Text = "Normal";
           this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
           // 
           // randomToolStripMenuItem
           // 
           this.randomToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.mail_send_receive;
           this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
           this.randomToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
           this.randomToolStripMenuItem.Text = "Shuffled";
           this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
           // 
           // testToolStripMenuItem
           // 
           this.testToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.applications_office;
           this.testToolStripMenuItem.Name = "testToolStripMenuItem";
           this.testToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
           this.testToolStripMenuItem.Text = "Take Te&st";
           this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
           // 
           // toolStripMenuItem9
           // 
           this.toolStripMenuItem9.Name = "toolStripMenuItem9";
           this.toolStripMenuItem9.Size = new System.Drawing.Size(126, 6);
           // 
           // localeToolStripMenuItem
           // 
           this.localeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishUSToolStripMenuItem,
            this.turkishToolStripMenuItem,
            this.françaisToolStripMenuItem,
            this.हनदToolStripMenuItem,
            this.മലയളToolStripMenuItem,
            this.espanolToolStripMenuItem});
           this.localeToolStripMenuItem.Image = global::FlashCardMaster.Properties.Resources.preferences_desktop_locale;
           this.localeToolStripMenuItem.Name = "localeToolStripMenuItem";
           this.localeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
           this.localeToolStripMenuItem.Text = "Locale";
           // 
           // englishUSToolStripMenuItem
           // 
           this.englishUSToolStripMenuItem.Name = "englishUSToolStripMenuItem";
           this.englishUSToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.englishUSToolStripMenuItem.Text = "English (Default)";
           this.englishUSToolStripMenuItem.Click += new System.EventHandler(this.englishUSToolStripMenuItem_Click);
           // 
           // turkishToolStripMenuItem
           // 
           this.turkishToolStripMenuItem.Name = "turkishToolStripMenuItem";
           this.turkishToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.turkishToolStripMenuItem.Text = "Türkçe";
           this.turkishToolStripMenuItem.Click += new System.EventHandler(this.turkishToolStripMenuItem_Click);
           // 
           // françaisToolStripMenuItem
           // 
           this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
           this.françaisToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.françaisToolStripMenuItem.Text = "Français";
           this.françaisToolStripMenuItem.Click += new System.EventHandler(this.françaisToolStripMenuItem_Click);
           // 
           // हनदToolStripMenuItem
           // 
           this.हनदToolStripMenuItem.Name = "हनदToolStripMenuItem";
           this.हनदToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.हनदToolStripMenuItem.Text = "हिन्दी";
           this.हनदToolStripMenuItem.Click += new System.EventHandler(this.हनदToolStripMenuItem_Click);
           // 
           // മലയളToolStripMenuItem
           // 
           this.മലയളToolStripMenuItem.Name = "മലയളToolStripMenuItem";
           this.മലയളToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.മലയളToolStripMenuItem.Text = "മലയാളം";
           this.മലയളToolStripMenuItem.Click += new System.EventHandler(this.മലയളToolStripMenuItem_Click);
           // 
           // espanolToolStripMenuItem
           // 
           this.espanolToolStripMenuItem.Name = "espanolToolStripMenuItem";
           this.espanolToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
           this.espanolToolStripMenuItem.Text = "Español";
           this.espanolToolStripMenuItem.Click += new System.EventHandler(this.espanolToolStripMenuItem_Click);
           // 
           // helpToolStripMenuItem
           // 
           this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem2,
            this.aboutToolStripMenuItem});
           this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
           this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
           this.helpToolStripMenuItem.Text = "&Help";
           // 
           // helpToolStripMenuItem2
           // 
           this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
           this.helpToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F1;
           this.helpToolStripMenuItem2.Size = new System.Drawing.Size(118, 22);
           this.helpToolStripMenuItem2.Text = "Hel&p";
           this.helpToolStripMenuItem2.Click += new System.EventHandler(this.helpToolStripMenuItem2_Click);
           // 
           // aboutToolStripMenuItem
           // 
           this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
           this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
           this.aboutToolStripMenuItem.Text = "&About";
           this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
           // 
           // tsMainTool
           // 
           this.tsMainTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.btManualEdit,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.ddSearchOptions,
            this.txtSearch});
           this.tsMainTool.Location = new System.Drawing.Point(0, 24);
           this.tsMainTool.Name = "tsMainTool";
           this.tsMainTool.Size = new System.Drawing.Size(490, 25);
           this.tsMainTool.TabIndex = 1;
           this.tsMainTool.Text = "toolStrip1";
           // 
           // toolStripButton2
           // 
           this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButton2.Image = global::FlashCardMaster.Properties.Resources.document_new;
           this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton2.Name = "toolStripButton2";
           this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
           this.toolStripButton2.Text = "New";
           this.toolStripButton2.Click += new System.EventHandler(this.newDeckToolStripMenuItem_Click);
           // 
           // toolStripButton1
           // 
           this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButton1.Image = global::FlashCardMaster.Properties.Resources.document_open;
           this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton1.Name = "toolStripButton1";
           this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
           this.toolStripButton1.Text = "Open";
           this.toolStripButton1.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
           // 
           // toolStripButton3
           // 
           this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButton3.Image = global::FlashCardMaster.Properties.Resources.document_save;
           this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton3.Name = "toolStripButton3";
           this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
           this.toolStripButton3.Text = "Save";
           this.toolStripButton3.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
           // 
           // toolStripSeparator1
           // 
           this.toolStripSeparator1.Name = "toolStripSeparator1";
           this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
           // 
           // btManualEdit
           // 
           this.btManualEdit.Image = global::FlashCardMaster.Properties.Resources.system_file_manager;
           this.btManualEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.btManualEdit.Name = "btManualEdit";
           this.btManualEdit.Size = new System.Drawing.Size(47, 22);
           this.btManualEdit.Text = "Edit";
           this.btManualEdit.Click += new System.EventHandler(this.btManualEdit_Click);
           // 
           // toolStripButton4
           // 
           this.toolStripButton4.Image = global::FlashCardMaster.Properties.Resources.applications_development;
           this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton4.Name = "toolStripButton4";
           this.toolStripButton4.Size = new System.Drawing.Size(63, 22);
           this.toolStripButton4.Text = "Design";
           this.toolStripButton4.Click += new System.EventHandler(this.designCardToolStripMenuItem_Click);
           // 
           // toolStripButton5
           // 
           this.toolStripButton5.Image = global::FlashCardMaster.Properties.Resources.x_office_presentation;
           this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton5.Name = "toolStripButton5";
           this.toolStripButton5.Size = new System.Drawing.Size(64, 22);
           this.toolStripButton5.Text = "Review";
           this.toolStripButton5.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
           // 
           // toolStripButton6
           // 
           this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.toolStripButton6.Image = global::FlashCardMaster.Properties.Resources.mail_send_receive;
           this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.toolStripButton6.Name = "toolStripButton6";
           this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
           this.toolStripButton6.Text = "Review Cards - Random";
           this.toolStripButton6.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
           // 
           // ddSearchOptions
           // 
           this.ddSearchOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.ddSearchOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           this.ddSearchOptions.DropDown = this.searchContext;
           this.ddSearchOptions.Image = global::FlashCardMaster.Properties.Resources.system_search;
           this.ddSearchOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
           this.ddSearchOptions.Name = "ddSearchOptions";
           this.ddSearchOptions.Size = new System.Drawing.Size(29, 22);
           this.ddSearchOptions.Text = "Search Options";
           this.ddSearchOptions.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
           // 
           // searchContext
           // 
           this.searchContext.Name = "searchContext";
           this.searchContext.OwnerItem = this.ddSearchOptions;
           this.searchContext.ShowImageMargin = false;
           this.searchContext.Size = new System.Drawing.Size(36, 4);
           // 
           // txtSearch
           // 
           this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
           this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this.txtSearch.Name = "txtSearch";
           this.txtSearch.Size = new System.Drawing.Size(150, 25);
           this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
           // 
           // tsStatus
           // 
           this.tsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbStatus});
           this.tsStatus.Location = new System.Drawing.Point(0, 235);
           this.tsStatus.Name = "tsStatus";
           this.tsStatus.Size = new System.Drawing.Size(490, 22);
           this.tsStatus.TabIndex = 2;
           this.tsStatus.Text = "statusStrip1";
           // 
           // tbStatus
           // 
           this.tbStatus.Name = "tbStatus";
           this.tbStatus.Size = new System.Drawing.Size(39, 17);
           this.tbStatus.Text = "Ready";
           // 
           // cardListContext
           // 
           this.cardListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.toolStripMenuItem14,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripMenuItem13,
            this.toolStripMenuItem12,
            this.toolStripMenuItem15});
           this.cardListContext.Name = "cardListContext";
           this.cardListContext.ShowImageMargin = false;
           this.cardListContext.Size = new System.Drawing.Size(98, 126);
           // 
           // editToolStripMenuItem1
           // 
           this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
           this.editToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
           this.editToolStripMenuItem1.Text = "Edit";
           this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
           // 
           // backupTimer
           // 
           this.backupTimer.Interval = 30000;
           this.backupTimer.Tick += new System.EventHandler(this.backupTimer_Tick);
           // 
           // toolStripMenuItem10
           // 
           this.toolStripMenuItem10.Name = "toolStripMenuItem10";
           this.toolStripMenuItem10.Size = new System.Drawing.Size(97, 22);
           this.toolStripMenuItem10.Text = "Cu&t";
           this.toolStripMenuItem10.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
           // 
           // toolStripMenuItem11
           // 
           this.toolStripMenuItem11.Name = "toolStripMenuItem11";
           this.toolStripMenuItem11.Size = new System.Drawing.Size(97, 22);
           this.toolStripMenuItem11.Text = "&Copy";
           this.toolStripMenuItem11.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
           // 
           // toolStripMenuItem13
           // 
           this.toolStripMenuItem13.Name = "toolStripMenuItem13";
           this.toolStripMenuItem13.Size = new System.Drawing.Size(97, 22);
           this.toolStripMenuItem13.Text = "Dele&te";
           this.toolStripMenuItem13.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
           // 
           // toolStripMenuItem14
           // 
           this.toolStripMenuItem14.Name = "toolStripMenuItem14";
           this.toolStripMenuItem14.Size = new System.Drawing.Size(94, 6);
           // 
           // toolStripMenuItem12
           // 
           this.toolStripMenuItem12.Name = "toolStripMenuItem12";
           this.toolStripMenuItem12.Size = new System.Drawing.Size(94, 6);
           // 
           // toolStripMenuItem15
           // 
           this.toolStripMenuItem15.Name = "toolStripMenuItem15";
           this.toolStripMenuItem15.Size = new System.Drawing.Size(97, 22);
           this.toolStripMenuItem15.Text = "Select &All";
           this.toolStripMenuItem15.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
           // 
           // lvCards
           // 
           this.lvCards.Activation = System.Windows.Forms.ItemActivation.TwoClick;
           this.lvCards.AllowColumnReorder = true;
           this.lvCards.AllowDrop = true;
           this.lvCards.AllowReorder = true;
           this.lvCards.CheckBoxes = true;
           this.lvCards.ContextMenuStrip = this.cardListContext;
           this.lvCards.Dock = System.Windows.Forms.DockStyle.Fill;
           this.lvCards.FullRowSelect = true;
           this.lvCards.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
           this.lvCards.LineColor = System.Drawing.SystemColors.WindowText;
           this.lvCards.Location = new System.Drawing.Point(0, 49);
           this.lvCards.Name = "lvCards";
           this.lvCards.ShowItemToolTips = true;
           this.lvCards.Size = new System.Drawing.Size(490, 186);
           this.lvCards.TabIndex = 3;
           this.lvCards.UseCompatibleStateImageBehavior = false;
           this.lvCards.View = System.Windows.Forms.View.Details;
           this.lvCards.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvCards_ItemChecked);
           this.lvCards.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvCards_DragDrop);
           this.lvCards.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCards_ColumnClick);
           this.lvCards.ItemReordered += new System.EventHandler(this.lvCards_ItemReordered);
           this.lvCards.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvCards_DragEnter);
           this.lvCards.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.lvCards_ColumnReordered);
           this.lvCards.DragOver += new System.Windows.Forms.DragEventHandler(this.lvCards_DragOver);
           // 
           // MainWindow
           // 
           this.AllowDrop = true;
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(490, 257);
           this.Controls.Add(this.lvCards);
           this.Controls.Add(this.tsStatus);
           this.Controls.Add(this.tsMainTool);
           this.Controls.Add(this.menuMain);
           this.MainMenuStrip = this.menuMain;
           this.MinimumSize = new System.Drawing.Size(400, 139);
           this.Name = "MainWindow";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "Flash Card";
           this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragDrop);
           this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainWindow_DragEnter);
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
           this.menuMain.ResumeLayout(false);
           this.menuMain.PerformLayout();
           this.tsMainTool.ResumeLayout(false);
           this.tsMainTool.PerformLayout();
           this.tsStatus.ResumeLayout(false);
           this.tsStatus.PerformLayout();
           this.cardListContext.ResumeLayout(false);
           this.ResumeLayout(false);
           this.PerformLayout();

	   }

	   #endregion

	   private System.Windows.Forms.MenuStrip menuMain;
	   private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	   private System.Windows.Forms.ToolStrip tsMainTool;
	   private System.Windows.Forms.ToolStripButton btManualEdit;
	   private System.Windows.Forms.StatusStrip tsStatus;
	   private System.Windows.Forms.ToolStripMenuItem newDeckToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
	   private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem designCardToolStripMenuItem;
       private DragNDrop.DragAndDropListView lvCards;
	   private System.Windows.Forms.ToolStripMenuItem editCardsToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
	   private System.Windows.Forms.ToolStripMenuItem reviewCardsToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
	   private System.Windows.Forms.ToolStripButton toolStripButton1;
	   private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
	   private System.Windows.Forms.ToolStripButton toolStripButton2;
	   private System.Windows.Forms.ToolStripButton toolStripButton3;
	   private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	   private System.Windows.Forms.ToolStripButton toolStripButton4;
	   private System.Windows.Forms.ToolStripButton toolStripButton5;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
	   private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
	   private System.Windows.Forms.ToolStripStatusLabel tbStatus;
	   private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem saveDesignToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
	   private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
	   private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
	   private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem editCardsToolStripMenuItem1;
	   private System.Windows.Forms.ToolStripButton toolStripButton6;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
	   private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
	   private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
	   private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
	   private System.Windows.Forms.Timer backupTimer;
	   private System.Windows.Forms.ToolStripMenuItem localeToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem englishUSToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem turkishToolStripMenuItem;
	   private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
	   private System.Windows.Forms.ToolStripMenuItem हनदToolStripMenuItem;
	   private System.Windows.Forms.ToolStripMenuItem മലയളToolStripMenuItem;
	   private System.Windows.Forms.ContextMenuStrip cardListContext;
	   private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
	   private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
	   private System.Windows.Forms.ToolStripDropDownButton ddSearchOptions;
	   private System.Windows.Forms.ToolStripTextBox txtSearch;
	   private System.Windows.Forms.ContextMenuStrip searchContext;
	   private System.Windows.Forms.ToolStripMenuItem espanolToolStripMenuItem;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
       private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
       private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem15;
    }
}