﻿using System;
using TvWinForms;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinFormsExample
{
  public partial class FxForm3 : RadForm, IUserLeftTheForm, IUserVisitedTheForm
  {
    public FxForm3()
    {
      InitializeComponent();
    }

    public void EventUserLeftTheForm()
    {
      //Ms.Message("Form number 3 reports", "User left the page  !").Pos(MsgPos.TopLeft).Debug(2);
    }

    public void EventUserVisitedTheForm()
    {
      //Ms.Message("Form number 3 reports", "User visited the page  !").Pos(MsgPos.TopLeft).Info(2);
    }
  }
}