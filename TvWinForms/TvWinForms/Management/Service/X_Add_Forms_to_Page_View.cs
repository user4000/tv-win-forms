using System;
using TvWinForms.Form;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkService
  {
    bool PageExists(string uniqueName) => DicForms.ContainsKey(uniqueName);

    internal void AddSubFormToDictionary(SubForm form)
    {
      try
      {
        if (DicForms.ContainsKey(form.UniqueName) == false) DicForms.Add(form.UniqueName, form);
      }
      catch
      {
        if (form != null)
          RadMessageBox.Show($"Error ! Failed to add a Sub-form [{form.UniqueName}] to dictionary!");
        throw;
      }
    }

    void AddPageAndFormToDictionary(RadPageViewPage page, RadForm form)
    {
      if (DicPages.ContainsKey(page) == false) DicPages.Add(page, form);
    }

    private void AddFormToPage(SubForm subForm)
    {
      if (PageExists(subForm.UniqueName)) return;

      RadPageViewPage page = CreateNewPage(subForm);

      AddSubFormToDictionary(subForm);

      RadForm form = subForm.Form;

      form.TopLevel = false; /* It is very important */

      form.Dock = DockStyle.Fill;
      form.FormBorderStyle = FormBorderStyle.None;
      form.Visible = true;
      form.BringToFront();

      page.Controls.Add(form);

      AddPageAndFormToDictionary(page, form);

      subForm.SetPage(page);

      page.Tag = subForm;

      CreateTreeNode(subForm);
    }

    public SubForm GetSubForm(RadTreeNode node)
    {
      SubForm result = null;

      if (node is CxNode) result = (node as CxNode).MySubForm;

      return result;
    }

    void CreateTreeNode(SubForm subForm) // NOTE: Create node for user form //
    {
      string codeOfGroup = subForm.FormGroup.Code;

      // Now we have to find an existing group node for the user form //
      RadTreeNode[] nodesFound = MainForm.TvMain.FindNodes(oneNode => (FrameworkManager.GroupManager.IsGroupNode(oneNode)) && (((CxNode)oneNode).MyGroup.Code == codeOfGroup));

      if (nodesFound.Length != 1)
      {
        string error = $"[TvWinForms] framework: WARNING !!! Failed to find a group for sub-form {subForm.UniqueName} !";
        RadMessageBox.Show(error, "ERROR !", MessageBoxButtons.OK, RadMessageIcon.Error);
        Trace.WriteLine(error);
        return;
      }

      CxNode node = new CxNode()
      {
        Text = "  " + subForm.PageText,
        Font = FrameworkManager.FrameworkSettings.FontTreeviewSubFormNode ?? FrameworkManager.MainForm.TvMain.Font,
        ColorDefault = FrameworkManager.FrameworkSettings.ColorTreeviewSubFormNode,
        ColorDisabled = FrameworkManager.FrameworkSettings.ColorTreeviewSubFormNodeDisabled
      };

      RadTreeNode groupNode = nodesFound[0];
      groupNode.Nodes.Add(node);
      subForm.SetNodeForm(node);
      subForm.SetNodeGroup(groupNode);

      Group group = FrameworkManager.GroupManager.GetGroup(groupNode);

      node.SetForm(subForm);
      node.SetGroup(group);
      node.Image = MainForm.PicItem.Image;

      if (subForm.Form is FxLog) node.Image = MainForm.PicItemMessages.Image;
      if (subForm.Form is FxExit) node.Image = MainForm.PicItemExit.Image;
      if (subForm.Form is FxSettings) node.Image = MainForm.PicItemSettings.Image;

      node.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

      bool expandGroup = false;

      if ((subForm.Page != MainForm.PageExit)) expandGroup = true;

      if ((group != null) && (group.CollapseOnExit)) expandGroup = false;

      if (expandGroup) groupNode.Expand();

      node.Enabled = subForm.FlagNodeEnabled;

      node.Visible = subForm.FlagNodeVisible;

      node.SetColor();
    }
  }
}