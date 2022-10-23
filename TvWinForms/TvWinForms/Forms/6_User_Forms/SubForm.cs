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

    public RadPageViewPage Page { get; private set; }

    public RadTreeNode NodeForm { get; private set; }

    public RadTreeNode NodeGroup { get; private set; }

    public Group FormGroup { get; private set; }

    public bool FlagNodeEnabled { get; } = true; 

    public bool FlagNodeVisible { get; } = true; 


    private SubForm(ushort idForm, Group group, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    { 
      Form = form;
      UniqueName = uniqueName;
      PageText = pageText;
      FlagNodeEnabled = enabled;
      FlagNodeVisible = visible;
      FormGroup = group;

      IdForm = idForm;

      TypeForm = form.GetType();
      TypeName = TypeForm.FullName;
    }

    internal static SubForm Create(ushort idForm, Group group, RadForm form, string uniqueName, string pageText, bool enabled, bool visible)
    {
      SubForm userForm = new SubForm(idForm, group, form, uniqueName, pageText, enabled, visible);
      return userForm;
    }

    internal static SubForm Create<T>(ushort idForm, Group group, string uniqueName, string pageText, bool enabled, bool visible) where T : RadForm, new()
    {
      T form = new T();      
      return Create(idForm, group,  form, uniqueName, pageText, enabled, visible);
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