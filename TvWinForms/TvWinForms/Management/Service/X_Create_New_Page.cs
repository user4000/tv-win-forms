using System;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinForms
{
  partial class FrameworkService
  {
    RadPageViewPage CreateNewPageInnerMethod(SubForm form)
    {
      RadPageViewPage page = null;

      page = new RadPageViewPage() // Создание новой вкладки //
      {
        Name = form.UniqueName,
        Text = form.PageText
      };

      if (page.Item != null) page.Item.Visibility = ElementVisibility.Collapsed;

      MainForm.PvMain.Pages.Add(page); 

      return page;
    }

    internal RadPageViewPage CreateNewPage(SubForm form)
    {
      RadPageViewPage page = null;

      page = CreateNewPageInnerMethod(form);

      if (page == null) throw new ApplicationException("Error! Failed to find a [PageView] for standard form!"); 

      MainForm.PvMain.SelectedPage = null;

      return page;
    }
  }
}