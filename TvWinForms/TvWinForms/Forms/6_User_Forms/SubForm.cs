using System;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  public class SubForm
  {
    public RadForm Form { get; }

    public ushort IdForm { get; }

    public Type TypeForm { get; }

    public string TypeName { get; }

    public string UniqueName { get; } = string.Empty;

    public string PageText { get; } = string.Empty;

    public RadPageViewPage Page { get; set; }

    public RadTreeNode NodeForm { get; set; }

    public RadTreeNode NodeGroup { get; set; }


    public bool FlagNodeEnabled { get; } = true; // Активна или отключена верхушка вкладки //

    public bool FlagNodeVisible { get; } = true; // Видима или скрыта верхушка вкладки //


    private SubForm(ushort idForm, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    { 
      Form = form;
      UniqueName = uniqueName;
      PageText = pageText;
      FlagNodeEnabled = enabled;
      FlagNodeVisible = visible;

      IdForm = idForm;

      TypeForm = form.GetType();
      TypeName = TypeForm.FullName;
    }

    internal static SubForm Create(ushort idForm, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    {
      SubForm userForm = new SubForm(idForm, form, uniqueName, pageText, enabled, visible);
      return userForm;
    }

    internal static SubForm Create<T>(ushort idForm, string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();      
      return Create(idForm, form, uniqueName, pageText, enabled, visible);
    }




    internal void SetPage(RadPageViewPage page) => Page = page;

    internal void SetNodeForm(RadTreeNode node) => NodeForm = node;

    internal void SetNodeGroup(RadTreeNode node) => NodeGroup = node;



    internal void ExecStartWorkHandler()
    {
      if ((Form != null) && (Form is IStartWork))
      {
        IStartWork form = (IStartWork)Form;
        form.EventStartWork();
      };
    }

    internal void ExecEndWorkHandler()
    {
      if ((Form != null) && (Form is IEndWork))
      {
        IEndWork form = (IEndWork)Form;
        form.EventEndWork();
      };
    }

    void Dispose(bool ExecuteEndWorkHandler)
    {
      if (Form != null)
      {
        ExecEndWorkHandler();
        Form.Visible = false;
        Form.Close();
        try { Form.Dispose(); } catch { };
      }
    }
  }
}