using DownloadFile.BL;
using DownloadFile.Enums;
using DownloadFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading;

namespace DownloadFileTest.BL
{
	 [TestClass]
	 public class HTTPDownloadTest
	 {
		  [TestMethod]
		  public void TestHTTPSaveFileSuccess()
		  {
				// arrange
				string outputPath = @"C:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				config.Type = DownloadType.HTTP;
				string expectedOutputPath = @"c:\test\https\s3-ap-southeast-1.amazonaws.com\scb-ioffice\Dashboard\index.html";
				ManualResetEvent manualEvent = new ManualResetEvent(false);

				// act
				DownloadBase download = new HTTPDownload(config, outputPath);
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
		  public void TestHTTPSaveLargeFileSuccess()
		  {
				// arrange
				string outputPath = @"C:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/BUTNOW-Android/apk/BUTNOW-86.apk";
				config.Type = DownloadType.HTTP;
				string expectedOutputPath = @"C:\test\https\s3-ap-southeast-1.amazonaws.com\scb-ioffice\BUTNOW-Android\apk\BUTNOW-86.apk";
				ManualResetEvent manualEvent = new ManualResetEvent(false);

				// act
				DownloadBase download = new HTTPDownload(config, outputPath);
				download.DownloadCompleted += (status) =>
				{
					 manualEvent.Set();
				};
				download.startDownload();
				manualEvent.WaitOne(2000, false);

				// assert
				Assert.IsTrue(File.Exists(expectedOutputPath));
		  }
	 }
}
