using System;
using System.Drawing;
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

    public bool FlagSizeIsBeingChanged { get; private set; } = false;

  
    public FxMain()
    {
      InitializeComponent();
    }

    internal void SetProperties()
    {
      if (FrameworkSettings.VisualEffectOnStart)
      {
        this.Opacity = 0;
      }

      this.MinimumSize = new Size(800, 400);

      AdjustFirstPage();

      AdjustAboutProgramPage();

      AdjustStripViewContainer();

      AdjustMainPageviewAndTreeview();
    }

    void AdjustMainPageviewAndTreeview() // Настроим центральные элементы главной формы //
    {
      PnTreeview.Dock = DockStyle.Left;
      SplitterMainVertical.Dock = DockStyle.Left;
      PvMain.Dock = DockStyle.Fill;
      SplitterMainVertical.BringToFront();
      PvMain.BringToFront();
      PnTreeview.ShowBorder(false);
      //PnTreeview.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
      TvMain.LineColor = Color.FromArgb(180, 180, 180);
      TvMain.LineStyle = TreeLineStyle.Dot;
      //TvMain.Padding = new Padding(10, 5, 5, 5);

      MainForm.PnTreeview.Width = FrameworkSettings.TreeviewPanelWidth;
    }

    void AdjustStripViewContainer() // Полосу, отображающую вкладки, нужно скрыть //
    {
      ((StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new Padding(0);
      ((StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Visibility = ElementVisibility.Collapsed;
    }

    internal void LaunchStartTimer()
    {
      if (FrameworkManager.Events.StartByTimer == null) return;

      int milliseconds = Math.Abs(FrameworkSettings.StartTimerIntervalMilliseconds);

      if (milliseconds == 0) return;

      TmStartMainApplication.Interval = FrameworkSettings.StartTimerIntervalMilliseconds;
      TmStartMainApplication.Tick += new EventHandler(EventStartMainApplication);
      TmStartMainApplication.Start();
    }

    void EventStartMainApplication(object sender, EventArgs e)
    {
      TmStartMainApplication.Stop();
      TmStartMainApplication.Tick -= new EventHandler(EventStartMainApplication);
      FrameworkManager.Events.StartByTimer?.Invoke();
    }

    internal void AdjustFirstPage()
    {
      var page = this.PageEmpty;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);
      page.Item.Visibility = ElementVisibility.Collapsed;
    }

    internal void AdjustAboutProgramPage()
    {
      var page = this.PageAboutProgram;
      page.ItemSize = new SizeF(130F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);
      page.Item.Visibility = ElementVisibility.Collapsed;
    }

    internal void SetEvents()
    {
      this.Load += new EventHandler(EventFormLoad);

      if (FrameworkManager.Events.MainFormResize != null) this.Resize += new EventHandler(EventResize);

      if (FrameworkManager.Events.MainFormResizeBegin != null) this.ResizeBegin += new EventHandler(EventResizeBegin);

      if (FrameworkManager.Events.MainFormResizeEnd != null) this.ResizeEnd += new EventHandler(EventResizeEnd);


      NotifyIconMainForm.DoubleClick += new EventHandler(EventTrayIconDoubleClick);

      // Эти важные события будут запрограммированы в классе FrameworkManager //
      //this.FormClosing += new FormClosingEventHandler(EventFormClosing);
      //this.FormClosed += new FormClosedEventHandler(EventFormClosed);
    }

    internal void SetEventForSystemTrayIcon()
    {
      if (FrameworkSettings.FlagMinimizeMainFormToSystemTray == false) return;

      if (FlagSystemTrayIconIsConfigured == false)
      {
        // Приложение должно минимизироваться в трей, но программист не настроил иконку для системного лотка. Придётся сделать это за него //
        SetIconForSystemTray(null);
      };

      if (MainForm.NotifyIconMainForm.Icon == null) return; // Проверка на всякий случай - а то минимизируем главную форму а иконки нет в системном лотке //

      this.NotifyIconMainForm.Visible = true;
      this.Resize += new EventHandler(EventResizeCheckWindowState);
    }

    void EventTrayIconDoubleClick(object sender, EventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      this.ShowInTaskbar = true;
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
        this.Show();
        this.ShowInTaskbar = true;
      }
    }











    void EventResizeEnd(object sender, EventArgs e)
    {
      FlagSizeIsBeingChanged = false;
      FrameworkManager.Events.MainFormResizeEnd();
    }

    void EventResizeBegin(object sender, EventArgs e)
    {
      FlagSizeIsBeingChanged = true;
      FrameworkManager.Events.MainFormResizeBegin();
    }

    void EventResize(object sender, EventArgs e)
    {
      if (UserHasClickedExitButton) return;
      FrameworkManager.Events.MainFormResize();
    }

    public void EventFormLoad(object sender, EventArgs e)
    {
      Service.TreeviewCreateGroups();           // Создание главных элементов Treeview //

      Service.PlaceAllSubFormsToMainPageView(); // Создание всех форм пользователя, элементов Treeview и вкладок Pageview //

      FrameworkManager.Events.MainFormLoad?.Invoke();
    }

    internal void VisualEffectFadeIn()
    {
      if (FrameworkSettings.VisualEffectOnStart == false) return;
      if (FrameworkSettings.FlagMainFormStartMinimized) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        this.Opacity = ((double)currentStep) / steps;
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          this.Opacity = 1;
        }
      };
      timer.Start();      
    }

    internal void VisualEffectFadeOut()
    {
      if (FrameworkSettings.VisualEffectOnExit == false) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        this.Opacity = 1 - (((double)currentStep) / steps);
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          this.Opacity = 0;
        }
      };
      timer.Start();
    }

    internal void ShowMainPageView(bool show)
    {
      if (FrameworkSettings.HideMainPageViewBeforeMainFormIsShown == false) return;
     
      ((RadPageViewStripElement)PvMain.ViewElement).ItemContainer.Visibility = show ? ElementVisibility.Visible : ElementVisibility.Collapsed;
    }

    public void ShowSystemTrayIcon(bool show)
    {
      if (NotifyIconMainForm.Icon == null) return;
      NotifyIconMainForm.Visible = show;
    }
  }
}