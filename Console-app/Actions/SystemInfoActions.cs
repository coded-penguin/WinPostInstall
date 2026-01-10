namespace WinPostInstall.Actions;

public class SystemInfoActions
{
  public static void ShowGeneral()
  {
    ShowStub("General info");
  }

  public static void ShowCPU()
  {
    ShowStub("CPU info");
  }

  public static void ShowRAM()
  {
    ShowStub("RAM info");
  }

  public static void ShowGPU()
  {
    ShowStub("GPU info");
  }

  public static void ShowDisks()
  {
    ShowStub("Disks info");
  }

  public static void ShowNetwork()
  {
    ShowStub("Network info");
  }

  public static void ShowSecurity()
  {
    ShowStub("Security info");
  }

  private static void ShowStub(string title)
  {
    Console.Clear();
    Console.WriteLine($"=== {title} ===\n");
    Console.WriteLine("Something will be here later.");
    Console.WriteLine("\nPress any key to back in menu...");
    Console.ReadKey(true);
  }
}
