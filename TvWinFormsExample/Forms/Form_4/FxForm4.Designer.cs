namespace TvWinFormsExample
{
    partial class FxForm4
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
      this.BxTest = new Telerik.WinControls.UI.RadButton();
      this.BxTreeviewHide = new Telerik.WinControls.UI.RadButton();
      this.BxTreeviewShow = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTest)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTreeviewHide)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTreeviewShow)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.AutoSize = false;
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.Green;
      this.LbFormTwo.Location = new System.Drawing.Point(112, 219);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(603, 91);
      this.LbFormTwo.TabIndex = 3;
      this.LbFormTwo.Text = "Form Number 4";
      // 
      // BxTest
      // 
      this.BxTest.Font = new System.Drawing.Font("Segoe UI", 15F);
      this.BxTest.Location = new System.Drawing.Point(48, 376);
      this.BxTest.Name = "BxTest";
      this.BxTest.Size = new System.Drawing.Size(369, 33);
      this.BxTest.TabIndex = 4;
      this.BxTest.Text = "Change Treeview dock side";
      // 
      // BxTreeviewHide
      // 
      this.BxTreeviewHide.Font = new System.Drawing.Font("Segoe UI", 15F);
      this.BxTreeviewHide.Location = new System.Drawing.Point(48, 438);
      this.BxTreeviewHide.Name = "BxTreeviewHide";
      this.BxTreeviewHide.Size = new System.Drawing.Size(369, 33);
      this.BxTreeviewHide.TabIndex = 4;
      this.BxTreeviewHide.Text = "Treeview hide";
      // 
      // BxTreeviewShow
      // 
      this.BxTreeviewShow.Font = new System.Drawing.Font("Segoe UI", 15F);
      this.BxTreeviewShow.Location = new System.Drawing.Point(48, 497);
      this.BxTreeviewShow.Name = "BxTreeviewShow";
      this.BxTreeviewShow.Size = new System.Drawing.Size(369, 33);
      this.BxTreeviewShow.TabIndex = 4;
      this.BxTreeviewShow.Text = "Treeview show";
      // 
      // FxForm4
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(866, 622);
      this.Controls.Add(this.BxTreeviewShow);
      this.Controls.Add(this.BxTreeviewHide);
      this.Controls.Add(this.BxTest);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxForm4";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxForm4";
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTest)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTreeviewHide)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTreeviewShow)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    private Telerik.WinControls.UI.RadButton BxTest;
    private Telerik.WinControls.UI.RadButton BxTreeviewHide;
    private Telerik.WinControls.UI.RadButton BxTreeviewShow;
  }
}
