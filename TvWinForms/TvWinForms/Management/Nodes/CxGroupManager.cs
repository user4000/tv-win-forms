using System;
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


    public Group Create(string code, string text, string rank)
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

      Group group = Group.Create(code, text, rank);

      Groups.Add(group);
  
      SortList(true);

      return group;
    }

    void AddFrameworkStandardGroups()
    {
      GroupStandardCodes.Add(CodeStandardGroupAboutProgram);
      GroupStandardCodes.Add(CodeStandardGroupMessagesAndSettings);
      GroupStandardCodes.Add(CodeStandardGroupExitFromTheApplication);

      GroupStandardMessagesAndSettings = this.Create(CodeStandardGroupMessagesAndSettings, "Messages and Settings", "z01");
      GroupStandardAboutProgram = this.Create(CodeStandardGroupAboutProgram, "About Program", "z02");
      GroupStandardExit = this.Create(CodeStandardGroupExitFromTheApplication, "Exit", "z03");
    }

    RadTreeNode CreateGroupNode(Group group) // Это элемент, который в себе будет содержать другие элементы //
    {
      RadTreeNode node = new RadTreeNode();
      node.Text = group.Text;
      node.Tag = group.Code;
      node.Value = group.Code;
      node.Font = FrameworkManager.MainForm.TvMain.Font;
      return node;
    }

    internal void TreeviewCreateGroups()
    {
      FrameworkManager.MainForm.TvMain.AllowEdit = false;
      
      foreach (Group group in Groups)
      {        
        FrameworkManager.MainForm.TvMain.Nodes.Add(CreateGroupNode(group));
      }
    }
  }
}