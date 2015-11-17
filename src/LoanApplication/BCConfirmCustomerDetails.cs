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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace LoanApplication
{
    public partial class BCConfirmCustomerDetails : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public BCConfirmCustomerDetails()
        { 
            InitializeComponent();
            loadGroupNames(); 
            loadGrid();
            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //txtcustomerName.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool Validate()
        {
            if (cbgroupName.SelectedValue == null)
            {
                MessageBox.Show("Please select group name");
                return false;
            }
            //  else if (string.IsNullOrEmpty(txtcustomerName.Text))
            //{
            //    MessageBox.Show("Customer Name Can Not be Empty..");
            //    return false;
            //}
            else
            {
                return true;
            }
        }
        private void btncancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteRecord();
            SearchCustomer();
        }
        public void deleteRecord()
        {
            if (cbGroupNames.SelectedValue.ToString() != "0")
            {
                DialogResult result = MessageBox.Show("Do You Want To Remove Member?", "Remove Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result.Equals(DialogResult.OK))
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_DeleteCustomerfromGroup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        int GroupId = Convert.ToInt32(cbGroupNames.SelectedValue.ToString());
                        string CustomerName = dataGridView1.SelectedCells[1].Value.ToString();
                        int CustomerID = Convert.ToInt32(dataGridView1.SelectedCells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@GroupId", GroupId);
                        cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                        int rt = cmd.ExecuteNonQuery();

                        con.Close();
                        if (rt == 1)
                        {
                            MessageBox.Show("Customer Removed Sucessfully..");
                        }
                        else
                        {
                            MessageBox.Show("Cant Remove Customer");
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Internal Error Occured");
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
            else
            {
                MessageBox.Show("Please Select Group Name and Click on Search Button","Select Group Name",MessageBoxButtons.OKCancel);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //cbgroupName.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value);
                //txtcustomerName.Text = Convert.ToString(dataGridView1.SelectedRows[0].Cells[1].Value);
                //tabControl1.SelectedIndex = 0;
                //lblcustomername.Visible = true;
                //txtcustomerName.Visible = true;
                //button1.Visible = false;
            }
            else
            {
                MessageBox.Show("Please Select the record..");
            }
        }
        private void loadGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_LoadGroupCustomerGrid", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        //dataGridView1.Columns[0].HeaderCell.Value = "Sr.No";
                        dataGridView1.Columns[1].HeaderCell.Value = "Group Name";
                        dataGridView1.Columns[2].HeaderCell.Value = "Customer Name";
                        dataGridView1.Columns[0].Visible = false;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.Refresh();
                        dataGridView1.Show();
                        
                    }
                    else
                    {
                       // MessageBox.Show("Record Does Not Found");
                        dataGridView1.DataSource = null;
                        dataGridView1.Refresh();
                        dataGridView1.Show();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show("Internal Error Occured");
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
                    SqlCommand cmd = new SqlCommand("Usp_LoadGroupNamesforcustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    try
                    {
                        if (dt.Rows.Count > 0)
                        {
                            cbgroupName.DataSource = dt;
                            cbgroupName.DisplayMember = "GroupName";
                            cbgroupName.ValueMember = "GroupId";
                            // cbgroupName.Items.Insert(0, "-SELECT--");
                            // cbgroupName.Items.Insert(0, "--Select--");
                            // cbgroupName.SelectedIndex = 0;
                            cbGroupNames.DataSource = dt;
                            cbGroupNames.DisplayMember = "GroupName";
                            cbGroupNames.ValueMember = "GroupId";
                            //cbGroupNames.Items.Insert(0, "--Select--");
                            //cbGroupNames.SelectedIndex = 0;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Internal Error Occured");
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
        private void button7_Click(object sender, EventArgs e)
        {

            if (cbGroupNames.SelectedValue.ToString()=="0")
            {
                MessageBox.Show("Please Select Group Name First");
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();

            }
            else
            {
                SearchCustomer();
            }
        }
        public void SearchCustomer()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_SerchGroupmembers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {  
                int GroupId = Convert.ToInt32(cbGroupNames.SelectedValue.ToString());
                if (GroupId != 0)
                {
                    cmd.Parameters.AddWithValue("@GroupId", GroupId);
                    SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderCell.Value = "Group Name";
                        dataGridView1.Columns[1].HeaderCell.Value = "CustomerID";
                        dataGridView1.Columns[1].Visible = false;
                        dataGridView1.Columns[2].HeaderCell.Value = "Customer Name";
                        dataGridView1.Refresh();
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.AllowUserToDeleteRows = false;
                        dataGridView1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Record does not available");
                        dataGridView1.DataSource = null;
                    }
                }
                else
                {
                    
                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Internal Error Occured");
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbgroupName.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please Select Group Name First");
                dataGridView2.DataSource = null;
                dataGridView2.Refresh();

            }
            else
            {
                if (rbselectAll.Checked == true)
                {
                    rbselectAll.Checked = false;
                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    DisplayMembersNotInGroup();
                }
                else
                {
                    DisplayMembersNotInGroup();
                }
            }
        }
        /*Createsd by Sameer
         * Purpose:-Display member which is not already added in seleceted Group
         * Date:-15/10/2015
         */
        #region---------------DisplayMembersNotInGroup--------------------------------
        private void DisplayMembersNotInGroup()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            int GroupId = Convert.ToInt32(cbgroupName.SelectedValue.ToString());
            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_SerachMembersNotInGroup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupId", GroupId);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    if (dataGridView2.DataSource == null)
                    {
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                        dataGridView2.Columns.Add(chk);
                        chk.HeaderText = "Select";
                        chk.Name = "chk"; 
                    } 
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                         dataGridView2.DataSource = dt;
                         dataGridView2.Columns[0].HeaderCell.Value = "Select";
                        //dataGridView2.Columns[1].HeaderCell.Value = "Group Id";
                        dataGridView2.Columns[1].HeaderCell.Value = "CustomerId";
                        dataGridView2.Columns[2].HeaderCell.Value = "Name";
                        dataGridView2.Columns[1].Visible = false;
                        //dataGridView2.Columns[2].Visible = false;
                        dataGridView2.Refresh();
                        dataGridView2.AllowUserToAddRows = false;
                        dataGridView2.Show();
                        GetGroupMembersCount();
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.Hide();
                    }
                  
                }
            catch (Exception)
            {
                MessageBox.Show("Internal Error Occured");
            }
            
        }
        #endregion
        private void CreateMember()
        {
            int i = 0;
            List<int> ChkedRow = new List<int>();
            for (i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["Select"].Value) == true)
                {
                    ChkedRow.Add(i);
                }
            }
            if (ChkedRow.Count == 0)
            {
                MessageBox.Show("Select one checkbox");
                return;
            }
            foreach (int j in ChkedRow)
            {
                string str = @"INSERT INTO CustomerGroupDetails(GroupId,CustomerId) VALUES ('" + dataGridView2.Rows[j].Cells["GroupId"].Value + "', '" + dataGridView2.Rows[j].Cells["CustomerId"].Value + "');";
                try
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand com = new SqlCommand(str, con);
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            MessageBox.Show("Records successfully inserted");
        }
        private void loadcustomerGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                try
                {
                    #region
                    SqlCommand cmd = new SqlCommand("Usp_GetGroupId1", sqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GroupId", Convert.ToInt32(cbgroupName.SelectedValue.ToString()));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    if (dataGridView2.DataSource == null)
                    {
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                        dataGridView2.Columns.Add(chk);
                        chk.HeaderText = "Select";
                        chk.Name = "chk"; 
                    } 
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView2.DataSource = dt;
                        dataGridView2.Columns[0].HeaderCell.Value = "Select";
                        dataGridView2.Columns[1].HeaderCell.Value = "Group Id";
                        dataGridView2.Columns[2].HeaderCell.Value = "Customer Id";
                        dataGridView2.Columns[3].HeaderCell.Value = "Customer Name";
                        dataGridView2.Columns[1].Visible = false;
                        dataGridView2.Columns[2].Visible = false;
                        dataGridView2.Refresh();
                        dataGridView2.AllowUserToAddRows = false;
                        dataGridView2.Show();
                    }
                    else
                    {
                        dataGridView2.DataSource = null;
                        dataGridView2.Hide();
                    }
                    #endregion
                }
                catch (Exception eo)
                {
                    MessageBox.Show(eo.Message.ToString());
                }
            }
        }
        public void getGroupId()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Usp_GetGroupId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupName", cbgroupName.Text);
                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDa.Fill(dt); 
            } 
            catch (Exception)
            { 
                MessageBox.Show("Internal Error Occured"); 
            } 
            finally
            { 
                cmd.Dispose(); 
                con.Close(); 
                con.Dispose(); 
            } 
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
        }
        private void lblcustomername_Click(object sender, EventArgs e)
        {
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            int i = 0;
            int cnt = 0;
            string message = "";
            List<int> ChkedRow = new List<int>(); 
            for (i = 0; i <= dataGridView2.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridView2.Rows[i].Cells["chk"].Value) == true)
                {
                    ChkedRow.Add(i);
                    cnt++;
                } 
            }
            if (ChkedRow.Count == 0)
            {
                MessageBox.Show("Select more than one customer");
                return;
            }
            else if (ChkedRow.Count > (Convert.ToInt32(Convert.ToInt32(txtMaxMembers.Text) - Convert.ToInt32(txtAvailableMembers.Text))))
            {
                int No = Convert.ToInt32(Convert.ToInt32(txtMaxMembers.Text) - Convert.ToInt32(txtAvailableMembers.Text));
                if (No == 0)
                {
                    MessageBox.Show("Can't Add More Members in This Group.");
                }
                else
                {
                    MessageBox.Show("Maximum " + No + " Member Can Add");
                }
            }
            else
            {
            foreach (int j in ChkedRow)
            { 
                try
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    int customerId = Convert.ToInt32(dataGridView2.Rows[j].Cells["CustomerId"].Value);
                    //int groupId = Convert.ToInt32(dataGridView2.Rows[j].Cells["GroupId"].Value);
                    string customername = Convert.ToString(dataGridView2.Rows[j].Cells["Name"].Value);
                    int groupId = Convert.ToInt32(cbgroupName.SelectedValue.ToString());
                    SqlCommand com1 = new SqlCommand("select CustomerId from CustomerGroupDetails where GroupId = '" + groupId + "' and  CustomerId ='" + customerId + "'", con);
                    com1.ExecuteNonQuery();
                    SqlDataAdapter sqlDa = new SqlDataAdapter(com1);
                    DataTable dt = new DataTable();
                    sqlDa.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        message = "Member Already added in this group";
                    }
                    else
                   
                    {
                        string str = @"INSERT INTO CustomerGroupDetails(GroupId,CustomerId,Name) VALUES ('" + groupId + "', '" + dataGridView2.Rows[j].Cells["CustomerId"].Value + "','" + dataGridView2.Rows[j].Cells["Name"].Value + "');";
                        ///string str = @"INSERT INTO CustomerGroupDetails(GroupId,CustomerId,Name) VALUES (groupId,customerId,customername);
                        SqlCommand com = new SqlCommand(str, con);
                        com.ExecuteNonQuery();
                   }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
            if (message == "Member Already added in this group")
            {
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Member Added Sucessfully..");
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                    }

                }
                dataGridView2.EndEdit();
                DisplayMembersNotInGroup();
              
               

            }
            }
        }
        private void rbselectAll_CheckedChanged(object sender, EventArgs e)
        {
            loadcustomerGrid();
        }
        private void rbselectAll_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbselectAll.Checked == true)
            {
                loadGrid();
                rbselectAll.Checked = false;
            }
            else
            {
                rbselectAll.Checked = true;
            }
        }
        private void rbselectAll_CheckedChanged_2(object sender, EventArgs e)
        {
            if (rbselectAll.Checked == true)
            {
                loadGrid();
                rbselectAll.Checked = false;
            }
            else
            {
                //rbselectAll.Checked = true;
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetGroupMembersCount()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                int GroupID = Convert.ToInt32(cbgroupName.SelectedValue);

                con.Open();
                SqlCommand cmd = new SqlCommand("Usp_GetGroupMembrsCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@GroupId", GroupID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    txtMaxMembers.Text = dt.Rows[0]["MaxMembers"].ToString();
                    txtAvailableMembers.Text = dt.Rows[0]["AvailableMembers"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void btnClose_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
