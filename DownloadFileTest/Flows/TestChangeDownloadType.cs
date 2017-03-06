using NUnit.Extensions.Forms;
using NUnit.Framework;

namespace DownloadFileTest.Flows
{
	 [TestFixture, Apartment(System.Threading.ApartmentState.STA)]
	 public class TestChangeDownloadType : BaseMainForm
	 {
		  [Test]
		  public void ChangeDownloadTypeToHTTP()
		  {
				// arrange
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				LabelTester keyLbl = new LabelTester("keyLbl", "MainForm");
				TextBoxTester KeyFilePathTxt = new TextBoxTester("KeyFilePathTxt", "MainForm");
				ButtonTester selectKeyBtn = new ButtonTester("selectKeyBtn", "MainForm");
				ButtonTester clearKeyBtn = new ButtonTester("clearKeyBtn", "MainForm");

				// act
				typeCb.Select(0);

				// assert
				Assert.AreEqual("HTTP", typeCb.Text);
				Assert.IsFalse(keyLbl.Properties.Visible);
				Assert.IsFalse(KeyFilePathTxt.Properties.Visible);
				Assert.IsFalse(selectKeyBtn.Properties.Visible);
				Assert.IsFalse(clearKeyBtn.Properties.Visible);
		  }

		  [Test]
		  public void ChangeDownloadTypeToFTP()
		  {
				// arrange
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				LabelTester keyLbl = new LabelTester("keyLbl", "MainForm");
				TextBoxTester KeyFilePathTxt = new TextBoxTester("KeyFilePathTxt", "MainForm");
				ButtonTester selectKeyBtn = new ButtonTester("selectKeyBtn", "MainForm");
				ButtonTester clearKeyBtn = new ButtonTester("clearKeyBtn", "MainForm");

				// act
				typeCb.Select(1);

				// assert
				Assert.AreEqual("FTP", typeCb.Text);
				Assert.IsFalse(keyLbl.Properties.Visible);
				Assert.IsFalse(KeyFilePathTxt.Properties.Visible);
				Assert.IsFalse(selectKeyBtn.Properties.Visible);
				Assert.IsFalse(clearKeyBtn.Properties.Visible);
		  }

		  [Test]
		  public void ChangeDownloadTypeToSFTP()
		  {
				// arrange
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");
				LabelTester keyLbl = new LabelTester("keyLbl", "MainForm");
				TextBoxTester KeyFilePathTxt = new TextBoxTester("KeyFilePathTxt", "MainForm");
				ButtonTester selectKeyBtn = new ButtonTester("selectKeyBtn", "MainForm");
				ButtonTester clearKeyBtn = new ButtonTester("clearKeyBtn", "MainForm");

				// act
				typeCb.Select(2);

				// assert
				Assert.AreEqual("SFTP", typeCb.Text);
				Assert.IsTrue(keyLbl.Properties.Visible);
				Assert.IsTrue(KeyFilePathTxt.Properties.Visible);
				Assert.IsTrue(selectKeyBtn.Properties.Visible);
				Assert.IsTrue(clearKeyBtn.Properties.Visible);
		  }
	 }
}
