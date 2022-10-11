using System;
using System.Diagnostics;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkService
  {
    bool SelectPage(RadPageViewPage page)
    {
      if (page == MainForm.PageExit) return false;
      MainForm.PvMain.SelectedPage = page;
      return true;
    }

    /// <summary>
    /// Setting the form to be selected after the application starts
    /// </summary>
    
    public void SetStartForm(ushort id)
    {
      IdStartForm = id;
      if (FormExists(id) == false)
      {
        Trace.WriteLine($"[TvWinForms] framework: Warning! There is no form with id = {id}");
      }
    }

    
    /// <summary>
    /// Setting the form to be selected after the application starts
    /// </summary>

    public void SetStartForm(string UniqueFormName)
    {
      CodeStartForm = UniqueFormName;
      if (FormExists(UniqueFormName) == false)
      {
        Trace.WriteLine($"[TvWinForms] framework: Warning! There is no form with unique form name = {UniqueFormName}");
      }
    }

    internal bool GotoStartForm()
    {
      if (IdStartForm == 0) return false;

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.IdForm == IdStartForm)
        {
          //result = SelectPage(pair.Value.Page);
          // TODO: Сделать проверку, что не была выбрана форма EXIT //
          pair.Value.NodeForm.Selected = true;
          result = true;
          break;
        }
      }

      return result;
    }

    internal bool GotoStartFormUsingStringCode()
    {
      if (string.IsNullOrWhiteSpace(CodeStartForm)) return false;

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.UniqueName == CodeStartForm)
        {
          //result = SelectPage(pair.Value.Page);
          // TODO: Сделать проверку, что не была выбрана форма EXIT //
          pair.Value.NodeForm.Selected = true;
          result = true;
          break;
        }
      }

      return result;
    }
  }
}