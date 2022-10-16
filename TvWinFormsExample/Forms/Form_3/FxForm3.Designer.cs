namespace TvWinFormsExample
{
  partial class FxForm3
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.LbFormTwo = new Telerik.WinControls.UI.RadLabel();
      this.PvMain = new Telerik.WinControls.UI.RadPageView();
      this.PageFirst = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageLog = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageSettings = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageAboutProgram = new Telerik.WinControls.UI.RadPageViewPage();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).BeginInit();
      this.PvMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.Green;
      this.LbFormTwo.Location = new System.Drawing.Point(31, 31);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(232, 38);
      this.LbFormTwo.TabIndex = 2;
      this.LbFormTwo.Text = "Form Number 3";
      // 
      // PvMain
      // 
      this.PvMain.Controls.Add(this.PageFirst);
      this.PvMain.Controls.Add(this.PageLog);
      this.PvMain.Controls.Add(this.PageSettings);
      this.PvMain.Controls.Add(this.PageAboutProgram);
      this.PvMain.Font = new System.Drawing.Font("Verdana", 10F);
      this.PvMain.Location = new System.Drawing.Point(66, 121);
      this.PvMain.Name = "PvMain";
      this.PvMain.SelectedPage = this.PageFirst;
      this.PvMain.Size = new System.Drawing.Size(938, 478);
      this.PvMain.TabIndex = 7;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.UI.StripViewItemLayout)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.StripViewButtonsPanel)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).DrawBorder = true;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableImageTransparency = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableFocusBorder = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).EnableHighlight = true;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).ToolTipText = "Scroll Strip Left";
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Enabled = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).Visibility = Telerik.WinControls.ElementVisibility.Visible;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0))).MinSize = new System.Drawing.Size(32, 24);
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).ToolTipText = "Scroll Strip Right";
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).Enabled = false;
      ((Telerik.WinControls.UI.RadPageViewStripButtonElement)(this.PvMain.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(1))).MinSize = new System.Drawing.Size(32, 24);
      // 
      // PageFirst
      // 
      this.PageFirst.ItemSize = new System.Drawing.SizeF(64F, 30F);
      this.PageFirst.Location = new System.Drawing.Point(6, 35);
      this.PageFirst.Name = "PageFirst";
      this.PageFirst.Size = new System.Drawing.Size(926, 437);
      this.PageFirst.Text = "Page 1";
      // 
      // PageLog
      // 
      this.PageLog.ItemSize = new System.Drawing.SizeF(83F, 30F);
      this.PageLog.Location = new System.Drawing.Point(6, 35);
      this.PageLog.Name = "PageLog";
      this.PageLog.Size = new System.Drawing.Size(884, 370);
      this.PageLog.Text = "Messages";
      // 
      // PageSettings
      // 
      this.PageSettings.ItemSize = new System.Drawing.SizeF(74F, 30F);
      this.PageSettings.Location = new System.Drawing.Point(6, 35);
      this.PageSettings.Name = "PageSettings";
      this.PageSettings.Size = new System.Drawing.Size(884, 370);
      this.PageSettings.Text = "Settings";
      // 
      // PageAboutProgram
      // 
      this.PageAboutProgram.ItemSize = new System.Drawing.SizeF(121F, 30F);
      this.PageAboutProgram.Location = new System.Drawing.Point(6, 35);
      this.PageAboutProgram.Name = "PageAboutProgram";
      this.PageAboutProgram.Size = new System.Drawing.Size(926, 437);
      this.PageAboutProgram.Text = "About Program";
      // 
      // FxForm3
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1081, 671);
      this.Controls.Add(this.PvMain);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxForm3";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "";
      this.Load += new System.EventHandler(this.FxForm3_Load);
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).EndInit();
      this.PvMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    public Telerik.WinControls.UI.RadPageView PvMain;
    public Telerik.WinControls.UI.RadPageViewPage PageFirst;
    public Telerik.WinControls.UI.RadPageViewPage PageLog;
    public Telerik.WinControls.UI.RadPageViewPage PageSettings;
    public Telerik.WinControls.UI.RadPageViewPage PageAboutProgram;
  }
}
