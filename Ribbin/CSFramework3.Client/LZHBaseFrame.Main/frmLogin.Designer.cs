namespace LZHBaseFrame.Main
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkSaveLoginInfo = new DevExpress.XtraEditors.CheckEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.pcInputArea = new DevExpress.XtraEditors.PanelControl();
            this.btnModifyPwd = new System.Windows.Forms.LinkLabel();
            this.txtDataset = new DevExpress.XtraEditors.LookUpEdit();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblLoadingInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveLoginInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInputArea)).BeginInit();
            this.pcInputArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(232, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "欢迎使用LZTMES系统(User Login)";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(308, 67);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(83, 55);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登录 (&L)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(308, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 33);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消 (&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkSaveLoginInfo
            // 
            this.chkSaveLoginInfo.Location = new System.Drawing.Point(53, 67);
            this.chkSaveLoginInfo.Name = "chkSaveLoginInfo";
            this.chkSaveLoginInfo.Properties.Caption = "保存登录信息";
            this.chkSaveLoginInfo.Size = new System.Drawing.Size(104, 19);
            this.chkSaveLoginInfo.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "帐套：";
            // 
            // txtUser
            // 
            this.txtUser.EditValue = "admin";
            this.txtUser.Location = new System.Drawing.Point(55, 13);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(191, 20);
            this.txtUser.TabIndex = 21;
            // 
            // txtPwd
            // 
            this.txtPwd.EditValue = "LZHBaseFrame";
            this.txtPwd.Location = new System.Drawing.Point(55, 40);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(191, 20);
            this.txtPwd.TabIndex = 22;
            // 
            // pcInputArea
            // 
            this.pcInputArea.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcInputArea.Controls.Add(this.lblLoadingInfo);
            this.pcInputArea.Controls.Add(this.btnModifyPwd);
            this.pcInputArea.Controls.Add(this.txtDataset);
            this.pcInputArea.Controls.Add(this.txtUser);
            this.pcInputArea.Controls.Add(this.label1);
            this.pcInputArea.Controls.Add(this.txtPwd);
            this.pcInputArea.Controls.Add(this.label2);
            this.pcInputArea.Controls.Add(this.chkSaveLoginInfo);
            this.pcInputArea.Controls.Add(this.label8);
            this.pcInputArea.Location = new System.Drawing.Point(34, 44);
            this.pcInputArea.Name = "pcInputArea";
            this.pcInputArea.Size = new System.Drawing.Size(268, 154);
            this.pcInputArea.TabIndex = 24;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.AutoSize = true;
            this.btnModifyPwd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnModifyPwd.LinkColor = System.Drawing.Color.RoyalBlue;
            this.btnModifyPwd.Location = new System.Drawing.Point(203, 69);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(43, 14);
            this.btnModifyPwd.TabIndex = 229;
            this.btnModifyPwd.TabStop = true;
            this.btnModifyPwd.Text = "改密码";
            this.btnModifyPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnModifyPwd_LinkClicked);
            // 
            // txtDataset
            // 
            this.txtDataset.Location = new System.Drawing.Point(55, 109);
            this.txtDataset.Name = "txtDataset";
            this.txtDataset.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDataset.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetID", 100, "帐套编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DataSetName", 200, "帐套名称")});
            this.txtDataset.Properties.NullText = "";
            this.txtDataset.Properties.PopupWidth = 300;
            this.txtDataset.Size = new System.Drawing.Size(191, 20);
            this.txtDataset.TabIndex = 228;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LZHBaseFrame.Main.Properties.Resources.Role_32x32;
            this.pictureBox2.Location = new System.Drawing.Point(34, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // lblLoadingInfo
            // 
            this.lblLoadingInfo.AutoSize = true;
            this.lblLoadingInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLoadingInfo.Location = new System.Drawing.Point(78, 141);
            this.lblLoadingInfo.Name = "lblLoadingInfo";
            this.lblLoadingInfo.Size = new System.Drawing.Size(79, 13);
            this.lblLoadingInfo.TabIndex = 25;
            this.lblLoadingInfo.Text = "系统初始化...";
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 241);
            this.Controls.Add(this.pcInputArea);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveLoginInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInputArea)).EndInit();
            this.pcInputArea.ResumeLayout(false);
            this.pcInputArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkSaveLoginInfo;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.PanelControl pcInputArea;
        private DevExpress.XtraEditors.LookUpEdit txtDataset;
        private System.Windows.Forms.LinkLabel btnModifyPwd;
        public System.Windows.Forms.Label lblLoadingInfo;
    }
}