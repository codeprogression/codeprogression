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
 *  Original FileName :  Preferences.cs
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
using FlashCardMaster.User;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Org.Mentalis.Utilities;
using System.IO;

namespace FlashCardMaster.Dialogs
{
    public partial class Preferences : Form
    {
	   public void Localize() {
		  this.tabPage1.Text = i18n.Language.General;
		  this.tabPage2.Text = i18n.Language.Review;
		  this.tabPage3.Text = i18n.Language.HtmlExport;
          this.tabPage4.Text = i18n.Language.Advanced;

		  this.btAssociate.Text = i18n.Language.AssociateFiletypes;
		  this.label2.Text = i18n.Language.CSVSeperatorHint;
		  this.label1.Text = i18n.Language.CSVSeperator;

		  this.label7.Text = i18n.Language.SecondsL;
		  this.label6.Text = i18n.Language.SecondsL;
		  this.label5.Text = i18n.Language.AndShowBackSideFor;
		  this.label4.Text = i18n.Language.ShowFrontSideFor;
		  this.label3.Text = i18n.Language.ReviewDelays;
		  this.label8.Text = i18n.Language.Font;
		  this.label9.Text = i18n.Language.PrintFont;
		  this.btOk.Text = i18n.Language.OK;
		  this.btCancel.Text = i18n.Language.Cancel;

          this.ckManualDuplex.Text = i18n.Language.ManualDuplexOption;
          this.ckHqLayout.Text = i18n.Language.HqTextLayoutOption;
          this.ckEnableBackup.Text = i18n.Language.EnableBackupOption;

          this.label12.Text = i18n.Language.Delay;
          this.label13.Text = i18n.Language.SecondsL;

		  this.ckKeepStyles.Text = i18n.Language.KeepStylesInHtmlMessage;

		  this.Text = i18n.Language.Preferences;
	   }

	   public Preferences() {
	   	  InitializeComponent();
		  Utilities.Utility.SetIcon(this);
		  Localize();
//		  FlashCardMaster.Utilities.Utility.SetFormSize(this, .42f, .41f);
		  this.CenterToParent();
		  UpdateFontInfo();

		  this.tbSeperatorChar.Text = Settings.AppInstance.CsvSeperator.ToString();
		  this.numBack.Value = Settings.AppInstance.ReviewBackDelay;
		  this.numFront.Value = Settings.AppInstance.ReviewFrontDelay;
		  this.ckKeepStyles.Checked = Settings.AppInstance.KeepStylesInHtml;

          this.ckManualDuplex.Checked = Settings.AppInstance.PrinterLiesAboutDuplex;
          this.ckHqLayout.Checked = Settings.AppInstance.RenderingBreakWords;
          this.ckEnableBackup.Checked = Settings.AppInstance.SaveBackups;
          this.numBackupFrequency.Value = Settings.AppInstance.BackupInterval / 1000;

		  this.FormClosing += new FormClosingEventHandler(Preferences_FormClosing);
	   }

	   void Preferences_FormClosing(object sender, FormClosingEventArgs e) {
//		  Settings.WinSettings.SaveWindowSize(this.GetType().ToString(), this.Size);
	   }

	   private void Persist() {
		  Settings.AppInstance.CsvSeperator = this.tbSeperatorChar.Text[0];
		  Settings.AppInstance.ReviewBackDelay = this.numBack.Value;
		  Settings.AppInstance.ReviewFrontDelay = this.numFront.Value;
		  Settings.AppInstance.KeepStylesInHtml = this.ckKeepStyles.Checked;
          Settings.AppInstance.PrinterLiesAboutDuplex = this.ckManualDuplex.Checked;
          Settings.AppInstance.RenderingBreakWords = this.ckHqLayout.Checked;
          Settings.AppInstance.SaveBackups = this.ckEnableBackup.Checked;
          Settings.AppInstance.BackupInterval = (int)(this.numBackupFrequency.Value * 1000);
		  Settings.Save();
	   }

