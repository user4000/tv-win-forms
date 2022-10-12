using System;
using TvWinForms;
using System.Media;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Threading.Tasks;
using static TvWinForms.FrameworkManager;

namespace TvWinFormsExample
{
  public partial class FxForm1 : RadForm, IStartWork, IEndWork
  {
    public FxForm1()
    {
      InitializeComponent();
    }


    public void EventStartWork()
    {
      SetProperties();
      SetEvents();
      //Log.Save($"{this.GetType().FullName} ---> EventStartWork()");
    }

    void SetProperties()
    {
      BxTest2.Text = "Disable 8";
      BxTest3.Text = "Enable 8";
    }

    void SetEvents()
    {
      BxTest1.Click += new EventHandler(EventTest1);
      BxTest2.Click += new EventHandler(EventTest2);
      BxTest3.Click += new EventHandler(EventTest3);
    }

    private async void EventTest2(object sender, EventArgs e)
    {
      BxTest2.Enabled = false;

      Pages.EnablePage<FxForm8>(false);

      await Task.Delay(1000);
      BxTest2.Enabled = true;
    }

    private async void EventTest3(object sender, EventArgs e)
    {
      BxTest3.Enabled = false;

      Pages.EnablePage<FxForm8>(false);

      await Task.Delay(1000);
      BxTest3.Enabled = true;
    }

    private void EventTest1(object sender, EventArgs e)
    {
      Ms.Message("test", "test").Single(BxTest3).Sound(SystemSounds.Question).Info(3);
    }

    public void EventEndWork()
    {
      //Log.Save($"{this.GetType().FullName} ---> EventEndWork()");
    }
  }
}