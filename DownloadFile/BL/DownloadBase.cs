using DownloadFile.BL.Delegate;
using DownloadFile.Enums;
using DownloadFile.Models;
using System.IO;
using System.Linq;

namespace DownloadFile.BL
{
	 abstract public class DownloadBase
	 {
		  #region event
		  public event DownloadProgressEventHandler DownloadProgress;
		  public event DownloadCompletedEventHandler DownloadCompleted;
		  #endregion

		  #region init
		  public DownloadConfig downloadConfig { get; set; }
		  public string SaveDirectory { get; set; }
		  protected string TempDirectory = "c:\\tmp";

		  public DownloadBase(DownloadConfig config, string SaveDirectory)
		  {
				this.downloadConfig = config;
				this.SaveDirectory = SaveDirectory;
		  }
		  #endregion

		  #region base method
		  public string getDownloadFileName()
		  {
				return Path.GetFileName(this.downloadConfig.URL);
		  }

		  public string getSavePath()
		  {
				string saveDir = generateCorrectPath(this.SaveDirectory);
				return Path.Combine(saveDir, getDownloadFileName());
		  }

		  protected string getTempDirectorySavePath()
		  {
				string saveDir = generateCorrectPath(this.TempDirectory);
				return Path.Combine(saveDir, getDownloadFileName());
		  }

		  private string generateCorrectPath(string baseDirectory)
		  {
				string saveDir = Path.Combine(baseDirectory, Path.GetDirectoryName(this.downloadConfig.URL).Replace(":", ""));
				if (Directory.Exists(saveDir) == false)
				{
					 Directory.CreateDirectory(saveDir);
				}
				return saveDir;
		  }

		  public void NotifyDownloadProgress(int percentageProgress)
		  {
				if (this.DownloadProgress != null && this.DownloadProgress.GetInvocationList().Count() > 0)
				{
					 this.DownloadProgress(percentageProgress);
				}
		  }

		  public void NotifyDownloadCompleted(DownloadStatus status)
		  {
				string fileOnTemp = getTempDirectorySavePath();
				if (File.Exists(fileOnTemp))
				{
					 if (status == DownloadStatus.SUCCESS)
					 {
						  File.Copy(fileOnTemp, getSavePath(), true);
					 }
					 File.Delete(fileOnTemp);
				}
				if (this.DownloadCompleted != null && this.DownloadCompleted.GetInvocationList().Count() > 0)
				{
					 this.DownloadCompleted(status);
				}
		  }
		  #endregion

		  #region need to implement
		  abstract public void startDownload();
		  abstract public void stopDownload();
		  #endregion
	 }
}
