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
 *  Original FileName :  MainWindow.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FlashCardMaster.i18n;
using FlashCardMaster.User;
using FlashCardMaster.Utilities;
using LibFlashcard.Drivers;
using LibFlashcard.Model;
using LumenWorks.Framework.IO.Csv;
using Nithin.Philips.Utilities.AboutBox;

namespace FlashCardMaster.Dialogs
{
    public partial class MainWindow : Form
    {
	   public void Localize() {
		  this.fileToolStripMenuItem.Text = i18n.Language.MenuFile;
		  this.newDeckToolStripMenuItem.Text = i18n.Language.MenuNew;
		  this.openToolStripMenuItem.Text = i18n.Language.MenuOpen;
		  this.recentFilesToolStripMenuItem.Text = i18n.Language.MenuRecentFiles;
		  this.saveToolStripMenuItem.Text = i18n.Language.MenuSave;
		  this.saveAsToolStripMenuItem.Text = i18n.Language.MenuSaveAs;
		  this.saveDesignToolStripMenuItem.Text = i18n.Language.MenuOpenAsDesign;
		  this.printSetupToolStripMenuItem.Text = i18n.Language.MenuPageSetup;
		  this.printToolStripMenuItem.Text = i18n.Language.MenuPrint;
		  this.exitToolStripMenuItem.Text = i18n.Language.MenuExit;
		  this.editToolStripMenuItem.Text = i18n.Language.MenuEdit;
		  this.cutToolStripMenuItem.Text = i18n.Language.MenuCut;
		  this.copyToolStripMenuItem.Text = i18n.Language.MenuCopy;
		  this.pasteToolStripMenuItem.Text = i18n.Language.MenuPaste;
		  this.deleteToolStripMenuItem.Text = i18n.Language.MenuDelete;
		  this.selectAllToolStripMenuItem.Text = i18n.Language.MenuSelectAll;
          this.toolStripMenuItem10.Text = i18n.Language.MenuCut;
          this.toolStripMenuItem11.Text = i18n.Language.MenuCopy;
          this.toolStripMenuItem13.Text = i18n.Language.MenuDelete;
          this.toolStripMenuItem15.Text = i18n.Language.MenuSelectAll;
		  this.checkAllToolStripMenuItem.Text = i18n.Language.MenuCheckAll;
		  this.preferencesToolStripMenuItem.Text = i18n.Language.MenuPreferences;
		  this.toolsToolStripMenuItem.Text = i18n.Language.MenuTools;
		  this.editCardsToolStripMenuItem1.Text = i18n.Language.MenuEdit;
		  this.designCardToolStripMenuItem.Text = i18n.Language.MenuDesign;
		  this.editCardsToolStripMenuItem.Text = i18n.Language.MenuBatchAdd;
		  this.reviewCardsToolStripMenuItem.Text = i18n.Language.MenuReview;
		  this.normalToolStripMenuItem.Text = i18n.Language.Normal;
		  this.randomToolStripMenuItem.Text = i18n.Language.Shuffled;
		  this.testToolStripMenuItem.Text = i18n.Language.MenuTakeTest;
		  this.helpToolStripMenuItem.Text = i18n.Language.MenuHelp;
		  this.helpToolStripMenuItem2.Text = i18n.Language.MenuHelp;
		  this.aboutToolStripMenuItem.Text = i18n.Language.MenuAbout;
		  this.toolStripButton2.Text = i18n.Language.MenuNew;
		  this.toolStripButton1.Text = i18n.Language.MenuOpen;
		  this.toolStripButton3.Text = i18n.Language.MenuSave;
		  this.btManualEdit.Text = i18n.Language.MenuEdit;
		  this.toolStripButton4.Text = i18n.Language.MenuDesign;
		  this.toolStripButton5.Text = i18n.Language.MenuReview;
		  this.toolStripButton6.Text = i18n.Language.ReviewCardsShuffled;
		  this.tbStatus.Text = i18n.Language.Ready;
		  this.printPreviewToolStripMenuItem.Text = i18n.Language.PrintPreview;
		  this.localeToolStripMenuItem.Text = i18n.Language.Locale;
		  this.importToolStripMenuItem.Text = i18n.Language.Import;
		  this.ddSearchOptions.Text = i18n.Language.SearchOptions;
		  
		  if (clearToolStripItem != null) {
			 // This is a dynamically created object
			 clearToolStripItem.Text = i18n.Language.Clear;
		  }
	   }

	   LibFlashcard.Utilities.FileData currentFileData;

	   public MainWindow() 
		  :this(""){}

