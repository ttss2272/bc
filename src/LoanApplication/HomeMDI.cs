using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using System.Data.Sql;
using System.Configuration;
using System.IO;
using System.Security;
using LoanApplication.Reports;
namespace LoanApplication
{
    public partial class HomeMDI : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        private int childFormNumber = 0;
        public HomeMDI( )
        { 
                InitializeComponent();
                this.Text = "BC Loan Application";
        }
        
        private void ShowNewForm(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            
            CustomerDetails f2 = new CustomerDetails();
            f2.TopLevel = false;
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Left = 200;
            f2.Top = 0;
            f2.Dock = DockStyle.None;
            
            panel1.Controls.Add(f2);
            f2.Show(); 
        }
        private void OpenFile(object sender, EventArgs e)
        {
            //try
            //{
            //    foreach (Form childForm in MdiChildren)
            //    {
            //        childForm.Close();
            //    }
            //    AddUser objbcschemedetails = new AddUser();
            //    objbcschemedetails.TopLevel = false;
            //    objbcschemedetails.StartPosition = FormStartPosition.Manual;
            //    objbcschemedetails.Left = 100;
            //    objbcschemedetails.Top = 0;
            //    objbcschemedetails.Dock = DockStyle.None;
            //    panel1.Controls.Add(objbcschemedetails);
            //    objbcschemedetails.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //} 
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            { 
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                } 
                BCGroupCustomerDetails objgcgroupcustomerDetais = new BCGroupCustomerDetails();
                objgcgroupcustomerDetais.TopLevel = false;
                objgcgroupcustomerDetais.StartPosition = FormStartPosition.Manual;
                objgcgroupcustomerDetais.Left = 100;
                objgcgroupcustomerDetais.Top = 0;
                objgcgroupcustomerDetais.Dock = DockStyle.None;
                panel1.Controls.Add(objgcgroupcustomerDetais);
                objgcgroupcustomerDetais.Show();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payinstallment objgetpayment = new Payinstallment();
            objgetpayment.Show();
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{ 
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //    MemberWiseReport objbcschemedetails = new MemberWiseReport();
        //    objbcschemedetails.TopLevel = false;
        //    objbcschemedetails.StartPosition = FormStartPosition.Manual;
        //    objbcschemedetails.Left = 0;
        //    objbcschemedetails.Top = 0;
        //    objbcschemedetails.Dock = DockStyle.None;
        //    panel1.Controls.Add(objbcschemedetails);
        //    objbcschemedetails.Show();
        //}
        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                BCGroupDetails objbcgroupDetails = new BCGroupDetails();
                objbcgroupDetails.TopLevel = false;
                objbcgroupDetails.StartPosition = FormStartPosition.Manual;
                objbcgroupDetails.Left = 300;
                objbcgroupDetails.Top = 0;
                objbcgroupDetails.Dock = DockStyle.None;
                panel1.Controls.Add(objbcgroupDetails);
                objbcgroupDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                BCConfirmCustomerDetails objbcconfirmcustomerDetails = new BCConfirmCustomerDetails();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.StartPosition = FormStartPosition.Manual;
                objbcconfirmcustomerDetails.Left = 100;
                objbcconfirmcustomerDetails.Top = 0;
                objbcconfirmcustomerDetails.Dock = DockStyle.None;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                CustomerGetPaymentDetails objbcconfirmcustomerDetails = new CustomerGetPaymentDetails();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.StartPosition = FormStartPosition.Manual;
                objbcconfirmcustomerDetails.Left = 100;
                objbcconfirmcustomerDetails.Top = 0;
                objbcconfirmcustomerDetails.Dock = DockStyle.None;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                PayToCustomerDetails objbcconfirmcustomerDetails = new PayToCustomerDetails();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.StartPosition = FormStartPosition.Manual;
                objbcconfirmcustomerDetails.Left = 100;
                objbcconfirmcustomerDetails.Top = 0;
                objbcconfirmcustomerDetails.Dock = DockStyle.None;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
          
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoanToCustomer objbcschemedetails = new LoanToCustomer();
            objbcschemedetails.Show();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetPayment objpayinstallment = new GetPayment();
            objpayinstallment.Show();
        }
        private void payInstallmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            PayInstallmentReport objbcconfirmcustomerDetails = new PayInstallmentReport();
            objbcconfirmcustomerDetails.TopLevel = false;
            objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
            panel1.Controls.Add(objbcconfirmcustomerDetails);
            objbcconfirmcustomerDetails.Show();
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                CustomerReport objbcconfirmcustomerDetails = new CustomerReport();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void schemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                SchemeReport objbcconfirmcustomerDetails = new SchemeReport();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                GroupReport objbcconfirmcustomerDetails = new GroupReport();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void loanDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                LoanReport objbcconfirmcustomerDetails = new LoanReport();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void getInstallmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
                GetInstallmentReport objbcconfirmcustomerDetails = new GetInstallmentReport();
                objbcconfirmcustomerDetails.TopLevel = false;
                objbcconfirmcustomerDetails.Dock = DockStyle.Fill;
                panel1.Controls.Add(objbcconfirmcustomerDetails);
                objbcconfirmcustomerDetails.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Close();
        }
        private void schemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            } 
        }
        private void bCTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            BCTransaction objbcschemedetails = new BCTransaction();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.CenterScreen;
            objbcschemedetails.Left = 5;
            //objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
            
        }
        private void customerInstallmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            CustomerInstallmentReport objbcschemedetails = new CustomerInstallmentReport();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.Dock = DockStyle.Fill;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
        }
        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
           
            BCConfirmCustomerDetails objbcschemedetails = new BCConfirmCustomerDetails();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.Manual;
            objbcschemedetails.Left = 300;
            objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
        }
        private void customerStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            MemberWiseReport objbcschemedetails = new MemberWiseReport();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.CenterScreen;
            objbcschemedetails.Left = 30;
            objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
           
        }
        private void dailyTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Datewise_Monthly_Transaction_Report objbcschemedetails = new Datewise_Monthly_Transaction_Report();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.CenterScreen;
            objbcschemedetails.Left = 05;
            objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
        }
        private void installmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Installment objbcschemedetails = new Installment();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.CenterScreen;
            objbcschemedetails.Left = 20;
            objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
         }
        private void privateTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //     foreach (Form childForm in MdiChildren)
            //{
            //    childForm.Close();
            //}
            //     PrivateLoan objbcschemedetails = new PrivateLoan();
            //     objbcschemedetails.TopLevel = false;
            //     objbcschemedetails.StartPosition = FormStartPosition.Manual;
            //     objbcschemedetails.Left = 0;
            //     objbcschemedetails.Top = 0;
            //     objbcschemedetails.Dock = DockStyle.None;
            //     panel1.Controls.Add(objbcschemedetails);
            //     objbcschemedetails.Show();
        }
        private void customerwiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyDebitCredit objddc = new DailyDebitCredit();
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            objddc.TopLevel = false;
            objddc.StartPosition = FormStartPosition.Manual;
            objddc.Left = 10;
            objddc.Top = 0;
            objddc.Dock = DockStyle.None;
            panel1.Controls.Add(objddc);
            objddc.Show();
        }
        private void pendingPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            PendingPaymentReport objbcschemedetails = new PendingPaymentReport();
            objbcschemedetails.TopLevel = false;
            objbcschemedetails.StartPosition = FormStartPosition.Manual;
            objbcschemedetails.Left = 15;
            objbcschemedetails.Top = 0;
            objbcschemedetails.Dock = DockStyle.None;
            panel1.Controls.Add(objbcschemedetails);
            objbcschemedetails.Show();
        }
        private void groupwiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Groupwisereport objgroupwisereport = new Groupwisereport();
            
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
         
            objgroupwisereport.TopLevel = false;
            objgroupwisereport.StartPosition = FormStartPosition.Manual;
            objgroupwisereport.Left = 15;
            objgroupwisereport.Top = 0;
            objgroupwisereport.Dock = DockStyle.None;
            panel1.Controls.Add(objgroupwisereport);
            objgroupwisereport.Show();
        }
        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Transfer objtrn = new Transfer();
            //objtrn.StartPosition = FormStartPosition.CenterParent;
            //objtrn.Left = 100;
            objtrn.Show();
        }  
        private void receiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receive objrec = new Receive();
            //objrec.StartPosition = FormStartPosition.CenterParent;
            objrec.Show();
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Login objlog = new Login();
            //objlog.Show(); 
        }
        private void fileMenu_Click(object sender, EventArgs e)
        {
            //fileMenu.Visible = false;
        }
        private void editMenu_Click(object sender, EventArgs e)
        {
        }
        private void viewMenu_Click(object sender, EventArgs e)
        {
        }
        private void synchronizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        } 
        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //UserRegistration objreg = new UserRegistration();
            //objreg.Left = 100;
            //objreg.Show();
        }

        private void privateLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            Payment objPayment = new Payment();
            objPayment.TopLevel = false;
            objPayment.StartPosition = FormStartPosition.CenterScreen;
            objPayment.Left = 220;
            objPayment.Top = 0;
            objPayment.Dock = DockStyle.None;
            panel1.Controls.Add(objPayment);
            objPayment.Show();
        }

        private void privateLoanToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            PrivateLoan objprivtelonfrm = new PrivateLoan();
            objprivtelonfrm.TopLevel = false;
            objprivtelonfrm.StartPosition = FormStartPosition.CenterScreen;
            objprivtelonfrm.Left = 220;
            objprivtelonfrm.Top = 0;
            objprivtelonfrm.Dock = DockStyle.None;
            panel1.Controls.Add(objprivtelonfrm);
            objprivtelonfrm.Show();
        } 
    }
}
