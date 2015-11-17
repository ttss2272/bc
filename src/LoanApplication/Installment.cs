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
using System.Text.RegularExpressions;
using DataAcessLayer;
namespace LoanApplication
{
    public partial class Installment : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        double InstallmentAmount,PaymentAmount;
        int MemberID;
        string InstallmentStatus;
        #region----------------Installment----------------------
        public Installment()
        {
            InitializeComponent();
           // txtdueDate.MaxDate = DateTime.Now.Date;
            txtinstallmentDate.MaxDate = DateTime.Now.Date;
           // getCustomerId();
            LoadGroupNames();
            LoadGroupNamesSearch();
            DisableAll();
        }

        private void DisableAll()
        {
            txtbcamount.Enabled = false;
            txtduration.Enabled = false;
            txtinstallmentAmount.Enabled = false;
            //txtinstallmentDate.Text=;
            cbPaymentmode.Enabled = false;
            txtchequeNo.Enabled = false;
            txtpaymentAmount.Enabled = false;
            txtBalance.Enabled = false;
            txtActualAmt.Enabled = false;
            txtActualInstalment.Enabled = false;
            txtpriviousbalance.Enabled = false;
            cmbInstallmentMonth.Enabled = false;
            cbmemberName1.Enabled = false;
            cbGroupName.Enabled = false;
            txtinstallmentDate.Enabled = false;
            txtdueDate.Enabled = false;
            txtchequeNo.Enabled = false;
            btnSave.Hide();
            btnupdate.Hide();
            btnNew.Hide();
            
           
        }
        #endregion

        #region----------------LoadGroupNamesSearch----------------------
        private void LoadGroupNamesSearch()
        { 
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                { 
                    cbGroupnameforSearch.DisplayMember = "GroupName";
                    cbGroupnameforSearch.ValueMember = "GroupId";
                    cbGroupnameforSearch.DataSource = dt;
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------getCustomerId----------------------
        public void getCustomerId()
        {
             
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_GetInstallmentId", con); 
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDa.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                    {

                        int a = 1;
                        txtinstallmentId.Text = Convert.ToString(a);

                    }
                    else
                    {
                        txtinstallmentId.Text = dt.Rows[0][0].ToString();

                    }
                }
            }  
        }
        #endregion

        #region----------------LoadGroupNames----------------------
        public void LoadGroupNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cbGroupName.ValueMember = "GroupId";
                    cbGroupName.DisplayMember = "GroupName";
                    cmbInstallmentMonth.Text = "Select";
                    cbGroupName.DataSource = dt;

                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------loadMember----------------------
        public void loadMember()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {

                            cbmemberName1.DisplayMember = "Name";
                            cbmemberName1.ValueMember = "CustomerId";
                            cbmemberName1.SelectedValue = "0";
                            cbmemberName1.DataSource = dt;
                            //if(txtinstallmentAmount=="")
                        }
                        else
                        {
                            cbmemberName1.Text = "Select";
                            cbmemberName1.DataSource = null;
                        }
                        lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

        #region----------------loadMembersearch----------------------
        public void loadMembersearch()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open(); 
                    SqlCommand cmd = new SqlCommand("Usp_GetMembersofGroup", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupnameforSearch.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cbMemberName.DataSource = dt;
                            cbMemberName.DisplayMember = "Name";
                            cbMemberName.ValueMember = "CustomerId";
                            cbMemberName.Text = "Select";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

        #region----------------btnNew_Click----------------------
        private void btnNew_Click(object sender, EventArgs e)
        {
           // cbGroupName.Text = "--Select--";
            //cbmemberName1.SelectedIndex = -1;
            ClearAll();
            getCustomerId(); 
        }

        private void ClearAll()
        {
            txtbcamount.Text = "00";
            txtduration.Text = "0";
            txtinstallmentAmount.Text = "00";
            //txtinstallmentDate.Text=;
            cbPaymentmode.Text = "Select";
            txtchequeNo.Text = "0";
            txtpaymentAmount.Text = "00";
            txtBalance.Text = "00";
            txtActualAmt.Text = "00";
            txtActualInstalment.Text = "00";
            txtpriviousbalance.Text = "00";
            cmbInstallmentMonth.Text = "Select";
            cbmemberName1.Text = "Select";
            if (cbGroupName.Text == "SELECT")
            {
                lblMessege.Text = "";
            }
        }
        #endregion

        #region----------------btnClose_Click----------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region----------------btnSave_Click----------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblMessege.Text != "" && cbmemberName1.SelectedValue.ToString()!="Select")
            {
                saveInstallment();
               
            }
            else
            {
                MessageBox.Show("Please Select Group And Member First");
            }
        }
        #endregion

