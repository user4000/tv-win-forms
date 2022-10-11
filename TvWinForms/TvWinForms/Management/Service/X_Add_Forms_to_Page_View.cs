using System;
using System.Drawing;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

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
      
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);

      page.Item.Visibility = subForm.FlagNodeVisible ? ElementVisibility.Visible : ElementVisibility.Collapsed;

      page.Item.Enabled = subForm.FlagNodeEnabled;

      CreateTreeNode(subForm);
    }

    internal bool ThisIsGroupNode(RadTreeNode node)
    {
      return (node.Tag != null) && (node.Tag is string) && (string.IsNullOrWhiteSpace((string)node.Tag) == false);
    }

    void CreateTreeNode(SubForm subForm)
    {
      RadTreeNode node = new RadTreeNode()
      {
        Text = subForm.PageText,
        Value = subForm,
        Tag = string.Empty,
        Font = FrameworkManager.MainForm.TvMain.Font
      };

      string codeOfGroup = subForm.FormGroup.Code;

      RadTreeNode[] nodesFound = MainForm.TvMain.FindNodes(oneNode => (ThisIsGroupNode(oneNode)) && ((string)oneNode.Tag == codeOfGroup));

      if (nodesFound.Length == 1)
      {
        RadTreeNode groupNode = nodesFound[0];
        groupNode.Nodes.Add(node);
        subForm.SetNodeForm(node);
        subForm.SetNodeGroup(groupNode);
        groupNode.Expand();       
      }
      else
      {
        string error = $"[TvWinForms] framework: WARNING !!! Failed to find a group for sub-form {subForm.UniqueName} !";
        RadMessageBox.Show(error, "ERROR !", MessageBoxButtons.OK, RadMessageIcon.Error);
        Trace.WriteLine(error);
      }
    }
  }
}