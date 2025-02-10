using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerTenants : Form
    {
        private string userName;
        private SqlConnection con;

        public OwnerTenants(string username)
        {
            InitializeComponent();
            this.userName = username;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private void OwnerTenants_Load(object sender, EventArgs e)
        {
            PopulateHouseDropdown();
            InitializeDataGridView();
        }

        private void PopulateHouseDropdown()
        {
            try
            {
                con.Open();
                string query = @"SELECT oht.house_id 
                         FROM OwnerHouseTable oht
                         JOIN OwnerTable ot ON oht.owner_id = ot.owner_Id
                         WHERE ot.username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ownertenantchoosehousecombobox.Items.Clear();
                    while (reader.Read())
                    {
                        ownertenantchoosehousecombobox.Items.Add(reader["house_id"].ToString());
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void ownertenantchoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHouse = ownertenantchoosehousecombobox.SelectedItem.ToString();
            PopulateFlatDropdown(selectedHouse);
            PopulateTenantGrid(selectedHouse);
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
                    ownertenantschooseflatscombobox.Items.Clear();
                    while (reader.Read())
                    {
                        ownertenantschooseflatscombobox.Items.Add(reader["flat_Id"].ToString());
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
            ownerTenantsDataGridView.Columns.Add("Name", "Name");
            ownerTenantsDataGridView.Columns.Add("TenantID", "Tenant ID");
            ownerTenantsDataGridView.Columns.Add("MoveInDate", "Move-In Date");
            ownerTenantsDataGridView.Columns.Add("HouseNum", "House Number");
            ownerTenantsDataGridView.Columns.Add("Address", "Address");
            ownerTenantsDataGridView.Columns.Add("FlatDesignation", "Flat Designation");
            ownerTenantsDataGridView.Columns.Add("Due", "Due");

            DataGridViewButtonColumn sendNoticeColumn = new DataGridViewButtonColumn();
            sendNoticeColumn.Name = "SendNotice";
            sendNoticeColumn.HeaderText = "Send Notice";
            sendNoticeColumn.Text = "Send Notice";
            sendNoticeColumn.UseColumnTextForButtonValue = true;
            ownerTenantsDataGridView.Columns.Add(sendNoticeColumn);

            ownerTenantsDataGridView.CellClick += OwnerTenantsDataGridView_CellClick;
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
                    ownerTenantsDataGridView.Rows.Clear();
                    while (reader.Read())
                    {
                        ownerTenantsDataGridView.Rows.Add(
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
            if (e.ColumnIndex == ownerTenantsDataGridView.Columns["SendNotice"].Index && e.RowIndex >= 0)
            {
                string tenantId = ownerTenantsDataGridView.Rows[e.RowIndex].Cells["TenantID"].Value.ToString();
                OwnerNotice ownerNotice = new OwnerNotice(userName, tenantId);
                this.Hide();
                ownerNotice.Show();
            }
        }

        private void ownertenantsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void ownertenantsaddtenantbutton_Click(object sender, EventArgs e)
        {
            OwnerTenantsAddTenants ownerTenantsAddTenant = new OwnerTenantsAddTenants(userName);
            ownerTenantsAddTenant.Show();
            this.Hide();
        }

        private void ownertenantschooseflatscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownertenantschooseflatscombobox.SelectedItem != null)
            {
                string selectedFlat = ownertenantschooseflatscombobox.SelectedItem.ToString();
                PopulateTenantGridByFlat(selectedFlat);
            }
            else
            {
                // Handle the case where no item is selected
                MessageBox.Show("Please select a flat.");
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
                    ownerTenantsDataGridView.Rows.Clear();
                    while (reader.Read())
                    {
                        ownerTenantsDataGridView.Rows.Add(
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


        private void ownerTenantsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
