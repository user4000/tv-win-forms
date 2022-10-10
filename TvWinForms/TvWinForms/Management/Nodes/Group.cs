using System.Threading.Tasks;

namespace TvWinForms
{

  public class Group
  {
    public string Text { get; private set; }

    public string Code { get; private set; }

    public string Rank { get; private set; }

    private Group()
    {

    }

    private Group(string code, string text, string rank)
    {
      Text = text ?? string.Empty;
      Code = code ?? string.Empty;
      Rank = rank ?? string.Empty;         
    }

    internal static Group Create(string code, string text, string rank)
    {
      Group group = new Group(code, text, rank);
      return group;
    }
  }
}