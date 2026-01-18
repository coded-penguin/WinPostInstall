namespace WinPostInstall.Hardware.Models;

public class RamModuleInfo
{
  public ulong Capacity { get; set; }
  public int Speed { get; set; }
  public string Manufacturer { get; set; }
  public string PartNumber { get; set; }
  public int MemoryType { get; set; }
  public int FormFactor { get; set; }
}
