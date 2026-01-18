using WinPostInstall.Core.MenuSystem;

namespace WinPostInstall.Core.Rendering;

public class MenuRenderer
{
  private readonly int _startX;
  private readonly int _startY;

  public MenuRenderer(int startX = 0, int startY = 0)
  {
    _startX = startX;
    _startY = startY;
  }

  public void Render(Menu menu)
  {
    Console.Clear();

    var items = menu.CurrentItems;
    int y = _startY;

    Console.SetCursorPosition(_startX, y++);
    Console.WriteLine("===== WinPostInstall =====");

    y++;

    for (int i = 0; i < items.Count; i++)
    {
      Console.SetCursorPosition(_startX, y);

      if (i == menu.SelectedIndex)
      {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write($"> {items[i].Title}");
        Console.ResetColor();
      }
      else
      {
        Console.WriteLine($"  {items[i].Title}");
      }

      y++;
    }
  }
}
