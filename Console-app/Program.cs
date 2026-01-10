using System;
using System.Diagnostics;
using System.Text;

using WinPostInstall.Menu;
using WinPostInstall.Rendering;
using WinPostInstall.Controls;

class Program
{
  static void Main()
  {
    Console.OutputEncoding = Encoding.UTF8;

    var menu = MenuFactory.CreateMainMenu();
    int selectedIndex = 0;

    while (true)
    {
      MenuRender.Draw(menu, selectedIndex);
      MenuControlsHandler.HandleControls(menu, ref selectedIndex);
    }
  }
}
