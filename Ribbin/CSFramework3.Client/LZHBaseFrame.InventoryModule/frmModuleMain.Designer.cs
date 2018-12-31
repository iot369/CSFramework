namespace LZHBaseFrame.InventoryModule
{
    partial class frmModuleMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMainInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdj = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbReports = new DevExpress.XtraEditors.ImageListBoxControl();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnStockOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockIn = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdj = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheck = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ilReports
            // 
            this.ilReports.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilReports.ImageStream")));
            this.ilReports.Images.SetKeyName(0, "16_ArrayWhite.bmp");
            // 
            // pnlContainer
            // 
            this.pnlContainer.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlContainer.Appearance.Options.UseBackColor = true;
            this.pnlContainer.Controls.Add(this.labelControl4);
            this.pnlContainer.Controls.Add(this.labelControl3);
            this.pnlContainer.Controls.Add(this.labelControl2);
            this.pnlContainer.Controls.Add(this.labelControl1);
            this.pnlContainer.Controls.Add(this.pictureBox2);
            this.pnlContainer.Controls.Add(this.lbReports);
            this.pnlContainer.Controls.Add(this.btnStockOut);
            this.pnlContainer.Controls.Add(this.btnStockIn);
            this.pnlContainer.Controls.Add(this.panelControl3);
            this.pnlContainer.Controls.Add(this.btnCheck);
            this.pnlContainer.Controls.Add(this.simpleButton2);
            this.pnlContainer.Controls.Add(this.btnAdj);
            this.pnlContainer.Size = new System.Drawing.Size(967, 542);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMainInventory});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(967, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "存库模块";
            // 
            // menuMainInventory
            // 
            this.menuMainInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemStockIn,
            this.menuItemStockOut,
            this.menuItemAdj,
            this.menuItemCheck});
            this.menuMainInventory.Name = "menuMainInventory";
            this.menuMainInventory.Size = new System.Drawing.Size(68, 21);
            this.menuMainInventory.Text = "库存模块";
            // 
            // menuItemStockIn
            // 
            this.menuItemStockIn.Name = "menuItemStockIn";
            this.menuItemStockIn.Size = new System.Drawing.Size(124, 22);
            this.menuItemStockIn.Text = "入库单";
            this.menuItemStockIn.Click += new System.EventHandler(this.menuItemStockIn_Click);
            // 
            // menuItemStockOut
            // 
            this.menuItemStockOut.Name = "menuItemStockOut";
            this.menuItemStockOut.Size = new System.Drawing.Size(124, 22);
            this.menuItemStockOut.Text = "出库单";
            this.menuItemStockOut.Click += new System.EventHandler(this.menuItemStockOut_Click);
            // 
            // menuItemAdj
            // 
            this.menuItemAdj.Name = "menuItemAdj";
            this.menuItemAdj.Size = new System.Drawing.Size(124, 22);
            this.menuItemAdj.Text = "调整单";
            this.menuItemAdj.Click += new System.EventHandler(this.menuItemAdj_Click);
            // 
            // menuItemCheck
            // 
            this.menuItemCheck.Name = "menuItemCheck";
            this.menuItemCheck.Size = new System.Drawing.Size(124, 22);
            this.menuItemCheck.Text = "库存盘点";
            this.menuItemCheck.Click += new System.EventHandler(this.menuItemCheck_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.pictureBox1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(2, 467);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(963, 73);
            this.panelControl3.TabIndex = 30;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(388, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbReports
            // 
            this.lbReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbReports.HotTrackItems = true;
            this.lbReports.ImageList = this.ilReports;
            this.lbReports.Location = new System.Drawing.Point(773, 56);
            this.lbReports.Name = "lbReports";
            this.lbReports.Size = new System.Drawing.Size(189, 363);
            this.lbReports.TabIndex = 55;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(967, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 56;
            this.pictureBox2.TabStop = false;
            // 
            // btnStockOut
            // 
            this.btnStockOut.Image = global::LZHBaseFrame.InventoryModule.Properties.Resources._48_StockTaking;
            this.btnStockOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockOut.Location = new System.Drawing.Point(191, 309);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(84, 84);
            this.btnStockOut.TabIndex = 43;
            this.btnStockOut.Text = "出库单";
            this.btnStockOut.Click += new System.EventHandler(this.menuItemStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.Image = global::LZHBaseFrame.InventoryModule.Properties.Resources._48_Adjustment;
            this.btnStockIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStockIn.Location = new System.Drawing.Point(25, 67);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(84, 84);
            this.btnStockIn.TabIndex = 42;
            this.btnStockIn.Text = "入库单";
            this.btnStockIn.Click += new System.EventHandler(this.menuItemStockIn_Click);
            // 
            // btnAdj
            // 
            this.btnAdj.Enabled = false;
            this.btnAdj.Image = global::LZHBaseFrame.InventoryModule.Properties.Resources._48_NewProduct;
            this.btnAdj.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAdj.Location = new System.Drawing.Point(356, 190);
            this.btnAdj.Name = "btnAdj";
            this.btnAdj.Size = new System.Drawing.Size(84, 84);
            this.btnAdj.TabIndex = 18;
            this.btnAdj.Text = "調整單";
            this.btnAdj.Click += new System.EventHandler(this.menuItemAdj_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Enabled = false;
            this.btnCheck.Image = global::LZHBaseFrame.InventoryModule.Properties.Resources._48_SalaryParmater;
            this.btnCheck.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCheck.Location = new System.Drawing.Point(191, 190);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(84, 84);
            this.btnCheck.TabIndex = 16;
            this.btnCheck.Text = "库存盘点";
            this.btnCheck.Click += new System.EventHandler(this.menuItemCheck_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Enabled = false;
            this.simpleButton2.Image = global::LZHBaseFrame.InventoryModule.Properties.Resources._48_NewProduct;
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton2.Location = new System.Drawing.Point(191, 67);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(84, 84);
            this.simpleButton2.TabIndex = 18;
            this.simpleButton2.Text = "IQC";
            this.simpleButton2.Click += new System.EventHandler(this.menuItemAdj_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(115, 104);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 2);
            this.labelControl1.TabIndex = 57;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(281, 232);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 2);
            this.labelControl2.TabIndex = 58;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl3.Location = new System.Drawing.Point(229, 157);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(2, 31);
            this.labelControl3.TabIndex = 58;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Black;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl4.Location = new System.Drawing.Point(229, 280);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(2, 31);
            this.labelControl4.TabIndex = 58;
            // 
            // frmModuleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(967, 542);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmModuleMain";
            this.Controls.SetChildIndex(this.pnlContainer, 0);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pnlContainer)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMainInventory;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheck;
        private DevExpress.XtraEditors.SimpleButton btnAdj;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnStockOut;
        private DevExpress.XtraEditors.SimpleButton btnStockIn;
        private System.Windows.Forms.ToolStripMenuItem menuItemStockIn;
        private System.Windows.Forms.ToolStripMenuItem menuItemStockOut;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdj;
        protected System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.ImageListBoxControl lbReports;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCheck;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
