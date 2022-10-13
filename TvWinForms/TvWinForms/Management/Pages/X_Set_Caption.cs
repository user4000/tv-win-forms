using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool SetText(ushort id, string text)
    {
      var page = FindPage(id); if (page == null) return false;
      return SetText(page, text);
    }

    public bool SetText(string uniquePageName, string text)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return SetText(page, text);
    }

    public bool SetText<T>(string text)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return SetText(page, text);
    }

    bool SetText(RadPageViewPage page, string text)
    {
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