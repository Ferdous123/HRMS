using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerElectricBillEntryBillingHistory : Form
    {
        private string userName;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public OwnerElectricBillEntryBillingHistory(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void OwnerElectricBillEntryBillingHistory_Load(object sender, EventArgs e)
        {
            PopulateHouses();
        }

        private void PopulateHouses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT h.house_id FROM dbo.OwnerHouseTable oht JOIN dbo.HouseTable h ON oht.house_id = h.house_id WHERE oht.owner_id = (SELECT owner_Id FROM dbo.OwnerTable WHERE username = @username)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ownerbillinghistorychoosehousecombobox.Items.Add(reader["house_id"].ToString());
                        }
                    }
                }
            }
        }

        private void ownerbillinghistorychoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFlats();
        }

        private void PopulateFlats()
        {
            ownerbillinghistorychooseflatcombobox.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT f.flat_Id, f.flat_designation FROM dbo.HouseFlatTable hft JOIN dbo.FlatTable f ON hft.flat_id = f.flat_Id WHERE hft.house_id = @house_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@house_id", ownerbillinghistorychoosehousecombobox.SelectedItem.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ownerbillinghistorychooseflatcombobox.Items.Add(reader["flat_designation"].ToString());
                        }
                    }
                }
            }
        }

        private void ownerbillinghistorychooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateElectricBills();
        }

        private void PopulateElectricBills()
        {
            string flatDesignation = ownerbillinghistorychooseflatcombobox.SelectedItem?.ToString() ?? "All";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT eb.* FROM dbo.ElectricBillTable eb JOIN dbo.FlatTable f ON eb.flat_id = f.flat_Id WHERE f.flat_designation = @flat_designation OR @flat_designation = 'All'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@flat_designation", flatDesignation);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        billingHistoryGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void ownerbillinghsitorybackbutton_Click(object sender, EventArgs e)
        {
            OwnerElectricBillEntry ownerElectricBillEntry = new OwnerElectricBillEntry(userName);
            ownerElectricBillEntry.Show();
            this.Hide();
        }

        private void billingHistoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
