using DownloadFile.Enums;
using DownloadFile.Models;
using Moq;
using NUnit.Extensions.Forms;
using NUnit.Framework;

namespace DownloadFileTest.Flows
{
	 [TestFixture, Apartment(System.Threading.ApartmentState.STA)]
	 public class TestDownloadSuccess : BaseMainForm
	 {
		  [Test]
		  public void HTTPDownloadSuccess()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				string fileURL = "https://s3-ap-southeast-1.amazonaws.com/scb-ioffice/Dashboard/index.html";
				string outputPath = "c:\\test";

				// Step 1 Config Download
				// act
				urlTxt.Enter(fileURL);
				outputPathTxt.Enter(outputPath);
				addDownloadBtn.Click();

				// assert
				Assert.AreEqual("HTTP", typeCb.Text);
				Assert.AreEqual(1, mainForm.downloadConfigList.Count);

				DownloadConfig config = mainForm.downloadConfigList[0];
				Assert.IsFalse(config.Completed);
				Assert.IsFalse(config.Downloading);
				Assert.AreEqual(DownloadType.HTTP, config.Type);
				Assert.AreEqual(fileURL, config.URL);
				Assert.IsNull(config.KeyPath);
				Assert.IsNull(config.Username);
				Assert.IsNull(config.Password);

				// Step 2 Start Download
				// arrange
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() => mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.SUCCESS));

				// act
				startDownloadBtn.Click();
				FormTester downloadProgress = new FormTester("DownloadProgress");

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsTrue(config.Downloading);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Once);
				Assert.AreEqual("100% Download Completed", downloadProgress.Text);

				// Step 3 Close Download Form
				// arrange
				ButtonTester close = new ButtonTester("closeBtn", "DownloadProgress");

				// act
				close.Click();

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsFalse(config.Downloading);
		  }

		  [Test]
		  public void FTPDownloadSuccess()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				TextBoxTester userNameTxt = new TextBoxTester("userNameTxt", "MainForm");
				TextBoxTester passwordTxt = new TextBoxTester("passwordTxt", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				string fileURL = "ftp://52.220.30.8/AWS_Push_Service.p12";
				string outputPath = "c:\\test";
				string username = "test";
				string password = "test";

				// Step 1 Config Download
				// act
				urlTxt.Enter(fileURL);
				outputPathTxt.Enter(outputPath);
				userNameTxt.Enter(username);
				passwordTxt.Enter(password);
				addDownloadBtn.Click();

				// assert
				Assert.AreEqual("FTP", typeCb.Text);
				Assert.AreEqual(1, mainForm.downloadConfigList.Count);
				Assert.AreEqual(username, userNameTxt.Text);
				Assert.AreEqual(password, passwordTxt.Text);

				DownloadConfig config = mainForm.downloadConfigList[0];
				Assert.IsFalse(config.Completed);
				Assert.IsFalse(config.Downloading);
				Assert.AreEqual(DownloadType.FTP, config.Type);
				Assert.AreEqual(fileURL, config.URL);
				Assert.IsNull(config.KeyPath);
				Assert.AreEqual(username, config.Username);
				Assert.AreEqual(password, config.Password);

				// Step 2 Start Download
				// arrange
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() => mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.SUCCESS));

				// act
				startDownloadBtn.Click();
				FormTester downloadProgress = new FormTester("DownloadProgress");

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsTrue(config.Downloading);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Once);
				Assert.AreEqual("100% Download Completed", downloadProgress.Text);

				// Step 3 Close Download Form
				// arrange
				ButtonTester close = new ButtonTester("closeBtn", "DownloadProgress");

				// act
				close.Click();

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsFalse(config.Downloading);
		  }

		  [Test]
		  public void SFTPDownloadSuccess()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				TextBoxTester userNameTxt = new TextBoxTester("userNameTxt", "MainForm");
				TextBoxTester passwordTxt = new TextBoxTester("passwordTxt", "MainForm");
				TextBoxTester KeyFilePathTxt = new TextBoxTester("KeyFilePathTxt", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				string fileURL = "sftp://52.220.30.8/home/ec2-user/ec2key";
				string outputPath = "c:\\test";
				string username = "test";
				string password = "test";
				string key = "c:\\parse.pem";

				// Step 1 Config Download
				// act
				urlTxt.Enter(fileURL);
				outputPathTxt.Enter(outputPath);
				userNameTxt.Enter(username);
				passwordTxt.Enter(password);
				KeyFilePathTxt.Enter(key);
				addDownloadBtn.Click();

				// assert
				Assert.AreEqual("SFTP", typeCb.Text);
				Assert.AreEqual(1, mainForm.downloadConfigList.Count);
				Assert.AreEqual(username, userNameTxt.Text);
				Assert.AreEqual(password, passwordTxt.Text);
				Assert.AreEqual(key, KeyFilePathTxt.Text);

				DownloadConfig config = mainForm.downloadConfigList[0];
				Assert.IsFalse(config.Completed);
				Assert.IsFalse(config.Downloading);
				Assert.AreEqual(DownloadType.SFTP, config.Type);
				Assert.AreEqual(fileURL, config.URL);
				Assert.AreEqual(key, config.KeyPath);
				Assert.AreEqual(username, config.Username);
				Assert.IsNull(config.Password);

				// Step 2 Start Download
				// arrange
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				mainForm.downloadMock.Setup(download => download.startDownload()).Callback(() => mainForm.downloadMock.Object.NotifyDownloadCompleted(DownloadStatus.SUCCESS));

				// act
				startDownloadBtn.Click();
				FormTester downloadProgress = new FormTester("DownloadProgress");

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsTrue(config.Downloading);
				mainForm.downloadMock.Verify(download => download.startDownload(), Times.Once);
				Assert.AreEqual("100% Download Completed", downloadProgress.Text);

				// Step 3 Close Download Form
				// arrange
				ButtonTester close = new ButtonTester("closeBtn", "DownloadProgress");

				// act
				close.Click();

				// assert
				Assert.IsTrue(config.Completed);
				Assert.IsFalse(config.Downloading);
		  }
	 }
}
