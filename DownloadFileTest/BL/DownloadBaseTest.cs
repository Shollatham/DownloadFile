using DownloadFile.BL;
using DownloadFile.Enums;
using DownloadFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DownloadFileTest.BL
{
	 [TestClass]
	 public class DownloadBaseTest
	 {
		  [TestMethod]
		  public void TestOutputPath()
		  {
				// arrange
				string outputPath = @"c:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				config.Type = DownloadType.HTTP;

				// act
				DownloadBase download = new HTTPDownload(config, outputPath);

				// assert
				Assert.AreEqual(outputPath, download.SaveDirectory);
		  }

		  [TestMethod]
		  public void TestSaveFilePath()
		  {
				// arrange
				string outputPath = @"c:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				config.Type = DownloadType.HTTP;
				string expectedOutputPath = @"c:\test\https\s3-ap-southeast-1.amazonaws.com\scb-ioffice\Dashboard\index.html";

				// act
				DownloadBase download = new HTTPDownload(config, outputPath);

				// assert
				Assert.AreEqual(expectedOutputPath, download.getSavePath());
		  }

		  [TestMethod]
		  public void TestSaveFileName()
		  {
				// arrange
				string outputPath = @"c:\test";
				DownloadConfig config = new DownloadConfig();
				config.URL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				config.Type = DownloadType.HTTP;
				string expectedFileName = @"index.html";

				// act
				DownloadBase download = new HTTPDownload(config, outputPath);

				// assert
				Assert.AreEqual(expectedFileName, download.getDownloadFileName());
		  }
	 }
}
