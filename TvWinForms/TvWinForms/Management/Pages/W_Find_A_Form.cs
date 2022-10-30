using System;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinForms
{
  public partial class PagesManager
  {
    public T GetForm<T>(ushort id) where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if ((pair.Value.IdForm == id) && (pair.Value.Form is T))
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>(string uniqueName) where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if ((pair.Key == uniqueName) && (pair.Value.Form is T))
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>() where T : RadForm
    {
      T result = null;

      foreach (var pair in Service.DicForms)
      {
        if (pair.Value.Form is T)
        {
          try { result = (T)(pair.Value.Form); } catch { };
          break;
        }
      }

      return result;
    }

    public T GetForm<T>(RadPageViewPage page) where T : RadForm
    {
      T result = null;

      if (Service.DicPages.TryGetValue(page, out RadForm form))
      {
        if (form is T) // if (form.GetType().IsAssignableFrom(typeof(T)))
        {
          try { result = (T)(form); } catch { };
        }
      }

      return result;
    }
  }
}