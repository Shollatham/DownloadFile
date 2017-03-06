using DownloadFile.Enums;
using DownloadFile.Models;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.ComponentModel;
using System.IO;
using System.Timers;

namespace DownloadFile.BL
{
	 public class SFTPDownload : DownloadBase
	 {
		  protected SftpClient client;
		  private string host;
		  private string filePath;
		  private BackgroundWorker worker;
		  private SftpDownloadAsyncResult asyncResult;
		  private SftpFileAttributes fileInfo;
		  private int second = 0;
		  private Timer timer;

		  public SFTPDownload(DownloadConfig config, String SaveDirectory) : base(config, SaveDirectory)
		  {
				string temp = downloadConfig.URL.Substring(downloadConfig.URL.IndexOf("://") + 3);
				host = temp.Substring(0, temp.IndexOf("/"));
				filePath = temp.Substring(temp.IndexOf("/"));
				if (downloadConfig.KeyPath != null)
				{
					 PrivateKeyFile pvKey = new PrivateKeyFile(downloadConfig.KeyPath);
					 client = new SftpClient(host, downloadConfig.Username, pvKey);
				}
				else
				{
					 client = new SftpClient(host, downloadConfig.Username, downloadConfig.Password);
				}
				client.ErrorOccurred += Client_ErrorOccurred;
				timer = new Timer();
				timer.Interval = 1000;
				timer.Elapsed += Timer_Elapsed;
				worker = new BackgroundWorker();
				worker.WorkerReportsProgress = true;
				worker.WorkerSupportsCancellation = true;
				worker.DoWork += Worker_DoWork;
				worker.ProgressChanged += Worker_ProgressChanged;
				worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
		  }

		  private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		  {
				second++;
		  }

		  public override void startDownload()
		  {
				try
				{
					 if (client.IsConnected == false)
					 {
						  client.Connect();
					 }
					 second = 0;
					 timer.Start();
					 worker.RunWorkerAsync();
				}
				catch (Exception ex)
				{
					 if (client.IsConnected == true)
					 {
						  client.Disconnect();
					 }
					 throw ex;
				}
		  }

		  private void Worker_DoWork(object sender, DoWorkEventArgs e)
		  {
				using (var file = File.OpenWrite(this.getTempDirectorySavePath()))
				{
					 fileInfo = client.GetAttributes(filePath);
					 asyncResult = (SftpDownloadAsyncResult)client.BeginDownloadFile(filePath, file);
					 int oldSecond = 0;
					 while (!asyncResult.IsCompleted)
					 {
						  int percent = Convert.ToInt32((Convert.ToInt64(asyncResult.DownloadedBytes) * 100 / fileInfo.Size));
						  if (oldSecond != second)
						  {
								oldSecond = second;
								worker.ReportProgress(percent);
						  }
					 }
					 client.EndDownloadFile(asyncResult);
				}
		  }

		  private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		  {
				this.NotifyDownloadProgress(e.ProgressPercentage);
		  }

		  private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		  {
				if (asyncResult.IsDownloadCanceled)
				{
					 this.NotifyDownloadCompleted(DownloadStatus.CANCEL);
				}
				else if (asyncResult.IsCompleted)
				{
					 this.NotifyDownloadCompleted(DownloadStatus.SUCCESS);
				}
				else
				{
					 this.NotifyDownloadCompleted(DownloadStatus.ERROR);
				}
				if (client.IsConnected)
				{
					 client.Disconnect();
				}
				timer.Stop();
		  }

		  private void Client_ErrorOccurred(object sender, Renci.SshNet.Common.ExceptionEventArgs e)
		  {
				if (asyncResult != null && asyncResult.IsCompleted == false)
				{
					 client.EndDownloadFile(asyncResult);
				}
				if (client.IsConnected)
				{
					 client.Disconnect();
				}
				this.NotifyDownloadCompleted(DownloadStatus.ERROR);
				timer.Stop();
		  }

		  public override void stopDownload()
		  {
				if (asyncResult != null)
				{
					 asyncResult.IsDownloadCanceled = true;
					 if (asyncResult.IsCompleted == false)
					 {
						  client.EndDownloadFile(asyncResult);
					 }
				}
				timer.Stop();
		  }
	 }
}
