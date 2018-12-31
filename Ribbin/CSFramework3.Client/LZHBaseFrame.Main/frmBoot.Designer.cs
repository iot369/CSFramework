namespace LZHBaseFrame.Main
{
    partial class frmBoot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoot));
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblLoadingInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.EditValue = "1";
            this.progressBarControl1.Location = new System.Drawing.Point(88, 183);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressBarControl1.Size = new System.Drawing.Size(293, 18);
            this.progressBarControl1.TabIndex = 0;
            // 
            // lblLoadingInfo
            // 
            this.lblLoadingInfo.AutoSize = true;
            this.lblLoadingInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingInfo.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLoadingInfo.Location = new System.Drawing.Point(86, 203);
            this.lblLoadingInfo.Name = "lblLoadingInfo";
            this.lblLoadingInfo.Size = new System.Drawing.Size(59, 11);
            this.lblLoadingInfo.TabIndex = 13;
            this.lblLoadingInfo.Text = "系统初始化...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 336);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // frmBoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(522, 336);
            this.Controls.Add(this.lblLoadingInfo);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBoot";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblLoadingInfo;
        public DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.PictureBox pictureBox1;


    }
}