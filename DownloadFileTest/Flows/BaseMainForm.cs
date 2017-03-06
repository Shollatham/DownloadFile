using DownloadFile;
using DownloadFile.BL;
using DownloadFile.Models;
using DownloadFile.Views;
using Moq;
using NUnit.Framework;

namespace DownloadFileTest.Flows
{
	 [TestFixture, Apartment(System.Threading.ApartmentState.STA)]
	 public class BaseMainForm
	 {
		  protected MainFormTester mainForm;

		  [SetUp]
		  public void Setup()
		  {
				mainForm = new MainFormTester();
				mainForm.Show();

		  }

		  [TearDown]
		  public void TearDown()
		  {
				mainForm.Close();
				mainForm.Dispose();
		  }
	 }

	 // Modify class for test
	 public class MainFormTester : MainForm
	 {
		  public Mock<DownloadBase> downloadMock { get; set; }

		  public MainFormTester()
		  {
				downloadMock = new Mock<DownloadBase>(null, null);
		  }

		  protected override DownloadProgress CreateDownloadProgress(DownloadConfig config, string outputPath)
		  {
				return new DownloadProgressTester(config, outputPath, downloadMock.Object);
		  }
	 }

	 public class DownloadProgressTester : DownloadProgress
	 {
		  public DownloadProgressTester(DownloadConfig DownloadConfig, string SaveDirectory, DownloadBase download) : base(DownloadConfig, SaveDirectory) {
				this.download = download;
				this.download.downloadConfig = DownloadConfig;
				this.download.SaveDirectory = SaveDirectory;
		  }

		  protected override void CreateDownloadBL()
		  {
				return;
		  }
	 }
}
