using System;
using TvWinForms.Form;
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
      if (IdStartForm == 0)
      {
        Trace.WriteLine($"[TvWinForms] framework: Warning! IdStartForm = 0");
        return false;
      }

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.IdForm == IdStartForm)
        {
          // Trace.WriteLine($"FOUND !!! ---- {pair.Key} ---- {pair.Value.Form.GetType().FullName} ---- id = {pair.Value.IdForm}");

          if (pair.Value.Form is FxExit)
          {
            result = false;
            Trace.WriteLine($"[TvWinForms] framework: Warning! [FxExit] cannot be selected as a start form!");
            return result;
          }

          pair.Value.NodeForm.Selected = true;
          result = true;
          break;
        }
      }

      return result;
    }

    internal bool GotoStartFormUsingStringCode()
    {
      if (string.IsNullOrWhiteSpace(CodeStartForm))
      {
        Trace.WriteLine($"[TvWinForms] framework: Warning! CodeStartForm is EMPTY");
        return false;
      }

      bool result = false;

      foreach (var pair in DicForms)
      {
        if (pair.Value.UniqueName == CodeStartForm)
        {

          if (pair.Value.Form is FxExit)
          {
            result = false;
            Trace.WriteLine($"[TvWinForms] framework: Warning! [FxExit] cannot be selected as a start form!");
            return result;
          }

          pair.Value.NodeForm.Selected = true;
          result = true;
          break;
        }
      }

      return result;
    }
  }
}