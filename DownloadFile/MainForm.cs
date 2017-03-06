using DownloadFile.Enums;
using DownloadFile.Models;
using DownloadFile.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DownloadFile
{
	 public partial class MainForm : Form
	 {
		  public List<DownloadConfig> downloadConfigList = new List<DownloadConfig>();

		  #region init
		  public MainForm()
		  {
				InitializeComponent();
				typeCB.Items.Add(DownloadType.HTTP);
				typeCB.Items.Add(DownloadType.FTP);
				typeCB.Items.Add(DownloadType.SFTP);
				typeCB.SelectedItem = DownloadType.HTTP;
		  }
		  #endregion

		  #region event handler
		  private void typeCB_SelectedIndexChanged(object sender, EventArgs e)
		  {
				if (typeCB.SelectedItem == null)
				{
					 return;
				}
				if ((DownloadType)typeCB.SelectedItem == DownloadType.HTTP)
				{
					 credentialGb.Visible = false;
				}
				else
				{
					 credentialGb.Visible = true;
				}
				if ((DownloadType)typeCB.SelectedItem == DownloadType.SFTP)
				{
					 keyLbl.Visible = true;
					 KeyFilePathTxt.Visible = true;
					 selectKeyBtn.Visible = true;
					 clearKeyBtn.Visible = true;
				}
				else
				{
					 keyLbl.Visible = false;
					 KeyFilePathTxt.Visible = false;
					 selectKeyBtn.Visible = false;
					 clearKeyBtn.Visible = false;
				}
		  }

		  private void urlTxt_Leave(object sender, EventArgs e)
		  {
				changeType();
		  }

		  private void urlTxt_KeyDown(object sender, KeyEventArgs e)
		  {
				if (e.KeyCode == Keys.Return)
				{
					 changeType();
				}
		  }

		  private void selectKeyBtn_Click(object sender, EventArgs e)
		  {
				OpenFileDialog opd = new OpenFileDialog();
				opd.Filter = "Certificate files | *.pem";
				if (opd.ShowDialog() == DialogResult.OK)
				{
					 KeyFilePathTxt.Text = opd.FileName;
				}
		  }

		  private void clearKeyBtn_Click(object sender, EventArgs e)
		  {
				KeyFilePathTxt.Text = "";
		  }

		  private void selectOutputBtn_Click(object sender, EventArgs e)
		  {
				FolderBrowserDialog fbd = new FolderBrowserDialog();
				fbd.ShowNewFolderButton = true;
				fbd.SelectedPath = outputPathTxt.Text;
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					 outputPathTxt.Text = fbd.SelectedPath;
				}
		  }

		  private void addDownloadBtn_Click(object sender, EventArgs e)
		  {
				if (ValidateInput())
				{
					 DownloadConfig downloadConfig = new DownloadConfig();
					 downloadConfig.URL = urlTxt.Text;
					 downloadConfig.Type = (DownloadType)typeCB.SelectedItem;
					 if ((DownloadType)typeCB.SelectedItem != DownloadType.HTTP)
					 {
						  downloadConfig.Username = userNameTxt.Text;
						  if ((DownloadType)typeCB.SelectedItem == DownloadType.SFTP && KeyFilePathTxt.Text != "")
						  {
								downloadConfig.KeyPath = KeyFilePathTxt.Text;
						  }
						  else
						  {
								downloadConfig.Password = passwordTxt.Text;
						  }
					 }
					 downloadConfigList.Add(downloadConfig);
					 UpdateDownloadListGV();
				}
		  }

		  private void removeDownloadBtn_Click(object sender, EventArgs e)
		  {
				if (downloadListGv.SelectedCells.Count == 0)
				{
					 return;
				}
				DataGridViewCell selected = downloadListGv.SelectedCells[0];
				downloadConfigList.RemoveAt(selected.RowIndex);
				UpdateDownloadListGV();
		  }

		  private void startDownloadBtn_Click(object sender, EventArgs e)
		  {
				if (outputPathTxt.Text.Trim().Length == 0)
				{
					 MessageBox.Show("Please enter the output path.", "Wrong output");
					 return;
				}
				foreach (DownloadConfig config in downloadConfigList)
				{
					 if (config.Downloading == false && config.Completed == false)
					 {
						  DownloadProgress progressForm = CreateDownloadProgress(config, outputPathTxt.Text);
						  progressForm.FormClosed += ProgressForm_FormClosed;
						  progressForm.Show();
						  config.Downloading = true;
					 }
				}
				UpdateDownloadListGV();
		  }

		  private void ProgressForm_FormClosed(object sender, FormClosedEventArgs e)
		  {
				UpdateDownloadListGV();
		  }
		  #endregion

		  #region helper
		  private bool ValidateInput()
		  {
				if (urlTxt.Text.Trim().Length == 0 || typeCB.SelectedItem == null)
				{
					 MessageBox.Show("Please enter the correct input.", "Wrong input");
					 return false;
				}
				if (downloadConfigList.Exists(config => config.URL == urlTxt.Text))
				{
					 MessageBox.Show("Please enter the different URL.", "Dupicate URL");
					 return false;
				}

				return true;
		  }

		  private void changeType()
		  {
				String url = urlTxt.Text.ToUpper();
				if (url.StartsWith("HTTP"))
				{
					 typeCB.SelectedItem = DownloadType.HTTP;
				}
				else if (url.StartsWith("FTP"))
				{
					 typeCB.SelectedItem = DownloadType.FTP;
				}
				else if (url.StartsWith("SFTP"))
				{
					 typeCB.SelectedItem = DownloadType.SFTP;
				}
				else
				{
					 typeCB.SelectedItem = null;
				}
		  }

		  private void UpdateDownloadListGV()
		  {
				downloadListGv.DataSource = null;
				if (downloadConfigList.Count > 0)
				{
					 downloadListGv.DataSource = downloadConfigList;
				}
		  }

		  protected virtual DownloadProgress CreateDownloadProgress(DownloadConfig config, string outputPath)
		  {
				return new DownloadProgress(config, outputPath);
		  }

		  #endregion

	 }
}
