﻿using System.Data;

namespace TvWinForms.Extensions
{
  internal static class XxDataColumnChangeEventArgs
  {
    internal static string ZzProposedValue(this DataColumnChangeEventArgs e)
    {
      return e.ProposedValue==null ? string.Empty : e.ProposedValue.ToString();
    }
  }
}