        #region----------------saveInstallment----------------------
        private void saveInstallment()
        {
            try
            {
                InstallmentAmount =Convert.ToDouble(txtinstallmentAmount.Text);
                PaymentAmount =Convert.ToDouble(txtpaymentAmount.Text);
                int GroupId = Convert.ToInt32(cbGroupName.SelectedValue);
                MemberID = Convert.ToInt32(cbmemberName1.SelectedValue);
                double balance=0,previousBalance=0;
                balance =Convert.ToDouble(txtBalance.Text);

                previousBalance =Convert.ToDouble(txtpriviousbalance.Text);
                if (Validate())
                {
                    if (PaymentAmount < InstallmentAmount)
                    {
                        InstallmentStatus = "Pending";
                        balance = balance + previousBalance;
                        
                    }
                    else
                    {
                        InstallmentStatus = "Paid";
                        balance =Convert.ToDouble(balance);
                    }
                 if (btnSave.Text == "Save")
                 {

                     #region--------save code---------------------------------
                     //if (btnSave.Text == "Save")
                     //{
                     //    SqlConnection con = new SqlConnection(ConnectionString); 
                     //    con.Open(); 
                     //    SqlCommand cmd = new SqlCommand("Usp_SaveInstallment", con); 
                     //    cmd.CommandType = CommandType.StoredProcedure; 
                     //    try
                     //    { 
                     //        cmd.Parameters.AddWithValue("@InstallmentId", txtinstallmentId.Text.ToString());
                     //        cmd.Parameters.AddWithValue("@GroupName", cbGroupName.Text);
                     //        cmd.Parameters.AddWithValue("@MemberName", cbmemberName1.Text);
                     //        cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(txtbcamount.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@DurationInMonths", Convert.ToInt32(txtduration.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@InstallmentAmount", Convert.ToInt32(txtinstallmentAmount.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@InstallmentDate", Convert.ToDateTime(txtinstallmentDate.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@PaymentMode", cbPaymentmode.Text.ToString());
                     //        cmd.Parameters.AddWithValue("@ChequeNo", Convert.ToInt32(txtchequeNo.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@PaymentAmount", Convert.ToInt32(txtpaymentAmount.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@DueDate", Convert.ToDateTime(txtdueDate.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@Balance", Convert.ToInt32(txtBalance.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                     //        cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cbmemberName1.SelectedValue.ToString()));
                     //        cmd.Parameters.AddWithValue("@ActualInstallment", Convert.ToInt32(txtActualInstalment.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@ActualAmount", Convert.ToInt32(txtActualAmt.Text.ToString()));
                     //        cmd.Parameters.AddWithValue("@InstallmentStatus", "Paid");
                     //        string strMessage = Convert.ToString(cmd.ExecuteScalar());
                     //        if (strMessage == "This record already exists!")
                     //        {
                     //            MessageBox.Show(strMessage);
                     //        }
                     //        else
                     //        {
                     //            MessageBox.Show("Installment Paid Sucessfully.."); 
                     //        } 
                     //        con.Close();
                     //    } 
                     //    catch (Exception ex)
                     //    { 
                     //        MessageBox.Show(ex.Message.ToString()); 
                     //    }  
                     //    finally
                     //    { 
                     //        cmd.Dispose(); 
                     //        con.Close();  
                     //        con.Dispose(); 
                     //    }
                     //}
                     //else
                     #endregion
                     {
                         
                        
                         SqlConnection con = new SqlConnection(ConnectionString);
                         con.Open();
                         SqlCommand cmd = new SqlCommand("Usp_UpdateInstallment", con);
                         cmd.CommandType = CommandType.StoredProcedure;
                         try
                         {
                             

                             cmd.Parameters.AddWithValue("@InstallmentId", txtinstallmentId.Text.ToString());
                             cmd.Parameters.AddWithValue("@GroupId", GroupId);
                             cmd.Parameters.AddWithValue("@CustomerId", MemberID);
                             //cmd.Parameters.AddWithValue("@TotalAmount", Convert.ToInt32(txtbcamount.Text.ToString()));
                             //cmd.Parameters.AddWithValue("@DurationInMonths", Convert.ToInt32(txtduration.Text.ToString()));
                             //cmd.Parameters.AddWithValue("@InstallmentAmount", Convert.ToInt32(txtinstallmentAmount.Text.ToString()));
                             cmd.Parameters.AddWithValue("@InstallmentDate", Convert.ToDateTime(txtinstallmentDate.Text.ToString()));
                             cmd.Parameters.AddWithValue("@PaymentMode", cbPaymentmode.Text.ToString());
                             cmd.Parameters.AddWithValue("@ChequeNo", Convert.ToInt32(txtchequeNo.Text.ToString()));
                             cmd.Parameters.AddWithValue("@PaymentAmount", Convert.ToInt32(txtpaymentAmount.Text.ToString()));
                             cmd.Parameters.AddWithValue("@DueDate", Convert.ToDateTime(txtdueDate.Text.ToString()));
                             cmd.Parameters.AddWithValue("@PendingAmount", Convert.ToDouble(txtpriviousbalance.Text.ToString()));
                             //cmd.Parameters.AddWithValue("@ActualInstallment", Convert.ToInt32(txtActualInstalment.Text.ToString()));
                             //cmd.Parameters.AddWithValue("@ActualAmount", Convert.ToInt32(txtActualAmt.Text.ToString()));
                             cmd.Parameters.AddWithValue("@Balance", balance);
                             cmd.Parameters.AddWithValue("@InstallmentStatus", InstallmentStatus);
                             string strMessage = Convert.ToString(cmd.ExecuteScalar());
                             MessageBox.Show("Installment Paid Sucessfully..");
                            
                             con.Close();
                             ClearAll();
                         }
                         

                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message.ToString());
                         }

                         finally
                         {
                             cmd.Dispose();
                             con.Close();
                             con.Dispose();
                         }

                         
                     }


                 }
                 else
                 {
                     #region-------------UpdateInstallmentCode--------
                     //**Code return by sameer
                     SqlConnection con = new SqlConnection(ConnectionString);

                        con.Open();

                      
                        SqlCommand cmd = new SqlCommand("Usp_UpdateInstallment", con);

                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.AddWithValue("@InstallmentId", txtinstallmentId.Text.ToString());
                            cmd.Parameters.AddWithValue("@GroupId", GroupId);
                            cmd.Parameters.AddWithValue("@CustomerId", MemberID);
                            cmd.Parameters.AddWithValue("@InstallmentDate", Convert.ToDateTime(txtinstallmentDate.Text.ToString()));
                            cmd.Parameters.AddWithValue("@PaymentMode", cbPaymentmode.Text.ToString());
                            cmd.Parameters.AddWithValue("@ChequeNo", Convert.ToInt32(txtchequeNo.Text.ToString()));
                            cmd.Parameters.AddWithValue("@PaymentAmount", Convert.ToInt32(txtpaymentAmount.Text.ToString()));
                            cmd.Parameters.AddWithValue("@DueDate", Convert.ToDateTime(txtdueDate.Text.ToString()));
                            cmd.Parameters.AddWithValue("@PendingAmount", Convert.ToDouble(txtpriviousbalance.Text.ToString()));
                            cmd.Parameters.AddWithValue("@Balance", balance);
                            cmd.Parameters.AddWithValue("@InstallmentStatus", InstallmentStatus);
                            string strMessage = Convert.ToString(cmd.ExecuteScalar());
                            MessageBox.Show("Record Updated Successfully..");
                            
                       
                      con.Close();
                      ClearAll();
                         

                        }

                        catch (Exception ex)
                        {

                            throw ex;

                        }

                        finally
                        {

                            cmd.Dispose();

                            con.Close();

                            con.Dispose();

                        }


                     #endregion
                 }

               }
            } 
        
            catch (Exception ex)
            {
                // MessageBox.Show(ex.InnerException);
                MessageBox.Show(ex.Message.ToString());
            } 
        }
        
        #endregion

        #region---------------------------Validate()----------
        public bool Validate()
        {
            
            if (cbGroupName.SelectedValue.ToString() == "SELECT")
            {
                MessageBox.Show("Please Select Group Name");
                return false;
            }
            else if (cbmemberName1.SelectedValue.ToString() == "Select")
            {
                MessageBox.Show("Please Select Member Name");
                return false;
            }
            else if (txtinstallmentDate.Text == null || txtinstallmentDate.Text == "")
            {
                MessageBox.Show("Installment Date Can Not Be empty");
                return false;
            }
            else if (cbPaymentmode.Text == "Select")
            {
                MessageBox.Show("Payment Mode can not be empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtpaymentAmount.Text))
            {
                MessageBox.Show("Payment Amount can Not be Empty..");
                return false;
            }

            
            else
            {
                return true;
            }

        }
        #endregion

        #region----------------LoadGrid----------------------
        public void LoadGrid()
        {
            SqlConnection con = new SqlConnection(ConnectionString); 
            con.Open(); 
            SqlCommand cmd = new SqlCommand("Usp_LoadInstallmentGrid", con); 
            cmd.CommandType = CommandType.StoredProcedure; 
            try
            { 
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Refresh();
                    dataGridView1.Show();
                } 
            } 
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString()); 
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            }
        }
        #endregion

        #region----------------button2_Click----------------------
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region----------------deleteRecord----------------------
        public void deleteRecord()
        { 
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_DeleteInstallment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@InstallmentId", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Transactiom Deleted Sucessfully..");
                //LoadGrid(); //change by sameer(remove comment)
            } 
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString()); 
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            } 
        }
        #endregion

        #region----------------btnDelete_Click----------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (lblSearchMsg.Text != "")
            {
                if (result.Equals(DialogResult.OK))
                {
                    deleteRecord();
                    
                    lblSearchMsg.Text = "";
                    
                    //LoadGroupNames();
                    dataGridView1.Refresh();
                    dataGridView1.Show();
                }
                else
                {
                  
                    //
                }
            }
            else
            {
                MessageBox.Show("Please Group First To Delete Record");
            }
        }
        #endregion

        #region----------------btnupdate_Click----------------------
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (lblSearchMsg.Text != "")
            {
                try
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        txtinstallmentId.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                        cbGroupName.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                        cbmemberName1.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                        txtbcamount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
                        txtduration.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
                        txtinstallmentAmount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[5].Value);
                        txtinstallmentDate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[6].Value);
                        cbPaymentmode.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[7].Value);
                        txtchequeNo.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[8].Value);
                        if (txtchequeNo.Text == "")
                            txtchequeNo.Text = "0";
                        txtpaymentAmount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[9].Value);
                        txtdueDate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[10].Value);
                        txtBalance.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[11].Value);

                        tabControl1.SelectedIndex = 0;
                        btnSave.Text = "Update";


                    }
                    else
                    {
                        MessageBox.Show("Please Select the record..");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                lblSearchMsg.Text = "";
            }
            //else
            //{
            //    MessageBox.Show("Please Select Group First");
            //}
        }

       
        #endregion

        #region----------------getDetailsofTransations----------------------
        public void getDetailsofTransations()
        { 
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    
                    int tempMemb =Convert.ToInt32(cbmemberName1.SelectedValue);
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetDetailsofTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@MemberId",tempMemb);
              
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt); 
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            //cmbInstallmentMonth.SelectedIndex = -1;
                            //  txtbcamount.Text = dt.Rows[0][0].ToString();
                            //  txtduration.Text = dt.Rows[0][1].ToString();
                            //txtinstallmentAmount.Text = dt.Rows[0][2].ToString();
                            //txtActualAmt.Text = dt.Rows[0][3].ToString();
                            //txtActualInstalment.Text = dt.Rows[0][4].ToString();
                            txtinstallmentId.Text = dt.Rows[0]["InstallmentId"].ToString();
                            txtbcamount.Text = dt.Rows[0]["BCTotalAmount"].ToString();
                            txtduration.Text = dt.Rows[0]["DurationInMonths"].ToString();
                            txtinstallmentAmount.Text = dt.Rows[0]["InstallmentAmount"].ToString();
                            txtActualInstalment.Text = dt.Rows[0]["ActualInstallment"].ToString();
                            //cbPaymentmode.Text = dt.Rows[0]["PaymentMode"].ToString();
                            //txtchequeNo.Text = dt.Rows[0]["CheckNo"].ToString();
                            //txtpaymentAmount.Text = dt.Rows[0]["PaymentAmount"].ToString();
                            txtpriviousbalance.Text = dt.Rows[0]["PendingAmount"].ToString();
                            txtActualAmt.Text = dt.Rows[0]["ActualAmount"].ToString();
                            txtdueDate.Text = dt.Rows[0]["DueDate"].ToString();
                            //txtpriviousbalance.Text = dt.Rows[0][""].ToString();
                            txtBalance.Text = dt.Rows[0]["Balance"].ToString();
                            if ((txtpriviousbalance.Text == "") || (txtBalance.Text == ""))
                            {
                                txtpriviousbalance.Text = "0";
                                txtBalance.Text = "0";
                            }
                        }

                        
                        //else
                        //{
                            
                        //     MessageBox.Show("This Member completed this month Transaction!!!", "Transaction Incomplete", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                          
                        //}
                        //else
                        //{
                        //    ClearAll();
                        //}
                    } 
                    catch (Exception ex)
                    { 
                        MessageBox.Show(ex.Message.ToString()); 
                    } 
                    finally
                    { 
                        cmd.Dispose(); 
                        con.Close(); 
                        con.Dispose(); 
                    } 
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

       

        #region----------------BindInstallMonth----------------------
        private void BindInstallMonth(int MemberID)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
               
                try
                {
                    cmbInstallmentMonth.DataSource = null;
                    cmbInstallmentMonth.Items.Clear();
                    //cmbInstallmentMonth.SelectedText = "Select";
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_GetInstallmentMonths", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@MemberID",MemberID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                   
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cmbInstallmentMonth.DisplayMember = "InstallmentDate";
                            cmbInstallmentMonth.ValueMember = "InstallmentId";
                            cmbInstallmentMonth.SelectedText = "Select";
                            cmbInstallmentMonth.DataSource = dt;
                        }
                        //If it is first installment then prev instamllment field will be hide
                        else
                        {
                            cmbInstallmentMonth.Enabled = false;
                        }
                    } 
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    } 
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    } 
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

       

        #region----------------getBalance----------------------
        public void getBalance()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    if (cbmemberName1.SelectedValue != null)
                    {
                        #region
                        con.Open();

                        SqlCommand cmd = new SqlCommand("Usp_GetBalance", con);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupName.SelectedValue.ToString()));
                        cmd.Parameters.AddWithValue("@MemberId", Convert.ToInt32(cbmemberName1.SelectedValue.ToString()));
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        try
                        {
                            if (dt.Rows.Count > 0)
                            {
                                txtBalance.Text = dt.Rows[0][0].ToString();
                            }
                            else
                            {
                                txtpriviousbalance.Text = "0";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        finally
                        {
                            cmd.Dispose();
                            con.Close();
                            con.Dispose();
                        }
                        #endregion
                    }
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            
            }
        }
        #endregion

        #region----------------cbPaymentmode_SelectedIndexChanged----------------------
        private void cbPaymentmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaymentmode.Text == "CASH")
            {
                txtchequeNo.Text = "0";
                txtchequeNo.Enabled = false;

            }
            else
            {
                txtchequeNo.Enabled = true;
            }
        }
        #endregion

        #region----------------txtpaymentAmount_TextChanged----------------------
        private void txtpaymentAmount_TextChanged(object sender, EventArgs e)
       {
            try
            {
              if (txtpaymentAmount.Text != "")
              {
                  InstallmentAmount = Convert.ToDouble(txtinstallmentAmount.Text);
                 PaymentAmount = Convert.ToDouble(txtpaymentAmount.Text);
                 double PendinAmount=Convert.ToDouble(txtpriviousbalance.Text);
                 double Total = InstallmentAmount + PendinAmount;
                 if (PaymentAmount > Total)
                 {
                     MessageBox.Show("Payment Amount should be less than Installment Amount or Pending Amount","You Enter wrong amount",MessageBoxButtons.OKCancel);
                     txtpaymentAmount.Text = "00";
                     txtpaymentAmount.Focus();

                 }

                 else
                 {


                     //int priviousbalance = Convert.ToInt32(txtpriviousbalance.Text.ToString());
                     double bcamount = Convert.ToDouble(txtbcamount.Text.ToString());
                     double paymentAmount = Convert.ToDouble(txtpaymentAmount.Text.ToString());
                     double installmentAmount=Convert.ToDouble(txtinstallmentAmount.Text.ToString());
                     double previousPendingBalance = Convert.ToDouble(txtpriviousbalance.Text.ToString());
                     
                         previousPendingBalance = installmentAmount - paymentAmount;
                         txtpriviousbalance.Text = Convert.ToString(previousPendingBalance);
                         double balance = bcamount - paymentAmount;
                         txtBalance.Text = Convert.ToString(balance);
                    

                 }
              }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
             
        }
        #endregion

        #region----------------cbGroupnameforSearch_Click----------------------
        private void cbGroupnameforSearch_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region----------------button1_Click----------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if (lblSearchMsg.Text != "")
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_GetInstallmentDetails", sqlCon);
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbGroupnameforSearch.SelectedValue.ToString()));
                    cmd.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(cbMemberName.SelectedValue.ToString()));
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Refresh();
                            dataGridView1.AllowUserToAddRows = false;
                            dataGridView1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Record does not available");
                            dataGridView1.DataSource = null;
                            dataGridView1.ReadOnly = true;
                            dataGridView1.Refresh();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                finally
                {
                }
            }
            else
            {
                MessageBox.Show("Please Select Group First");
            }
        }
        #endregion

        #region----------------cbGroupName_SelectedIndexChanged----------------------
        private void cbGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (cbGroupName.Text != "SELECT")
                {
                    lblMessege.ForeColor = System.Drawing.Color.Green;
                    lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
                    if (lblMessege.Text != "")
                    {
                       
                        loadMember();
                        //BindInstallMonth();
                        cmbInstallmentMonth.Text = "Select";
                       
                    }
                    else
                    {
                        lblMessege.ForeColor = System.Drawing.Color.Red;
                        lblMessege.Text = "Please Select Group First";
                    }
                    lblMessege.Text = "You Are Selected " + cbGroupName.Text + " Group";
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region----------------cmbInstallmentMonth_SelectedIndexChanged----------------------
        private void cmbInstallmentMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            string InstallmentDate = cmbInstallmentMonth.Text.ToString();
            if (InstallmentDate != "Select" && InstallmentDate!="")
            {
                DateTime Installmentdate = Convert.ToDateTime(InstallmentDate);
                GetPreviousInstallment(Installmentdate);
            }
        }
        #endregion

        #region----------------GetInstallment----------------------
        private void GetPreviousInstallment(DateTime Installmentdate)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open(); 
                    SqlCommand cmd = new SqlCommand("Usp_GetPreviousInstallment", con); 
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@InstallmentDate", Installmentdate); 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        { 
                            
                            GVPreviousInstallment.ReadOnly = true;
                            GVPreviousInstallment.Refresh();
                            GVPreviousInstallment.AllowUserToAddRows = false;
                            GVPreviousInstallment.Show();
                            GVPreviousInstallment.DataSource = dt;
                            ////cbGroupName.SelectedItem = dt.Rows[0][0].ToString();
                            ////cbmemberName1.SelectedItem = dt.Rows[0]["MemberName"].ToString();
                            //txtbcamount.Text = dt.Rows[0]["BCTotalAmount"].ToString();
                            //txtduration.Text = dt.Rows[0]["DurationInMonths"].ToString();
                            //txtinstallmentAmount.Text = dt.Rows[0]["InstallmentAmount"].ToString();
                            //txtActualInstalment.Text = dt.Rows[0]["ActualInstallment"].ToString();
                            //cbPaymentmode.SelectedItem = dt.Rows[0]["PaymentMode"].ToString();
                            //txtchequeNo.Text = dt.Rows[0]["CheckNo"].ToString();
                            //txtpaymentAmount.Text = dt.Rows[0]["PaymentAmount"].ToString();
                            //txtActualAmt.Text = dt.Rows[0]["ActualAmount"].ToString();
                            //txtdueDate.Text = dt.Rows[0]["DueDate"].ToString(); 
                            ////txtpriviousbalance.Text = dt.Rows[0][""].ToString();
                            //txtBalance.Text = dt.Rows[0]["Balance"].ToString();
                        }
                        //else
                        //{
                        //    txtpriviousbalance.Text = "0";
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    finally
                    {
                        cmd.Dispose();
                        con.Close();
                        con.Dispose();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        #endregion

        #region----------------cmbInstallmentMonth_Click----------------------
        //private void cmbInstallmentMonth_Click(object sender, EventArgs e)
        //{
        //    //string InstallmentDate = cmbInstallmentMonth.Text.ToString();
        //    //if (InstallmentDate != "Select")
        //    //{
        //    //    DateTime Installmentdate = Convert.ToDateTime(InstallmentDate);
        //    //    GetPreviousInstallment(Installmentdate);
        //    //}
        //}
        #endregion

        private void cbGroupnameforSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSearchMsg.ForeColor = System.Drawing.Color.Green;
            lblSearchMsg.Text = "You Are Selected " + cbGroupnameforSearch.Text + " Group";
            if (lblSearchMsg.Text != "")
            {
                loadMembersearch();
            }
            else
            {
                lblSearchMsg.ForeColor = System.Drawing.Color.Red;
                lblSearchMsg.Text = "Please Select Group First";
            }
        }

        private void cbmemberName1_SelectedIndexChanged(object sender, EventArgs e)
         {
            
            MemberID = Convert.ToInt32(cbmemberName1.SelectedValue);
            if (cbmemberName1.Text != "Select")
            {
                cmbInstallmentMonth.Enabled = true;
                getDetailsofTransations();
                BindInstallMonth(MemberID);
                getBalance();

            }
            else
            {
                ClearAll();
            }
        }

        private void Installment_Load(object sender, EventArgs e)
        {
            //txtinstallmentDate.Text =Convert.ToString(DateTime.Now.Date);
            cbPaymentmode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentmode.SelectedIndex = 0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
