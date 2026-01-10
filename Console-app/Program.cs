using System;
using System.Diagnostics;
using System.Text;

class Program
{
  static int selectedIndex = 0;
  static string[] mainMenu =
  {
    "Оптимізація Windows",
    "Керування службами",
    "Інформація про систему",
    "Вихід"
  };

  static void Main(string[] args)
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    MainMenu();
  }

  static void MainMenu()
  {
    ConsoleKey key;
    do
    {
      Console.Clear();
      Console.WriteLine("===== WinPostInstall Tool =====\n");

      for (int i = 0; i < mainMenu.Length; i++)
      {
        if (i == selectedIndex)
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($">  {mainMenu[i]}");
          Console.ResetColor();
        }
        else
        {
          Console.WriteLine($"   {mainMenu[i]}");
        }
      }

      key = Console.ReadKey(true).Key;

      switch (key)
      {
        case ConsoleKey.UpArrow:
          selectedIndex--;
          if (selectedIndex < 0)
            selectedIndex = mainMenu.Length - 1;
          break;

        case ConsoleKey.DownArrow:
          selectedIndex++;
          if (selectedIndex >= mainMenu.Length)
            selectedIndex = 0;
          break;

        case ConsoleKey.Enter:
          HandleSelection();
          break;
      }
    } while (key != ConsoleKey.Escape);
  }

  static void HandleSelection()
  {
    switch (selectedIndex)
    {
      case 0:
        ShowSubmenu("Оптимізація Windows");
        break;

      case 1:
        ShowSubmenu("Керування службами");
        break;

      case 2:
        ShowSubmenu("Інформація про систему");
        break;

      case 3:
        Environment.Exit(0);
        break;
    }
  }

  static void ShowSubmenu(string title)
  {
    Console.Clear();
    Console.WriteLine($"=== {title} ===\n");
    Console.WriteLine("тут буде вкладення...");
    Console.WriteLine("\nНатисніть Esc або Backspace для повернення");
    Console.ReadKey();
  }
}
