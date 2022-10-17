using System.Drawing;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  public class CxNode : RadTreeNode
  {
    public SubForm MySubForm { get; private set; }

    public Group MyGroup { get; private set; }

    public void SetGroup(Group group) => MyGroup = group;

    public void SetForm(SubForm form) => MySubForm = form;

    public Color ColorDefault { get; set; } = Color.Black;

    public Color ColorDisabled { get; set; } = Color.Gray;

    public void SetColor()
    {
      this.ForeColor = this.Enabled ? ColorDefault : ColorDisabled;
    }

    public static void SetColor(RadTreeNode node)
    {
      if ((node is CxNode) == false) return;
      CxNode customNode = node as CxNode;
      if (customNode == null) return;
      customNode.SetColor();
    }
  }
}