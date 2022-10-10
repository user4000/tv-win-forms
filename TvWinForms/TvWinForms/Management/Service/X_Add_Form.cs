using System;
using System.Diagnostics;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TvWinForms
{
  partial class FrameworkService
  {
    ushort GetNextIdForm() => IdForm++;


    ushort IdStartForm { get; set; } = 0;

    string CodeStartForm { get; set; } = string.Empty;



    ushort IdAboutProgramForm { get; set; } = 0;

    string CodeAboutProgramForm { get; set; } = string.Empty;

    bool FlagAboutProgramFormHasBeenCreated { get; set; } = false;


    HashSet<string> HsUniqueNames { get; } = new HashSet<string>();


    /// <summary>
    /// This method allows you to add a user form and returns a unique numeric identifier for the form.
    /// </summary>

    public ushort AddForm(Group group, RadForm form, string uniqueName, string pageText, bool tabEnabled, bool tabVisible) // Добавление формы в очередь //
    {
      ushort id = GetNextIdForm();

      if (string.IsNullOrWhiteSpace(uniqueName)) uniqueName = form.GetType().FullName + "-" + id.ToString();

      if ( CheckNameIsUnique(uniqueName) == false) return 0;

      SubForm subForm = SubForm.Create(id, group, form, uniqueName, pageText, tabEnabled, tabVisible);

      QueueForms.Enqueue(subForm);

      return id;
    }



    /// <summary>
    /// This method allows you to add a user form and returns a unique numeric identifier for the form.
    /// </summary>

    public ushort AddForm<T>(Group group, string uniqueName, string pageText, bool tabEnabled, bool tabVisible) where T : RadForm, new() // Добавление формы в очередь //
    {
      ushort id = GetNextIdForm();

      if (string.IsNullOrWhiteSpace(uniqueName)) uniqueName = typeof(T).GetType().FullName + "-" + id.ToString();

      if (CheckNameIsUnique(uniqueName) == false) return 0;

      SubForm subForm = SubForm.Create<T>(id, group, uniqueName, pageText, tabEnabled, tabVisible);

      QueueForms.Enqueue(subForm);

      return id;
    }
  }
}