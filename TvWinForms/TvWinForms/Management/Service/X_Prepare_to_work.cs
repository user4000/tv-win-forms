using System;
using System.Collections.Generic;

namespace TvWinForms
{
  partial class FrameworkService
  {
    void AddFormsFromQueueToPageView()
    {
      while ( QueueForms.Count > 0 )
      {
        SubForm subForm = QueueForms.Dequeue();
        AddFormToPage(subForm);
      }
    }

    public void TreeviewCreateGroups()
    {
      FrameworkManager.GroupManager.TreeviewCreateGroups();
    }

    public void PlaceAllSubFormsToMainPageView()
    {
      CreateFormSetting(); 
      CreateFormLog();
      CreateFormExit();

      AddFormsFromQueueToPageView(); // Добавляем формы из очереди на Page View //
   
      ExecStartWorkHandlerForEachSubForm(); // Выполнить событие IStartForm для каждой формы, которая поддерживает этот интерфейс //
    }

    internal void ExecStartWorkHandlerForEachSubForm()
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms)
      {
        entry.Value.ExecStartWorkHandler();
      }
    }

    internal void ExecEndWorkHandlerForEachSubForm()
    {
      foreach (KeyValuePair<string, SubForm> entry in DicForms)
        entry.Value.ExecEndWorkHandler();
    }
  }
}