	   private void btOk_Click(object sender, EventArgs e) {
		  if (this.tbSeperatorChar.Text.Length == 1) {
			 Persist();
		  } else {
			 this.DialogResult = DialogResult.None;
		  }
	   }

       readonly string folderIconPath = Application.UserAppDataPath + ",4";
	   readonly string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My FlashCards");

	   private void btAssociate_Click(object sender, EventArgs e) {

           string folderIniPath = Path.Combine(folderPath, "desktop.ini");
           string desktopInid = "[.ShellClassInfo]\r\nIconFile=" + folderIconPath + "\r\nIconIndex=0\r\n";


           if (Directory.Exists(folderPath)) {
               try {
                   // not critical
                   File.WriteAllText(folderIniPath, desktopInid);
                   File.SetAttributes(folderIniPath, FileAttributes.System | FileAttributes.Hidden);
               } catch { }
           }
		  
		  FileAssociation cardFile = new FileAssociation();
		  cardFile.Extension = "card";
		  cardFile.ContentType = "application/flashcardmaster";
		  cardFile.FullName = "Flash Card Deck";
		  cardFile.ProperName = "CardDeck";
          cardFile.IconPath = Application.ExecutablePath;
		  cardFile.IconIndex = 1;
		  cardFile.AddCommand("Open", string.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
		  cardFile.Create();

		  FileAssociation cmlFile = new FileAssociation();
		  cmlFile.Extension = "cml";
		  cmlFile.ContentType = "text/xml";
		  cmlFile.FullName = "XML Flash Card Deck";
		  cmlFile.ProperName = "XMLCardDeck";
          cmlFile.IconPath = Application.ExecutablePath;
		  cmlFile.IconIndex = 2;
		  cmlFile.AddCommand("Open", string.Format("\"{0}\" \"%1\"", Application.ExecutablePath));
		  cmlFile.Create();

		  SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
	   }


	   private const int SHCNE_ASSOCCHANGED = 0x8000000;
	   private const int SHCNF_IDLIST = 0x0;


	   [DllImport("shell32.dll")]
	   static extern void SHChangeNotify(HChangeNotifyEventID wEventId,
								   HChangeNotifyFlags uFlags,
								   IntPtr dwItem1,
								   IntPtr dwItem2);

	   #region public enum HChangeNotifyFlags
	   /// <summary>
	   /// Flags that indicate the meaning of the <i>dwItem1</i> and <i>dwItem2</i> parameters.
	   /// The uFlags parameter must be one of the following values.
	   /// </summary>
	   [Flags]
	   public enum HChangeNotifyFlags
	   {
		  /// <summary>
		  /// The <i>dwItem1</i> and <i>dwItem2</i> parameters are DWORD values.
		  /// </summary>
		  SHCNF_DWORD = 0x0003,
		  /// <summary>
		  /// <i>dwItem1</i> and <i>dwItem2</i> are the addresses of ITEMIDLIST structures that
		  /// represent the item(s) affected by the change.
		  /// Each ITEMIDLIST must be relative to the desktop folder.
		  /// </summary>
		  SHCNF_IDLIST = 0x0000,
		  /// <summary>
		  /// <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings of
		  /// maximum length MAX_PATH that contain the full Path names
		  /// of the items affected by the change.
		  /// </summary>
		  SHCNF_PATHA = 0x0001,
		  /// <summary>
		  /// <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings of
		  /// maximum length MAX_PATH that contain the full Path names
		  /// of the items affected by the change.
		  /// </summary>
		  SHCNF_PATHW = 0x0005,
		  /// <summary>
		  /// <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings that
		  /// represent the friendly names of the printer(s) affected by the change.
		  /// </summary>
		  SHCNF_PRINTERA = 0x0002,
		  /// <summary>
		  /// <i>dwItem1</i> and <i>dwItem2</i> are the addresses of null-terminated strings that
		  /// represent the friendly names of the printer(s) affected by the change.
		  /// </summary>
		  SHCNF_PRINTERW = 0x0006,
		  /// <summary>
		  /// The function should not return until the notification
		  /// has been delivered to all affected components.
		  /// As this flag modifies other data-type flags, it cannot by used by itself.
		  /// </summary>
		  SHCNF_FLUSH = 0x1000,
		  /// <summary>
		  /// The function should begin delivering notifications to all affected components
		  /// but should return as soon as the notification process has begun.
		  /// As this flag modifies other data-type flags, it cannot by used by itself.
		  /// </summary>
		  SHCNF_FLUSHNOWAIT = 0x2000
	   }
	   #endregion // enum HChangeNotifyFlags

	   #region enum HChangeNotifyEventID
	   /// <summary>
	   /// Describes the event that has occurred.
	   /// Typically, only one event is specified at a time.
	   /// If more than one event is specified, the values contained
	   /// in the <i>dwItem1</i> and <i>dwItem2</i>
	   /// parameters must be the same, respectively, for all specified events.
	   /// This parameter can be one or more of the following values.
	   /// </summary>
	   /// <remarks>
	   /// <para><b>Windows NT/2000/XP:</b> <i>dwItem2</i> contains the index
	   /// in the system image list that has changed.
	   /// <i>dwItem1</i> is not used and should be <see langword="null"/>.</para>
	   /// <para><b>Windows 95/98:</b> <i>dwItem1</i> contains the index
	   /// in the system image list that has changed.
	   /// <i>dwItem2</i> is not used and should be <see langword="null"/>.</para>
	   /// </remarks>
	   [Flags]
	   enum HChangeNotifyEventID
	   {
		  /// <summary>
		  /// All events have occurred.
		  /// </summary>
		  SHCNE_ALLEVENTS = 0x7FFFFFFF,

		  /// <summary>
		  /// A file type association has changed. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/>
		  /// must be specified in the <i>uFlags</i> parameter.
		  /// <i>dwItem1</i> and <i>dwItem2</i> are not used and must be <see langword="null"/>.
		  /// </summary>
		  SHCNE_ASSOCCHANGED = 0x08000000,

		  /// <summary>
		  /// The attributes of an item or folder have changed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the item or folder that has changed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_ATTRIBUTES = 0x00000800,

		  /// <summary>
		  /// A nonfolder item has been created.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the item that was created.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_CREATE = 0x00000002,

		  /// <summary>
		  /// A nonfolder item has been deleted.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the item that was deleted.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_DELETE = 0x00000004,

		  /// <summary>
		  /// A drive has been added.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive that was added.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_DRIVEADD = 0x00000100,

		  /// <summary>
		  /// A drive has been added and the Shell should create a new window for the drive.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive that was added.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_DRIVEADDGUI = 0x00010000,

		  /// <summary>
		  /// A drive has been removed. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive that was removed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_DRIVEREMOVED = 0x00000080,

		  /// <summary>
		  /// Not currently used.
		  /// </summary>
		  SHCNE_EXTENDED_EVENT = 0x04000000,

		  /// <summary>
		  /// The amount of free space on a drive has changed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive on which the free space changed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_FREESPACE = 0x00040000,

		  /// <summary>
		  /// Storage media has been inserted into a drive.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive that contains the new media.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_MEDIAINSERTED = 0x00000020,

		  /// <summary>
		  /// Storage media has been removed from a drive.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the root of the drive from which the media was removed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_MEDIAREMOVED = 0x00000040,

		  /// <summary>
		  /// A folder has been created. <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/>
		  /// or <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the folder that was created.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_MKDIR = 0x00000008,

		  /// <summary>
		  /// A folder on the local computer is being shared via the network.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the folder that is being shared.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_NETSHARE = 0x00000200,

		  /// <summary>
		  /// A folder on the local computer is no longer being shared via the network.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the folder that is no longer being shared.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_NETUNSHARE = 0x00000400,

		  /// <summary>
		  /// The name of a folder has changed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the previous pointer to an item identifier list (PIDL) or name of the folder.
		  /// <i>dwItem2</i> contains the new PIDL or name of the folder.
		  /// </summary>
		  SHCNE_RENAMEFOLDER = 0x00020000,

		  /// <summary>
		  /// The name of a nonfolder item has changed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the previous PIDL or name of the item.
		  /// <i>dwItem2</i> contains the new PIDL or name of the item.
		  /// </summary>
		  SHCNE_RENAMEITEM = 0x00000001,

		  /// <summary>
		  /// A folder has been removed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the folder that was removed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_RMDIR = 0x00000010,

		  /// <summary>
		  /// The computer has disconnected from a server.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the server from which the computer was disconnected.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// </summary>
		  SHCNE_SERVERDISCONNECT = 0x00004000,

		  /// <summary>
		  /// The contents of an existing folder have changed,
		  /// but the folder still exists and has not been renamed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_IDLIST"/> or
		  /// <see cref="HChangeNotifyFlags.SHCNF_PATH"/> must be specified in <i>uFlags</i>.
		  /// <i>dwItem1</i> contains the folder that has changed.
		  /// <i>dwItem2</i> is not used and should be <see langword="null"/>.
		  /// If a folder has been created, deleted, or renamed, use SHCNE_MKDIR, SHCNE_RMDIR, or
		  /// SHCNE_RENAMEFOLDER, respectively, instead.
		  /// </summary>
		  SHCNE_UPDATEDIR = 0x00001000,

		  /// <summary>
		  /// An image in the system image list has changed.
		  /// <see cref="HChangeNotifyFlags.SHCNF_DWORD"/> must be specified in <i>uFlags</i>.
		  /// </summary>
		  SHCNE_UPDATEIMAGE = 0x00008000,

	   }
	   #endregion // enum HChangeNotifyEventID

	   private void btChooseFont_Click(object sender, EventArgs e) {
		  using (FontDialog dlgFont = new FontDialog()) {
			 dlgFont.Font = Settings.AppInstance.PreferredFont.GetFont();
			 dlgFont.ShowEffects = false;
			 if (dlgFont.ShowDialog(this) == DialogResult.OK) {
				Settings.AppInstance.PreferredFont = new Settings.FontInfo(dlgFont.Font);
				UpdateFontInfo();
			 }
		  }
	   }

	   private void btChoosePrintFont_Click(object sender, EventArgs e) {
		  using (FontDialog dlgFont = new FontDialog()) {
			 dlgFont.Font = Settings.AppInstance.PrintFont.GetFont();
			 dlgFont.ShowEffects = false;
			 if (dlgFont.ShowDialog(this) == DialogResult.OK) {
				Settings.AppInstance.PrintFont = new Settings.FontInfo(dlgFont.Font);
				UpdateFontInfo();
			 }
		  }
	   }

	   private void UpdateFontInfo() {
		  Font font = Settings.AppInstance.PreferredFont.GetFont();
		  lblFontInfo.Text = string.Format("{0}, {1}, {2}pt", font.Name, font.Style, font.Size);
		  font.Dispose();

		  font = Settings.AppInstance.PrintFont.GetFont();
		  lblPrintFontInfo.Text = string.Format("{0}, {1}, {2}pt", font.Name, font.Style, font.Size);
		  font.Dispose();
	   }

        private void ckEnableBackup_CheckedChanged(object sender, EventArgs e) {
            tableLayoutPanel3.Enabled = ckEnableBackup.Checked;
        }

        private void tbSeperatorChar_TextChanged(object sender, EventArgs e) {
                if (string.IsNullOrEmpty(tbSeperatorChar.Text)) {
                    ctError.SetIconAlignment(tbSeperatorChar, ErrorIconAlignment.MiddleRight);
                    ctError.SetError(tbSeperatorChar, i18n.Language.FieldNameEmptyError);
                    btOk.Enabled = false;
                } else {
                    ctError.SetError(tbSeperatorChar, string.Empty);
                    btOk.Enabled = true;
                }
        }

	   
    }
}