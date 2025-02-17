namespace FlashCardMaster.Dialogs
{
    partial class BatchEntry
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
           this.txInput = new System.Windows.Forms.TextBox();
           this.btCancel = new System.Windows.Forms.Button();
           this.btOk = new System.Windows.Forms.Button();
           this.label1 = new System.Windows.Forms.Label();
           this.label2 = new System.Windows.Forms.Label();
           this.SuspendLayout();
           // 
           // txInput
           // 
           this.txInput.AcceptsReturn = true;
           this.txInput.AcceptsTab = true;
           this.txInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.txInput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.txInput.Location = new System.Drawing.Point(12, 36);
           this.txInput.Multiline = true;
           this.txInput.Name = "txInput";
           this.txInput.Size = new System.Drawing.Size(475, 230);
           this.txInput.TabIndex = 0;
           this.txInput.TextChanged += new System.EventHandler(this.txInput_TextChanged);
           // 
           // btCancel
           // 
           this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btCancel.Location = new System.Drawing.Point(331, 272);
           this.btCancel.Name = "btCancel";
           this.btCancel.Size = new System.Drawing.Size(75, 23);
           this.btCancel.TabIndex = 1;
           this.btCancel.Text = "Cancel";
           this.btCancel.UseVisualStyleBackColor = true;
           this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
           // 
           // btOk
           // 
           this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.btOk.Enabled = false;
           this.btOk.Location = new System.Drawing.Point(412, 272);
           this.btOk.Name = "btOk";
           this.btOk.Size = new System.Drawing.Size(75, 23);
           this.btOk.TabIndex = 2;
           this.btOk.Text = "OK";
           this.btOk.UseVisualStyleBackColor = true;
           this.btOk.Click += new System.EventHandler(this.btOk_Click);
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(12, 13);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(94, 13);
           this.label1.TabIndex = 3;
           this.label1.Text = "Enter as: <1>, <2>";
           // 
           // label2
           // 
           this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(12, 277);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(193, 13);
           this.label2.TabIndex = 4;
           this.label2.Text = "Use [Ctrl] + [Enter] to enter a line break.";
           this.label2.Visible = false;
           // 
           // BatchEntry
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(499, 307);
           this.Controls.Add(this.label2);
           this.Controls.Add(this.label1);
           this.Controls.Add(this.btOk);
           this.Controls.Add(this.btCancel);
           this.Controls.Add(this.txInput);
           this.MinimizeBox = false;
           this.Name = "BatchEntry";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           this.Text = "Batch Entry";
           this.ResumeLayout(false);
           this.PerformLayout();

	   }

	   #endregion

	   private System.Windows.Forms.TextBox txInput;
	   private System.Windows.Forms.Button btCancel;
	   private System.Windows.Forms.Button btOk;
	   private System.Windows.Forms.Label label1;
	   private System.Windows.Forms.Label label2;
    }
}