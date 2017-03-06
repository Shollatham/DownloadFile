using DownloadFile.BL;
using DownloadFile.Enums;
using DownloadFile.Models;
using System;
using System.Windows.Forms;

namespace DownloadFile.Views
{
	 public partial class DownloadProgress : Form
	 {
		  public DownloadConfig DownloadConfig { get; set; }
		  public string SaveDirectory;
		  protected DownloadBase download;
		  public int Timer = 0;

		  #region init
		  public DownloadProgress(DownloadConfig DownloadConfig, string SaveDirectory)
		  {
				InitializeComponent();
				this.DownloadConfig = DownloadConfig;
				this.SaveDirectory = SaveDirectory;
		  }

		  private void DownloadProgress_Load(object sender, EventArgs e)
		  {
				CreateDownloadBL();
				try
				{
					 download.DownloadProgress += Download_DownloadProgress;
					 download.DownloadCompleted += Download_DownloadCompleted;
					 fileNameLbl.Text = download.getDownloadFileName();
					 savePathLbl.Text = download.getSavePath();
					 download.startDownload();
					 timerTicker.Start();
				}
				catch (Exception ex)
				{
					 timerTicker.Stop();
					 MessageBox.Show(ex.Message, "Download Error!!");
					 Download_DownloadCompleted(DownloadStatus.ERROR);
				}
		  }
		  #endregion

		  #region event handler
		  private void Download_DownloadProgress(int percentageProgress)
		  {
				downloadProgressLbl.Invoke(new Action(() =>
				{
					 downloadProgressLbl.Text = String.Format("{0} % Download Time {1} seconds.", percentageProgress, Timer);
					 this.Text = String.Format("{0}% Downloading...", percentageProgress);
				}));
				progressBar.Invoke(new Action(() =>
				{
					 progressBar.Value = percentageProgress;
				}));
		  }

		  private void Download_DownloadCompleted(DownloadStatus status)
		  {
				timerTicker.Stop();
				cancelBtn.Visible = false;
				if (status == DownloadStatus.SUCCESS)
				{
					 this.Text = "100% Download Completed";
					 DownloadConfig.Completed = true;
					 closeBtn.Visible = true;
					 restartBtn.Visible = false;
				}
				else if (status == DownloadStatus.CANCEL)
				{
					 this.Text = progressBar.Value + "% Download cancelled";
					 closeBtn.Visible = true;
					 restartBtn.Visible = true;
				}
				else if (status == DownloadStatus.ERROR)
				{
					 this.Text = progressBar.Value + "% Download Error!!";
					 closeBtn.Visible = true;
					 restartBtn.Visible = true;
				}
		  }

		  private void DownloadProgress_FormClosing(object sender, FormClosingEventArgs e)
		  {
				if (download != null)
				{
					 download.stopDownload();
				}
				DownloadConfig.Downloading = false;
		  }

		  private void timerTicker_Tick(object sender, EventArgs e)
		  {
				Timer++;
		  }

		  private void cancelBtn_Click(object sender, EventArgs e)
		  {
				if (download != null)
				{
					 download.stopDownload();
				}
		  }

		  private void restartBtn_Click(object sender, EventArgs e)
		  {
				try
				{
					 Timer = 0;
					 cancelBtn.Visible = true;
					 closeBtn.Visible = false;
					 restartBtn.Visible = false;
					 download.startDownload();
					 timerTicker.Start();
				}
				catch (Exception ex)
				{
					 timerTicker.Stop();
					 MessageBox.Show(ex.Message, "Download Error!!");
					 Download_DownloadCompleted(DownloadStatus.ERROR);
				}
		  }

		  private void closeBtn_Click(object sender, EventArgs e)
		  {
				this.Close();
		  }
		  #endregion

		  #region helper
		  protected virtual void CreateDownloadBL()
		  {
				if (DownloadConfig.Type == DownloadType.FTP)
				{
					 download = new FTPDownload(DownloadConfig, SaveDirectory);
				}
				else if (DownloadConfig.Type == DownloadType.SFTP)
				{
					 download = new SFTPDownload(DownloadConfig, SaveDirectory);
				}
				else
				{
					 download = new HTTPDownload(DownloadConfig, SaveDirectory);
				}
		  }
		  #endregion
	 }
}
