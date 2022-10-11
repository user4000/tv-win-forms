using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static void GotoEmptyPage() => MainForm.PvMain.SelectedPage = MainForm.PageEmpty;

    static void EventSelectedNodeChanged(object sender, RadTreeViewEventArgs e) // Событие: пользователь выбрал элемент Treeview //
    {
      if (e.Node == null) return;

      if (Service.ThisIsGroupNode(e.Node)) // Выбран элемент, который представляет собой группу элементов //
      {
        GotoEmptyPage();
        return;
      }

      SubForm subForm = Service.GetSubForm(e.Node); // Попробуем узнать, какая форма соответствует данному элементу //

      if (subForm == null)
      {
        GotoEmptyPage();
        return;
      }

      if (subForm.Page != null)
      {
        MainForm.PvMain.SelectedPage = subForm.Page;
      }
      else
      {
        GotoEmptyPage();
      }
    }
  }
}