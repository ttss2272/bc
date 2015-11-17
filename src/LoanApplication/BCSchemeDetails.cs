using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLayer;
using Entity;
namespace LoanApplication
{
    /*
-- ===========================================================================================
-- Author:		Raj
-- Create date: 10-06-2015
-- Description:	Save scheme dtails
-- Updated By :
-- Updated Date:
-- ===========================================================================================    
*/
    public partial class BCSchemeDetails : Form
    {
        EntSchemeDetails objent = new EntSchemeDetails();
        BLSchemeDetails objschemedetails = new BLSchemeDetails();
        public BCSchemeDetails()
        {
            InitializeComponent();
            DataTable dt= new DataTable();
            BLSchemeDetails objBL = new BLSchemeDetails();
            dt = objBL.GetSchemeNames();
            if (dt.Rows.Count > 0)
             {
               for( int i=0; i<dt.Rows.Count; i++)
                 {
                   ddlschemenames.Items.Add(dt.Rows[0][i]);
                 }
              }
            
            bindGrid();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           
            string Output = string.Empty;

            if (btnsave.Text == "Save")
            {

                EntSchemeDetails objUserBEL = new EntSchemeDetails();

                objUserBEL.BCId =Convert.ToSByte(txtschemeId.Text);
                objUserBEL.BCName = txtschemename.Text.ToString();
                objUserBEL.StartDate = Convert.ToDateTime(txtstartDate.Text.ToString());
                objUserBEL.EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                objUserBEL.Amount = Convert.ToInt32(TxtAmount.Text.ToString());
                objUserBEL.Duration = txtDuration.Text.ToString();
                objUserBEL.InstallmentDate = Convert.ToDateTime(txtinstallmentdate.Text.ToString());
                BLSchemeDetails objUserBLL = new BLSchemeDetails();

                Output = objUserBLL.InsertUserDetails(objUserBEL);
                MessageBox.Show("Scheme Saved Successfully..");

            }

            else
            {
                MessageBox.Show("Internal error occure");

            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtschemeId.Text = "";
            txtschemename.Text = "";
            txtstartDate.Text = "";
            txtEndDate.Text = "";
            TxtAmount.Text = "";
            txtDuration.Text = "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bindGrid()
        {
            DataTable dt = new DataTable();
            BLSchemeDetails objBL = new BLSchemeDetails();
            dt = objBL.BindFullGrid();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.Show();
            }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        //private void GetSearchResult()
        //{
        //    DataTable dt = new DataTable();
        //    BLSchemeDetails objBL = new BLSchemeDetails();
        //    string schemename = ddlschemenames.SelectedValue.ToString();
        //    dt = objBL.GetSearchResult(schemename);
        //    if (dt.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = dt;
        //        dataGridView1.Refresh();
        //        dataGridView1.Show();
        //    }

        //}
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
    

