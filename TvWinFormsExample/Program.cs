﻿using System;
using TvWinForms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using System.Threading.Tasks;
using static TvWinForms.FrameworkManager;

namespace TvWinFormsExample
{
  static class Program
  {
    public static MySettings AppSettings { get => FrameworkManager.ApplicationSettings<MySettings>(); } // User custom settings in Property Grid //

    public static StandardFrameworkSettings FmSettings { get; } = FrameworkManager.FrameworkSettings; // Framework embedded settings //


    static void SaveToLog(string msg) => FrameworkManager.Log.Save(msg);






    static void SetFrameworkSettingsBeforeLoadingFromTextFile()
    {
      string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
      string applicationName = "Test_Application";

      FrameworkManager.Service.CreateApplicationSettings<MySettings>(assemblyName);
      FrameworkManager.CreateLogger(null, applicationName);

      FrameworkManager.SetApplicationIcon(Properties.Resources.ApplicationIcon);     
      FrameworkManager.SetIconForSystemTray(Properties.Resources.ApplicationIcon);

      /* Настройки фреймворка, которые не сохраняются в текстовом файле и требуют явного указания значений (если не устраивают значения по умолчанию) */

      FmSettings.ConfirmExitButtonText = " Click me, my friend !";

      FmSettings.HeaderFormExit = "Test exit";
      FmSettings.HeaderFormLog = "Test log";
      FmSettings.HeaderFormSettings = "Test settings";
    }

    static void OverrideFrameworkSettingsAfterLoadingFromTextFile()
    {
      /* 
       Именно в этом методе вы можете изменить те настройки фреймворка, которые получают свои значения из текстового файла.
       Значения, заданные в этом методе перекрывают (имеют больший приоритет) те значения, которые при старте программы считываются из файла.
         
       Это может быть полезно в тех случаях, когда в некотором приложении настройка не должна зависеть от значения в текстовом файле,
       (например, потому что её может изменить какой-нибудь продвинутый и не в меру активный пользователь)
       а должна иметь явное значение и не допускать изменения этого значения.
      */

      FrameworkSettings.StartTimerIntervalMilliseconds = 1000;
    }

    static void SetFrameworkSettingsAfterLoadingFromTextFile()
    {      
      Events.OverrideLoadedFrameworkSettings = OverrideFrameworkSettingsAfterLoadingFromTextFile;
    }

    static void SetUserForms()
    {
      Group grUsers = GroupManager.Create("users", "Work with users", "01");
      Group grContracts = GroupManager.Create("contracts", "Contracts and Consignments", "02");
      Group grWarehouse = GroupManager.Create("movement", "Item movement", "03");
    

      ushort f1 = Service.AddForm<FxForm1>(grUsers, "form1", "My Form 1", true, true);
      ushort f2 = Service.AddForm<FxForm2>(grUsers, "form2", "My Form 2", true, true);
      ushort f3 = Service.AddForm<FxForm3>(grUsers, "form3", "My Form 3", true, true);

      ushort f4 = Service.AddForm<FxForm1>(grContracts, "form4", "My Form 4", true, true);
      ushort f5 = Service.AddForm<FxForm2>(grContracts, "form5", "My Form 5", true, true);
      ushort f6 = Service.AddForm<FxForm3>(grContracts, "form6", "My Form 6", true, true);

      ushort f7 = Service.AddForm<FxForm1>(grWarehouse, "form7", "My Form 7", true, true);
      ushort f8 = Service.AddForm<FxForm2>(grWarehouse, "form8", "My Form 8", true, true);
      ushort f9 = Service.AddForm<FxForm3>(grWarehouse, "form9", "My Form 9", true, true);

      ushort aboutProgram = Service.AddForm<FxAboutProgram>(GroupManager.GroupStandardAboutProgram, "formAboutProgram", "About my super program", true, true);

      Service.SetStartForm("form1"); // or Service.SetStartForm(f3);
    }

    static void SetApplicationEvents()
    {
      Action action1 = () => 
      {
        //SaveToLog("MainFormLoad");
      };

      Action action2 = () => 
      {
        //SaveToLog("BeforeSubFormsAreCreated");
      };

      Action action3 = () => 
      {
        //SaveToLog("BeforeMainFormBecomesVisible");
      };

      Action action4 = () => 
      {
        //SaveToLog("MainFormShown");
      };

      Action action5 = () => 
      {
        //SaveToLog("Start");
      };

      Action action6 = () => 
      {
        //SaveToLog("StartByTimer");
        Ms.ShortMessage("Application has been started", 290, null, MsgPos.BottomRight).Info(1);
      };





      // Далее указаны события в порядке выполнения //

      Events.MainFormLoad = action1;

      Events.BeforeSubFormsAreCreated = action2;

      // Then EventStartWork of each sub-form is executed ... //

      Events.BeforeMainFormBecomesVisible = action3;

      Events.MainFormShown = action4;

      Events.Start = action5;        // <--- Данное событие есть основная стартовая точка приложения // 

      Events.StartByTimer = action6; // <--- Ещё одна стартовая точка приложения, выполняемая с задержкой (настройка FrameworkSettings.StartTimerIntervalMilliseconds) // 
    }

