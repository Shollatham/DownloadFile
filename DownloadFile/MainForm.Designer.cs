namespace DownloadFile
{
	 partial class MainForm
	 {
		  /// <summary>
		  /// Required designer variable.
		  /// </summary>
		  private System.ComponentModel.IContainer components = null;

		  /// <summary>
		  /// Clean up any resources being used.
		  /// </summary>
		  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		  protected override void Dispose(bool disposing)
		  {
				if (disposing && (components != null))
				{
					 components.Dispose();
				}
				base.Dispose(disposing);
		  }

		  #region Windows Form Designer generated code

		  /// <summary>
		  /// Required method for Designer support - do not modify
		  /// the contents of this method with the code editor.
		  /// </summary>
		  private void InitializeComponent()
		  {
				this.label1 = new System.Windows.Forms.Label();
				this.urlTxt = new System.Windows.Forms.TextBox();
				this.label2 = new System.Windows.Forms.Label();
				this.typeCB = new System.Windows.Forms.ComboBox();
				this.usernameLbl = new System.Windows.Forms.Label();
				this.userNameTxt = new System.Windows.Forms.TextBox();
				this.passwordTxt = new System.Windows.Forms.TextBox();
				this.passwordLbl = new System.Windows.Forms.Label();
				this.downloadListGv = new System.Windows.Forms.DataGridView();
				this.KeyFilePathTxt = new System.Windows.Forms.TextBox();
				this.keyLbl = new System.Windows.Forms.Label();
				this.selectKeyBtn = new System.Windows.Forms.Button();
				this.credentialGb = new System.Windows.Forms.GroupBox();
				this.clearKeyBtn = new System.Windows.Forms.Button();
				this.addDownloadBtn = new System.Windows.Forms.Button();
				this.removeDownloadBtn = new System.Windows.Forms.Button();
				this.startDownloadBtn = new System.Windows.Forms.Button();
				this.label6 = new System.Windows.Forms.Label();
				this.outputPathTxt = new System.Windows.Forms.TextBox();
				this.selectOutputBtn = new System.Windows.Forms.Button();
				((System.ComponentModel.ISupportInitialize)(this.downloadListGv)).BeginInit();
				this.credentialGb.SuspendLayout();
				this.SuspendLayout();
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(12, 18);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(46, 20);
				this.label1.TabIndex = 0;
				this.label1.Text = "URL:";
				// 
				// urlTxt
				// 
				this.urlTxt.Location = new System.Drawing.Point(135, 15);
				this.urlTxt.Name = "urlTxt";
				this.urlTxt.Size = new System.Drawing.Size(851, 26);
				this.urlTxt.TabIndex = 1;
				this.urlTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.urlTxt_KeyDown);
				this.urlTxt.Leave += new System.EventHandler(this.urlTxt_Leave);
				// 
				// label2
				// 
				this.label2.AutoSize = true;
				this.label2.Location = new System.Drawing.Point(1015, 18);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(43, 20);
				this.label2.TabIndex = 2;
				this.label2.Text = "Type";
				// 
				// typeCB
				// 
				this.typeCB.AllowDrop = true;
				this.typeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
				this.typeCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
				this.typeCB.FormattingEnabled = true;
				this.typeCB.Location = new System.Drawing.Point(1103, 15);
				this.typeCB.Name = "typeCB";
				this.typeCB.Size = new System.Drawing.Size(143, 28);
				this.typeCB.TabIndex = 3;
				this.typeCB.SelectedIndexChanged += new System.EventHandler(this.typeCB_SelectedIndexChanged);
				// 
				// usernameLbl
				// 
				this.usernameLbl.AutoSize = true;
				this.usernameLbl.Location = new System.Drawing.Point(6, 32);
				this.usernameLbl.Name = "usernameLbl";
				this.usernameLbl.Size = new System.Drawing.Size(83, 20);
				this.usernameLbl.TabIndex = 4;
				this.usernameLbl.Text = "Username";
				// 
				// userNameTxt
				// 
				this.userNameTxt.Location = new System.Drawing.Point(95, 29);
				this.userNameTxt.Name = "userNameTxt";
				this.userNameTxt.Size = new System.Drawing.Size(194, 26);
				this.userNameTxt.TabIndex = 5;
				// 
				// passwordTxt
				// 
				this.passwordTxt.Location = new System.Drawing.Point(379, 29);
				this.passwordTxt.Name = "passwordTxt";
				this.passwordTxt.PasswordChar = '*';
				this.passwordTxt.Size = new System.Drawing.Size(191, 26);
				this.passwordTxt.TabIndex = 7;
				// 
				// passwordLbl
				// 
				this.passwordLbl.AutoSize = true;
				this.passwordLbl.Location = new System.Drawing.Point(295, 32);
				this.passwordLbl.Name = "passwordLbl";
				this.passwordLbl.Size = new System.Drawing.Size(78, 20);
				this.passwordLbl.TabIndex = 6;
				this.passwordLbl.Text = "Password";
				// 
				// downloadListGv
				// 
				this.downloadListGv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.downloadListGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
				this.downloadListGv.Location = new System.Drawing.Point(7, 173);
				this.downloadListGv.Name = "downloadListGv";
				this.downloadListGv.RowTemplate.Height = 28;
				this.downloadListGv.Size = new System.Drawing.Size(1104, 260);
				this.downloadListGv.TabIndex = 8;
				// 
				// KeyFilePathTxt
				// 
				this.KeyFilePathTxt.Location = new System.Drawing.Point(631, 29);
				this.KeyFilePathTxt.Name = "KeyFilePathTxt";
				this.KeyFilePathTxt.ReadOnly = true;
				this.KeyFilePathTxt.Size = new System.Drawing.Size(276, 26);
				this.KeyFilePathTxt.TabIndex = 9;
				// 
				// keyLbl
				// 
				this.keyLbl.AutoSize = true;
				this.keyLbl.Location = new System.Drawing.Point(576, 32);
				this.keyLbl.Name = "keyLbl";
				this.keyLbl.Size = new System.Drawing.Size(35, 20);
				this.keyLbl.TabIndex = 10;
				this.keyLbl.Text = "Key";
				// 
				// selectKeyBtn
				// 
				this.selectKeyBtn.Location = new System.Drawing.Point(913, 25);
				this.selectKeyBtn.Name = "selectKeyBtn";
				this.selectKeyBtn.Size = new System.Drawing.Size(70, 34);
				this.selectKeyBtn.TabIndex = 11;
				this.selectKeyBtn.Text = "Select";
				this.selectKeyBtn.UseVisualStyleBackColor = true;
				this.selectKeyBtn.Click += new System.EventHandler(this.selectKeyBtn_Click);
				// 
				// credentialGb
				// 
				this.credentialGb.Controls.Add(this.clearKeyBtn);
				this.credentialGb.Controls.Add(this.usernameLbl);
				this.credentialGb.Controls.Add(this.selectKeyBtn);
				this.credentialGb.Controls.Add(this.userNameTxt);
				this.credentialGb.Controls.Add(this.keyLbl);
				this.credentialGb.Controls.Add(this.passwordLbl);
				this.credentialGb.Controls.Add(this.KeyFilePathTxt);
				this.credentialGb.Controls.Add(this.passwordTxt);
				this.credentialGb.Location = new System.Drawing.Point(16, 93);
				this.credentialGb.Name = "credentialGb";
				this.credentialGb.Size = new System.Drawing.Size(1067, 74);
				this.credentialGb.TabIndex = 12;
				this.credentialGb.TabStop = false;
				this.credentialGb.Text = "Credential";
				// 
				// clearKeyBtn
				// 
				this.clearKeyBtn.Location = new System.Drawing.Point(989, 25);
				this.clearKeyBtn.Name = "clearKeyBtn";
				this.clearKeyBtn.Size = new System.Drawing.Size(72, 34);
				this.clearKeyBtn.TabIndex = 12;
				this.clearKeyBtn.Text = "Clear";
				this.clearKeyBtn.UseVisualStyleBackColor = true;
				this.clearKeyBtn.Click += new System.EventHandler(this.clearKeyBtn_Click);
				// 
				// addDownloadBtn
				// 
				this.addDownloadBtn.Location = new System.Drawing.Point(1103, 61);
				this.addDownloadBtn.Name = "addDownloadBtn";
				this.addDownloadBtn.Size = new System.Drawing.Size(143, 91);
				this.addDownloadBtn.TabIndex = 12;
				this.addDownloadBtn.Text = "Add";
				this.addDownloadBtn.UseVisualStyleBackColor = true;
				this.addDownloadBtn.Click += new System.EventHandler(this.addDownloadBtn_Click);
				// 
				// removeDownloadBtn
				// 
				this.removeDownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.removeDownloadBtn.Location = new System.Drawing.Point(1117, 173);
				this.removeDownloadBtn.Name = "removeDownloadBtn";
				this.removeDownloadBtn.Size = new System.Drawing.Size(129, 39);
				this.removeDownloadBtn.TabIndex = 13;
				this.removeDownloadBtn.Text = "Remove";
				this.removeDownloadBtn.UseVisualStyleBackColor = true;
				this.removeDownloadBtn.Click += new System.EventHandler(this.removeDownloadBtn_Click);
				// 
				// startDownloadBtn
				// 
				this.startDownloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
				this.startDownloadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
				this.startDownloadBtn.Location = new System.Drawing.Point(1117, 281);
				this.startDownloadBtn.Name = "startDownloadBtn";
				this.startDownloadBtn.Size = new System.Drawing.Size(129, 152);
				this.startDownloadBtn.TabIndex = 14;
				this.startDownloadBtn.Text = "Start Download";
				this.startDownloadBtn.UseVisualStyleBackColor = false;
				this.startDownloadBtn.Click += new System.EventHandler(this.startDownloadBtn_Click);
				// 
				// label6
				// 
				this.label6.AutoSize = true;
				this.label6.Location = new System.Drawing.Point(12, 61);
				this.label6.Name = "label6";
				this.label6.Size = new System.Drawing.Size(107, 20);
				this.label6.TabIndex = 15;
				this.label6.Text = "Output Folder";
				// 
				// outputPathTxt
				// 
				this.outputPathTxt.Location = new System.Drawing.Point(135, 61);
				this.outputPathTxt.Name = "outputPathTxt";
				this.outputPathTxt.Size = new System.Drawing.Size(851, 26);
				this.outputPathTxt.TabIndex = 16;
				// 
				// selectOutputBtn
				// 
				this.selectOutputBtn.Location = new System.Drawing.Point(1005, 61);
				this.selectOutputBtn.Name = "selectOutputBtn";
				this.selectOutputBtn.Size = new System.Drawing.Size(91, 34);
				this.selectOutputBtn.TabIndex = 13;
				this.selectOutputBtn.Text = "Select";
				this.selectOutputBtn.UseVisualStyleBackColor = true;
				this.selectOutputBtn.Click += new System.EventHandler(this.selectOutputBtn_Click);
				// 
				// MainForm
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(1262, 444);
				this.Controls.Add(this.addDownloadBtn);
				this.Controls.Add(this.selectOutputBtn);
				this.Controls.Add(this.outputPathTxt);
				this.Controls.Add(this.label6);
				this.Controls.Add(this.startDownloadBtn);
				this.Controls.Add(this.removeDownloadBtn);
				this.Controls.Add(this.credentialGb);
				this.Controls.Add(this.downloadListGv);
				this.Controls.Add(this.typeCB);
				this.Controls.Add(this.label2);
				this.Controls.Add(this.urlTxt);
				this.Controls.Add(this.label1);
				this.MinimumSize = new System.Drawing.Size(700, 500);
				this.Name = "MainForm";
				this.Text = "Download File";
				((System.ComponentModel.ISupportInitialize)(this.downloadListGv)).EndInit();
				this.credentialGb.ResumeLayout(false);
				this.credentialGb.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();

		  }

		  #endregion

		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.TextBox urlTxt;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.ComboBox typeCB;
		  private System.Windows.Forms.Label usernameLbl;
		  private System.Windows.Forms.TextBox userNameTxt;
		  private System.Windows.Forms.TextBox passwordTxt;
		  private System.Windows.Forms.Label passwordLbl;
		  private System.Windows.Forms.DataGridView downloadListGv;
		  private System.Windows.Forms.TextBox KeyFilePathTxt;
		  private System.Windows.Forms.Label keyLbl;
		  private System.Windows.Forms.Button selectKeyBtn;
		  private System.Windows.Forms.GroupBox credentialGb;
		  private System.Windows.Forms.Button addDownloadBtn;
		  private System.Windows.Forms.Button removeDownloadBtn;
		  private System.Windows.Forms.Button startDownloadBtn;
		  private System.Windows.Forms.Label label6;
		  private System.Windows.Forms.TextBox outputPathTxt;
		  private System.Windows.Forms.Button selectOutputBtn;
		  private System.Windows.Forms.Button clearKeyBtn;
	 }
}

