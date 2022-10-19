using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static async void EventMainFormShown(object sender, EventArgs e)
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      
      Events.BeforeMainFormBecomesVisible?.Invoke();

      MainForm.TvMain.TreeViewElement.BackColor = FrameworkSettings.ColorTreeviewBackground ?? MainForm.BackColor;
   
      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;


      // Установим новое событие - "Пользователь ходит по элементам древовидного списка" //
      MainForm.TvMain.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(EventSelectedNodeChanged);

      MainForm.TvMain.Click += new EventHandler(EventUserClickedOnTreeview);

      MainForm.PnTreeview.Resize += new EventHandler(EventPanelTreeviewResize);



      bool startForm = Service.GotoStartForm();

      if (startForm == false) Service.GotoStartFormUsingStringCode();



      MainForm.ShowMainPageView(true);



      Events.MainFormShown?.Invoke();

      Events.Start?.Invoke();

      if (Events.StartAsync != null)
      {
        await Events.StartAsync();
      }


      MainForm.LaunchStartTimer();

      MainForm.SetEventForSystemTrayIcon();

      if (FlagServiceApplication()) MainForm.ShowInTaskbar = false; // Если это серверное приложение то не показывать его на панели задач //
    }
  }
}