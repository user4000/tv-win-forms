using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool GotoPage(ushort id)
    { 
      return GotoPage(FindPage(id));
    }

    public bool GotoPage(string uniqueName)
    {
      return GotoPage(FindPage(uniqueName));
    }

    public bool GotoPage<T>()
    {
      return GotoPage(FindPage<T>());
    }

    bool GotoPage(RadPageViewPage page)
    {
      if (page == null) return false;

      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null))
        {
          MainForm.TvMain.SelectedNode = subForm.NodeForm;
          result = true;
        }
      }

      return result;
    }
  }
}