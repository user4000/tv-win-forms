using System;
using TvWinForms.Form;
using static TvWinForms.FrameworkManager;

namespace TvWinForms
{
  public partial class FrameworkService
  {
    public void CreateFormLog()
    {
      FxLog form = new FxLog();
      FormLog = form;
      AlertService = new TmAlertService(this, FormLog);
      AddForm(GroupManager.GroupStandardMessagesAndSettings, form, null, FrameworkSettings.HeaderFormLog, true, true);
    }

    public void CreateFormSetting()
    {
      FxSettings form = new FxSettings();
      FormSettings = form;

      StandardApplicationSettings loadedSettings = null;

      try
      {
        loadedSettings = CurrentApplicationSettings;
        SetCurrentSettings(loadedSettings); // Set just loaded settings as current settings //
      }
      catch 
      {
        ProjectDefaultApplicationSettings.LinkToPropertyGrid(FormSettings.GxProperty);
        //Log.Save(MsgType.Error, "An error has occured during loading application settings.", "");
        //Log.Save(ex, "method name = [IsSettingsForm]");
      }

      FormSettings.AcceptLoadedSettings(loadedSettings);

      AddForm(GroupManager.GroupStandardMessagesAndSettings, form, null, FrameworkSettings.HeaderFormSettings, true, true);
    }

    public void CreateFormExit()
    {
      FxExit form = new FxExit();
      FormExit = form;
      AddForm(GroupManager.GroupStandardExit, form, null, FrameworkSettings.HeaderFormExit, true, true);
    }
  }
}