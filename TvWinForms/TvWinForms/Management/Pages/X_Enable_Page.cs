using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool EnablePage(ushort id, bool enable)
    {
      var page = FindPage(id); if (page == null) return false;
      return Enable(page, enable);
    }

    public bool EnablePage(string uniquePageName, bool enable)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return Enable(page, enable);
    }

    public bool EnablePage<T>(bool enable)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return Enable(page, enable);
    }

    bool Enable(RadPageViewPage page, bool enable)
    {
      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null) && (subForm.NodeForm.Enabled != enable)) subForm.NodeForm.Enabled = enable;
        result = true;
      }

      return result;
    }
  }
}