    static void SetEventsMainFormClosing()
    {
      Action action1 = () => { WriteToEventLog("Main Exit Test 1"); };

      Action<object, FormClosedEventArgs> action2 = (object sender, FormClosedEventArgs args) => { WriteToEventLog("Main Exit Test 2"); };

      Func<Task> task1 = async () =>
      {
        WriteToEventLog("Main Exit ASYNC Point 1 - START");
        await Task.Delay(500);
        WriteToEventLog("Main Exit ASYNC Point 1 - END");
      };

      Events.MainFormClosing = action1;

      Events.MainFormClosingAsync = task1;

      Events.MainFormClosed = action2;
    }


    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      SetExceptionHandler();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Сначала установим настройки фреймворка которые не сохраняются в текстовом файле //
      SetFrameworkSettingsBeforeLoadingFromTextFile();

      // Потом установим настройки фреймворка, которые сохраняются в текстовом файле, но их значения мы хотим явно переопределить //
      SetFrameworkSettingsAfterLoadingFromTextFile();

      // Затем укажем какие формы нужно создать на вкладках главной формы //
      SetUserForms();

      // Затем следует настроить события фреймворка //
      SetApplicationEvents();

      // Затем следует настроить события, выполняемые при завершении работы приложения //
      SetEventsMainFormClosing();

      // Далее следует запуск фреймворка //
      FrameworkManager.Run();
    }




































    static void WriteToEventLog(string message)
    {
      using (EventLog eventLog = new EventLog("Application"))
      {
        eventLog.Source = "Application";
        eventLog.WriteEntry(message, EventLogEntryType.Information);
      }
    }



    public static void Debug(string message)
    {
      //if (EnterNewBlock) System.Diagnostics.Debug.Indent(); else System.Diagnostics.Debug.Unindent();
      System.Diagnostics.Debug.WriteLine(message);
    }

    public static void SetExceptionHandler()
    {
      //==========================================================================================================================
      // Add the event handler for handling UI thread exceptions to the event.
      Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);

      // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // Add the event handler for handling non-UI thread exceptions to the event. 
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
      //==========================================================================================================================
    }

    // Creates the error message and displays it.
    private static DialogResult ShowThreadExceptionDialog(string title, Exception ex)
    {
      string errorMsg = "An application error occurred. Please contact the adminstrator " + "with the following information:\n\n";
      errorMsg = errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace;

      FxMessage FormMessage = FxMessage.Create();
      FormMessage.ShowMessage(errorMsg);
      return DialogResult.Abort;
      /*
      return RadMessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, RadMessageIcon.Error);
      return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
      */
    }

    public static void UIThreadException(object sender, ThreadExceptionEventArgs t)
    {
      DialogResult result = DialogResult.Cancel;
      try
      {
        result = ShowThreadExceptionDialog("UI thread exception. An error has been occurred", t.Exception);
        Directory.CreateDirectory("log");
        LogErrorToFile(t.Exception);
      }
      catch (Exception ex)
      {
        try
        {
          //RadMessageBox.Show("Fatal Windows Forms Error", "Fatal Windows Forms Error", MessageBoxButtons.OK, RadMessageIcon.Error);
          RadMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
        }
        finally
        {
          Application.Exit();
        }
      }

      // Exits the program when the user clicks Abort.
      if (result == DialogResult.Abort)
        Application.Exit();
    }

    // Handle the UI exceptions by showing a dialog box, and asking the user whether
    // or not they wish to abort execution.
    // N_O_T_E: This exception cannot be kept from terminating the application - it can only 
    // log the event, and inform the user about it. 
    public static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      try
      {
        Exception ex = (Exception)e.ExceptionObject;
        string errorMsg = "An application error occurred. Please contact the adminstrator " +
            "with the following information:\n\n";

        // Since we can't prevent the app from terminating, log this to the event log.
        if (!EventLog.SourceExists("ThreadException"))
        {
          EventLog.CreateEventSource("ThreadException", "Application");
        }

        // Create an EventLog instance and assign its source.
        EventLog myLog = new EventLog() { Source = "ThreadException" };
        myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);
        LogErrorToFile(ex);
      }
      catch (Exception exc)
      {
        try
        {
          MessageBox.Show
            ("Fatal Non-UI Error. Could not write the error to the event log. Reason: "
              + exc.Message, "Fatal Non-UI Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
          Application.Exit();
        }
      }
    }

    public static void LogErrorToFile(Exception ex)
    {
      string time = DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");
      string filePath = $@"log\Error_{time}.txt";
      using (StreamWriter writer = new StreamWriter(filePath, true))
      {
        writer.WriteLine("-----------------------------------------------------------------------------");
        writer.WriteLine("Date : " + DateTime.Now.ToString());
        writer.WriteLine();

        while (ex != null)
        {
          writer.WriteLine(ex.GetType().FullName);
          writer.WriteLine("Message : " + ex.Message);
          writer.WriteLine("StackTrace : " + ex.StackTrace);

          ex = ex.InnerException;
        }
      }
    }
  }
}