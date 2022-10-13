﻿using System;
using System.Drawing;
using System.Windows.Forms;
using static TvWinForms.FrameworkManager;

namespace TvWinForms
{

  partial class StandardFrameworkSettings
  {

    private string headerFormSettings = "Settings";
    public string HeaderFormSettings
    {
      get => headerFormSettings;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormSettings = value;
      }
    }




    private string headerFormExit = "Exit";
    public string HeaderFormExit
    {
      get => headerFormExit;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormExit = value;
      }
    }



    private string headerFormLog = "Message log";
    public string HeaderFormLog
    {
      get => headerFormLog;
      set
      {
        if (!string.IsNullOrWhiteSpace(value)) headerFormLog = value;
      }
    }






    private Padding propertyGridPadding = new Padding(30, 30, 30, 30);

    public Padding PropertyGridPadding
    {
      get => propertyGridPadding;
      set
      {
        if
          (
          (value.Left <= 300) &&
          (value.Left >= 10) &&
          (value.Right <= 300) &&
          (value.Right >= 10) &&
          (value.Top <= 300) &&
          (value.Top >= 10) &&
          (value.Bottom <= 300) &&
          (value.Bottom >= 10)
          )
          propertyGridPadding = value;
      }
    }
  }
}