namespace LoanApplication
{
    partial class HomeMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeMDI));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bCTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.installmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.privateLoanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.privateLoanToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerStatementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingPaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupwiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerwiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synchronizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGroupId = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.synchronizeToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1028, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator3,
            this.saveToolStripMenuItem,
            this.toolStripSeparator4,
            this.addMemberToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(67, 23);
            this.fileMenu.Text = "Master";
            this.fileMenu.Click += new System.EventHandler(this.fileMenu_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.newToolStripMenuItem.Text = "Customer";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.saveToolStripMenuItem.Text = "Add Group";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
            // 
            // addMemberToolStripMenuItem
            // 
            this.addMemberToolStripMenuItem.Name = "addMemberToolStripMenuItem";
            this.addMemberToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.addMemberToolStripMenuItem.Text = "Add member";
            this.addMemberToolStripMenuItem.Click += new System.EventHandler(this.addMemberToolStripMenuItem_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bCTransactionToolStripMenuItem,
            this.toolStripSeparator1,
            this.installmentToolStripMenuItem,
            this.toolStripSeparator5,
            this.privateLoanToolStripMenuItem,
            this.toolStripSeparator2,
            this.privateLoanToolStripMenuItem1});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(103, 23);
            this.editMenu.Text = "Transaction";
            this.editMenu.Click += new System.EventHandler(this.editMenu_Click);
            // 
            // bCTransactionToolStripMenuItem
            // 
            this.bCTransactionToolStripMenuItem.Name = "bCTransactionToolStripMenuItem";
            this.bCTransactionToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.bCTransactionToolStripMenuItem.Text = "BC Transaction";
            this.bCTransactionToolStripMenuItem.Click += new System.EventHandler(this.bCTransactionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // installmentToolStripMenuItem
            // 
            this.installmentToolStripMenuItem.Name = "installmentToolStripMenuItem";
            this.installmentToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.installmentToolStripMenuItem.Text = "Installment";
            this.installmentToolStripMenuItem.Click += new System.EventHandler(this.installmentToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(181, 6);
            // 
            // privateLoanToolStripMenuItem
            // 
            this.privateLoanToolStripMenuItem.Name = "privateLoanToolStripMenuItem";
            this.privateLoanToolStripMenuItem.Size = new System.Drawing.Size(184, 24);
            this.privateLoanToolStripMenuItem.Text = "Payment";
            this.privateLoanToolStripMenuItem.Click += new System.EventHandler(this.privateLoanToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // privateLoanToolStripMenuItem1
            // 
            this.privateLoanToolStripMenuItem1.Name = "privateLoanToolStripMenuItem1";
            this.privateLoanToolStripMenuItem1.Size = new System.Drawing.Size(184, 24);
            this.privateLoanToolStripMenuItem1.Text = "Private Loan";
            this.privateLoanToolStripMenuItem1.Click += new System.EventHandler(this.privateLoanToolStripMenuItem1_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.customerStatementToolStripMenuItem,
            this.dailyTransactionToolStripMenuItem,
            this.pendingPaymentToolStripMenuItem,
            this.groupwiseReportToolStripMenuItem,
            this.customerwiseReportToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(68, 23);
            this.viewMenu.Text = "Report";
            this.viewMenu.Click += new System.EventHandler(this.viewMenu_Click);
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Enabled = false;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.toolBarToolStripMenuItem.Text = "Memberwise  ";
            // 
            // customerStatementToolStripMenuItem
            // 
            this.customerStatementToolStripMenuItem.Name = "customerStatementToolStripMenuItem";
            this.customerStatementToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.customerStatementToolStripMenuItem.Text = "Member Wise Report";
            this.customerStatementToolStripMenuItem.Click += new System.EventHandler(this.customerStatementToolStripMenuItem_Click);
            // 
            // dailyTransactionToolStripMenuItem
            // 
            this.dailyTransactionToolStripMenuItem.Name = "dailyTransactionToolStripMenuItem";
            this.dailyTransactionToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.dailyTransactionToolStripMenuItem.Text = "Datewise Transaction Report";
            this.dailyTransactionToolStripMenuItem.Click += new System.EventHandler(this.dailyTransactionToolStripMenuItem_Click);
            // 
            // pendingPaymentToolStripMenuItem
            // 
            this.pendingPaymentToolStripMenuItem.Name = "pendingPaymentToolStripMenuItem";
            this.pendingPaymentToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.pendingPaymentToolStripMenuItem.Text = "Customer Pending Payment Report";
            this.pendingPaymentToolStripMenuItem.Click += new System.EventHandler(this.pendingPaymentToolStripMenuItem_Click);
            // 
            // groupwiseReportToolStripMenuItem
            // 
            this.groupwiseReportToolStripMenuItem.Name = "groupwiseReportToolStripMenuItem";
            this.groupwiseReportToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.groupwiseReportToolStripMenuItem.Text = "Monthly Installment Report";
            this.groupwiseReportToolStripMenuItem.Click += new System.EventHandler(this.groupwiseReportToolStripMenuItem_Click);
            // 
            // customerwiseReportToolStripMenuItem
            // 
            this.customerwiseReportToolStripMenuItem.Name = "customerwiseReportToolStripMenuItem";
            this.customerwiseReportToolStripMenuItem.Size = new System.Drawing.Size(326, 24);
            this.customerwiseReportToolStripMenuItem.Text = "Daily Credit and Debit Report";
            this.customerwiseReportToolStripMenuItem.Click += new System.EventHandler(this.customerwiseReportToolStripMenuItem_Click);
            // 
            // synchronizeToolStripMenuItem
            // 
            this.synchronizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transferToolStripMenuItem,
            this.receiveToolStripMenuItem});
            this.synchronizeToolStripMenuItem.Name = "synchronizeToolStripMenuItem";
            this.synchronizeToolStripMenuItem.Size = new System.Drawing.Size(106, 23);
            this.synchronizeToolStripMenuItem.Text = "Synchronize";
            this.synchronizeToolStripMenuItem.Click += new System.EventHandler(this.synchronizeToolStripMenuItem_Click);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.transferToolStripMenuItem.Text = "Transfer";
            this.transferToolStripMenuItem.Click += new System.EventHandler(this.transferToolStripMenuItem_Click);
            // 
            // receiveToolStripMenuItem
            // 
            this.receiveToolStripMenuItem.Name = "receiveToolStripMenuItem";
            this.receiveToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.receiveToolStripMenuItem.Text = "Receive";
            this.receiveToolStripMenuItem.Click += new System.EventHandler(this.receiveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(47, 23);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1028, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 976);
            this.panel1.TabIndex = 4;
            // 
            // lblGroupId
            // 
            this.lblGroupId.AutoSize = true;
            this.lblGroupId.Location = new System.Drawing.Point(706, 9);
            this.lblGroupId.Name = "lblGroupId";
            this.lblGroupId.Size = new System.Drawing.Size(35, 13);
            this.lblGroupId.TabIndex = 6;
            this.lblGroupId.Text = "label1";
            this.lblGroupId.Visible = false;
            // 
            // lblMemberId
            // 
            this.lblMemberId.AutoSize = true;
            this.lblMemberId.Location = new System.Drawing.Point(747, 9);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(35, 13);
            this.lblMemberId.TabIndex = 7;
            this.lblMemberId.Text = "label2";
            this.lblMemberId.Visible = false;
            // 
            // HomeMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 750);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.lblGroupId);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "HomeMDI";
            this.Text = "HomeMDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem customerStatementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem bCTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingPaymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupwiseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerwiseReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synchronizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiveToolStripMenuItem;
        private System.Windows.Forms.Label lblGroupId;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.ToolStripMenuItem privateLoanToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem privateLoanToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}



