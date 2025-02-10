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
    public partial class OwnerElectricBillEntry : Form
    {
        private string userName;
        private int ownerId;

        public OwnerElectricBillEntry(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void OwnerElectricBillEntry_Load(object sender, EventArgs e)
        {
            ownerId = GetOwnerId(userName);
            PopulateHouseComboBox();
        }

        private int GetOwnerId(string username)
        {

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT owner_Id FROM OwnerTable WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void PopulateHouseComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT house_id FROM OwnerHouseTable WHERE owner_Id = @OwnerID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OwnerID", ownerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ownerelectricbillentrychoosehousecombobox.Items.Add(reader["house_id"]);
                        }
                    }
                }
            }
        }

        private void ownerflatfinencialschoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedHouse = (dynamic)ownerelectricbillentrychoosehousecombobox.SelectedItem;
            int houseId = selectedHouse.HouseID;
            PopulateFlatComboBox(houseId);
        }

        private void PopulateFlatComboBox(int houseId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FlatID FROM HouseFlatTable WHERE HouseID = @HouseID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HouseID", houseId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int flatId = reader.GetInt32(0);
                            string flatDesignation = GetFlatDesignation(flatId);
                            ownerelectricbillchooseflatcombobox.Items.Add(new { FlatID = flatId, FlatDesignation = flatDesignation });
                        }
                    }
                }
            }
        }

        private string GetFlatDesignation(int flatId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT FlatDesignation FROM FlatTable WHERE FlatID = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    return (string)command.ExecuteScalar();
                }
            }
        }

        private void ownerelectricbillchooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedFlat = (dynamic)ownerelectricbillchooseflatcombobox.SelectedItem;
            int flatId = selectedFlat.FlatID;
            PopulatePreviousMeterReading(flatId);
        }

        private void PopulatePreviousMeterReading(int flatId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PreviousMeterReading FROM FlatTable WHERE FlatID = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    ownerelectricbillprevmeterreadingtextbox.Text = command.ExecuteScalar().ToString();
                }
            }
        }

        private void ownerelectricbillcurrmeterreadingtextbox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(ownerelectricbillprevmeterreadingtextbox.Text, out int prevReading) &&
                int.TryParse(ownerelectricbillcurrmeterreadingtextbox.Text, out int currReading))
            {
                if (currReading < prevReading)
                {
                    MessageBox.Show("Current meter reading cannot be less than previous meter reading.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int electricityConsumed = currReading - prevReading;
                ownerelectricbillelectricityconsumedtextbox.Text = electricityConsumed.ToString();

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Rate FROM FlatFinancials WHERE FlatID = @FlatID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var selectedFlat = (dynamic)ownerelectricbillchooseflatcombobox.SelectedItem;
                        int flatId = selectedFlat.FlatID;
                        command.Parameters.AddWithValue("@FlatID", flatId);
                        decimal rate = (decimal)command.ExecuteScalar();
                        decimal billAmount = electricityConsumed * rate;
                        ownerelectricbilentrybilltextbox.Text = billAmount.ToString("F2");
                    }
                }
            }
        }

        private void ownerelectricbillentryconfirmbutton_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
        }

        private void ownerelectricbillentrynextbutton_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
            MoveToNextFlat();
        }

        private void UpdateDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE FlatTable SET PreviousMeterReading = @CurrentMeterReading WHERE FlatID = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    var selectedFlat = (dynamic)ownerelectricbillchooseflatcombobox.SelectedItem;
                    int flatId = selectedFlat.FlatID;
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    command.Parameters.AddWithValue("@CurrentMeterReading", int.Parse(ownerelectricbillcurrmeterreadingtextbox.Text));
                    command.ExecuteNonQuery();
                }
            }
        }

        private void MoveToNextFlat()
        {
            int currentIndex = ownerelectricbillchooseflatcombobox.SelectedIndex;
            if (currentIndex < ownerelectricbillchooseflatcombobox.Items.Count - 1)
            {
                ownerelectricbillchooseflatcombobox.SelectedIndex = currentIndex + 1;
            }
            else
            {
                MessageBox.Show("All flats are entered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }







        /// <summary>
        /// /////////////////////////////////////////////////////////
        /// </summary>



        private void ownerelectricbillentrybackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void ownerelectricbillentrybillinghistrybutton_Click(object sender, EventArgs e)
        {
            OwnerElectricBillEntryBillingHistory ownerElectricBillEntryBillingHistory = new OwnerElectricBillEntryBillingHistory(userName);
            ownerElectricBillEntryBillingHistory.Show();
            this.Hide();
        }

        private void ownerelectricbillchooseflatcombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
