using System;
using Telerik.WinControls;

namespace TvWinForms
{
  public partial class FrameworkService
  {
    bool FormIsInTheQueue(ushort id)
    {
      bool result = false;
      foreach (var item in QueueForms)
      {
        if (item.IdForm == id)
        {
          result = true;
          break;
        }
      }
      return result;
    }

    bool FormIsInTheQueue(string uniqueFormName)
    {
      bool result = false;
      foreach (var item in QueueForms)
      {
        if (item.UniqueName == uniqueFormName)
        {
          result = true;
          break;
        }
      }
      return result;
    }

    bool CheckNameIsUnique(string name)
    {
      bool result = false;

      if (HsUniqueNames.Contains(name))
      {
        RadMessageBox.Show($"Form name [{name}] is not unique !", "ERROR ! ", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
      }
      else
      {
        HsUniqueNames.Add(name);
        result = true;
      }

      if (string.IsNullOrWhiteSpace(name))
      {
        result = false;
        RadMessageBox.Show($"Form name is empty !", "ERROR ! ", System.Windows.Forms.MessageBoxButtons.OK, RadMessageIcon.Error);
      }

      return result;
    }
  }
}