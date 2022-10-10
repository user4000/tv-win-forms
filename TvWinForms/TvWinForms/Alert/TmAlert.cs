using System.ComponentModel;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  public class TmAlert : RadDesktopAlert
  {      
    internal TmAlert(IContainer container) : base(container)
    {
      AutoClose = true;
      FadeAnimationFrames = 100;
      FadeAnimationSpeed = 50;
      FadeAnimationType = FadeAnimationType.FadeOut;
      AutoSize = true;
      CanMove = true;
      PopupAnimation = false;
      ShowOptionsButton = false;
      Opacity = TmAlertPainter.AlertOpacity;      
    }
  }
}