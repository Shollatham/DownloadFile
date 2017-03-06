using DownloadFile.Enums;
using DownloadFile.Models;
using Moq;
using NUnit.Extensions.Forms;
using NUnit.Framework;

namespace DownloadFileTest.Flows
{
	 [TestFixture, Apartment(System.Threading.ApartmentState.STA)]
	 public class TestDownload : BaseMainForm
	 {
		  [Test]
		  public void DownloadFailedAndClose()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() =>
				{
					 mainForm.downloadMock.Object.NotifyDownloadProgress(50);
					 mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.ERROR);
				});
				string fileURL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				string outputPath = "c:\\test";

				// Step 1 Config Download
				// act
				urlTxt.Enter(fileURL);
				outputPathTxt.Enter(outputPath);
				addDownloadBtn.Click();
				startDownloadBtn.Click();
				FormTester downloadProgress = new FormTester("DownloadProgress");
				ButtonTester restartBtn = new ButtonTester("restartBtn", "DownloadProgress");
				ButtonTester closeBtn = new ButtonTester("closeBtn", "DownloadProgress");

				// assert
				DownloadConfig config = mainForm.downloadConfigList[0];
				Assert.IsFalse(config.Completed);
				Assert.IsTrue(config.Downloading);
				Assert.AreEqual("50% Download Error!!", downloadProgress.Text);
				Assert.IsTrue(restartBtn.Properties.Visible);
				Assert.IsTrue(closeBtn.Properties.Visible);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Once);

				// Step 2 Close Download Form
				// act
				closeBtn.Click();

				// assert
				Assert.IsFalse(config.Completed);
				Assert.IsFalse(config.Downloading);
		  }

		  [Test]
		  public void DownloadFailedAndRetry()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() =>
				{
					 mainForm.downloadMock.Object.NotifyDownloadProgress(50);
					 mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.ERROR);
				});
				string fileURL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				string outputPath = "c:\\test";

				// Step 1 Config Download
				// act
				urlTxt.Enter(fileURL);
				outputPathTxt.Enter(outputPath);
				addDownloadBtn.Click();
				startDownloadBtn.Click();
				FormTester downloadProgress = new FormTester("DownloadProgress");
				ButtonTester restartBtn = new ButtonTester("restartBtn", "DownloadProgress");
				ButtonTester closeBtn = new ButtonTester("closeBtn", "DownloadProgress");

				// assert
				DownloadConfig config = mainForm.downloadConfigList[0];
				Assert.IsFalse(config.Completed);
				Assert.IsTrue(config.Downloading);
				Assert.AreEqual("50% Download Error!!", downloadProgress.Text);
				Assert.IsTrue(restartBtn.Properties.Visible);
				Assert.IsTrue(closeBtn.Properties.Visible);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Once);

				// Step 2 Retry Download Form
				// arrange
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() => mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.SUCCESS));

				// act
				restartBtn.Click();

				// assert
				Assert.AreEqual("100% Download Completed", downloadProgress.Text);
				Assert.IsTrue(config.Completed);
				Assert.IsTrue(config.Downloading);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Exactly(2));

				// Step 4 Close Download Form
				// act
				closeBtn.Click();

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsFalse(config.Downloading);
		  }
	 }
}
