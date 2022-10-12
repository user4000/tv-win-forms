using System;
using Telerik.WinControls.UI;
using TvWinForms.Extensions;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static bool NodesWereHidden { get; set; } = false;

    private static void EventPanelTreeviewResize(object sender, EventArgs e)
    {
      ShowMainNodes(MainForm.PnTreeview.Width > 70);
    }

    static void ShowMainNodes(bool show)
    {
      if ((show) && (NodesWereHidden == false)) return;
      NodesWereHidden = !show;
      foreach (RadTreeNode node in MainForm.TvMain.Nodes) node.Visible = show;
    }
  }
}