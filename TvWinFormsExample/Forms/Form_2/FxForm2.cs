using System;
using TvWinForms;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinFormsExample
{
  public partial class FxForm2 : RadForm, IUserLeftTheFormAsync, IUserVisitedTheFormAsync
  {
    public FxForm2()
    {
      InitializeComponent();
    }

    public async Task EventUserLeftTheFormAsync()
    {
      await Task.Delay(100);
      //Ms.Message("Form number 2 reports", "User left the page ASYNC !").Single(MsgPos.TopLeft).Fail(2);
    }

    public async Task EventUserVisitedTheFormAsync()
    {
      await Task.Delay(100);
      //Ms.Message("Form number 2 reports", "User visited the page ASYNC !").Single(MsgPos.TopLeft).Warning(2);
    }
  }
}