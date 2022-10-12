using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool GotoPage(ushort id)
    {
      var page = FindPage(id); if (page == null) return false;
      return GotoPage(page);
    }

    public bool GotoPage(string uniquePageName)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return GotoPage(page);
    }

    public bool GotoPage<T>()
    {
      var page = FindPage<T>(); if (page == null) return false;
      return GotoPage(page);
    }

    bool GotoPage(RadPageViewPage page)
    {
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