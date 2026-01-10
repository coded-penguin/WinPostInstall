using WinPostInstall.Core;

namespace WinPostInstall.Controls;

public static class MenuControlsHandler
{
  public static void HandleControls(List<MenuItem> menu, ref int selectedIndex)
  {
    var key = Console.ReadKey(true).Key;

    switch (key)
    {
      case ConsoleKey.UpArrow:
        selectedIndex--;
        if (selectedIndex < 0) selectedIndex = GetFlatCount(menu) - 1;
        break;

      case ConsoleKey.DownArrow:
        selectedIndex++;
        if (selectedIndex >= GetFlatCount(menu)) selectedIndex = 0;
        break;

      case ConsoleKey.Enter:
        var item = GetItemByIndex(menu, selectedIndex);
        if (item.isLeaf)
          item.OnSelect?.Invoke();
        else
          item.isExpanded = !item.isExpanded;
        break;
    }
  }

  private static int GetFlatCount(List<MenuItem> items)
  {
    int count = 0;
    foreach (var item in items)
    {
      count++;
      if (item.isExpanded && item.Children.Any())
        count += GetFlatCount(item.Children);
    }

    return count;
  }

  private static MenuItem GetItemByIndex(List<MenuItem> items, int target, ref int index)
  {
    foreach(var item in items)
    {
      if (index == target) return item;
      index++;

      if (item.isExpanded && item.Children.Any())
      {
        var found = GetItemByIndex(item.Children, target, ref index);
        if (found != null) return found;
      }
    }

    return null;
  }

  private static MenuItem GetItemByIndex(List<MenuItem> items, int target)
  {
    int index = 0;
    return GetItemByIndex(items, target, ref index);
  }
}
