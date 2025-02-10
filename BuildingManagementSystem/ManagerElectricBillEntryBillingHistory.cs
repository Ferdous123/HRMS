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
    public partial class ManagerElectricBillEntryBillingHistory : Form
    {
        private string userName;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
        public ManagerElectricBillEntryBillingHistory(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void managerbillinghsitorybackbutton_Click(object sender, EventArgs e)
        {
            ManagerElectricBillEntry managerElectricBillEntry = new ManagerElectricBillEntry(userName);
            managerElectricBillEntry.Show();
            this.Hide();
        }

        private void ManagerElectricBillEntryBillingHistory_Load(object sender, EventArgs e)
        {
            PopulateHouses();
        }

        private void PopulateHouses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT h.house_id FROM dbo.ManagerHouseTable oht JOIN dbo.HouseTable h ON oht.house_id = h.house_id WHERE oht.manager_id = (SELECT manager_Id FROM dbo.ManagerTable WHERE username = @username)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            managerbillinghistorychoosehousecombobox.Items.Add(reader["house_id"].ToString());
                        }
                    }
                }
            }
        }
        private void managerbillinghistorychoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFlats();
        }

        private void PopulateFlats()
        {
            managerbillinghistorychooseflatcombobox.Items.Clear();
            if (managerbillinghistorychoosehousecombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a house.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT f.flat_Id, f.flat_designation FROM dbo.HouseFlatTable hft JOIN dbo.FlatTable f ON hft.flat_id = f.flat_Id WHERE hft.house_id = @house_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@house_id", managerbillinghistorychoosehousecombobox.SelectedItem.ToString());
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            managerbillinghistorychooseflatcombobox.Items.Add(reader["flat_designation"].ToString());
                        }
                    }
                }
            }
        }


        private void managerbillinghistorychooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateElectricBills();
        }

        private void PopulateElectricBills()
        {
            string flatDesignation = managerbillinghistorychooseflatcombobox.SelectedItem?.ToString() ?? "All";
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

        private void managerbillinghistorychoosehousecombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PopulateFlats();
        }

        private void managerbillinghistorychooseflatcombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            PopulateElectricBills();
        }
    }
}

