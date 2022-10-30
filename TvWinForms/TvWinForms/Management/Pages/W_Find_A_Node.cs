using System;
using System.Drawing;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class PagesManager
  {
    public RadTreeNode GetNode(ushort id)
    {
      return GetNode(FindPage(id));
    }

    public RadTreeNode GetNode(string uniqueName, Image image)
    {
      return GetNode(FindPage(uniqueName));
    }

    public RadTreeNode GetNode<T>(Image image)
    {
      return GetNode(FindPage<T>());
    }

    RadTreeNode GetNode(RadPageViewPage page)
    {
      if (page == null) return null;

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