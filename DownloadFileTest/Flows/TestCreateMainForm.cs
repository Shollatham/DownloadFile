using NUnit.Extensions.Forms;
using NUnit.Framework;

namespace DownloadFileTest.Flows
{
	 [TestFixture, Apartment(System.Threading.ApartmentState.STA)]
	 public class TestCreateMainForm : BaseMainForm
	 {
		  [Test]
		  public void CreateMainForm()
		  {
				// arrange
				TextBoxTester urlTxt = new TextBoxTester("urlTxt", "MainForm");
				TextBoxTester outputPathTxt = new TextBoxTester("outputPathTxt", "MainForm");
				ButtonTester startDownloadBtn = new ButtonTester("startDownloadBtn", "MainForm");
				ButtonTester removeDownloadBtn = new ButtonTester("removeDownloadBtn", "MainForm");
				ButtonTester addDownloadBtn = new ButtonTester("addDownloadBtn", "MainForm");
				ButtonTester selectOutputBtn = new ButtonTester("selectOutputBtn", "MainForm");
				ButtonTester selectKeyBtn = new ButtonTester("selectKeyBtn", "MainForm");
				ButtonTester clearKeyBtn = new ButtonTester("clearKeyBtn", "MainForm");
				ComboBoxTester typeCb = new ComboBoxTester("typeCB", "MainForm");

				// assert
				Assert.IsTrue(urlTxt.Properties.Visible);
				Assert.IsTrue(outputPathTxt.Properties.Visible);
				Assert.AreEqual("Download File", mainForm.Text);
				Assert.AreEqual("Start Download", startDownloadBtn.Text);
				Assert.IsTrue(startDownloadBtn.Properties.Visible);
				Assert.AreEqual("Remove", removeDownloadBtn.Text);
				Assert.IsTrue(removeDownloadBtn.Properties.Visible);
				Assert.AreEqual("Add", addDownloadBtn.Text);
				Assert.IsTrue(addDownloadBtn.Properties.Visible);
				Assert.AreEqual("Select", selectOutputBtn.Text);
				Assert.IsTrue(selectOutputBtn.Properties.Visible);
				Assert.AreEqual("Select", selectKeyBtn.Text);
				Assert.IsFalse(selectKeyBtn.Properties.Visible);
				Assert.AreEqual("Clear", clearKeyBtn.Text);
				Assert.IsFalse(clearKeyBtn.Properties.Visible);
				Assert.AreEqual("HTTP", typeCb.Text);
				Assert.IsTrue(typeCb.Properties.Visible);
		  }
	 }
}
