using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static bool NodesWereHidden { get; set; } = false;

    internal static bool TreeviewIsCollapsed() => MainForm.PnTreeview.Width < 70;

    internal static bool TreeviewIsTooWide() => MainForm.PnTreeview.Width > TreeviewMaxWidth;

    internal static int TreeviewMaxWidth { get => ((3 * MainForm.Width) / 10); }


    private static void EventPanelTreeviewResize(object sender, EventArgs e)
    {
      if (MainForm.WindowState == System.Windows.Forms.FormWindowState.Minimized) return;

      ShowMainNodes(TreeviewIsCollapsed() == false);

      if (TreeviewIsCollapsed() == false)
      {
        FrameworkSettings.TreeviewPanelWidth = MainForm.PnTreeview.Width;
      }

      if (TreeviewIsTooWide())
      {
        MainForm.PnTreeview.Width = TreeviewMaxWidth; 
      }
    }

    static void ShowMainNodes(bool show)
    {
      if ((show) && (NodesWereHidden == false)) return;
      NodesWereHidden = !show;
      foreach (RadTreeNode node in MainForm.TvMain.Nodes) node.Visible = show;
    }

    static void EventUserClickedOnTreeview(object sender, EventArgs e)
    {
      if (MainForm.TvMain.Width < 150) MainForm.PnTreeview.Width = 250;
    }
  }
}