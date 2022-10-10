using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    private static void EventMainFormClosed(object sender, FormClosedEventArgs e)
    {
      Events.MainFormClosed?.Invoke(sender, e);
    }
  }
}