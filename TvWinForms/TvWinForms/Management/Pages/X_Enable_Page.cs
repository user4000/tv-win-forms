using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool EnablePage(ushort id, bool enable)
    {
      return Enable(FindPage(id), enable);
    }

    public bool EnablePage(string uniqueName, bool enable)
    {
      return Enable(FindPage(uniqueName), enable);
    }

    public bool EnablePage<T>(bool enable)
    {
      return Enable(FindPage<T>(), enable);
    }

    bool Enable(RadPageViewPage page, bool enable)
    {
      if (page == null) return false;

      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null) && (subForm.NodeForm.Enabled != enable))
        {
          subForm.NodeForm.Enabled = enable;
          CxNode.SetColor(subForm.NodeForm);
        }
        result = true;
      }

      return result;
    }
  }
}