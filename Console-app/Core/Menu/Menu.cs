namespace WinPostInstall.Core.MenuSystem;

public class Menu
{
  public List<MenuItem> RootItems { get; }
  public MenuItem? CurrentParent { get; private set; }
  public List<MenuItem> CurrentItems =>
    CurrentParent == null ? RootItems : CurrentParent.Children;

  public int SelectedIndex { get; private set; }

  public Menu(List<MenuItem> rootItems)
  {
    RootItems = rootItems;
    SelectedIndex = 0;
    CurrentParent = null;
  }

  public void moveUp()
  {
    if (SelectedIndex > 0)
      SelectedIndex--;
  }

  public void moveDown()
  {
    if (SelectedIndex < CurrentItems.Count - 1)
      SelectedIndex++;
  }

  public void Select()
  {
    if (CurrentItems.Count == 0)
      return;

    var selectedItem = CurrentItems[SelectedIndex];

    if (selectedItem.Children.Count > 0)
    {
      CurrentParent = selectedItem;
      SelectedIndex = 0;
    }
    else
      selectedItem.Action?.Invoke();
  }

  public void Back()
  {
    if (CurrentParent != null)
    {
      CurrentParent = null;
      SelectedIndex = 0;
    }
  }
}
