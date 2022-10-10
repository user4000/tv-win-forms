﻿using System;
using Telerik.WinControls.UI;

namespace TvWinForms.Extensions
{
  internal static class XxGridViewDataColumn
  {
    internal static GridViewDataColumn ZzPin(this GridViewDataColumn column)
    {
      column.IsPinned = true; return column;
    }
  }
}