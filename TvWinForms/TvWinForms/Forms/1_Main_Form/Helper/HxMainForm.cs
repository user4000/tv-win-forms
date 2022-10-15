using System;
using System.Drawing;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinForms.Forms
{
  internal partial class HxMainForm
  {
    FxMain Form { get; set; }

    RadContextMenu MenuTreeview { get; set; }

    HxMainForm()
    {

    }

    HxMainForm(FxMain mainForm)
    {
      Form = mainForm;
    }

    internal static HxMainForm Create(FxMain mainForm) => new HxMainForm(mainForm);


    internal void Configure()
    {
      foreach (var page in Form.PvMain.Pages)
      {
        page.Item.Visibility = ElementVisibility.Hidden;
      }

      FrameworkManager.ImageLoader.TryToLoadImages();

      #region Tune Icons ---------------------------------------------------------------------------------------------------------

      FrameworkManager.SetIconDefaultValuesIfTheyHaveNoAnyValue();

      Form.Icon = IconApplication;
      Form.NotifyIconMainForm.Icon = IconSystemTray;

      #endregion ----------------------------------------------------------------------------------------------------------------

      Form.Text = FrameworkSettings.MainFormCaption;

      Form.Visible = false;

      if (FrameworkManager.FlagServiceApplication()) Form.WindowState = FormWindowState.Minimized;

      Form.ShowMainPageView(false);

      Service.Configure(Form);

      Pages.Configure(Form);

      Form.Text = FrameworkSettings.MainFormCaption;

      this.SetProperties();

      this.SetEvents();
    }

    void SetProperties()
    {
      if (FrameworkSettings.VisualEffectOnStart)
      {
        Form.Opacity = 0;
      }

      Form.MinimumSize = new Size(800, 600);

      AdjustFirstPage();

      AdjustAboutProgramPage();

      AdjustStripViewContainer();

      AdjustMainPageviewAndTreeview();
    }


    void SetEvents()
    {
      Form.Load += new EventHandler(EventFormLoad);

      if (FrameworkManager.Events.MainFormResize != null) Form.Resize += new EventHandler(EventResize);

      if (FrameworkManager.Events.MainFormResizeBegin != null) Form.ResizeBegin += new EventHandler(EventResizeBegin);

      if (FrameworkManager.Events.MainFormResizeEnd != null) Form.ResizeEnd += new EventHandler(EventResizeEnd);


      Form.NotifyIconMainForm.DoubleClick += new EventHandler(EventTrayIconDoubleClick);

      SetContextMenuForTreeview();


      // Следующие важные события будут запрограммированы в классе FrameworkManager //

      //Form.FormClosing += new FormClosingEventHandler(EventFormClosing);
      //Form.FormClosed += new FormClosedEventHandler(EventFormClosed);
    }
  }
}
