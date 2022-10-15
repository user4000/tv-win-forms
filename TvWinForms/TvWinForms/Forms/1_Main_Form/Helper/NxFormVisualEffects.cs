using System;
using System.Windows.Forms;
using static TvWinForms.FrameworkManager;

namespace TvWinForms.Forms
{
  partial class HxMainForm
  {

    internal void VisualEffectFadeIn()
    {
      if (FrameworkSettings.VisualEffectOnStart == false) return;
      if (FrameworkSettings.FlagMainFormStartMinimized) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        Form.Opacity = ((double)currentStep) / steps;
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          Form.Opacity = 1;
        }
      };
      timer.Start();
    }

    internal void VisualEffectFadeOut()
    {
      if (FrameworkSettings.VisualEffectOnExit == false) return;

      int duration = 500; // in milliseconds
      int steps = 25;
      Timer timer = new Timer() { Interval = duration / steps };
      int currentStep = 0;
      timer.Tick += (arg1, arg2) =>
      {
        Form.Opacity = 1 - (((double)currentStep) / steps);
        currentStep++;

        if (currentStep >= steps)
        {
          timer.Stop();
          timer.Dispose();
          Form.Opacity = 0;
        }
      };
      timer.Start();
    }
  }
}