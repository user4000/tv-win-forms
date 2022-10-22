using System;
using TvWinForms;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading.Tasks;
using Telerik.WinControls.UI;
using static TvWinForms.FrameworkManager;

namespace TvWinFormsExample
{
  public partial class FxForm2 : RadForm, IStartWork, IUserLeftTheFormAsync, IUserVisitedTheFormAsync
  {

    string Header { get; set; } 

    string Message { get; set; } 

    public FxForm2()
    {
      InitializeComponent();
    }

    public void EventStartWork()
    {
      SetProperties();
      SetEvents();
    }

    private void SetProperties()
    {
      Header = Faker.Person.Ssn() + " " + Faker.Address.StreetName() + " " + Faker.Address.SecondaryAddress() + " " +
       Faker.Colors.SystemColor() + " " + Faker.Education.Major() + " " + Faker.Lorem.Sentence(3);

      Message = Faker.Lorem.Sentence(25);

      FrameworkSettings.MaxAlertCount = 7;
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

    private void SetEvents()
    {
      BxTest1.Click += new EventHandler(EventTest1);
      BxTest2.Click += new EventHandler(EventTest2);
      BxTest3.Click += new EventHandler(EventTest3);
      BxTest4.Click += new EventHandler(EventTest4);
      BxTest5.Click += new EventHandler(EventTest5);
      BxTest6.Click += new EventHandler(EventTest6);
      BxTestAlertStack.Click += new EventHandler(EventTestAlertStack);
    }

    private async void EventTestAlertStack(object sender, EventArgs e)
    {
      (BxTestAlertStack).Enabled = false;

      Header = Faker.Address.USCounty() + " " + Faker.Address.USCity() + " " + Faker.Company.CatchPhrase();
      Message = Faker.User.Username() + " " + Faker.Sports.SportType() + " " + Faker.Name.FullName() + " " +
        Faker.Commerce.ProductName() + " " + Faker.Person.Ssn() + " " + Faker.Company.CatchPhrase();

      Ms.Message(Header, Message).Pos(MsgPos.BottomLeft).Debug(25);

      await Task.Delay(1000);
      (BxTestAlertStack).Enabled = true;
    }

    private async void EventTest1(object sender, EventArgs e)
    {
      (BxTest1).Enabled = false;  
      Ms.Message(Header, Message).Single(BxTest1).Debug(5);
      await Task.Delay(1000);
      (BxTest1).Enabled = true;
    }

    private async void EventTest2(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;
      Ms.Message(Header, Message).Single(sender as Control).Info(5);
      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }

    private async void EventTest3(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;
      Ms.Message(Header, Message).Single(sender as Control).Ok(5);
      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }

    private async void EventTest4(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;
      Ms.Message(Header, Message).Single(sender as Control).Fail(5);
      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }

    private async void EventTest5(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;
      Ms.Message(Header, Message).Single(sender as Control).Warning(5);
      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }

    private async void EventTest6(object sender, EventArgs e)
    {
      (sender as Control).Enabled = false;
      Ms.Message(Header, Message).Single(sender as Control).Error(5);
      await Task.Delay(1000);
      (sender as Control).Enabled = true;
    }
  }
}