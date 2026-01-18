namespace WinPostInstall.Hardware.Models;

public class DiskInfo
{
  public string Model { get; set; }
  public ulong Size { get; set; }
  public string InterfaceType { get; set; }
  public string Serial { get; set; }
  public string Firmware { get; set; }
}
