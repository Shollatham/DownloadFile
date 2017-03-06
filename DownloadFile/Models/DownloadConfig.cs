using DownloadFile.Enums;

namespace DownloadFile.Models
{
	 public class DownloadConfig
	 {
		  public string URL { get; set; }
		  public DownloadType Type { get; set; }
		  public string Username { get; set; }
		  public string Password { get; set; }
		  public string KeyPath { get; set; }
		  public bool Downloading { get; set; }
		  public bool Completed { get; set; }
	 }
}
