using WinPostInstall.Core.MenuSystem;
using WinPostInstall.Core.Rendering;

namespace WinPostInstall.Core.Controls;

public class MenuControlsHandler
{
  private readonly Menu _menu;
  private readonly MenuRenderer _renderer;
  private bool _isRunning = true;

  public MenuControlsHandler (Menu menu)
  {
    _menu = menu;
    _renderer = new MenuRenderer();
  }

  public void Run()
  {
    Console.CursorVisible = false;

    while(_isRunning)
    {
      _renderer.Render(_menu);

      var key = Console.ReadKey(true).Key;

      switch (key)
      {
        case ConsoleKey.UpArrow:
          _menu.moveUp();
          break;

        case ConsoleKey.DownArrow:
          _menu.moveDown();
          break;

        case ConsoleKey.Enter:
          _menu.Select();
          break;

        case ConsoleKey.Backspace:
        case ConsoleKey.Escape:
         _menu.Back();
         break;
      }
    }
  }
}
