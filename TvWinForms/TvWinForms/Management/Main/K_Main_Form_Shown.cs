using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static void EventMainFormShown(object sender, EventArgs e)
    {
      MainForm.Shown -= new EventHandler(EventMainFormShown);

      Events.BeforeSubFormsAreCreated?.Invoke();

      Service.TreeviewCreateGroups();

      Service.PlaceAllSubFormsToMainPageView();


      Events.BeforeMainFormBecomesVisible?.Invoke();

      MainForm.VisualEffectFadeIn();

      MainForm.Visible = true;


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

    static void EventSelectedNodeChanged(object sender, RadTreeViewEventArgs e)
    {
      if (e.Node == null) return;

      if (Service.ThisIsGroupNode(e.Node)) // Выбран элемент, который представляет собой группу элементов //
      {
        MainForm.PvMain.SelectedPage = MainForm.PageEmpty;
        return;
      }
    }
  }
}