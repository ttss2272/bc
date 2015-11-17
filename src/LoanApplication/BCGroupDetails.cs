using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAcessLayer;
using Entity;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace LoanApplication
{
    public partial class BCGroupDetails : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
       
        public BCGroupDetails()
        {
           
            InitializeComponent();
            //txtstartdate.MaxDate = DateTime.Now.Date;
            //txtenddate.MaxDate = DateTime.Now.Date;
            loadGroupNames();
            loadGrid();
            cbgroupname.Text = "--Select--";
        }
        private void loadGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_LoadGrid", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderCell.Value = "Sr.No";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.Columns[1].HeaderCell.Value = "Group Name";
                        dataGridView1.Columns[2].HeaderCell.Value = "Start Date";
                        dataGridView1.Columns[3].HeaderCell.Value = "End Date";
                        dataGridView1.Columns[4].HeaderCell.Value = "BC Amount";
                        dataGridView1.Columns[5].HeaderCell.Value = "No Of Members";
                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Refresh();
                        dataGridView1.Show();
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.Hide();
                    
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    throw eo;
                }
            }
        }
        private void loadGroupNames()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_LoadGroupNames", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cbgroupname.DataSource = dt;
                            cbgroupname.DisplayMember = "GroupName";
                            cbgroupname.ValueMember = "GroupId";
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
                 
                 
                    #endregion
                }
                catch (Exception eo)
                {
                    throw eo;
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            
            if(validate())
            {
                try
                {
                    DateTime dtstart = Convert.ToDateTime(txtstartdate.Text.ToString());
                    DateTime dtend = Convert.ToDateTime(txtenddate.Text.ToString());
                    float BCAmount = (float)Convert.ToDecimal(txtBCamount.Text.ToString());
                    int NoOfMembers = Convert.ToInt32(txtNoOfMember.Text);
                    if (button3.Text == "ADD")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SaveanUpdateGroup", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@GroupName", txtgroupname.Text.ToString());
                        cmd.Parameters.AddWithValue("@BCAmount", BCAmount);
                        cmd.Parameters.AddWithValue("@NoOfMembers", NoOfMembers);
                        cmd.Parameters.AddWithValue("@StartDate", dtstart);
                        cmd.Parameters.AddWithValue("@EndDate", dtend);
                        // cmd.ExecuteNonQuery();
                        string output = Convert.ToString(cmd.ExecuteScalar());
                        if (output == "This record already exists!")
                        {
                            MessageBox.Show(output);
                            txtgroupname.Text = "";
                            txtBCamount.Text = "";
                            txtNoOfMember.Text = "";
                            txtstartdate.Text = "";
                            txtenddate.Text = "";
                            con.Close();
                            loadGrid();
                            loadGroupNames();
                        }
                        else
                        {
                            MessageBox.Show("Group Details Added sucessfully..");
                            txtgroupname.Text = "";
                            txtBCamount.Text = "";
                            txtNoOfMember.Text = "";
                            txtstartdate.Text = "";
                            txtenddate.Text = "";
                            con.Close();
                            loadGrid();
                            loadGroupNames();
                        }
                    }
                    else
                    {
                        if (validate())
                        {
                            con.Open();
                            SqlCommand cmd1 = new SqlCommand("Usp_UpdateGroup", con);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                            cmd1.Parameters.AddWithValue("@Id", id);
                            cmd1.Parameters.AddWithValue("@GroupName", txtgroupname.Text.ToString());
                            cmd1.Parameters.AddWithValue("@BCAmount", BCAmount);
                            cmd1.Parameters.AddWithValue("@NoOfMembers", NoOfMembers);
                            cmd1.Parameters.AddWithValue("@StartDate", dtstart);
                            cmd1.Parameters.AddWithValue("@EndDate", dtend);
                             string result=cmd1.ExecuteScalar().ToString();
                             if (result == "1")
                             {
                                 MessageBox.Show("Group Details Updated Sucessfully..");

                                 txtgroupname.Text = "";
                                 txtBCamount.Text = "";
                                 txtNoOfMember.Text = "";
                                 txtstartdate.Text = "";
                                 txtenddate.Text = "";
                                 con.Close();
                                 loadGrid();
                                 loadGroupNames();
                                 button3.Text = "ADD";
                                 txtNoOfMember.Text = "";
                             }
                             else if (result == "This group transaction already done")
                             {
                                 MessageBox.Show("This group transaction already done", "Cannot update this group", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                                 txtgroupname.Text = "";
                                 txtBCamount.Text = "";
                                 txtNoOfMember.Text = "";
                                 txtstartdate.Text = "";
                                 txtenddate.Text = "";
                                 con.Close();
                                 loadGrid();
                                 loadGroupNames();
                                 button3.Text = "ADD";

                             }
                             else
                             {
                                 MessageBox.Show("This record already exists!");
                                 txtgroupname.Text = "";
                                 txtBCamount.Text = "";
                                 txtNoOfMember.Text = "";
                                 txtstartdate.Text = "";
                                 txtenddate.Text = "";
                                 con.Close();
                                 loadGrid();
                                 loadGroupNames();
                             }
                        }
                    }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message.ToString()); 
            }
            finally
            { 
               // cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            }
        }
        else
            {
       
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtgroupname.Text = "";
        }
        public void SearchGroup()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_GetGroupNames", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@GroupName", cbgroupname.Text);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].HeaderCell.Value = "Group Name";
                    dataGridView1.Columns[2].HeaderCell.Value = "Start Date";
                    dataGridView1.Columns[3].HeaderCell.Value = "End Date";
                    dataGridView1.Columns[4].HeaderCell.Value = "BC Amount";
                    dataGridView1.Columns[5].HeaderCell.Value = "No Of Members";
                    dataGridView1.Refresh();
                    dataGridView1.Show();
                }
                else
                {
                    MessageBox.Show("Record not available..");
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
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            deleteRecord();
            loadGrid();
            loadGroupNames();
        }
        public void deleteRecord()
        {
            DialogResult result = MessageBox.Show("Do You Want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result.Equals(DialogResult.OK))
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_DeleteGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@GroupId", id);
                    //string Result=cmd.ExecuteNonQuery().ToString();
                    string Result = cmd.ExecuteScalar().ToString();
                    con.Close();
                    if (Result == "Group Deleted Sucessfully")
                    {
                        MessageBox.Show("Group Deleted Sucessfully..");
                        txtgroupname.Text = "";
                    }
                    else if (Result == "Group Transaction is done")
                    {
                        MessageBox.Show("This Group Transaction Completed, You Can Not Deleted Group");
                    }
                    else
                    {
                        MessageBox.Show("This Group Transaction is pending you cannot delete this group");
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
            else
            {
               
            }
          
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbgroupname.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Group Name First");
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
            }
            else
            {
                
                if (rbselectall.Checked == true)
                {
                    rbselectall.Checked = false;
                    SearchGroup();
                }
                else
                {
                    // cbgroupname.Enabled = true;
                    SearchGroup();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //txtid.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                txtgroupname.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                txtBCamount.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[4].Value);
                txtNoOfMember.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[5].Value);
                txtstartdate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value);
                txtenddate.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value);
               // tabControl1.SelectedIndex = 0;
                button3.Text = "Update";
            }
            else
            {
                MessageBox.Show("Please Select the record..");
            }
        }
        public bool validate()
        {
            DateTime dtstart = Convert.ToDateTime(txtstartdate.Text.ToString());
            DateTime dtend = Convert.ToDateTime(txtenddate.Text.ToString());

            if (string.IsNullOrEmpty(txtgroupname.Text))
            {
                MessageBox.Show("Group Name Can Not be Empty..");
                txtgroupname.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtBCamount.Text))
            {
                MessageBox.Show("BC Amount Cannot be Empty...");
                txtBCamount.Focus();
                return false;
            }
            else if (txtBCamount.Text == "0")
            {
                MessageBox.Show("BC Amount Cannot be 0");
                txtBCamount.Focus();
                return false;
            }
           
            

            else if (dtend <= dtstart)
            {
                MessageBox.Show("End Date Must Be Greater Than Start Date");
                txtenddate.Focus();
                return false;
            }

            else if (txtNoOfMember.Text=="1")
            {
                MessageBox.Show("Minimum 2 member are required to create Group");
                
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfMember.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Only Numbers");

                txtNoOfMember.Text.Remove(txtNoOfMember.Text.Length - 1);
                txtNoOfMember.Focus();
                txtNoOfMember.Text = "";
                return false;
            }
            else
            {
                return true;
            }
            
        }
        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            cbgroupname.Enabled = true;
        }
        private void cbSelectAll_MouseClick(object sender, MouseEventArgs e)
        {
            
        }
        private void rbselectall_CheckedChanged(object sender, EventArgs e)
        {
            if (rbselectall.Checked == true)
            {
               // cbgroupname.Enabled = false;
                loadGrid();
            }
            else
            {
               // cbgroupname.Enabled = true;
            
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbselectall.Checked == true)
            {
                 cbgroupname.Enabled = false;
                 btnSearch.Enabled = false;
                loadGrid();
            }
            else
            {
                 cbgroupname.Enabled = true;
                 btnSearch.Enabled = true;
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtBCamount_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBCamount.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers for BC Amount.");
                txtBCamount.Text.Remove(txtBCamount.Text.Length - 1);
                txtBCamount.Text = "";
            }
        }

        private void txtNoOfMember_TextChanged(object sender, EventArgs e)
        {
          /*  if (System.Text.RegularExpressions.Regex.IsMatch(txtNoOfMember.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter Only Numbers");
                
                txtNoOfMember.Text.Remove(txtNoOfMember.Text.Length - 1);
                txtNoOfMember.Focus();
                txtNoOfMember.Text = "";
            }*/
        }

        private void txtenddate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime stdt = Convert.ToDateTime(txtstartdate.Text);
                DateTime eddt = Convert.ToDateTime(txtenddate.Text);
               int no= Convert.ToInt32(((eddt.Year - stdt.Year) * 12) + eddt.Month - stdt.Month); //double no = (eddt - stdt).TotalDays;
               no++;

               // no = Math.Round( no / 30);
                txtNoOfMember.Text = Convert.ToString(no);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtenddate_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime stdt = Convert.ToDateTime(txtstartdate.Text);
            //    DateTime eddt = Convert.ToDateTime(txtenddate.Text);
            //    int no = Convert.ToInt32(((eddt.Year - stdt.Year) * 12) + eddt.Month - stdt.Month);
            //    txtNoOfMember.Text = Convert.ToString( no);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}

        }

        private void txtstartdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime stdt = Convert.ToDateTime(txtstartdate.Text);
                DateTime eddt = Convert.ToDateTime(txtenddate.Text);
                int no = Convert.ToInt32(((eddt.Year - stdt.Year) * 12) + eddt.Month - stdt.Month); //double no = (eddt - stdt).TotalDays;
                no++;

                // no = Math.Round( no / 30);
                txtNoOfMember.Text = Convert.ToString(no);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

       
    }
}
