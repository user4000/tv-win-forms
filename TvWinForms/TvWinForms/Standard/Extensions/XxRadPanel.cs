using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TvWinForms.Extensions
{
  internal static class XxRadPanel
  {
    internal static void ShowBorder(this RadPanel panel, bool Show)
    {
      panel.PanelElement.PanelBorder.Visibility = Show ? ElementVisibility.Visible : ElementVisibility.Collapsed;
    }
  }
}