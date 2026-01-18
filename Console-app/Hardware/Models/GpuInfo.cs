namespace WinPostInstall.Hardware.Models;

public class GpuInfo
{
  public string Name { get; set; }
  public ulong Memory { get; set; }
  public string DriverVersion { get; set; }
  public string Chip { get; set; }
  public string Resolution { get; set; }
  public int RefreshRate { get; set; }
  public string Status { get; set; }
}
