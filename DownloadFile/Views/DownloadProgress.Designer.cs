namespace DownloadFile.Views
{
	 partial class DownloadProgress
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
				this.components = new System.ComponentModel.Container();
				this.progressBar = new System.Windows.Forms.ProgressBar();
				this.label1 = new System.Windows.Forms.Label();
				this.fileNameLbl = new System.Windows.Forms.Label();
				this.label2 = new System.Windows.Forms.Label();
				this.savePathLbl = new System.Windows.Forms.Label();
				this.label3 = new System.Windows.Forms.Label();
				this.downloadProgressLbl = new System.Windows.Forms.Label();
				this.cancelBtn = new System.Windows.Forms.Button();
				this.timerTicker = new System.Windows.Forms.Timer(this.components);
				this.closeBtn = new System.Windows.Forms.Button();
				this.restartBtn = new System.Windows.Forms.Button();
				this.SuspendLayout();
				// 
				// progressBar
				// 
				this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
				this.progressBar.Location = new System.Drawing.Point(13, 13);
				this.progressBar.Name = "progressBar";
				this.progressBar.Size = new System.Drawing.Size(874, 49);
				this.progressBar.TabIndex = 0;
				// 
				// label1
				// 
				this.label1.AutoSize = true;
				this.label1.Location = new System.Drawing.Point(13, 69);
				this.label1.Name = "label1";
				this.label1.Size = new System.Drawing.Size(79, 20);
				this.label1.TabIndex = 1;
				this.label1.Text = "File URL :";
				// 
				// fileNameLbl
				// 
				this.fileNameLbl.AutoSize = true;
				this.fileNameLbl.Location = new System.Drawing.Point(110, 69);
				this.fileNameLbl.Name = "fileNameLbl";
				this.fileNameLbl.Size = new System.Drawing.Size(13, 20);
				this.fileNameLbl.TabIndex = 2;
				this.fileNameLbl.Text = ".";
				// 
				// label2
				// 
				this.label2.AutoSize = true;
				this.label2.Location = new System.Drawing.Point(13, 103);
				this.label2.Name = "label2";
				this.label2.Size = new System.Drawing.Size(90, 20);
				this.label2.TabIndex = 3;
				this.label2.Text = "Save Path :";
				// 
				// savePathLbl
				// 
				this.savePathLbl.AutoSize = true;
				this.savePathLbl.Location = new System.Drawing.Point(110, 103);
				this.savePathLbl.Name = "savePathLbl";
				this.savePathLbl.Size = new System.Drawing.Size(13, 20);
				this.savePathLbl.TabIndex = 4;
				this.savePathLbl.Text = ".";
				// 
				// label3
				// 
				this.label3.AutoSize = true;
				this.label3.Location = new System.Drawing.Point(17, 138);
				this.label3.Name = "label3";
				this.label3.Size = new System.Drawing.Size(147, 20);
				this.label3.TabIndex = 5;
				this.label3.Text = "Download Progress";
				// 
				// downloadProgressLbl
				// 
				this.downloadProgressLbl.AutoSize = true;
				this.downloadProgressLbl.Location = new System.Drawing.Point(170, 138);
				this.downloadProgressLbl.Name = "downloadProgressLbl";
				this.downloadProgressLbl.Size = new System.Drawing.Size(13, 20);
				this.downloadProgressLbl.TabIndex = 6;
				this.downloadProgressLbl.Text = ".";
				// 
				// cancelBtn
				// 
				this.cancelBtn.Location = new System.Drawing.Point(771, 129);
				this.cancelBtn.Name = "cancelBtn";
				this.cancelBtn.Size = new System.Drawing.Size(116, 39);
				this.cancelBtn.TabIndex = 7;
				this.cancelBtn.Text = "Cancel";
				this.cancelBtn.UseVisualStyleBackColor = true;
				this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
				// 
				// timerTicker
				// 
				this.timerTicker.Tick += new System.EventHandler(this.timerTicker_Tick);
				// 
				// closeBtn
				// 
				this.closeBtn.Location = new System.Drawing.Point(771, 129);
				this.closeBtn.Name = "closeBtn";
				this.closeBtn.Size = new System.Drawing.Size(116, 39);
				this.closeBtn.TabIndex = 8;
				this.closeBtn.Text = "Close";
				this.closeBtn.UseVisualStyleBackColor = true;
				this.closeBtn.Visible = false;
				this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
				// 
				// restartBtn
				// 
				this.restartBtn.Location = new System.Drawing.Point(649, 129);
				this.restartBtn.Name = "restartBtn";
				this.restartBtn.Size = new System.Drawing.Size(116, 39);
				this.restartBtn.TabIndex = 9;
				this.restartBtn.Text = "Restart";
				this.restartBtn.UseVisualStyleBackColor = true;
				this.restartBtn.Visible = false;
				this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
				// 
				// DownloadProgress
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(899, 185);
				this.Controls.Add(this.restartBtn);
				this.Controls.Add(this.closeBtn);
				this.Controls.Add(this.cancelBtn);
				this.Controls.Add(this.downloadProgressLbl);
				this.Controls.Add(this.label3);
				this.Controls.Add(this.savePathLbl);
				this.Controls.Add(this.label2);
				this.Controls.Add(this.fileNameLbl);
				this.Controls.Add(this.label1);
				this.Controls.Add(this.progressBar);
				this.Name = "DownloadProgress";
				this.Text = "Downloading...";
				this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadProgress_FormClosing);
				this.Load += new System.EventHandler(this.DownloadProgress_Load);
				this.ResumeLayout(false);
				this.PerformLayout();

		  }

		  #endregion

		  private System.Windows.Forms.ProgressBar progressBar;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.Label fileNameLbl;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.Label savePathLbl;
		  private System.Windows.Forms.Label label3;
		  private System.Windows.Forms.Label downloadProgressLbl;
		  private System.Windows.Forms.Button cancelBtn;
		  private System.Windows.Forms.Timer timerTicker;
		  private System.Windows.Forms.Button closeBtn;
		  private System.Windows.Forms.Button restartBtn;
	 }
}