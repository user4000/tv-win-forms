using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static void EventMainFormShown(object sender, EventArgs e)
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      Events.BeforeSubFormsAreCreated?.Invoke();

      Events.BeforeMainFormBecomesVisible?.Invoke();

      MainForm.TvMain.TreeViewElement.BackColor = MainForm.BackColor; //MainForm.PageEmpty.BackColor;  

      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;


      // Установим новое событие - "Пользователь ходит по элементам древовидного списка" //
      MainForm.TvMain.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(EventSelectedNodeChanged);



      bool startForm = Service.GotoStartForm();

      if (startForm == false) Service.GotoStartFormUsingStringCode();




      MainForm.ShowMainPageView(true);




      Events.MainFormShown?.Invoke();

      Events.Start?.Invoke();

      MainForm.LaunchStartTimer();

      MainForm.SetEventForSystemTrayIcon();

      if (FlagServiceApplication()) MainForm.ShowInTaskbar = false; // Если это серверное приложение то не показывать его на панели задач //
    }
  }
}