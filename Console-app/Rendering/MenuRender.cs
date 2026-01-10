using WinPostInstall.Core;

namespace WinPostInstall.Rendering;

public static class MenuRender
{
  public static void Draw(List<MenuItem> menu, int selectedIndex)
  {
    Console.Clear();
    DrawItems(menu, selectedIndex, 0, "");
  }

  private static int DrawItems(List<MenuItem> items, int selectedIndex, int index, string ident)
  {
    for (int i = 0; i < items.Count; i++)
    {
      bool isLast = i == items.Count - 1;
      bool isFirst = i == 0;
      var item = items[i];

      string prefix = isFirst ? "┌─ " : isLast ? "└─ " : "├─ ";
      string pointer = index == selectedIndex ? "> " : "  ";

      Console.WriteLine(pointer + ident + prefix + item.Title);
      index++;

      if (item.isExpanded && item.Children.Any())
      {
        string newIdent = ident + (isLast ? "  " : "| ");
        index = DrawItems(item.Children, selectedIndex, index, newIdent);
      }
    }

    return index;
  }
}
