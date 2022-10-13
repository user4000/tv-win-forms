using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public RadTreeNode GetNode(ushort id)
    {
      var page = FindPage(id); if (page == null) return null;
      return GetNode(page);
    }

    public RadTreeNode GetNode(string uniquePageName, Image image)
    {
      var page = FindPage(uniquePageName); if (page == null) return null;
      return GetNode(page);
    }

    public RadTreeNode GetNode<T>(Image image)
    {
      var page = FindPage<T>(); if (page == null) return null;
      return GetNode(page);
    }

    RadTreeNode GetNode(RadPageViewPage page)
    {
      RadTreeNode result = null;

      if ((page != null) && (page.Tag != null) && (page.Tag is SubForm))
      {
        SubForm subForm = page.Tag as SubForm;
        if ((subForm != null)) result = subForm.NodeForm;
      }

      return result;
    }
  }
}