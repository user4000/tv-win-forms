using System.ComponentModel;
using Telerik.WinControls.UI;

namespace TvWinForms
{
  public class TmAlert : RadDesktopAlert
  {      
    internal TmAlert(IContainer container) : base(container)
    {
      AutoClose = true;

      //FadeAnimationFrames = 10;
      //FadeAnimationSpeed = 5;
      //FadeAnimationType = FadeAnimationType.FadeOut;

      AutoSize = true;
      CanMove = true;

      PopupAnimation = false;
      PopupAnimationDirection = RadDirection.Down;
      PopupAnimationEasing = Telerik.WinControls.RadEasingType.Default;

      ShowOptionsButton = false;    
      Opacity = TmAlertPainter.AlertOpacity;      
    }
  }
}