using DownloadFile.Enums;

namespace DownloadFile.BL.Delegate
{
	 public delegate void DownloadProgressEventHandler(int percentageProgress);
	 public delegate void DownloadCompletedEventHandler(DownloadStatus status);
}
