using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoanApplication
{
    public partial class PayInstallmentReport : Form
    {
        public PayInstallmentReport()
        {
            InitializeComponent();
        }

        private void PayInstallmentReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
