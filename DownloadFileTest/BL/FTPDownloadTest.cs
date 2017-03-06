using DownloadFile.BL;
using DownloadFile.Enums;
using DownloadFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading;

namespace DownloadFileTest.BL
{
	 /// <summary>
	 /// Summary description for FTPDownload
	 /// </summary>
	 [TestClass]
	 public class FTPDownloadTest
	 {
		  [TestMethod]
		  public void TestFTPSaveFileSuccess()
		  {
				// arrange
				string outputPath = @"C:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "ftp://52.220.30.8/AWS_Push_Service.p12";
				config.Type = DownloadType.FTP;
				config.Username = "butnow";
				config.Password = "butnow";
				string expectedOutputPath = @"c:\test\ftp\52.220.30.8\AWS_Push_Service.p12";
				ManualResetEvent manualEvent = new ManualResetEvent(false);

				// act
				DownloadBase download = new FTPDownload(config, outputPath);
				download.DownloadCompleted += (status) =>
				{
					 manualEvent.Set();
				};
				download.startDownload();
				manualEvent.WaitOne(2000, false);

				// assert
				Assert.IsTrue(File.Exists(expectedOutputPath));
		  }

		  [TestMethod]
		  public void TestFTPSaveLargeFileSuccess()
		  {
				// arrange
				string outputPath = @"c:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "ftp://52.220.30.8/mongodb-mms-3.4.1.385-1.x86_64.rpm";
				config.Type = DownloadType.FTP;
				config.Username = "butnow";
				config.Password = "butnow";
				string expectedOutputPath = @"c:\test\ftp\52.220.30.8\mongodb-mms-3.4.1.385-1.x86_64.rpm";
				ManualResetEvent manualEvent = new ManualResetEvent(false);
				bool isStartDownload = false;

				// act
				DownloadBase download = new FTPDownload(config, outputPath);
				download.DownloadProgress += (percentageProgress) =>
				{
					 isStartDownload = true;
					 manualEvent.Set();
				};
				download.startDownload();
				manualEvent.WaitOne(10000, false);

				// assert
				Assert.IsFalse(File.Exists(expectedOutputPath));
				Assert.IsTrue(isStartDownload);
		  }
	 }
}
