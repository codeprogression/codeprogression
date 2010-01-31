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
 *  Original FileName :  Program.cs
 *  Created           :  Tue Oct 03 2006
 *  Description       :  
 *************************************************************************/

using System;
using System.Windows.Forms;
using FlashCardMaster.Dialogs;
using FlashCardMaster.i18n;
using FlashCardMaster.User;
using LibFlashcard.Drivers;

namespace FlashCardMaster
{
    class Program
    {

        [STAThread]
        public static void Main(string[] args) {
#if RELEASE || ERROR_REPORT_TEST
		  try {
			 Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
#endif

            CsvDriver.PreserveNewLinesInCsv = Settings.AppInstance.PreserveNewLinesInCsv;
            CsvDriver.CsvSeparator = Settings.AppInstance.CsvSeperator;
            LaTeXDriver.ConvertMarkup = Settings.AppInstance.KeepStylesInHtml;
            XhtmlDriver.ConvertMarkup = Settings.AppInstance.KeepStylesInHtml;

            string file = "";
            if (args.Length == 1) { file = args[0]; }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(file));
#if RELEASE || ERROR_REPORT_TEST
		  } catch (Exception ex) {
			 CatchException(ex);
		  }
#endif
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) {
            CatchException(e.Exception);
        }

        private static void CatchException(Exception ex) {
            try {
                for (int i = 0; i < Application.OpenForms.Count; i++) {
                    Application.OpenForms[i].Hide();
                }

                using (GlobalExceptionCatcher catcher = new GlobalExceptionCatcher(ex)) {
                    catcher.ShowDialog();
                }
            } catch {
                MessageBox.Show("Oops! Everything seems to be going wrong. Sorry.\nPlease restart the application manually.", Application.ProductName);
            }
        }

        public static string AboutVersion {
            get { return string.Format(Language.VersionFormat, Application.ProductName, Application.ProductVersion); }
        }

        public static string AboutContributors {
            get { return string.Format(Language.ContributorsFormat, Application.ProductName, Application.ProductVersion); }
        }

        public static string LicenseInfo {
            get { return Language.AboutLicense; }
        }
    }
}
