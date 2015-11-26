namespace LoanApplication
{
    partial class MemberWiseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberWiseReport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbMemberName = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbgroupNames = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MemberWisecrystalReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.cbMemberName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbgroupNames);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1285, 112);
            this.panel1.TabIndex = 2;
            // 
            // cbMemberName
            // 
            this.cbMemberName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMemberName.FormattingEnabled = true;
            this.cbMemberName.Items.AddRange(new object[] {
            "--Select--"});
            this.cbMemberName.Location = new System.Drawing.Point(586, 79);
            this.cbMemberName.Name = "cbMemberName";
            this.cbMemberName.Size = new System.Drawing.Size(246, 28);
            this.cbMemberName.TabIndex = 48;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(845, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 30);
            this.btnSearch.TabIndex = 47;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbgroupNames
            // 
            this.cbgroupNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgroupNames.FormattingEnabled = true;
            this.cbgroupNames.Items.AddRange(new object[] {
            "--Select--"});
            this.cbgroupNames.Location = new System.Drawing.Point(586, 43);
            this.cbgroupNames.Name = "cbgroupNames";
            this.cbgroupNames.Size = new System.Drawing.Size(246, 28);
            this.cbgroupNames.TabIndex = 46;
            this.cbgroupNames.Click += new System.EventHandler(this.cbgroupNames_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(452, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Member Name";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(452, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 20);
            this.label17.TabIndex = 44;
            this.label17.Text = "Group Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Felix Titling", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(614, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memberwise Report";
            // 
            // MemberWisecrystalReport
            // 
            this.MemberWisecrystalReport.ActiveViewIndex = -1;
            this.MemberWisecrystalReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MemberWisecrystalReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.MemberWisecrystalReport.Location = new System.Drawing.Point(1, 120);
            this.MemberWisecrystalReport.Name = "MemberWisecrystalReport";
            this.MemberWisecrystalReport.ShowGroupTreeButton = false;
            this.MemberWisecrystalReport.Size = new System.Drawing.Size(1285, 614);
            this.MemberWisecrystalReport.TabIndex = 3;
            // 
            // MemberWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1246, 734);
            this.Controls.Add(this.MemberWisecrystalReport);
            this.Controls.Add(this.panel1);
            this.Name = "MemberWiseReport";
            this.Text = "MemberWiseReport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbgroupNames;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer MemberWisecrystalReport;
        private System.Windows.Forms.ComboBox cbMemberName;
    }
}