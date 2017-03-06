using DownloadFile.Models;
using System;
using System.Net;

namespace DownloadFile.BL
{
	 public class FTPDownload : HTTPDownload
	 {
		  public FTPDownload(DownloadConfig config, String SaveDirectory) : base(config, SaveDirectory)
		  {
				this.webClient.Credentials = new NetworkCredential(downloadConfig.Username, downloadConfig.Password);
		  }
	 }
}
