namespace WinPostInstall.Core;

public class MenuItem
{
  public string Title { get; set; }
  public List<MenuItem> Children { get; set; } = new();
  public bool isExpanded { get; set; } = false;
  public Action? OnSelect { get; set; }

  public bool isLeaf => Children.Count == 0;

  public MenuItem(string title, Action? onSelect = null)
  {
    Title = title;
    OnSelect = onSelect;
  }
}
