using System;
using System.Drawing;
using TvWinForms.Forms;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TvWinForms.Extensions;
using static TvWinForms.FrameworkManager;

namespace TvWinForms
{
  public partial class FxMain : RadForm
  {
    System.Windows.Forms.Timer TmStartMainApplication { get; set; } = new System.Windows.Forms.Timer();

    public bool FlagSizeIsBeingChanged { get; internal set; } = false;
  
    internal HxMainForm MnForm { get; private set; }

    public FxMain()
    {
      InitializeComponent();
    }

    internal void Configure()
    {
      MnForm = HxMainForm.Create(this);
      MnForm.Configure();
    }


    internal void VisualEffectFadeIn() => MnForm.VisualEffectFadeIn();

    internal void VisualEffectFadeOut() => MnForm.VisualEffectFadeOut();



    internal void LaunchStartTimer()
    {
      if (FrameworkManager.Events.StartByTimer == null) return;

      int milliseconds = Math.Abs(FrameworkSettings.StartTimerIntervalMilliseconds);

      if (milliseconds == 0) return;

      this.TmStartMainApplication.Interval = FrameworkSettings.StartTimerIntervalMilliseconds;
      this.TmStartMainApplication.Tick += new EventHandler(EventStartMainApplication);
      this.TmStartMainApplication.Start();
    }


    internal void EventStartMainApplication(object sender, EventArgs e)
    {
      this.TmStartMainApplication.Stop();
      this.TmStartMainApplication.Tick -= new EventHandler(EventStartMainApplication);
      FrameworkManager.Events.StartByTimer?.Invoke();
    }





    internal void SetEventForSystemTrayIcon()
    {
      if (FrameworkSettings.FlagMinimizeMainFormToSystemTray == false) return;

      if (FlagSystemTrayIconIsConfigured == false)
      {
        // Приложение должно минимизироваться в трей, но программист не настроил иконку для системного лотка. Придётся сделать это за него //
        SetIconForSystemTray(null);
      };

      if (this.NotifyIconMainForm.Icon == null) return; // Проверка на всякий случай - а то минимизируем главную форму а иконки нет в системном лотке //

      this.NotifyIconMainForm.Visible = true;
      this.Resize += new EventHandler(EventResizeCheckWindowState);
    }

    void EventResizeCheckWindowState(object sender, EventArgs e)
    {
      if (UserHasClickedExitButton) return;

      if ((this.WindowState == FormWindowState.Minimized))
      {
        this.ShowInTaskbar = false;
        this.Hide();
      }
      else if (this.WindowState == FormWindowState.Normal)
      {
        if (this.Visible == false) this.Show();
        if (this.ShowInTaskbar == false) this.ShowInTaskbar = true;
        if (PnTreeview.Width > FrameworkManager.TreeviewMaxWidth) PnTreeview.Width = FrameworkManager.TreeviewMaxWidth;
      }
    }

    internal void ShowMainPageView(bool show)
    {
      if (FrameworkSettings.HideMainPageViewBeforeMainFormIsShown == false) return;
     
      ((RadPageViewStripElement)this.PvMain.ViewElement).ItemContainer.Visibility = show ? ElementVisibility.Visible : ElementVisibility.Collapsed;
    }


    public void ChangeTreeviewDockSide() => MnForm.ChangeTreeviewDockSide();

    public void ShowSystemTrayIcon(bool show)
    {
      if (this.NotifyIconMainForm.Icon == null) return;
      this.NotifyIconMainForm.Visible = show;
    }

    public void ShowTreeviewPanel(bool show, int width = 0)
    {
      if (show == false)
      {
        PnTreeview.Width = 30;
        return;
      }

      if (width <= 10) width = FrameworkManager.TreeviewMaxWidth;
      if (width > FrameworkManager.TreeviewMaxWidth) width = FrameworkManager.TreeviewMaxWidth;

      PnTreeview.Width = width;
    }
  }
}