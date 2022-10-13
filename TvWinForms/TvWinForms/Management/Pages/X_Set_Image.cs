using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool SetImage(ushort id, Image image)
    {
      var page = FindPage(id); if (page == null) return false;
      return SetImage(page, image);
    }

    public bool SetImage(string uniquePageName, Image image)
    {
      var page = FindPage(uniquePageName); if (page == null) return false;
      return SetImage(page, image);
    }

    public bool SetImage<T>(Image image)
    {
      var page = FindPage<T>(); if (page == null) return false;
      return SetImage(page, image);
    }

    bool SetImage(RadPageViewPage page, Image image)
    {
      bool result = false;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null) && (subForm.NodeForm != null)) subForm.NodeForm.Image = image;
        result = true;
      }

      return result;
    }
  }
}