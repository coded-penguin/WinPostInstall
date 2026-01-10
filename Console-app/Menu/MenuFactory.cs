using WinPostInstall.Core;
using WinPostInstall.Actions;

namespace WinPostInstall.Menu;

public static class MenuFactory
{
  public static List<MenuItem> CreateMainMenu()
  {
    return new List<MenuItem>
    {
      new MenuItem("About system")
      {
        Children =
        {
          new MenuItem("General information", SystemInfoActions.ShowGeneral),
          new MenuItem("CPU", SystemInfoActions.ShowCPU),
          new MenuItem("RAM", SystemInfoActions.ShowRAM),
          new MenuItem("GPU", SystemInfoActions.ShowGPU),
          new MenuItem("Disks", SystemInfoActions.ShowDisks),
          new MenuItem("Network", SystemInfoActions.ShowNetwork),
          new MenuItem("Security", SystemInfoActions.ShowSecurity),
        }
      },

      new MenuItem("Windows optimization"),
      new MenuItem("Task manager"),
      new MenuItem("Settings"),
      new MenuItem("Exit", () => Environment.Exit(0))
    };
  }
}
