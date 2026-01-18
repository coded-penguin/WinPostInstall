namespace WinPostInstall.Core.MenuSystem;

public class MenuItem
{
  public string Title { get; set; }
  public Action? Action { get; set; }
  public List<MenuItem> Children { get; set; } = new();
  public bool isExpanded { get; set; } = false;

  public MenuItem(string title)
  {
    Title = title;
  }

  public MenuItem(string title, Action action)
  {
    Title = title;
    Action = action;
  }

  public MenuItem(string title, List<MenuItem> children)
  {
    Title = title;
    Children = children;
  }
}
