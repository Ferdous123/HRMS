using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class ManagerTenants : Form
    {
        private string userName;
        private SqlConnection con;

        public ManagerTenants(string username)
        {
            InitializeComponent();
            this.userName = username;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        }
        private void PopulateHouseDropdown()
        {
            try
            {
                con.Open();
                string query = @"SELECT oht.house_id 
                         FROM ManagerHouseTable oht
                         JOIN ManagerTable ot ON oht.manager_id = ot.manager_Id
                         WHERE ot.username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    managertenantchoosehousecombobox.Items.Clear();
                    while (reader.Read())
                    {
                        managertenantchoosehousecombobox.Items.Add(reader["house_id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void PopulateFlatDropdown(string house)
        {
            try
            {
                con.Open();
                string query = @"SELECT f.flat_Id 
                                 FROM HouseFlatTable hft
                                 JOIN FlatTable f ON hft.flat_id = f.flat_Id
                                 WHERE hft.house_id = @house_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", house);
                    SqlDataReader reader = cmd.ExecuteReader();
                    managertenantschooseflatscombobox.Items.Clear();
                    while (reader.Read())
                    {
                        managertenantschooseflatscombobox.Items.Add(reader["flat_Id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("TenantID", "Tenant ID");
            dataGridView1.Columns.Add("MoveInDate", "Move-In Date");
            dataGridView1.Columns.Add("HouseNum", "House Number");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("FlatDesignation", "Flat Designation");
            dataGridView1.Columns.Add("Due", "Due");

            DataGridViewButtonColumn sendNoticeColumn = new DataGridViewButtonColumn();
            sendNoticeColumn.Name = "SendNotice";
            sendNoticeColumn.HeaderText = "Send Notice";
            sendNoticeColumn.Text = "Send Notice";
            sendNoticeColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(sendNoticeColumn);

            dataGridView1.CellClick += OwnerTenantsDataGridView_CellClick;
        }

        private void PopulateTenantGrid(string houseId)
        {
            try
            {
                con.Open();
                string query = @"
                    SELECT 
                        tt.name, 
                        tt.tenant_id, 
                        fot.move_in_date, 
                        ht.house_num, 
                        ht.address, 
                        ft.flat_designation, 
                        tdt.due
                    FROM 
                        FlatOccupationTable fot
                    JOIN 
                        TenantTable tt ON fot.tenant_id = tt.tenant_Id
                    JOIN 
                        HouseTable ht ON fot.house_id = ht.house_Id
                    JOIN 
                        FlatTable ft ON fot.flat_id = ft.flat_Id
                    LEFT JOIN 
                        TenantDueTable tdt ON tt.tenant_Id = tdt.tenant_Id
                    WHERE 
                        fot.house_id = @house_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", houseId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["name"].ToString(),
                            reader["tenant_id"].ToString(),
                            reader["move_in_date"].ToString(),
                            reader["house_num"].ToString(),
                            reader["address"].ToString(),
                            reader["flat_designation"].ToString(),
                            reader["due"].ToString()
                        );
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void OwnerTenantsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["SendNotice"].Index && e.RowIndex >= 0)
            {
                string tenantId = dataGridView1.Rows[e.RowIndex].Cells["TenantID"].Value.ToString();
                ManagerNotice ownerNotice = new ManagerNotice(userName);
                this.Hide();
                ownerNotice.Show();
            }
        }

        private void PopulateTenantGridByFlat(string flatId)
        {
            try
            {
                con.Open();
                string query = @"
            SELECT 
                tt.name, 
                tt.tenant_id, 
                fot.move_in_date, 
                ht.house_num, 
                ht.address, 
                ft.flat_designation, 
                tdt.due
            FROM 
                FlatOccupationTable fot
            JOIN 
                TenantTable tt ON fot.tenant_id = tt.tenant_Id
            JOIN 
                HouseTable ht ON fot.house_id = ht.house_Id
            JOIN 
                FlatTable ft ON fot.flat_id = ft.flat_Id
            LEFT JOIN 
                TenantDueTable tdt ON tt.tenant_Id = tdt.tenant_Id
            WHERE 
                fot.flat_id = @flat_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@flat_id", flatId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["name"].ToString(),
                            reader["tenant_id"].ToString(),
                            reader["move_in_date"].ToString(),
                            reader["house_num"].ToString(),
                            reader["address"].ToString(),
                            reader["flat_designation"].ToString(),
                            reader["due"].ToString()
                        );
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void managertenantsbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void managertenantsaddtenantbutton_Click(object sender, EventArgs e)
        {
            ManagerTenantsAddTenant managerTenantsAddTenant = new ManagerTenantsAddTenant(userName);
            managerTenantsAddTenant.Show();
            this.Hide();
        }

        private void ManagerTenants_Load(object sender, EventArgs e)
        {
            PopulateHouseDropdown();
            InitializeDataGridView();
        }

        private void managertenantchoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHouse = managertenantchoosehousecombobox.SelectedItem.ToString();
            PopulateFlatDropdown(selectedHouse);
            PopulateTenantGrid(selectedHouse);
        }

        private void managertenantschooseflatscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managertenantschooseflatscombobox.SelectedItem != null)
            {
                string selectedFlat = managertenantschooseflatscombobox.SelectedItem.ToString();
                PopulateTenantGridByFlat(selectedFlat);
            }
            else
            {
                MessageBox.Show("Please select a flat.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
