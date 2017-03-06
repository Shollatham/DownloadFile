using DownloadFile.Enums;
using DownloadFile.Models;
using System;
using System.ComponentModel;
using System.Net;

namespace DownloadFile.BL
{
	 public class HTTPDownload : DownloadBase
	 {
		  protected WebClient webClient = new WebClient();

		  public HTTPDownload(DownloadConfig config, String SaveDirectory) : base(config, SaveDirectory)
		  {
				webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
				webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
		  }

		  public override void startDownload()
		  {
				webClient.DownloadFileAsync(new Uri(downloadConfig.URL), this.getTempDirectorySavePath());
		  }

		  public override void stopDownload()
		  {
				if (this.webClient.IsBusy)
				{
					 this.webClient.CancelAsync();
				}
		  }

		  private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		  {
				this.NotifyDownloadProgress(e.ProgressPercentage);
		  }

		  private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		  {
				if (e.Cancelled)
				{
					 this.NotifyDownloadCompleted(DownloadStatus.CANCEL);
				}
				else if (e.Error != null)
				{
					 this.NotifyDownloadCompleted(DownloadStatus.ERROR);
				}
				else
				{
					 this.NotifyDownloadCompleted(DownloadStatus.SUCCESS);
				}
		  }
	 }
}
