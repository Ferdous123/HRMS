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
    public partial class ManagerElectricBillEntry : Form
    {
        private string userName;
        private int ownerId;

        public ManagerElectricBillEntry(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void ManagerElectricBillEntry_Load(object sender, EventArgs e)
        {
            ownerId = GetOwnerId(userName);
            PopulateHouseComboBox();
            ownerelectricbillentrydatepickerbox.Value = DateTime.Now;
        }

        private int GetOwnerId(string username)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT manager_Id FROM ManagerTable WHERE username = @UserName";
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
                string query = "SELECT house_id FROM ManagerHouseTable WHERE manager_id = @OwnerID";
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
            if (ownerelectricbillentrychoosehousecombobox.SelectedItem != null)
            {
                int houseId = (int)ownerelectricbillentrychoosehousecombobox.SelectedItem;
                PopulateFlatComboBox(houseId);
            }
        }

        private void PopulateFlatComboBox(int houseId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT flat_id FROM HouseFlatTable WHERE house_id = @HouseID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HouseID", houseId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int flatId = reader.GetInt32(0);
                            string flatDesignation = GetFlatDesignation(flatId);
                            ownerelectricbillchooseflatcombobox.Items.Add(flatDesignation);
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
                string query = "SELECT flat_designation FROM FlatTable WHERE flat_Id = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    return (string)command.ExecuteScalar();
                }
            }
        }

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

        private void ownerelectricbillchooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerelectricbillchooseflatcombobox.SelectedItem != null)
            {
                string flatDesignation = ownerelectricbillchooseflatcombobox.SelectedItem.ToString();
                int flatId = GetFlatIdByDesignation(flatDesignation);
                PopulatePreviousMeterReading(flatId);
                PopulateUnitRate(flatId);
            }
        }

        private int GetFlatIdByDesignation(string flatDesignation)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT flat_Id FROM FlatTable WHERE flat_designation = @FlatDesignation";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatDesignation", flatDesignation);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private void PopulatePreviousMeterReading(int flatId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT latest_meter_reading FROM FlatFinancialsTable WHERE flat_id = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        ownerelectricbillprevmeterreadingtextbox.Text = result.ToString();
                    }
                    else
                    {
                        ownerelectricbillprevmeterreadingtextbox.Text = "No Matching Record";
                    }
                }
            }
        }

        private void PopulateUnitRate(int flatId)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT electricity_per_unit_rate FROM FlatFinancialsTable WHERE flat_id = @FlatID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FlatID", flatId);
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        float rate = (float)(double)result;
                        texownerelectricbillunitrate.Text = rate.ToString("F2");
                    }
                    else
                    {
                        texownerelectricbillunitrate.Text = "No Matching Record";
                    }
                }
            }
        }

        private void ownerelectricbillprevmeterreadingtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerelectricbillcurrmeterreadingtextbox_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(ownerelectricbillprevmeterreadingtextbox.Text, out float prevReading) &&
               float.TryParse(ownerelectricbillcurrmeterreadingtextbox.Text, out float currReading))
            {
                float electricityConsumed = currReading - prevReading;
                ownerelectricbillelectricityconsumedtextbox.Text = electricityConsumed.ToString();

                if (float.TryParse(texownerelectricbillunitrate.Text, out float rate))
                {
                    float billAmount = electricityConsumed * rate;
                    ownerelectricbilentrybilltextbox.Text = billAmount.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Invalid unit rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ownerelectricbillelectricityconsumedtextbox_TextChanged(object sender, EventArgs e)
        {

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
            if (ownerelectricbillchooseflatcombobox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(ownerelectricbillprevmeterreadingtextbox.Text) ||
                string.IsNullOrWhiteSpace(ownerelectricbillcurrmeterreadingtextbox.Text) ||
                string.IsNullOrWhiteSpace(texownerelectricbillunitrate.Text) ||
                string.IsNullOrWhiteSpace(ownerelectricbilentrybilltextbox.Text))
            {
                MessageBox.Show("Please ensure all fields are filled in correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string flatDesignation = ownerelectricbillchooseflatcombobox.SelectedItem.ToString();
            int flatId = GetFlatIdByDesignation(flatDesignation);

            if (!float.TryParse(ownerelectricbillprevmeterreadingtextbox.Text, out float prevReading) ||
                !float.TryParse(ownerelectricbillcurrmeterreadingtextbox.Text, out float currReading) ||
                !float.TryParse(texownerelectricbillunitrate.Text, out float perUnitCost) ||
                !float.TryParse(ownerelectricbilentrybilltextbox.Text, out float postpaidElectricBill))
            {
                MessageBox.Show("Please ensure all numeric fields contain valid numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (currReading < prevReading)
            {
                MessageBox.Show("Current meter reading cannot be less than previous meter reading.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime billingMonth = ownerelectricbillentrydatepickerbox.Value.Date;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string meterType = "Postpaid";

                    // Check for existing entry and remove it if exists
                    string checkQuery = "SELECT COUNT(*) FROM ElectricBillTable WHERE flat_id = @FlatID AND CONVERT(date, billing_month) = @BillingMonth";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection, transaction))
                    {
                        checkCommand.Parameters.AddWithValue("@FlatID", flatId);
                        checkCommand.Parameters.AddWithValue("@BillingMonth", billingMonth);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            string deleteQuery = "DELETE FROM ElectricBillTable WHERE flat_id = @FlatID AND CONVERT(date, billing_month) = @BillingMonth";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                            {
                                deleteCommand.Parameters.AddWithValue("@FlatID", flatId);
                                deleteCommand.Parameters.AddWithValue("@BillingMonth", billingMonth);
                                deleteCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // CheckDate
                    DateTime lastEntryDate;
                    string lastEntryQuery = "SELECT TOP 1 billing_month FROM ElectricBillTable WHERE flat_id = @FlatID ORDER BY billing_month DESC";
                    using (SqlCommand lastEntryCommand = new SqlCommand(lastEntryQuery, connection, transaction))
                    {
                        lastEntryCommand.Parameters.AddWithValue("@FlatID", flatId);
                        var result = lastEntryCommand.ExecuteScalar();
                        if (result != null)
                        {
                            lastEntryDate = ((DateTime)result).Date;
                        }
                        else
                        {
                            lastEntryDate = DateTime.MinValue;
                        }
                    }

                    if (lastEntryDate != DateTime.MinValue && billingMonth.Day != 1)
                    {
                        int daysSinceLastEntry = (billingMonth - lastEntryDate).Days;
                        float dailyConsumption = (currReading - prevReading) / daysSinceLastEntry;

                        DateTime firstOfMonth = new DateTime(billingMonth.Year, billingMonth.Month, 1);
                        int daysToFirstOfMonth = (billingMonth - firstOfMonth).Days;
                        float approximatedReading = currReading - (dailyConsumption * daysToFirstOfMonth);

                        DialogResult result = MessageBox.Show($"The bill record date is not the 1st of the month. Do you want to approximate the reading for the 1st of the month? The approximated reading will be {approximatedReading:F2}.", "Approximate Reading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            ownerelectricbillcurrmeterreadingtextbox.Text = approximatedReading.ToString("F2");
                            ownerelectricbillentrydatepickerbox.Value = firstOfMonth;

                            currReading = approximatedReading;
                            billingMonth = firstOfMonth;

                            float electricityConsumed = currReading - prevReading;
                            ownerelectricbillelectricityconsumedtextbox.Text = electricityConsumed.ToString("F2");

                            float billAmount = electricityConsumed * perUnitCost;
                            ownerelectricbilentrybilltextbox.Text = billAmount.ToString("F2");
                        }
                    }

                    // Insert into ElectricBillTable
                    string insertQuery = "INSERT INTO ElectricBillTable (flat_id, prev_postpaid_meter_reading, current_postpaid_meter_reading, per_unit_cost, billing_month, postpaid_electric_bill, meter_type) " +
                                         "VALUES (@FlatID, @PrevMeterReading, @CurrentMeterReading, @PerUnitCost, @BillingMonth, @PostpaidElectricBill, @MeterType)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                    {
                        insertCommand.Parameters.AddWithValue("@FlatID", flatId);
                        insertCommand.Parameters.AddWithValue("@PrevMeterReading", prevReading);
                        insertCommand.Parameters.AddWithValue("@CurrentMeterReading", currReading);
                        insertCommand.Parameters.AddWithValue("@PerUnitCost", perUnitCost);
                        insertCommand.Parameters.AddWithValue("@BillingMonth", billingMonth);
                        insertCommand.Parameters.AddWithValue("@PostpaidElectricBill", postpaidElectricBill);
                        insertCommand.Parameters.AddWithValue("@MeterType", meterType);

                        insertCommand.ExecuteNonQuery();
                    }

                    // Update FlatFinancialsTable
                    string updateQuery = "UPDATE FlatFinancialsTable SET latest_meter_reading = @CurrentMeterReading WHERE flat_id = @FlatID";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                    {
                        updateCommand.Parameters.AddWithValue("@CurrentMeterReading", currReading);
                        updateCommand.Parameters.AddWithValue("@FlatID", flatId);

                        updateCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Electric bill entry and meter reading update successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void texownerelectricbillunitrate_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerelectricbillentrydatepickerbox_ValueChanged(object sender, EventArgs e)
        {

        }




















        private void managerelectricbillentrybackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void managerelectricbillentrybillinghistrybutton_Click(object sender, EventArgs e)
        {
            ManagerElectricBillEntryBillingHistory managerElectricBillEntryBillingHistory = new ManagerElectricBillEntryBillingHistory(userName);
            managerElectricBillEntryBillingHistory.Show();
            this.Hide();
        }


        private void managerelectricbillentrychoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void managerelectricbillchooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void managerelectricbillcurrmeterreadingtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void managerelectricbillprevmeterreadingtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void managerelectricbillelectricityconsumedtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void managerelectricbilentrybilltextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerelectricbillentrychoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerelectricbillentrychoosehousecombobox.SelectedItem != null)
            {
                int houseId = (int)ownerelectricbillentrychoosehousecombobox.SelectedItem;
                PopulateFlatComboBox(houseId);
            }
        }

        private void texownerelectricbillunitrate_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ownerelectricbillchooseflatcombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string flatDesignation = ownerelectricbillchooseflatcombobox.SelectedItem.ToString();
            int flatId = GetFlatIdByDesignation(flatDesignation);
            PopulatePreviousMeterReading(flatId);
            PopulateUnitRate(flatId);
        }

        private void ownerelectricbillcurrmeterreadingtextbox_TextChanged_1(object sender, EventArgs e)
        {
            if (float.TryParse(ownerelectricbillprevmeterreadingtextbox.Text, out float prevReading) &&
               float.TryParse(ownerelectricbillcurrmeterreadingtextbox.Text, out float currReading))
            {
                float electricityConsumed = currReading - prevReading;
                ownerelectricbillelectricityconsumedtextbox.Text = electricityConsumed.ToString();

                if (float.TryParse(texownerelectricbillunitrate.Text, out float rate))
                {
                    float billAmount = electricityConsumed * rate;
                    ownerelectricbilentrybilltextbox.Text = billAmount.ToString("F2");
                }
                else
                {
                    MessageBox.Show("Invalid unit rate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ownerelectricbillentryconfirmbutton_Click_1(object sender, EventArgs e)
        {
            UpdateDatabase();
        }

        private void ownerelectricbillentrynextbutton_Click_1(object sender, EventArgs e)
        {
            UpdateDatabase();
            MoveToNextFlat();

        }
    }
}
