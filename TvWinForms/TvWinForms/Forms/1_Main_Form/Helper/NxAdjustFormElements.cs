using System;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TvWinForms.Extensions;
using static TvWinForms.FrameworkManager;

namespace TvWinForms.Forms
{
  partial class HxMainForm
  {
    DateTime TimeDockSideChange { get; set; } = new DateTime(2022, 1, 1);

    internal void ChangeTreeviewDockSide()
    {
      var diffInSeconds = Math.Abs( (DateTime.Now - TimeDockSideChange).TotalSeconds);
      if (diffInSeconds < 2) return;

      TimeDockSideChange = DateTime.Now;

      DockStyle dock = (Form.PnTreeview.Dock == DockStyle.Right ? DockStyle.Left : DockStyle.Right);
      Form.PnTreeview.Dock = dock;
      Form.SplitterMainVertical.Dock = dock;
    }

    internal void AdjustMainPageviewAndTreeview() // Настроим центральные элементы главной формы //
    {
      bool leftSide = FrameworkSettings.TreeviewIsLocatedOnTheLeftSide;
      DockStyle dock = leftSide ? DockStyle.Left : DockStyle.Right;

      Form.PnTreeview.Dock = dock;
      Form.SplitterMainVertical.Dock = dock;
      Form.PvMain.Dock = DockStyle.Fill;
      Form.SplitterMainVertical.BringToFront();
      Form.PvMain.BringToFront();
      Form.PnTreeview.ShowBorder(false);

      //PnTreeview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
      Form.TvMain.LineColor = Color.FromArgb(180, 180, 180);
      Form.TvMain.LineStyle = TreeLineStyle.Dot;
      //TvMain.Padding = new Padding(10, 5, 5, 5);

      Form.TvMain.ShowExpandCollapse = true;
      Form.PnTreeview.Width = FrameworkSettings.TreeviewPanelWidth;
    }

    internal void AdjustStripViewContainer() // Полосу, отображающую вкладки, нужно скрыть //
    {
      ((StripViewItemContainer)(Form.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new Padding(0);
      ((StripViewItemContainer)(Form.PvMain.GetChildAt(0).GetChildAt(0))).Visibility = ElementVisibility.Collapsed;
    }

    internal void AdjustFirstPage()
    {
      var page = Form.PageEmpty;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.Visibility = ElementVisibility.Collapsed;
    }

    internal void AdjustAboutProgramPage()
    {
      var page = Form.PageAboutProgram;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.Visibility = ElementVisibility.Collapsed;
    }
  }
}