using WinPostInstall.Hardware;
using Hardware.Info;
using WinPostInstall.Hardware.Models;

namespace WinPostInstall.Providers;

public class HardwareInfoProvider : IHardwareProvider
{
  private readonly HardwareInfo _hardwareInfo;

  public HardwareInfoProvider()
  {
    _hardwareInfo = new HardwareInfo();
    _hardwareInfo.RefreshAll();
  }

  public IEnumerable<CpuInfo> GetCpuInfo()
  {
    var list = new List<CpuInfo>();

    foreach(var cpu in _hardwareInfo.CpuList)
    {
      list.Add(new CpuInfo
      {
        Name = cpu.Name,
        Manufacturer = cpu.Manufacturer,
        Cores = cpu.NumberOfCores,
        Threads = cpu.NumberOfLogicalProcessors,
        MaxClockSpeedGHz = cpu.MaxClockSpeed / 1000f,
        CurrentClockSpeedGHz = cpu.CurrentClockSpeed / 1000f,
        L2CacheSizeKb = cpu.L2CacheSize,
        L3CacheSizeKb = cpu.L3CacheSize,
      });
    }

    return list;
  }
}
