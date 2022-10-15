using System;
using System.Windows.Forms;
using static TvWinForms.FrameworkManager;

namespace TvWinForms.Forms
{
  partial class HxMainForm
  {
    void EventFormLoad(object sender, EventArgs e)
    {
      Service.TreeviewCreateGroups();           // Создание главных элементов Treeview //

      Service.PlaceAllSubFormsToMainPageView(); // Создание всех форм пользователя, элементов Treeview и вкладок Pageview //

      FrameworkManager.Events.MainFormLoad?.Invoke();
    }

    void EventResize(object sender, EventArgs e)
    {
      if (UserHasClickedExitButton) return;
      FrameworkManager.Events.MainFormResize();
    }

    void EventResizeEnd(object sender, EventArgs e)
    {
      Form.FlagSizeIsBeingChanged = false;
      FrameworkManager.Events.MainFormResizeEnd();
    }

    void EventResizeBegin(object sender, EventArgs e)
    {
      Form.FlagSizeIsBeingChanged = true;
      FrameworkManager.Events.MainFormResizeBegin();
    }

    void EventTrayIconDoubleClick(object sender, EventArgs e)
    {
      Form.WindowState = FormWindowState.Normal;
      Form.ShowInTaskbar = true;
    }
  }
}