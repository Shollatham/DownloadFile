using DownloadFile.BL;
using DownloadFile.Enums;
using DownloadFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading;

namespace DownloadFileTest.BL
{
	 [TestClass]
	 public class SFTPDownloadTest
	 {
		  [TestMethod]
		  public void TestSFTPSaveFileSuccess()
		  {
				// arrange
				string outputPath = @"C:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "sftp://52.220.30.8/home/ec2-user/ec2key";
				config.Type = DownloadType.SFTP;
				config.Username = "ec2-user";
				config.KeyPath = @"parse.pem";
				string expectedOutputPath = @"c:\test\sftp\52.220.30.8\home\ec2-user\ec2key";
				ManualResetEvent manualEvent = new ManualResetEvent(false);

				// act
				DownloadBase download = new SFTPDownload(config, outputPath);
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
		  public void TestSFTPSaveLargeFileSuccess()
		  {
				// arrange
				string outputPath = @"C:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "sftp://52.220.30.8/home/ec2-user/mongodb-mms-3.4.1.385-1.x86_64.rpm";
				config.Type = DownloadType.SFTP;
				config.Username = "ec2-user";
				config.KeyPath = @"parse.pem";
				string expectedOutputPath = @"c:\test\sftp\52.220.30.8\home\ec2-user\mongodb-mms-3.4.1.385-1.x86_64.rpm";
				ManualResetEvent manualEvent = new ManualResetEvent(false);
				bool isStartDownload = false;

				// act
				DownloadBase download = new SFTPDownload(config, outputPath);
				download.DownloadCompleted += (status) =>
				{
					 manualEvent.Set();
				};
				download.DownloadProgress += (percentageProgress) =>
				{
					 isStartDownload = true;
					 manualEvent.Set();
				};
				download.startDownload();
				manualEvent.WaitOne(20000, false);

				// assert
				Assert.IsFalse(File.Exists(expectedOutputPath));
				Assert.IsTrue(isStartDownload);
		  }

		  private void Download_DownloadCompleted(DownloadStatus status)
		  {
				throw new System.NotImplementedException();
		  }
	 }
}
