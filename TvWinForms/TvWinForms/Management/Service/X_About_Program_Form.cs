using System;

namespace TvWinForms
{
  public partial class FrameworkService
  {
    void SetAboutProgramForm(ushort idForm)
    {
      IdAboutProgramForm = idForm;
    }

    void SetAboutProgramForm(string UniqueFormName)
    {
      CodeAboutProgramForm = UniqueFormName;
    }

    bool IsAboutProgramForm(SubForm form)
    {
      return

        (
          (form.IdForm == IdAboutProgramForm) && (IdAboutProgramForm > 0)
        )

        ||

        (
          (form.UniqueName == CodeAboutProgramForm) && (string.IsNullOrWhiteSpace(CodeAboutProgramForm) == false)
        );
    }
  }
}