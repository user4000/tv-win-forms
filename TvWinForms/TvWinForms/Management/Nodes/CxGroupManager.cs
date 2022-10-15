using System;
using System.Linq;
using Telerik.WinControls.UI;
using System.Collections.Generic;

namespace TvWinForms
{
  public class CxGroupManager
  {
    public string CodeStandardGroupMessagesAndSettings { get; } = "Framework_standard_group____messages_and_settings";

    public string CodeStandardGroupExitFromTheApplication { get; } = "Framework_standard_group____main_exit";

    public string CodeStandardGroupAboutProgram { get; } = "Framework_standard_group____about_program";


    List<Group> Groups { get; } = new List<Group>();

    HashSet<string> GroupCodes { get; } = new HashSet<string>();

    HashSet<string> GroupStandardCodes { get; } = new HashSet<string>();


    public Group GroupStandardAboutProgram { get; private set; }


    internal Group GroupStandardMessagesAndSettings { get; private set; }


    internal Group GroupStandardExit { get; private set; }



    CxGroupManager()
    {
      AddFrameworkStandardGroups();
    }

    internal static CxGroupManager CreateManager() => new CxGroupManager();


    internal void SortList(bool sort)
    {
      if (sort) Groups.Sort((x, y) => x.Rank.CompareTo(y.Rank));
    }


    public bool StandardFrameworkGroup(string code) => GroupStandardCodes.Contains(code);

    public bool StandardFrameworkGroup(Group group) => StandardFrameworkGroup(group.Code);


    public Group Create(string code, string text, string rank, bool expandOnSelect = false, bool collapseOnExit = false)
    {
      if (GroupCodes.Contains(code))
      {
        throw new ApplicationException($"The group code value you specified is not unique: {code}");
      }

      if (string.IsNullOrWhiteSpace(code))
      {
        throw new ApplicationException($"The group code value you specified is empty!");
      }

      if (string.IsNullOrWhiteSpace(text))
      {
        throw new ApplicationException($"The group text value you specified is empty!");
      }

      GroupCodes.Add(code);

      if (string.IsNullOrWhiteSpace(rank)) rank = "abc";

      if (StandardFrameworkGroup(code) == false)
      {
        rank = "a_" + rank;
      }

      Group group = Group.Create(code, text, rank, expandOnSelect, collapseOnExit);

      Groups.Add(group);
  
      SortList(true);

      return group;
    }

    void AddFrameworkStandardGroups() // NOTE: Creating standard groups //
    {
      GroupStandardCodes.Add(CodeStandardGroupAboutProgram);
      GroupStandardCodes.Add(CodeStandardGroupMessagesAndSettings);
      GroupStandardCodes.Add(CodeStandardGroupExitFromTheApplication);

      GroupStandardMessagesAndSettings = this.Create(CodeStandardGroupMessagesAndSettings, "Settings and messages", "z01", true);
      GroupStandardAboutProgram = this.Create(CodeStandardGroupAboutProgram, "About program", "z02", true, true);
      GroupStandardExit = this.Create(CodeStandardGroupExitFromTheApplication, "Exit", "z03", true, true);
    }

    CxNode CreateGroupNode(Group group) // NOTE: Create GROUP node // 
    {
      CxNode node = new CxNode();
      node.Text = "  " + group.Text;
      node.SetGroup(group);
      node.ForeColor = FrameworkManager.FrameworkSettings.ColorTreeviewGroupNode;
      node.Font = FrameworkManager.FrameworkSettings.FontTreeviewGroupNode ?? FrameworkManager.MainForm.TvMain.Font;
      node.Image = FrameworkManager.MainForm.PicGroup.Image;

      if (group.Code == this.CodeStandardGroupExitFromTheApplication) node.Image = FrameworkManager.MainForm.PicGroupExit.Image;
      if (group.Code == this.CodeStandardGroupMessagesAndSettings) node.Image = FrameworkManager.MainForm.PicGroupSettings.Image;

      node.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;

      return node;
    }

    internal void TreeviewCreateGroups()
    {
      FrameworkManager.MainForm.TvMain.AllowEdit = false;

      GroupStandardExit.SetText(FrameworkManager.FrameworkSettings.HeaderGroupExit);
      GroupStandardAboutProgram.SetText(FrameworkManager.FrameworkSettings.HeaderGroupAboutProgram);
      GroupStandardMessagesAndSettings.SetText(FrameworkManager.FrameworkSettings.HeaderGroupMessagesAndSettings);
 
      foreach (Group group in Groups)
      {        
        FrameworkManager.MainForm.TvMain.Nodes.Add(CreateGroupNode(group));
      }
    }

    public bool IsGroupNode(RadTreeNode node) // Можно также использовать свойство Level //
    {
      // return (node.Tag != null) && (node.Tag is string) && (string.IsNullOrWhiteSpace((string)node.Tag) == false);
      return (node.Level == 0);
    }

    public Group GetGroup(string groupCode)
    {
      return Groups.FirstOrDefault(group => group.Code == groupCode);
    }

    public Group GetGroup(RadTreeNode node)
    {
      Group group = null;
      if (node is CxNode) group = (node as CxNode).MyGroup;
      return group;
    }

    internal RadTreeNode GetParent(RadTreeNode node)
    {
      RadTreeNode parent = null;
      if (node == null) return parent;
      if (node.Level == 0) return node;
      parent = node.Parent;
      return parent;
    }
  }
}