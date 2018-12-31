namespace LZHBaseFrame.DataDictionary
{
    partial class frmTest03
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txttestcode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txttestname = new DevExpress.XtraEditors.TextEdit();
            this.gctest03 = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.testcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.btnEmpty = new DevExpress.XtraEditors.SimpleButton();
            this.btnQuery = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txt_CustomerFrom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttestcode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttestname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctest03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.tableLayoutPanel1);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.txttestname);
            this.tpDetail.Controls.Add(this.labelControl2);
            this.tpDetail.Controls.Add(this.txttestcode);
            this.tpDetail.Controls.Add(this.labelControl1);
            this.tpDetail.Size = new System.Drawing.Size(931, 565);
            // 
            // controlNavigatorSummary
            // 
            this.controlNavigatorSummary.Buttons.Append.Visible = false;
            this.controlNavigatorSummary.Buttons.CancelEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.Edit.Visible = false;
            this.controlNavigatorSummary.Buttons.EndEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.NextPage.Visible = false;
            this.controlNavigatorSummary.Buttons.PrevPage.Visible = false;
            this.controlNavigatorSummary.Buttons.Remove.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 40);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "代码";
            // 
            // txttestcode
            // 
            this.txttestcode.Location = new System.Drawing.Point(62, 37);
            this.txttestcode.Name = "txttestcode";
            this.txttestcode.Size = new System.Drawing.Size(100, 21);
            this.txttestcode.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "名称";
            // 
            // txttestname
            // 
            this.txttestname.Location = new System.Drawing.Point(62, 76);
            this.txttestname.Name = "txttestname";
            this.txttestname.Size = new System.Drawing.Size(100, 21);
            this.txttestname.TabIndex = 1;
            this.txttestname.EditValueChanged += new System.EventHandler(this.textEdit2_EditValueChanged);
            // 
            // gctest03
            // 
            this.gctest03.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctest03.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gctest03.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gctest03.Location = new System.Drawing.Point(3, 63);
            this.gctest03.MainView = this.gvSummary;
            this.gctest03.Name = "gctest03";
            this.gctest03.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gctest03.Size = new System.Drawing.Size(925, 499);
            this.gctest03.TabIndex = 11;
            this.gctest03.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.testcode,
            this.testname});
            this.gvSummary.GridControl = this.gctest03;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // testcode
            // 
            this.testcode.Caption = "代码";
            this.testcode.FieldName = "testcode";
            this.testcode.Name = "testcode";
            this.testcode.Visible = true;
            this.testcode.VisibleIndex = 0;
            // 
            // testname
            // 
            this.testname.Caption = "名称";
            this.testname.FieldName = "testname";
            this.testname.Name = "testname";
            this.testname.Visible = true;
            this.testname.VisibleIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gctest03, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelControl3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 565);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.txt_Name);
            this.panelControl3.Controls.Add(this.labelControl22);
            this.panelControl3.Controls.Add(this.btnEmpty);
            this.panelControl3.Controls.Add(this.btnQuery);
            this.panelControl3.Controls.Add(this.pictureBox3);
            this.panelControl3.Controls.Add(this.txt_CustomerFrom);
            this.panelControl3.Controls.Add(this.labelControl27);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 3);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(925, 54);
            this.panelControl3.TabIndex = 11;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(334, 5);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(114, 21);
            this.txt_Name.TabIndex = 27;
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(268, 9);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(36, 14);
            this.labelControl22.TabIndex = 28;
            this.labelControl22.Text = "名称：";
            // 
            // btnEmpty
            // 
            this.btnEmpty.Location = new System.Drawing.Point(563, 5);
            this.btnEmpty.Name = "btnEmpty";
            this.btnEmpty.Size = new System.Drawing.Size(76, 41);
            this.btnEmpty.TabIndex = 21;
            this.btnEmpty.Text = "清空(&E)";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(479, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(73, 42);
            this.btnQuery.TabIndex = 20;
            this.btnQuery.Text = "查询(&S)";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::LZHBaseFrame.DataDictionary.Properties.Resources.find50x50;
            this.pictureBox3.Location = new System.Drawing.Point(4, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // txt_CustomerFrom
            // 
            this.txt_CustomerFrom.Location = new System.Drawing.Point(141, 5);
            this.txt_CustomerFrom.Name = "txt_CustomerFrom";
            this.txt_CustomerFrom.Size = new System.Drawing.Size(100, 21);
            this.txt_CustomerFrom.TabIndex = 14;
            // 
            // labelControl27
            // 
            this.labelControl27.Location = new System.Drawing.Point(74, 7);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(36, 14);
            this.labelControl27.TabIndex = 16;
            this.labelControl27.Text = "代码：";
            // 
            // frmTest03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(938, 621);
            this.Name = "frmTest03";
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            this.tpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttestcode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttestname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctest03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CustomerFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txttestcode;
        private DevExpress.XtraEditors.TextEdit txttestname;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gctest03;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn testcode;
        private DevExpress.XtraGrid.Columns.GridColumn testname;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.SimpleButton btnEmpty;
        private DevExpress.XtraEditors.SimpleButton btnQuery;
        private System.Windows.Forms.PictureBox pictureBox3;
        private DevExpress.XtraEditors.TextEdit txt_CustomerFrom;
        private DevExpress.XtraEditors.LabelControl labelControl27;
    }
}
