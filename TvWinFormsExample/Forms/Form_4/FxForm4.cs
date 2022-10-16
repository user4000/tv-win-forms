using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using TvWinForms;

namespace TvWinFormsExample
{
  public partial class FxForm4 : RadForm, IStartWork
  {
    public FxForm4()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      SetEvents();
    }

    private void SetEvents()
    {
      BxTest.Click += new EventHandler(EventTest);
      BxTreeviewHide.Click += new EventHandler(EventTestHide);
      BxTreeviewShow.Click += new EventHandler(EventTestShow);
    }

    private async void EventTest(object sender, EventArgs e)
    {
      BxTest.Enabled = false;
      FrameworkManager.MainForm.ChangeTreeviewDockSide();
      await Task.Delay(2500);
      BxTest.Enabled = true;
    }

    private async void EventTestHide(object sender, EventArgs e)
    {
      BxTreeviewHide.Enabled = false;
      FrameworkManager.MainForm.ShowTreeviewPanel(false);
      await Task.Delay(1500);
      BxTreeviewHide.Enabled = true;
    }

    private async void EventTestShow(object sender, EventArgs e)
    {
      BxTreeviewShow.Enabled = false;
      FrameworkManager.MainForm.ShowTreeviewPanel(true);     
      await Task.Delay(1500);
      BxTreeviewShow.Enabled = true;
    }
  }
}