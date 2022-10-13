using System;
using Telerik.WinControls.UI;
using TvWinForms.Extensions;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static bool NodesWereHidden { get; set; } = false;

    internal static bool TreeviewIsCollapsed() => MainForm.PnTreeview.Width < 70;

    private static void EventPanelTreeviewResize(object sender, EventArgs e)
    {
      ShowMainNodes(TreeviewIsCollapsed() == false);

      if (TreeviewIsCollapsed() == false)
      {
        FrameworkSettings.TreeviewPanelWidth = MainForm.PnTreeview.Width;
      }
    }

    static void ShowMainNodes(bool show)
    {
      if ((show) && (NodesWereHidden == false)) return;
      NodesWereHidden = !show;
      foreach (RadTreeNode node in MainForm.TvMain.Nodes) node.Visible = show;
    }
  }
}