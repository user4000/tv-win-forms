using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public bool SetImage(ushort id, Image image)
    {
      return SetImage(FindPage(id), image);
    }

    public bool SetImage(string uniqueName, Image image)
    {
      return SetImage(FindPage(uniqueName), image);
    }

    public bool SetImage<T>(Image image)
    {
      return SetImage(FindPage<T>(), image);
    }

    bool SetImage(RadPageViewPage page, Image image)
    {
      if (page == null) return false;

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