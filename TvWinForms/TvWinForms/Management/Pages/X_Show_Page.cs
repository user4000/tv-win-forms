using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool ShowPage(ushort id, bool visible)
    {
      return ShowPage(FindPage(id), visible);
    }

    public bool ShowPage(string uniqueName, bool visible)
    {
      return ShowPage(FindPage(uniqueName), visible);
    }

    public bool ShowPage<T>(bool visible)
    {
      return ShowPage(FindPage<T>(), visible);
    }

    bool ShowPage(RadPageViewPage page, bool visible)
    {
      if (page == null) return false;

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