using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool ShowPage(ushort id, bool visible)
    {
      var page = FindPage(id); if (page == null) return false;
      return ShowPage(page, visible);
    }

    public bool ShowPage(string uniquePageName, bool visible)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return ShowPage(page, visible);
    }

    public bool ShowPage<T>(bool visible)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return ShowPage(page, visible);
    }

    bool ShowPage(RadPageViewPage page, bool visible)
    {
      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null) && (subForm.NodeForm.Visible != visible)) subForm.NodeForm.Visible = visible;
        result = true;
      }

      return result;
    }
  }
}