	   public MainWindow(string file) {
		  InitializeComponent();
		  Utilities.Utility.SetIcon(this);
		  Localize();
		  Utility.SetFormSize(this, .5f, .55f);
		  this.CenterToScreen();

#if RELEASE
		  // Hide test languages
		  françaisToolStripMenuItem.Visible = false;
		  हनदToolStripMenuItem.Visible = false;
#endif

		  lvCards.ShowGroups = false;

		  UpdateRecentItems();

          if (string.IsNullOrEmpty(file) || !File.Exists(file)) {
              string backupName = CheckBackup();
              if (!string.IsNullOrEmpty(backupName)
                 && (MessageBox.Show(string.Format(i18n.Language.OpenBackupQuestion, "Untitled"), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
                  currentFileData = new LibFlashcard.Utilities.FileData(backupName);
                  currentFileData.FileName = "";
                  this.currentFileData.DataModified += new EventHandler(currentFileData_DataModified);
                  UpdateFileUI();
                  UpdateListAll();

                  ResetBackup();
              } else {
                  CreateNew();
              }
          } else {
              Open(file);
          }

		  backupTimer.Interval = Settings.AppInstance.BackupInterval;
		  if (Settings.AppInstance.SaveBackups) {
			 backupTimer.Start();
		  }
	   }

	   #region RecentItemsMenu

	   ToolStripMenuItem clearToolStripItem;

	   private void UpdateRecentItems() {
		  recentFilesToolStripMenuItem.DropDownItems.Clear();
		  for (int i = Settings.AppInstance.History.Count - 1; i >= 0; i--) {
			 AddRecentItem(Settings.AppInstance.History[i]);
		  }
		  if (Settings.AppInstance.History.Count > 0) {
			 recentFilesToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());

			 if (this.clearToolStripItem != null && !this.clearToolStripItem.IsDisposed) {
				this.clearToolStripItem.Dispose();
			 }

			 this.clearToolStripItem = new ToolStripMenuItem(i18n.Language.Clear, null, delegate(object sender, EventArgs e) {
				Settings.AppInstance.History.Clear();
				UpdateRecentItems();
			 });
			 recentFilesToolStripMenuItem.DropDownItems.Add(clearToolStripItem);
		  }
	   }

	   private void AddRecentItem(string str) {
		  ToolStripItem item = new ToolStripMenuItem(Utility.ShortenPath(str, 70).Replace("&", "&&"));
		  item.DisplayStyle = ToolStripItemDisplayStyle.Text;
		  item.Tag = str;
		  item.Click += Handle_RecentItem_Click;
		  recentFilesToolStripMenuItem.DropDownItems.Add(item);
	   }


	   private void Handle_RecentItem_Click(object sender, EventArgs e) {
		  string path = (sender as ToolStripItem).Tag as string;
		  if (!File.Exists(path)) {
			 MessageBox.Show(i18n.Language.FileNotExistMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			 // remove item
			 Settings.AppInstance.History.Remove(path);
			 UpdateRecentItems();
			 return;
		  }

		  if (CheckCurrent()) {
			 Open(path);
		  }
	   }

	   #endregion

	   #region File Operations

	   /// <summary>
	   /// Creates a new file. If the current file is dirty, provides the user an opportunity to save.
	   /// </summary>
	   private void CreateNew() {
		  if (CheckCurrent()) {
			 this.currentFileData = null;
			 CardDeck defaultDeck = new CardDeck();
			 defaultDeck.AddStyle(new CardElementStyle(0, i18n.Language.Key, SystemColors.ControlText, Color.Transparent, CardElementPositions.Center, CardElementSides.Front, CardElementType.Key));
			 defaultDeck.AddStyle(new CardElementStyle(1, i18n.Language.Answer, SystemColors.ControlText, Color.Transparent, CardElementPositions.Center, CardElementSides.Back, CardElementType.Answer));
			 this.currentFileData = new LibFlashcard.Utilities.FileData(defaultDeck);
			 this.currentFileData.DataModified += new EventHandler(currentFileData_DataModified);
			 UpdateFileUI();
			 UpdateListAll();
		  }
	   }

	   /// <summary>
	   /// Shows an OpenFileDialog and allow user to open a file. If the current file is dirty, provides the user an opportunity to save.
	   /// </summary>
	   /// <returns>If true, a file was opened otherwise false.</returns>
	   private bool Open() {
		  if (CheckCurrent()) {
			 using (OpenFileDialog dlgOpen = new OpenFileDialog()) {
				dlgOpen.Title = i18n.Language.Open;
				int index;
				dlgOpen.Filter = AbstractDriver.GetReadersFilter(out index);
				dlgOpen.FilterIndex = index+1;
				if (dlgOpen.ShowDialog(this) == DialogResult.OK) {
				    Open(dlgOpen.FileName);
				    return true;
				}
			 }
		  }
		  return false;
	   }

	   /// <summary>
	   /// Opens a specified file.
	   /// </summary>
	   /// <param name="file">The file to open</param>
	   private void Open(string file) {
		  try {
			 ResetBackup(); // Delete the current file's backup, user had his chance.

			 string backupName = CheckBackup(file);
			 bool usingBackup = false;
			 if (!string.IsNullOrEmpty(backupName) 
				&& (MessageBox.Show(string.Format(i18n.Language.OpenBackupQuestion, Path.GetFileName(file)), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)) {
				    currentFileData = new LibFlashcard.Utilities.FileData(backupName);
				    currentFileData.FileName = file;
				    usingBackup = true;
				    ResetBackup();
			 } else {
				currentFileData = new LibFlashcard.Utilities.FileData(file);
			 }

			 if (!currentFileData.CanFullSerialize) {
				MessageBox.Show(i18n.Language.MissingStyleInfoMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			 }

			 UpdateListAll();
			 currentFileData.DataModified += new EventHandler(currentFileData_DataModified);
			 currentFileData.Modified = usingBackup; // if using backup, set dirty flag
			 Settings.AppInstance.History.Add(file);
			 UpdateRecentItems();
		  } catch (Exception ex) {
			 HandleFileIOException(file, ex);
		  }
	   }

	   /// <summary>
	   /// Starts a new design from an existing file.
	   /// </summary>
	   private void OpenAsDesign() {
		  if (Open()) {
			 this.currentFileData.Deck.Cards.Clear();
			 this.currentFileData.FileName = "";
			 this.currentFileData.Modified = false;
			 UpdateListAll();
		  }
	   }

	   /// <summary>
	   /// Converts IO exception messages to more meaningful ones.
	   /// </summary>
	   private void HandleFileIOException(string file, Exception ex) {
		  string reason = i18n.Language.CorruptFileMessage;

		  if (ex is FileNotFoundException) {
			 reason = i18n.Language.FileNotExistMessage;
		  } else if (ex is SerializationException) {
			 reason = i18n.Language.DeSerializationFailedMessage;
		  } else if (ex is MissingFieldException) {
			 // TODO: Write help explaing how to merge files with mismatched fields.
			 reason = i18n.Language.FieldMismatchMessage;
		  } else if (ex is MalformedCsvException) {
			 reason = i18n.Language.CorruptCsvFileMessage;
		  } else if (ex is NotSupportedException) {
			 reason = string.Format(i18n.Language.FileNotSupportedMessageHint, ex.Message);
		  } else {
			 reason += string.Format(i18n.Language.GenericOpenErrorMessage, ex.GetType(), ex.Message);
		  }

		  //TODO: Check for version mismatch
		  MessageBox.Show(string.Format(i18n.Language.fUnableToOpenMessage, file, reason), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

	   }

	   public void Merge() {
		  using (OpenFileDialog dlgOpen = new OpenFileDialog()) {
			 dlgOpen.Title = i18n.Language.Import;
			 int index;
			 dlgOpen.Filter = AbstractDriver.GetReadersFilter(out index);
			 dlgOpen.FilterIndex = index;
			 dlgOpen.Multiselect = true;
			 if (dlgOpen.ShowDialog(this) == DialogResult.OK) {
				for (int i = dlgOpen.FileNames.Length - 1; i >= 0; i--) {
				    Merge(dlgOpen.FileNames[i]);
				}
				UpdateListAll();
				this.currentFileData.Modified = true;
			 }
		  }
	   }

	   public void Merge(string file) {
		  try {
			 this.currentFileData.Merge(file);
		  } catch (Exception ex) {
			 HandleFileIOException(file, ex);
		  }
	   }

	   /// <summary>
	   /// Check if the current file is dirty and gives the user and opportunity to save.
	   /// </summary>
	   /// <returns>True, if the file was saved or user opted to discard changes, otherwise false.</returns>
	   private bool CheckCurrent() {
		  if ((currentFileData != null) && (currentFileData.Modified)) {
			 string name = i18n.Language.Untitled;
			 if (currentFileData.FileName != "") { name = Path.GetFileName(currentFileData.FileName); }
			 DialogResult result = MessageBox.Show(string.Format(i18n.Language.fSaveChangesQuestion, name), Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
			 if (result == DialogResult.Yes) {
				Save();
			 } else if (result == DialogResult.Cancel) {
				return false;
			 }
		  }
		  ResetBackup();  // User have saved the file. Reset backup.
		  return true;
	   }

	   private void SaveAs() {
		  SaveAs(true);
	   }

	   /// <summary>
	   /// Saves a copy of current file. A dialog will be shown and the currentFileData.FileName will be switched (with some exceptions).
	   /// </summary>
	   /// <param name="saveAs">If true, the title of the dialog will be localized 'Save As', otherwise 'Save'.</param>
	   /// <returns>If true, save was successful.</returns>
	   private bool SaveAs(bool saveAs) {
		  using (SaveFileDialog dlgSave = new SaveFileDialog()) {
			 if (saveAs) {
				dlgSave.Title = i18n.Language.SaveAs;
			 } else {
				dlgSave.Title = i18n.Language.Save;
			 }
			 dlgSave.Filter = AbstractDriver.GetWritersFilter();
             dlgSave.FileName = Path.GetFileNameWithoutExtension(currentFileData.FileName);
ShowDialog:
			 if (dlgSave.ShowDialog(this) == DialogResult.OK) {
				string ext = Path.GetExtension(dlgSave.FileName);

                if (AbstractDriver.NeedKeyAnswer(ext) && (!currentFileData.Deck.HasKey() || !currentFileData.Deck.HasAnswer())) {
                    MessageBox.Show(string.Format(i18n.Language.NeedKeyAnswer, ext), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dlgSave.FileName = Path.GetFileNameWithoutExtension(currentFileData.FileName); // Without this line XP won't change the extension.
                    goto ShowDialog;
				}else if (!AbstractDriver.CanWrite(ext)) {
				    MessageBox.Show(string.Format(i18n.Language.UnsupportedFormat, Path.GetFileName(dlgSave.FileName)), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dlgSave.FileName = Path.GetFileNameWithoutExtension(currentFileData.FileName); // Without this line XP won't change the extension.
				    goto ShowDialog;
				}else if (!AbstractDriver.CanRead(ext)) {
				    // Cannot read this format, so save a copy.
				    MessageBox.Show(string.Format(i18n.Language.WriteOnlyFormatWarning, Path.GetFileName(dlgSave.FileName)), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				    currentFileData.Save(dlgSave.FileName);
				} else {
				    if (AbstractDriver.IsPartialSupport(ext)) {
					   // Saving in this format may cause data loss. warn user.
					   MessageBox.Show(string.Format(i18n.Language.fDataLossWarning, ext), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				    }
				    // Switch to new file
				    currentFileData.FileName = dlgSave.FileName;
				    currentFileData.Save();
				    Settings.AppInstance.History.Add(dlgSave.FileName);
				}

				UpdateFileUI();
				UpdateRecentItems();
				
				return true;
			 } else {
				return false;
			 }
		  }
	   }

	   /// <summary>
	   /// Saves the current file. A SaveFileDialog will be shown if necessary.
	   /// </summary>
	   /// <returns></returns>
	   private bool Save() {
		  if (currentFileData.FileName == "") {
			 return SaveAs(false);
		  } else {
			 string ext = Path.GetExtension(currentFileData.FileName);
			 if (AbstractDriver.CanRead(ext) && AbstractDriver.IsPartialSupport(ext)) {
				tbStatus.Text = string.Format(i18n.Language.fDataLossWarning, ext);
			 }
			 currentFileData.Save();
			 return true;
		  }
	   }

	   [Obsolete]
	   private void SaveDesign() {
		  using (SaveFileDialog dlgSave = new SaveFileDialog()) {
			 dlgSave.Title = i18n.Language.SaveAs;
			 dlgSave.FileName = i18n.Language.NewDesign;
			 dlgSave.Filter = AbstractDriver.GetWritersFilter();
			 if (dlgSave.ShowDialog(this) == DialogResult.OK) {
				CardDeck dummy = currentFileData.Deck.GetTemplate();
				LibFlashcard.Utilities.FileData data = new LibFlashcard.Utilities.FileData(dummy);
				data.Save(dlgSave.FileName);
			 }
		  }
	   }

	   #endregion

	   #region AutoBackup

	   private void backupTimer_Tick(object sender, EventArgs e) {
		  SaveBackup();
	   }

	   private void SaveBackup() {
		  try {
			 if (currentFileData != null) {
				Console.WriteLine("{0} Saving Backup", DateTime.Now.ToLongTimeString());
				currentFileData.Save(Utility.GetBackupName(currentFileData.FileName));
			 }
		  } catch (Exception) { }
	   }

	   private void ResetBackup() {
		  if (currentFileData != null) {
			 string fileName = Utility.GetBackupName(currentFileData.FileName);
			 if (File.Exists(fileName)) {
				File.Delete(fileName);
			 }
		  }
	   }

        /// <summary>
        /// Checks if a backup for the Untitled (unsaved) file exists.
        /// </summary>
        /// <returns></returns>
       private string CheckBackup() {
           string backupName = Utility.GetBackupName("");
           if (File.Exists(backupName)) {
               return backupName;
           }
           return string.Empty;
       }

	   private string CheckBackup(string fileName) {
		  string backupName = Utility.GetBackupName(fileName);
		  if (File.Exists(backupName)) {
			 if (File.GetLastWriteTimeUtc(backupName) > File.GetLastWriteTimeUtc(fileName)) {
				return backupName;
			 }
		  }
		  return string.Empty;
	   }

	   #endregion

	   #region FileData Class & Related

	   private void UpdateFileUI() {
		  if (currentFileData.FileName == "") {
			 this.Text = string.Format(i18n.Language.fMainWindowTitle, Application.ProductName, i18n.Language.Untitled);
		  } else {
			 this.Text = string.Format(i18n.Language.fMainWindowTitle, Application.ProductName, Path.GetFileName(currentFileData.FileName));
		  }
		  if (currentFileData.Modified) { this.Text += "*"; }
	   }

	   void currentFileData_DataModified(object sender, EventArgs e) {
		  UpdateFileUI();
	   }

	   #endregion

	   #region List Update/Refresh

       // Updates data shown in the ListViewItem from the attached Card.
	   private void RefreshList() {
		  lvCards.BeginUpdate();
		  for (int i = 0; i < lvCards.Items.Count; i++) {
			 CardToListViewItem(lvCards.Items[i], lvCards.Items[i].Tag as Card);
		  }
		  lvCards.EndUpdate();
	   }

	   // Creates a ListViewItem from a Card object.
       private ListViewItem CardToListViewItem(Card card) {
		  ListViewItem item = new ListViewItem();
		  CardToListViewItem(item, card);
		  return item;
	   }

       // Sets a ListViewItem from a Card object.
	   private void CardToListViewItem(ListViewItem item, Card card) {
		  string[] fields = new string[card.Elements.Count];
		  for (int i = 0; i < card.Elements.Count; i++) {
			 fields[i] = LibFlashcard.WikiText.WikiMarkupParser.RemoveMarkup(card.Elements[i].Text);
			 if (item.SubItems.Count > i) {
				item.SubItems[i].Text = fields[i];
			 } else {
				item.SubItems.Add(fields[i]);
			 }
		  }

		  item.Checked = card.Enabled;
		  if (item.Tag == null) { item.Tag = card; }
	   }

	   /// <summary>
	   ///  Updates list items and column headers
	   /// </summary>
	   private void UpdateListAll() {
		  if (lvCards.HeaderStyle != ColumnHeaderStyle.Clickable) {
			 lvCards.HeaderStyle = ColumnHeaderStyle.Clickable;
		  }

		  lvCards.BeginUpdate();
		  lvCards.Columns.Clear();

		  UpdateSearchOptions();

		  foreach (CardElementStyle style in currentFileData.Deck.Styles) {
			 string name = style.Name;
#if DEBUG
			 name += "=" + style.Index.ToString();
#endif
             ColumnHeader header = new ColumnHeader();
             header.Text = LibFlashcard.WikiText.WikiMarkupParser.RemoveMarkup(name);
             header.Tag = style;
			 lvCards.Columns.Add(header);
		  }


		  UpdateListItems();

		  // Sets the header size
		  lvCards.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		  for (int i = 0; i < lvCards.Columns.Count; i++) {
			 int prefWidth = TextRenderer.MeasureText(lvCards.Columns[i].Text, lvCards.Font).Width + 20;
			 if (lvCards.Columns[i].Width < prefWidth) {
				lvCards.Columns[i].Width = prefWidth;
			 }
		  }
		  lvCards.EndUpdate();
	   }
       
       // Updates list items, but not column headers
	   private void UpdateListItems() {
		  currentFileData.SuppressEvents = true;
		  lvCards.Items.Clear();
		  foreach (Card card in currentFileData.Deck.Cards) {
			 lvCards.Items.Add(CardToListViewItem(card));
		  }
		  currentFileData.SuppressEvents = false;
	   }

	   #endregion

	   private void newDeckToolStripMenuItem_Click(object sender, EventArgs e) {
		  CreateNew();
	   }

	   private void openToolStripMenuItem_Click(object sender, EventArgs e) {
		  Open();
	   }

	   private void designCardToolStripMenuItem_Click(object sender, EventArgs e) {
		  DesignCard();
	   }

	   private void DesignCard() {
		  using (CardDesigner des = new CardDesigner(currentFileData.Deck)) {
			 des.Font = this.Font;
			 des.ShowDialog();
			 UpdateListAll();
			 currentFileData.Modified = true;
#if RELEASE
			 if (this.currentFileData.FileName == string.Empty) {
				if (MessageBox.Show(i18n.Language.SaveNowQuestion, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
				    Save();
				}
			 }
#endif
		  }
	   }

	   private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
		  Save();
	   }

	   private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
		  Application.Exit();
	   }

	   private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
		  SaveAs();
	   }

	   private void saveDesignToolStripMenuItem_Click(object sender, EventArgs e) {
		  OpenAsDesign();
	   }

	   private void normalToolStripMenuItem_Click(object sender, EventArgs e) {
		  ReviewCards(LibFlashcard.Utilities.EnumerationOrder.Normal);
	   }

	   private void randomToolStripMenuItem_Click(object sender, EventArgs e) {
		  ReviewCards(LibFlashcard.Utilities.EnumerationOrder.Random);
	   }

	   Reviewer rev;
	   private void ReviewCards(LibFlashcard.Utilities.EnumerationOrder order) {
		  rev = new Reviewer(new LibFlashcard.Utilities.BiDirectionalEnumerator<Card>(this.currentFileData.Deck.Cards.FindAll(
			    delegate(Card card) { return card.Enabled; })
			    , order));
		  rev.Font = this.Font;
		  rev.DataModified += new EventHandler(rev_DataModified);
		  rev.FormClosing += new FormClosingEventHandler(rev_FormClosing);
		  rev.Show();
		  this.Hide();
	   }

	   void rev_FormClosing(object sender, FormClosingEventArgs e) {
		  this.rev = null;
		  this.Show();
	   }

	   void rev_DataModified(object sender, EventArgs e) {
		  RefreshList();
		  currentFileData.Modified = true;
	   }

	   BatchEntry batchInput;
	   private void BatchInput() {
		  if (batchInput == null) {
			 batchInput = new BatchEntry(currentFileData.Deck);
			 batchInput.Font = this.Font;
			 batchInput.FormClosing += new FormClosingEventHandler(batchInput_FormClosing);
			 batchInput.DataParsed += new EventHandler(batchInput_DataParsed);
			 batchInput.Show(this);
		  } else {
			 batchInput.BringToFront();
		  }
	   }

	   void batchInput_DataParsed(object sender, EventArgs e) {
		  currentFileData.Deck.Cards.AddRange(batchInput.Cards);
		  UpdateListAll();
		  currentFileData.Modified = true;
	   }

	   void batchInput_FormClosing(object sender, FormClosingEventArgs e) {
		  batchInput = null;
	   }

	   private void EditDeck() {
		  EditDeck(null);
	   }

	   private void EditDeck(Card selected) {
		  using (ManualEntry me = new ManualEntry(this.currentFileData.Deck, selected)) {
			 me.Font = this.Font;
			 me.ShowDialog(this);
			 this.currentFileData.Modified = true;
			 UpdateListAll();
		  }
	   }

	   private void editCardsToolStripMenuItem_Click(object sender, EventArgs e) {
		  BatchInput();
	   }

	   private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
		  e.Cancel = !CheckCurrent();
		  if (this.WindowState == FormWindowState.Normal) {
			 Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
		  }
		  Settings.Save();
	   }

	   private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
		  using (AboutBox about = new AboutBox()) {
			 about.Font = this.Font;
			 List<InformationPage> ipages = new List<InformationPage>(3);
			 ipages.Add(new InformationPage(i18n.Language.Version, Program.AboutVersion));
			 ipages.Add(new InformationPage(i18n.Language.License, Language.AboutLicense));
			 ipages.Add(new InformationPage(i18n.Language.Contributors, Program.AboutContributors));
			 ipages.Add(new InformationPage(i18n.Language.Translators, Language.AboutTranslators));
			 about.PageCollection = ipages;

			 about.ProductName = Application.ProductName;
			 about.ProductVersion = Application.ProductVersion;
			 about.ProductCopyright = "(C) 2003-2008 Nithin Philips";
			 about.ProductUrl = "http://flashcardmaster.sourceforge.net/";

			 about.ProductLargeIcon = Properties.Resources.App_128;
			 about.Icon = Properties.Resources.App;
			 about.Size = new Size(420, 297);
			 about.ShowDialog(this);
		  }
	   }

	   private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
		  using (Preferences prefs = new Preferences()) {
			 prefs.Font = this.Font;
			 prefs.ShowDialog(this);
             if (backupTimer.Interval != Settings.AppInstance.BackupInterval) {
                 backupTimer.Stop();
                 backupTimer.Interval = Settings.AppInstance.BackupInterval;
                 backupTimer.Start();
             }
		  }
	   }

	   private void lvCards_ItemChecked(object sender, ItemCheckedEventArgs e) {
		  Card card = e.Item.Tag as Card;
//		  if (e.Item.Checked) { Card.LearnStatus = CardLearningStaus.Learned; } else { Card.LearnStatus = CardLearningStaus.NotLearned; }
		  card.Enabled = e.Item.Checked;
		  currentFileData.Modified = true;
//		  CardToListViewItem(e.Item, Card);
	   }

	   private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
		  bool allChecked = true;
		  for (int i = 0; i < lvCards.Items.Count; i++) {
			 allChecked &= lvCards.Items[i].Checked;
			 if (!allChecked) {
				break;
			 }
		  }
		  if (allChecked) {
			 checkAllToolStripMenuItem.Text = i18n.Language.MenuUnCheckAll;
		  } else {
			 checkAllToolStripMenuItem.Text = i18n.Language.MenuCheckAll;
		  }
		  checkAllToolStripMenuItem.Tag = allChecked;
	   }

	   private void checkAllToolStripMenuItem_Click(object sender, EventArgs e) {
		  bool check = (bool)((ToolStripItem)sender).Tag;
		  check = !check;

		  for (int i = 0; i < lvCards.Items.Count; i++) {
			 lvCards.Items[i].Checked = check;
		  }
	   }

	   private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
		  for (int i = 0; i < lvCards.Items.Count; i++) {
			 lvCards.Items[i].Selected = true;
		  }
	   }

	   private void btManualEdit_Click(object sender, EventArgs e) {
		  EditDeck();
	   }

	   private void printToolStripMenuItem_Click(object sender, EventArgs e) {
		  if (currentFileData.Deck.Cards.Count > 0) {
			 try {
				CardDeckPrinter printer = new CardDeckPrinter(this.currentFileData.Deck, SelectedIndicesToInt(lvCards.SelectedIndices), Path.GetFileNameWithoutExtension(this.currentFileData.FileName), this);
				printer.Print();
			 } catch(Exception ex) {
				MessageBox.Show(string.Format("Printing Failed.\r\nDetails: {0}", ex.Message), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			 }
		  } else {
			 MessageBox.Show(i18n.Language.NoCardToPrintMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		  }
	   }

	   private void printSetupToolStripMenuItem_Click(object sender, EventArgs e) {
		  CardDeckPrinter.ShowSetup(this);
	   }

	   private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e) {
		  if (currentFileData.Deck.Cards.Count > 0) {
			 CardDeckPrinter printer = new CardDeckPrinter(this.currentFileData.Deck, SelectedIndicesToInt(lvCards.SelectedIndices), Path.GetFileNameWithoutExtension(this.currentFileData.FileName), this);
			 if (!printer.CanDuplex) {
				if (MessageBox.Show(i18n.Language.PrinterCannotDuplex, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
				    // Print AABB
				    printer.ManualDuplex = true;
				}
				// Print ABAB
			 }
			 printer.ShowPreview();
		  } else {
			 MessageBox.Show(i18n.Language.NoCardToPrintMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		  }
	   }

	   private int[] SelectedIndicesToInt(ListView.SelectedIndexCollection col) {
		  int[] result = new int[col.Count];
		  for (int i = 0; i < col.Count; i++) {
			 result[i] = col[i];
		  }
		  return result;
	   }

	   private void testToolStripMenuItem_Click(object sender, EventArgs e) {
		  if (this.currentFileData.Deck.Cards.Count < 4) {
			 MessageBox.Show(i18n.Language.QuizMinCardMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			 return;
		  }else if(!Quiz.IsDeckValid(this.currentFileData.Deck)){
			 MessageBox.Show(i18n.Language.QuizDeckInvalid, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			 return;
		  } else {
			 using (MultipleChoiceTest mc = new MultipleChoiceTest(new MultipleChoiceQuiz(this.currentFileData.Deck.Cards))) {
				mc.Font = this.Font;
				this.Visible = false;
				mc.ShowDialog(this);
				this.Visible = true;
			 }
		  }
	   }

	   private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
		  for (int i = lvCards.SelectedItems.Count - 1; i >= 0; i--) {
			 this.currentFileData.Deck.Cards.Remove(lvCards.SelectedItems[i].Tag as Card);
			 this.lvCards.Items.Remove(lvCards.SelectedItems[i]);
		  }
		  this.currentFileData.Modified = true;
	   }

	   private void importToolStripMenuItem_Click(object sender, EventArgs e) {
		  Merge();
	   }

	   System.Windows.Forms.DataFormats.Format clipboardDataType = DataFormats.GetFormat(typeof(Card[]).FullName);

	   private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
		  Copy();
	   }

	   private void Copy() {
		  // Set string data
		  Card[] cards = new Card[lvCards.SelectedItems.Count];
		  StringBuilder sb = new StringBuilder();
		  for (int i = 0; i < lvCards.SelectedItems.Count; i++) {
			 cards[i] = lvCards.SelectedItems[i].Tag as Card;
			 cards[i].ToCSVString(sb, Settings.AppInstance.CsvSeperator, Settings.AppInstance.PreserveNewLinesInCsv);
			 sb.Append(Environment.NewLine);
		  }

		  // Set object data
		  IDataObject dataObj = new DataObject();
		  string s = sb.ToString();
		  dataObj.SetData(DataFormats.Text, false, s);
		  dataObj.SetData(DataFormats.StringFormat, false, s);
		  dataObj.SetData(DataFormats.CommaSeparatedValue, false, s);
		  dataObj.SetData(clipboardDataType.Name, false, cards);
		  Clipboard.SetDataObject(dataObj, true);
	   }

	   private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
		  if (Clipboard.ContainsData(clipboardDataType.Name)) {
			 Card[] data;
			 IDataObject dataObj = Clipboard.GetDataObject();

			 if (dataObj.GetDataPresent(clipboardDataType.Name)) {
				data = dataObj.GetData(clipboardDataType.Name) as Card[];
                if (data.Length > 0) {
                    if (data[0].Elements.Count > this.currentFileData.Deck.Styles.Count) {
                        // Field counts do not match, fail.
                        int diff = data[0].Elements.Count - this.currentFileData.Deck.Styles.Count;
                        MessageBox.Show(string.Format(diff == 1 ? i18n.Language.PasteFieldMismatchSingular : i18n.Language.PasteFieldMismatchPlural, diff), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } else {
                        this.currentFileData.Deck.AddCards(data, true);
                        UpdateListAll();
                    }
                }
			 }
		  }
	   }

	   private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
		  Copy();
		  for (int i = lvCards.SelectedItems.Count - 1; i >= 0; i--) {
			 this.currentFileData.Deck.Cards.Remove(lvCards.SelectedItems[i].Tag as Card);
			 lvCards.SelectedItems[i].Remove();
		  }
	   }

	   private void Localize(string culture) {
		  try {
			 System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
			 System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
			 Localize();
			 UpdateFileUI();
		  } catch (System.ArgumentException argEx) {
			 MessageBox.Show(argEx.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		  }
	   }

	   SortOrder currentSortOrder = SortOrder.None;
       int previouslySortedColumn = -1;
	   private void lvCards_ColumnClick(object sender, ColumnClickEventArgs e) {
          lvCards.BeginUpdate();
          if (currentSortOrder == SortOrder.None) currentSortOrder = SortOrder.Descending;
          else if (currentSortOrder == SortOrder.Descending) currentSortOrder = SortOrder.Ascending;
          else if (currentSortOrder == SortOrder.Ascending) currentSortOrder = SortOrder.None;

          if (currentSortOrder == SortOrder.None) {
              currentFileData.Deck.SortCardsByIndex((LibFlashcard.Utilities.SortOrder)SortOrder.Ascending);
          } else {
              currentFileData.Deck.SortCards(e.Column, (LibFlashcard.Utilities.SortOrder)currentSortOrder);
          }
           
          lvCards.Sorting = currentSortOrder;
		  UpdateListItems();
          SetSortIcons(previouslySortedColumn, e.Column);
          previouslySortedColumn = e.Column;
		  currentFileData.Modified = true; // sorted
          lvCards.EndUpdate();
       }

       #region SortIcon

       [StructLayout(LayoutKind.Sequential)]
       public struct HDITEM
       {
           public Int32 mask;
           public Int32 cxy;
           [MarshalAs(UnmanagedType.LPTStr)]
           public String pszText;
           public IntPtr hbm;
           public Int32 cchTextMax;
           public Int32 fmt;
           public Int32 lParam;
           public Int32 iImage;
           public Int32 iOrder;
       };

       // Parameters for ListView-Headers
       public const Int32    HDI_FORMAT = 0x0004;
       public const Int32      HDF_LEFT = 0x0000;
       public const Int32    HDF_STRING = 0x4000;
       public const Int32    HDF_SORTUP = 0x0400;
       public const Int32  HDF_SORTDOWN = 0x0200;
       public const Int32 LVM_GETHEADER = 0x1000 + 31;  // LVM_FIRST + 31
       public const Int32   HDM_GETITEM = 0x1200 + 11;  // HDM_FIRST + 11
       public const Int32   HDM_SETITEM = 0x1200 + 12;  // HDM_FIRST + 12

       [DllImport("user32.dll")]
       private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

       [DllImport("user32.dll", EntryPoint = "SendMessage")]
       private static extern IntPtr SendMessageITEM(IntPtr Handle, Int32 msg, IntPtr wParam, ref HDITEM lParam);


       private void SetSortIcons(int previouslySortedColumn, int newSortColumn) {
           IntPtr hHeader = SendMessage(lvCards.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
           IntPtr newColumn = new IntPtr(newSortColumn);
           IntPtr prevColumn = new IntPtr(previouslySortedColumn);
           HDITEM hdItem;
           IntPtr rtn;

           // Only update the previous item if it existed and if it was a different one.
           if (previouslySortedColumn != -1 && previouslySortedColumn != newSortColumn) {
               // Clear icon from the previous column.
               hdItem = new HDITEM();
               hdItem.mask = HDI_FORMAT;
               rtn = SendMessageITEM(hHeader, HDM_GETITEM, prevColumn, ref hdItem);
               hdItem.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP;
               rtn = SendMessageITEM(hHeader, HDM_SETITEM, prevColumn, ref hdItem);
           }

           // Set icon on the new column.
           hdItem = new HDITEM();
           hdItem.mask = HDI_FORMAT;
           rtn = SendMessageITEM(hHeader, HDM_GETITEM, newColumn, ref hdItem);
           if (lvCards.Sorting == SortOrder.Ascending) {
               hdItem.fmt &= ~HDF_SORTDOWN;
               hdItem.fmt |= HDF_SORTUP;
           } else if (lvCards.Sorting == SortOrder.Descending) {
               hdItem.fmt &= ~HDF_SORTUP;
               hdItem.fmt |= HDF_SORTDOWN;
           } else {
               hdItem.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP;
           }
           rtn = SendMessageITEM(hHeader, HDM_SETITEM, newColumn, ref hdItem);
       }

       #endregion

       private void englishUSToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("en-US");	  
	   }

	   private void turkishToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("tr-TR");
	   }

	   private void françaisToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("fr-FR");
	   }

	   private void हनदToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("hi-IN");
	   }

	   private void espanolToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("es-ES");
	   }

	   private void helpToolStripMenuItem2_Click(object sender, EventArgs e) {
		  Help.ShowHelp(this, "Help.chm");
	   }

	   private void മലയളToolStripMenuItem_Click(object sender, EventArgs e) {
		  Localize("ml-IN");
	   }

	   // edit - contextmenu
	   private void editToolStripMenuItem1_Click(object sender, EventArgs e) {
           if (lvCards.SelectedItems.Count > 0) {
			 Card selected = lvCards.SelectedItems[0].Tag as Card;
			 EditDeck(selected);
		  }
	   }

	   #region Search

	   //TODO: Maybe provide context-sensitive AutoFill list.

	   System.Threading.Timer searchTimer;

	   private void txtSearch_TextChanged(object sender, EventArgs e) {
		  if (searchTimer != null) {
			 searchTimer.Dispose();
			 searchTimer = null;
		  }
		  txtSearch.BackColor = SystemColors.Window;
		  searchTimer = new System.Threading.Timer(this.PerformSearch, null, 500, System.Threading.Timeout.Infinite);
	   }

	   private void PerformSearch(object state) {
		  this.Invoke(new MethodInvoker(this.PerformSearch));
	   }

	   private void ResetSearch() {
		  UpdateListItems();
	   }

	   SearchQuery.SearchType searchtype = SearchQuery.SearchType.Wildcard;
	   int searchFieldIndex = -1;
	   private void UpdateSearchOptions() {
		  searchContext.Items.Clear();
		  foreach (CardElementStyle style in currentFileData.Deck.Styles) {
			 ToolStripMenuItem item = new ToolStripMenuItem(LibFlashcard.WikiText.WikiMarkupParser.RemoveMarkup(style.Name));
			 item.Click += ModifyFieldIndex;
			 item.Tag = style.Index;
			 searchContext.Items.Add(item);
		  }

		  ToolStripMenuItem allFieldsItem = new ToolStripMenuItem(i18n.Language.AllFields);
		  allFieldsItem.Click += ModifyFieldIndex;
		  allFieldsItem.Tag = -1;
		  searchContext.Items.Add(allFieldsItem);
		  
		  searchContext.Items.Add(new ToolStripSeparator());
		  searchContext.Items.Add(i18n.Language.RegularExpression, null, SearchToggleRegex);

		  ModifyFieldIndex(allFieldsItem, null);
	   }

	   void SearchToggleRegex(object sender, EventArgs e) {
		  ToolStripMenuItem menu = (ToolStripMenuItem)sender;
		  if (searchtype == SearchQuery.SearchType.Wildcard) {
			 menu.Font = new Font(menu.Font, FontStyle.Bold);
			 searchtype = SearchQuery.SearchType.Regex;
		  } else {
			 menu.Font = new Font(menu.Font, FontStyle.Regular);
			 searchtype = SearchQuery.SearchType.Wildcard;
		  }

		  // Update results
		  if (txtSearch.Text != string.Empty) {
			 PerformSearch();
		  }
	   }

	   ToolStripMenuItem last;
	   void ModifyFieldIndex(object sender, EventArgs e) {
		  ToolStripMenuItem menu = (ToolStripMenuItem)sender;
		  menu.Font = new Font(menu.Font, FontStyle.Bold);
		  searchFieldIndex = (int)menu.Tag;
		  if ((last != null) && (last != menu)) {
			 last.Font = new Font(last.Font, FontStyle.Regular);
		  }
		  last = menu;

		  // Update results
		  if (txtSearch.Text != string.Empty) {
			 PerformSearch();
		  }
	   }

	   private void PerformSearch() {
		  currentFileData.SuppressEvents = true;
		  lvCards.Items.Clear();

		  try {
			 if (string.IsNullOrEmpty(txtSearch.Text)) {
				ResetSearch();
			 } else {
				SearchQuery query = new SearchQuery(txtSearch.Text, searchtype);
				int fieldIndex = this.searchFieldIndex;
				string text;
				foreach (Card card in currentFileData.Deck.Cards) {	    
				   // All
				   foreach (CardElement field in card) {
					  if ((fieldIndex != -1) && (field.Style.Index != fieldIndex)) {
						 continue;
					  }
					  // Any markup is removed, so that the 
					  // search is performed on what the user
					  // sees on the list
					  text = LibFlashcard.WikiText.WikiMarkupParser.RemoveMarkup(field.Text);
					  if (query.Match(text)) {
						 lvCards.Items.Add(CardToListViewItem(card));
						 break;
					  }
				   }
				}
			 }
		  } catch (Exception) {
			 txtSearch.BackColor = Color.IndianRed;
			 ResetSearch();
#if DEBUG
			 throw;
#else
			 return;
#endif
		  } finally {
			 currentFileData.SuppressEvents = false;
		  }
	   }

	   class SearchQuery
	   {
		  public enum SearchType { Wildcard, Regex };

		  Regex regex;
		  string query;
		  SearchType type;

		  public SearchQuery(string query, SearchType type) {
			 this.query = query;
			 this.type = type;
			 switch (type) {
				case SearchType.Wildcard:
				    MakeWildCard(query);
				    break;
				case SearchType.Regex:
				    MakeRegex(query);
				    break;
				default:
				    throw new ArgumentException("Invalid enum value", "type");
			 }
		  }

		  public bool Match(string s) {
			 return regex.Match(s).Success;
		  }

		  private void MakeWildCard(string query) {
			 MakeRegex(".*" + Regex.Escape(query) + ".*");
		  }

		  private void MakeRegex(string query) {
			 regex = new Regex(query, RegexOptions.IgnoreCase);
		  }
	   }

	   #endregion

	   #region Drag & Drop
	   private void MainWindow_DragEnter(object sender, DragEventArgs e) {
		  if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
			 e.Effect = DragDropEffects.Copy;
		  }
	   }

	   private void MainWindow_DragDrop(object sender, DragEventArgs e) {
		  if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
			 string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
			 if ((files != null) && (files.Length > 0)) {
				if (CheckCurrent()) { Open(files[0]); }
			 }
		  }
	   }

