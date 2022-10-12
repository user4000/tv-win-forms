using Telerik.WinControls.UI;

namespace TvWinForms
{
  public class CxNode : RadTreeNode
  {
    public SubForm MySubForm { get; private set; }

    public Group MyGroup { get; private set; }

    public void SetGroup(Group group) => MyGroup = group;

    public void SetForm(SubForm form) => MySubForm = form;
  }
}