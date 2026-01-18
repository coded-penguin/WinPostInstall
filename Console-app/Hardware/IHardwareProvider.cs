using WinPostInstall.Hardware.Models;

namespace WinPostInstall.Hardware;

public interface IHardwareProvider
{
  // General
  // string GetOsName();
  // string GetOsVersion();
  // string GetArchitecture();
  // string GetComputerName();
  // string GetUserName();
  // ulong GetTotalRam();
  // ulong GetFreeRam();
  // DateTime GetLastBootTime();

  // CPU
  IEnumerable<CpuInfo> GetCpuInfo();

  // RAM
  // IEnumerable<RamModuleInfo> GetRamModules();

  // GPU
  // IEnumerable<GpuInfo> GetGpuInfo();

  // // Disk
  // IEnumerable<DiskInfo> GetDisks();

  // System (Motherboard + BIOS)
  // IEnumerable<MotherboardInfo> GetMotherboards();
  // IEnumerable<BiosInfo> GetBios();

  // Battery
  // IEnumerable<BatteryInfo> GetBatteries();

  // Drivers (limited info)
  // IEnumerable<DriverInfo> GetDrivers();
}
