using System;
using System.Windows.Forms;

namespace TvWinForms
{
  public partial class FrameworkManager
  {
    static FxMain CreateMainForm()
    {
      MainForm = new FxMain();

      MainForm.Configure();
     

      MainForm.FormClosing += new FormClosingEventHandler(EventMainFormClosing);

      MainForm.FormClosed += new FormClosedEventHandler(EventMainFormClosed);

      MainForm.Shown += new EventHandler(EventMainFormShown);

      FrameworkSettings.RestoreMainFormLocationAndSize();


      // Если пользователь хочет применить тему приложения, то сделаем это по части имени темы //
      if (string.IsNullOrWhiteSpace(FrameworkSettings.ThemeName) == false)
      {
        ThemeManager.SetApplicationTheme(FrameworkSettings.ThemeName);
      }


      //Application.ApplicationExit += new EventHandler(EventApplicationExit);

      return MainForm;
    }
  }
}