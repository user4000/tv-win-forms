using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool SetText(ushort id, string text)
    {
      return SetText(FindPage(id), text);
    }

    public bool SetText(string uniqueName, string text)
    {
      return SetText(FindPage(uniqueName), text);
    }

    public bool SetText<T>(string text)
    {
      return SetText(FindPage<T>(), text);
    }

    bool SetText(RadPageViewPage page, string text)
    {
      if (page == null) return false;

      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null) && (subForm.NodeForm.Text != text)) subForm.NodeForm.Text = text;
        result = true;
      }

      return result;
    }
  }
}