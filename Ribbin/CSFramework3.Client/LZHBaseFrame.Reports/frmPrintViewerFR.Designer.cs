namespace LZHBaseFrame.Reports
{
    partial class frmPrintViewerFR
    {
        /// <summary>
        /// shejibianliang
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// qinglishiyongziyuan
        /// </summary>
        /// <param name="disposing">ruguoyingshifang</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows chuangtishengchagn

        /// <summary>
        /// shejiqizhichisuoxu
        /// shiongdaimabianji
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintViewerFR));
            this.FRPreview = new AxFastReport.AxTfrxActivePreviewForm();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbExportTypes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.FRPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // FRPreview
            // 
            resources.ApplyResources(this.FRPreview, "FRPreview");
            this.FRPreview.Name = "FRPreview";
            this.FRPreview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FRPreview.OcxState")));
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbExportTypes
            // 
            resources.ApplyResources(this.cbExportTypes, "cbExportTypes");
            this.cbExportTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportTypes.FormattingEnabled = true;
            this.cbExportTypes.Name = "cbExportTypes";
            // 
            // frmPrintViewerFR
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbExportTypes);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.FRPreview);
            this.Name = "frmPrintViewerFR";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrintViewerFR_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrintViewerFR_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.FRPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxFastReport.AxTfrxActivePreviewForm FRPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbExportTypes;
    }
}