       private void lvCards_DragEnter(object sender, DragEventArgs e) {
           if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
               e.Effect = DragDropEffects.Copy;
           }
       }

       private void lvCards_DragOver(object sender, DragEventArgs e) {
           if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
               e.Effect = DragDropEffects.Copy;
           }
       }

       private void lvCards_DragDrop(object sender, DragEventArgs e) {
           if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
               MainWindow_DragDrop(this, e);
           }
       }

	   #endregion

       private void lvCards_ItemReordered(object sender, EventArgs e) {
           for (int i = 0; i < lvCards.Items.Count; i++) {
               Card card = lvCards.Items[i].Tag as Card;
               card.Index = i;
           }
           this.currentFileData.Deck.SortCardsByIndex((LibFlashcard.Utilities.SortOrder)SortOrder.Ascending);
           this.currentSortOrder = SortOrder.None;
           this.currentFileData.Modified = true;
       }

       private void lvCards_ColumnReordered(object sender, ColumnReorderedEventArgs e) {
           List<CardElementStyle> list = new List<CardElementStyle>(currentFileData.Deck.Styles);

           CardElementStyle temp = list[e.OldDisplayIndex];
           list.Remove(temp);
           list.Insert(e.NewDisplayIndex, temp);

           for (int i = 0; i < list.Count; i++) {
               list[i].Index = i;
           }

           currentFileData.Deck.SortStyles();
           this.currentFileData.Modified = true;

           Console.WriteLine("{0} to {1}",e.OldDisplayIndex, e.NewDisplayIndex);

           this.BeginInvoke((MethodInvoker)delegate() {
               UpdateListAll();
           });
       }

    }
}