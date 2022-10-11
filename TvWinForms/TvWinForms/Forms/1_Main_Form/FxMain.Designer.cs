namespace TvWinForms
{
    partial class FxMain
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
      this.components = new System.ComponentModel.Container();
      this.MainFormMenu = new Telerik.WinControls.UI.RadMenu();
      this.MenuItemFirstItem = new Telerik.WinControls.UI.RadMenuItem();
      this.PnMainTop = new Telerik.WinControls.UI.RadPanel();
      this.SplitterMainHorizontal = new System.Windows.Forms.Splitter();
      this.SplitterMainVertical = new System.Windows.Forms.Splitter();
      this.PvMain = new Telerik.WinControls.UI.RadPageView();
      this.PageEmpty = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageLog = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageSettings = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageAboutProgram = new Telerik.WinControls.UI.RadPageViewPage();
      this.PageExit = new Telerik.WinControls.UI.RadPageViewPage();
      this.NotifyIconMainForm = new System.Windows.Forms.NotifyIcon(this.components);
      this.TvMain = new Telerik.WinControls.UI.RadTreeView();
      this.PnTreeview = new Telerik.WinControls.UI.RadPanel();
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).BeginInit();
      this.PvMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TvMain)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnTreeview)).BeginInit();
      this.PnTreeview.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // MainFormMenu
      // 
      this.MainFormMenu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MainFormMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuItemFirstItem});
      this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
      this.MainFormMenu.Name = "MainFormMenu";
      this.MainFormMenu.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
      this.MainFormMenu.Size = new System.Drawing.Size(1192, 28);
      this.MainFormMenu.TabIndex = 1;
      this.MainFormMenu.Visible = false;
      // 
      // MenuItemFirstItem
      // 
      this.MenuItemFirstItem.Name = "MenuItemFirstItem";
      this.MenuItemFirstItem.Padding = new System.Windows.Forms.Padding(15, 1, 15, 1);
      this.MenuItemFirstItem.Text = "Main menu";
      this.MenuItemFirstItem.UseCompatibleTextRendering = false;
      // 
      // PnMainTop
      // 
      this.PnMainTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PnMainTop.Location = new System.Drawing.Point(0, 28);
      this.PnMainTop.Name = "PnMainTop";
      this.PnMainTop.Size = new System.Drawing.Size(1192, 35);
      this.PnMainTop.TabIndex = 2;
      this.PnMainTop.Visible = false;
      // 
      // SplitterMainHorizontal
      // 
      this.SplitterMainHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
      this.SplitterMainHorizontal.Location = new System.Drawing.Point(0, 63);
      this.SplitterMainHorizontal.Name = "SplitterMainHorizontal";
      this.SplitterMainHorizontal.Size = new System.Drawing.Size(1192, 5);
      this.SplitterMainHorizontal.TabIndex = 3;
      this.SplitterMainHorizontal.TabStop = false;
      this.SplitterMainHorizontal.Visible = false;
      // 
      // SplitterMainVertical
      // 
      this.SplitterMainVertical.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.SplitterMainVertical.Location = new System.Drawing.Point(0, 760);
      this.SplitterMainVertical.Name = "SplitterMainVertical";
      this.SplitterMainVertical.Size = new System.Drawing.Size(1192, 10);
      this.SplitterMainVertical.TabIndex = 5;
      this.SplitterMainVertical.TabStop = false;
      // 
      // PvMain
      // 
      this.PvMain.Controls.Add(this.PageEmpty);
      this.PvMain.Controls.Add(this.PageLog);
      this.PvMain.Controls.Add(this.PageSettings);
      this.PvMain.Controls.Add(this.PageAboutProgram);
      this.PvMain.Controls.Add(this.PageExit);
      this.PvMain.Font = new System.Drawing.Font("Verdana", 10F);
      this.PvMain.Location = new System.Drawing.Point(377, 100);
      this.PvMain.Name = "PvMain";
      this.PvMain.SelectedPage = this.PageEmpty;
      this.PvMain.Size = new System.Drawing.Size(758, 627);
      this.PvMain.TabIndex = 6;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PvMain.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(1);
      ((Telerik.WinControls.UI.StripViewItemContainer)(this.PvMain.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // PageEmpty
      // 
      this.PageEmpty.ItemSize = new System.Drawing.SizeF(99F, 30F);
      this.PageEmpty.Location = new System.Drawing.Point(6, 35);
      this.PageEmpty.Name = "PageEmpty";
      this.PageEmpty.Size = new System.Drawing.Size(746, 586);
      this.PageEmpty.Text = "Page Empty";
      // 
      // PageLog
      // 
      this.PageLog.ItemSize = new System.Drawing.SizeF(83F, 30F);
      this.PageLog.Location = new System.Drawing.Point(6, 35);
      this.PageLog.Name = "PageLog";
      this.PageLog.Size = new System.Drawing.Size(746, 586);
      this.PageLog.Text = "Messages";
      // 
      // PageSettings
      // 
      this.PageSettings.ItemSize = new System.Drawing.SizeF(74F, 30F);
      this.PageSettings.Location = new System.Drawing.Point(6, 35);
      this.PageSettings.Name = "PageSettings";
      this.PageSettings.Size = new System.Drawing.Size(746, 586);
      this.PageSettings.Text = "Settings";
      // 
      // PageAboutProgram
      // 
      this.PageAboutProgram.ItemSize = new System.Drawing.SizeF(121F, 30F);
      this.PageAboutProgram.Location = new System.Drawing.Point(6, 35);
      this.PageAboutProgram.Name = "PageAboutProgram";
      this.PageAboutProgram.Size = new System.Drawing.Size(746, 586);
      this.PageAboutProgram.Text = "About Program";
      // 
      // PageExit
      // 
      this.PageExit.ItemSize = new System.Drawing.SizeF(43F, 30F);
      this.PageExit.Location = new System.Drawing.Point(6, 35);
      this.PageExit.Name = "PageExit";
      this.PageExit.Size = new System.Drawing.Size(746, 586);
      this.PageExit.Text = "Exit";
      // 
      // NotifyIconMainForm
      // 
      this.NotifyIconMainForm.Text = "Application";
      // 
      // TvMain
      // 
      this.TvMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
      this.TvMain.Cursor = System.Windows.Forms.Cursors.Default;
      this.TvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TvMain.Font = new System.Drawing.Font("Verdana", 9F);
      this.TvMain.ForeColor = System.Drawing.Color.Black;
      this.TvMain.HotTracking = false;
      this.TvMain.ItemHeight = 30;
      this.TvMain.LineStyle = Telerik.WinControls.UI.TreeLineStyle.Solid;
      this.TvMain.Location = new System.Drawing.Point(1, 1);
      this.TvMain.Name = "TvMain";
      this.TvMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
      this.TvMain.ShowLines = true;
      this.TvMain.ShowRootLines = false;
      this.TvMain.Size = new System.Drawing.Size(315, 627);
      this.TvMain.SpacingBetweenNodes = -1;
      this.TvMain.TabIndex = 1;
      this.TvMain.TreeIndent = 35;
      // 
      // PnTreeview
      // 
      this.PnTreeview.Controls.Add(this.TvMain);
      this.PnTreeview.Location = new System.Drawing.Point(25, 98);
      this.PnTreeview.Name = "PnTreeview";
      this.PnTreeview.Padding = new System.Windows.Forms.Padding(1);
      this.PnTreeview.Size = new System.Drawing.Size(317, 629);
      this.PnTreeview.TabIndex = 7;
      // 
      // FxMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1192, 770);
      this.Controls.Add(this.PnTreeview);
      this.Controls.Add(this.PvMain);
      this.Controls.Add(this.SplitterMainVertical);
      this.Controls.Add(this.SplitterMainHorizontal);
      this.Controls.Add(this.PnMainTop);
      this.Controls.Add(this.MainFormMenu);
      this.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.Name = "FxMain";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "";
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PvMain)).EndInit();
      this.PvMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TvMain)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnTreeview)).EndInit();
      this.PnTreeview.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    public Telerik.WinControls.UI.RadMenu MainFormMenu;
    public Telerik.WinControls.UI.RadMenuItem MenuItemFirstItem;
    public Telerik.WinControls.UI.RadPanel PnMainTop;
    public System.Windows.Forms.Splitter SplitterMainHorizontal;
    public System.Windows.Forms.Splitter SplitterMainVertical;
    public Telerik.WinControls.UI.RadPageViewPage PageEmpty;
    public Telerik.WinControls.UI.RadPageViewPage PageLog;
    public Telerik.WinControls.UI.RadPageViewPage PageSettings;
    public Telerik.WinControls.UI.RadPageViewPage PageAboutProgram;
    public Telerik.WinControls.UI.RadPageViewPage PageExit;
    public Telerik.WinControls.UI.RadPageView PvMain;
    public System.Windows.Forms.NotifyIcon NotifyIconMainForm;
    public Telerik.WinControls.UI.RadTreeView TvMain;
    public Telerik.WinControls.UI.RadPanel PnTreeview;
  }
}
