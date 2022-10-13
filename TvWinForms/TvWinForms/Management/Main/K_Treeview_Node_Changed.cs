using System;
using TvWinForms.Form;
using System.Diagnostics;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  partial class FrameworkManager
  {
    static void GotoEmptyPage() => MainForm.PvMain.SelectedPage = MainForm.PageEmpty;

    public static RadTreeNode CurrentNode { get; private set; }

    public static RadTreeNode PreviousNode { get; private set; }

    // У элементов верхнего уровня значение свойства Level = 0 //

    static void EventSelectedNodeChanged(object sender, RadTreeViewEventArgs e) // Событие: пользователь выбрал элемент Treeview //
    {
      PreviousNode = CurrentNode;

      CurrentNode = e.Node;

      EventUserLeftNode(PreviousNode, CurrentNode); // Событие: Пользователь покинул элемент Treeview //

      if (e.Node == null) return;

      //Trace.WriteLine($"EventSelectedNodeChanged ---- {CurrentNode.Text} ---- {CurrentNode.Level}");

      if (GroupManager.IsGroupNode(e.Node))    // Выбран элемент, который представляет собой группу элементов //
      {
        EventUserSelectedGroupNode(e.Node);
        GotoEmptyPage();
        return;
      }

      if (MainForm.TvMain.HotTracking) MainForm.TvMain.HotTracking = false;

      SubForm subForm = Service.GetSubForm(e.Node); // Попробуем узнать, какая форма соответствует данному элементу //

      if (subForm == null)
      {
        GotoEmptyPage();
        return;
      }

      if (subForm.Page != null)
      {
        MainForm.PvMain.SelectedPage = subForm.Page;
      }
      else
      {
        GotoEmptyPage();
      }
    }

    static void EventUserSelectedGroupNode(RadTreeNode node) // Выбран элемент, который представляет собой группу элементов //
    {
      if ((node.Level > 0) || ((node is CxNode) == false)) return;

      CxNode customNode = node as CxNode;

      if ((customNode == null) || (customNode.MyGroup == null)) return;

      string code = customNode.MyGroup.Code;
      Group group = GroupManager.GetGroup(code);
      if (group == null) return;

      MainForm.TvMain.HotTracking = (group.Code == GroupManager.CodeStandardGroupExitFromTheApplication);

      if (((group.ExpandOnSelect) || (FrameworkSettings.TreeviewNavigationAlwaysExpandOnSelect)) && (!node.Expanded)) node.Expand();
    }

    static void EventUserLeftNode(RadTreeNode nodePrevious, RadTreeNode nodeCurrent) // Событие: Пользователь покинул элемент Treeview //
    {
      Group groupPrevious = GroupManager.GetGroup(nodePrevious);

      if (groupPrevious == null) return;

      Group groupCurrent = GroupManager.GetGroup(nodeCurrent);

      RadTreeNode parentPrevious = GroupManager.IsGroupNode(nodePrevious) ? nodePrevious : nodePrevious.Parent;

      if (parentPrevious == null) return;


      if (groupPrevious.Code == GroupManager.CodeStandardGroupExitFromTheApplication)
      {      
        if ((nodeCurrent is CxNode) && (((nodeCurrent as CxNode)?.MySubForm?.Form is FxExit)))
        {
          return; // Пользователь нажал на элемент "Выход" //
        }
        else
        {
          parentPrevious.Collapse(); // Сворачиваем группу "Выход" только в том случае, если не был выбран пункт "Выход" //
          return;
        }
      }

      string codeOfCurrentGroup = groupCurrent == null ? string.Empty : groupCurrent.Code;

      bool collapse1 = groupPrevious.CollapseOnExit || FrameworkSettings.TreeviewNavigationAlwaysCollapseOnExit;
      bool collapse2 = (parentPrevious.Expanded) && (groupPrevious.Code != codeOfCurrentGroup);
      bool collapse3 = !((groupPrevious.Code == GroupManager.CodeStandardGroupMessagesAndSettings) && (groupPrevious.CollapseOnExit == false));
      bool collapse4 = !(FrameworkSettings.TreeviewNavigationPreventCollapseOnExit);

      if (collapse1 && collapse2 && collapse3 && collapse4) parentPrevious.Collapse();
    }
  }
}