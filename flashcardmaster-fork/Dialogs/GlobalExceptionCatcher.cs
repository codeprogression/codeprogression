using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;

namespace FlashCardMaster.Dialogs
{
    public partial class GlobalExceptionCatcher : Form
    {
	   const string BUG_POST_URL = "http://flashcardmaster.sourceforge.net/CrashHandler/postbug.php";
	   const string BUG_POST_KEY = "message";

	   string header = "";
	   string message = "";
	   string userMessage = "";

	   Exception ex;

	   public GlobalExceptionCatcher(Exception ex) {
		  InitializeComponent();
		  this.Text = Application.ProductName + " " + Application.ProductVersion;
		  this.ex = ex;
		  header = string.Format("{0}/{1} ({2} {3};{4}; CLR {5}){6}{6}", Application.ProductName, Application.ProductVersion, Environment.OSVersion.Platform, Environment.OSVersion.Version, CultureInfo.CurrentCulture.Name, System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion(), Environment.NewLine);
		  LogException(ex);
		  
		  ctExplanation.Text = string.Format("Sorry, an unhandled error has occued in {0}. We apologize for any inconveniences this may have caused you.\nYou can help improve {0} by sending us details about this error. No personally identifiable information will be sent.", Application.ProductName);
	   }

	   // based on http://doogal.co.uk/exception.php
	   private void LogException(Exception exception) {
		  DateTime now = System.DateTime.UtcNow;
		  StringBuilder error = new StringBuilder();
		  error.Append("Date:              " +
			 now.ToString("MM-dd-yyyy HH:mm:ss UTC") + Environment.NewLine);
		  error.Append("OS:                " +
		    System.Environment.OSVersion.ToString() + Environment.NewLine);
		  error.Append("Culture:           " +
		    CultureInfo.CurrentCulture.Name + Environment.NewLine);
		  error.Append("App up time:       " +
		    (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString() + Environment.NewLine);
		  error.Append("Exception class:   " +
		    exception.GetType().ToString() + Environment.NewLine);
		  error.Append("Exception message: " +
		    GetExceptionStack(exception) + Environment.NewLine);

		  error.Append(Environment.NewLine);
		  error.Append("Stack Trace:");
		  error.Append(Environment.NewLine);
		  error.Append(exception.StackTrace);
		  error.Append(Environment.NewLine);
		  error.Append(Environment.NewLine);
		  error.Append("Loaded Assemblies:");
		  error.Append(Environment.NewLine);
		  foreach (string s in LoadedAssembliesAsViewableList()) {
			 error.Append("   " + s);
			 error.Append(Environment.NewLine);
		  }
		  error.Append(Environment.NewLine);
		  error.Append("Loaded Modules:");
		  error.Append(Environment.NewLine);
		  Process thisProcess = Process.GetCurrentProcess();
		  foreach (ProcessModule module in thisProcess.Modules) {
			 error.Append("   " + module.FileName + " [" + module.FileVersionInfo.FileVersion + "]");
			 error.Append(Environment.NewLine);
		  }

		  
		  message = error.ToString();
		  ctPreview.Text = header + message;
	   }

	   // based on http://doogal.co.uk/exception.php
	   private string[] LoadedAssembliesAsViewableList() {
		  Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
		  string[] result = new string[assems.Length];
		  for (int i = 0; i < assems.Length; i++ ) {
			 Assembly assem = assems[i];
			 AssemblyName assName = assem.GetName();
			 result[i] = assName.Name + " (" + assName.Version.ToString() + ")";
		  }
		  return result;
	   }

	   // from on http://doogal.co.uk/exception.php
	   private string GetExceptionStack(Exception e) {
		  StringBuilder message = new StringBuilder();
		  message.Append(e.Message);
		  while ((e = e.InnerException) != null) {	 
			 message.Append(Environment.NewLine);
			 message.Append(e.Message);
		  }
		  return message.ToString();
	   }

	   private void btnClose_Click(object sender, EventArgs e) {
		  if (ctRestart.Checked) {
			 Application.Restart();
		  } else {
			 Application.Exit();
		  }
	   }

	   private void ctSend_Click(object sender, EventArgs e) {
		  ctSend.Enabled = false;
		  this.Cursor = Cursors.WaitCursor;
		  try {
			 if (SendMessage()) {
				if (ctRestart.Checked) {
				    Application.Restart();
				} else {
				    Application.Exit();
				}
			 }
		  } catch {
			 // MessageBox.Show("A further exception occured while sending data. Quitting", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
              if (ctRestart.Checked) {
                  Application.Restart();
              } else {
                  Application.Exit();
              }
		  }
	   }

	   private bool SendMessage() {
		  // can't have & in the message
		  string finalMessage = header + userMessage + message;
		  finalMessage = finalMessage.Replace("&", " and ");
		  finalMessage = finalMessage.Replace(@"\", @"\\");

		  // Create a request using a URL that can receive a post. 
		  WebRequest request = WebRequest.Create(BUG_POST_URL);
		  // Set the Method property of the request to POST.
		  request.Method = "POST";
		  // Create POST data and convert it to a byte array.
		  string postData =  BUG_POST_KEY + "=" + finalMessage;
		  byte[] byteArray = Encoding.UTF8.GetBytes(postData);
		  // Set the ContentType property of the WebRequest.
		  request.ContentType = "application/x-www-form-urlencoded";
		  // Set the ContentLength property of the WebRequest.
		  request.ContentLength = byteArray.Length;
		  // Get the request stream.
		  Stream dataStream = request.GetRequestStream();
		  // Write the data to the request stream.
		  dataStream.Write(byteArray, 0, byteArray.Length);
		  // Close the Stream object.
		  dataStream.Close();
		  // Get the response.
		  WebResponse response = request.GetResponse();
		  // Display the status.
		  if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK) {
			 return true;
		  } else {
			 return false;
		  }
	   }

	   private void ctUserDesc_TextChanged(object sender, EventArgs e) {
		  if (string.IsNullOrEmpty(ctUserDesc.Text)) {
			 userMessage = "";
			 ctPreview.Text = header + message;
		  } else {
			 userMessage = "User Description: " + ctUserDesc.Text  + Environment.NewLine + Environment.NewLine;
			 ctPreview.Text = header + userMessage + message;
		  }
	   }

	   private void ctDetails_Click(object sender, EventArgs e) {
		  ctContainer.Panel2Collapsed = !ctContainer.Panel2Collapsed;
		  ctDetails.Text = ctContainer.Panel2Collapsed ? "+" : "—";
	   }
    }
}