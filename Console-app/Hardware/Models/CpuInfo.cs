namespace WinPostInstall.Hardware.Models;

public class CpuInfo
{
  public string Name { get; set; }
  public string Manufacturer { get; set; }
  public uint Cores { get; set; }
  public uint Threads { get; set; }
  public float MaxClockSpeedGHz { get; set; }
  public float CurrentClockSpeedGHz { get; set; }
  // public string Socket { get; set; }
  public uint L2CacheSizeKb { get; set; }
  public uint L3CacheSizeKb { get; set; }
}
