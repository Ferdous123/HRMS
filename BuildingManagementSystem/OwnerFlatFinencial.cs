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
    public partial class OwnerFlatFinencial : Form
    {
        private string userName;
        private int userId;
        private Dictionary<string, int> flatDesignationToIdMap = new Dictionary<string, int>();

        public OwnerFlatFinencial(string username)
        {
            InitializeComponent();
            this.userName = username;
            this.userId = GetUserIdByUsername(userName);
            PopulateHouseComboBox();
        }

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        private int GetUserIdByUsername(string username)
        {
            int userId = 0;
            string query = "SELECT owner_Id FROM OwnerTable WHERE username = @Username";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Username", username);

                con.Open();
                userId = (int)command.ExecuteScalar();
                con.Close();
            }

            return userId;
        }

        private void PopulateHouseComboBox()
        {
            string query = "SELECT house_id FROM OwnerHouseTable WHERE owner_id = @OwnerId";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@OwnerId", userId);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ownerFlatFinencialsChooseHouseComboBox.Items.Add(reader["house_id"].ToString());
                }
                con.Close();
            }
        }

        private void PopulateFlatComboBox(int houseId)
        {
            string query = "SELECT hf.flat_id, f.flat_designation FROM HouseFlatTable hf JOIN FlatTable f ON hf.flat_id = f.flat_id WHERE hf.house_id = @HouseId";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@HouseId", houseId);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                flatDesignationToIdMap.Clear();
                ownerFlatFinencialsChooseFlatComboBox.Items.Clear();
                while (reader.Read())
                {
                    string flatDesignation = reader["flat_designation"].ToString();
                    int flatId = (int)reader["flat_id"];
                    flatDesignationToIdMap[flatDesignation] = flatId;
                    ownerFlatFinencialsChooseFlatComboBox.Items.Add(flatDesignation);
                }
                con.Close();
            }
        }

        private void PopulateFinancialFields(int flatId)
        {
            string query = "SELECT * FROM FlatFinancialsTable WHERE flat_id = @FlatId";

            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@FlatId", flatId);

                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ownerFlatFinencialsRentTextBox.Text = reader["rent_amount"].ToString();
                    ownerFlatFinencialsServiceChargeTextBox.Text = reader["service_charge"].ToString();
                    ownerFlatFinencialsCleaningChargeTextBox.Text = reader["cleaning_charge"].ToString();
                    ownerFlatFinencialsWaterBillTextBox.Text = reader["water_bill"].ToString();
                    ownerFlatFinencialsGasBillTextBox.Text = reader["postpaid_gas_bill"].ToString();
                    ownerFlatFinencialsMiscellaneousTextBox.Text = reader["miscellaneous"].ToString();
                    ownerFlatFinencialsMeterReadingTextBox.Text = reader["latest_meter_reading"].ToString();
                    ownerFlatFinencialsUnitRateTextBox.Text = reader["electricity_per_unit_rate"].ToString();
                }
                else
                {
                    ownerFlatFinencialsRentTextBox.Text = "No Record Found";
                    ownerFlatFinencialsServiceChargeTextBox.Text = "No Record Found";
                    ownerFlatFinencialsCleaningChargeTextBox.Text = "No Record Found";
                    ownerFlatFinencialsWaterBillTextBox.Text = "No Record Found";
                    ownerFlatFinencialsGasBillTextBox.Text = "No Record Found";
                    ownerFlatFinencialsMiscellaneousTextBox.Text = "No Record Found";
                    ownerFlatFinencialsMeterReadingTextBox.Text = "No Record Found";
                    ownerFlatFinencialsUnitRateTextBox.Text = "No Record Found";
                }
                con.Close();
            }
        }

        private void ownerflatfinencialsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void OwnerFlatFinencial_Load(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsChooseHouseComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int houseId = int.Parse(ownerFlatFinencialsChooseHouseComboBox.SelectedItem.ToString());
            PopulateFlatComboBox(houseId);
        }

        private void ownerFlatFinencialsChooseFlatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFlatDesignation = ownerFlatFinencialsChooseFlatComboBox.SelectedItem.ToString();
            int flatId = flatDesignationToIdMap[selectedFlatDesignation];
            PopulateFinancialFields(flatId);
        }

        private void ownerFlatFinencialsUnitRateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsMeterReadingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsServiceChargeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsRentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsCleaningChargeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsWaterBillTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsGasBillTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ownerFlatFinencialsMiscellaneousTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void manageflatsupdatebutton_Click(object sender, EventArgs e)
        {
            UpdateFinancialFields();
        }

        private void ownerFlatFinencialsNextbutton_Click(object sender, EventArgs e)
        {
            UpdateFinancialFields();
            int currentIndex = ownerFlatFinencialsChooseFlatComboBox.SelectedIndex;
            if (currentIndex < ownerFlatFinencialsChooseFlatComboBox.Items.Count - 1)
            {
                ownerFlatFinencialsChooseFlatComboBox.SelectedIndex = currentIndex + 1;
            }
            else
                MessageBox.Show("No more flats to Update.");
        }

        private void UpdateFinancialFields()
        {
            if (ValidateFields())
            {
                string selectedFlatDesignation = ownerFlatFinencialsChooseFlatComboBox.SelectedItem.ToString();
                int flatId = flatDesignationToIdMap[selectedFlatDesignation];

                string checkQuery = "SELECT COUNT(*) FROM FlatFinancialsTable WHERE flat_id = @FlatId";
                int count = 0;

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, con))
                {
                    checkCommand.Parameters.AddWithValue("@FlatId", flatId);

                    con.Open();
                    count = (int)checkCommand.ExecuteScalar();
                    con.Close();
                }

                if (count > 0)
                {
                    string updateQuery = "UPDATE FlatFinancialsTable SET rent_amount = @RentAmount, service_charge = @ServiceCharge, cleaning_charge = @CleaningCharge, water_bill = @WaterBill, postpaid_gas_bill = @GasBill, miscellaneous = @Miscellaneous, latest_meter_reading = @MeterReading, electricity_per_unit_rate = @UnitRate WHERE flat_id = @FlatId";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                    {
                        updateCommand.Parameters.AddWithValue("@RentAmount", double.Parse(ownerFlatFinencialsRentTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@ServiceCharge", double.Parse(ownerFlatFinencialsServiceChargeTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@CleaningCharge", double.Parse(ownerFlatFinencialsCleaningChargeTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@WaterBill", double.Parse(ownerFlatFinencialsWaterBillTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@GasBill", double.Parse(ownerFlatFinencialsGasBillTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@Miscellaneous", double.Parse(ownerFlatFinencialsMiscellaneousTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@MeterReading", double.Parse(ownerFlatFinencialsMeterReadingTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@UnitRate", double.Parse(ownerFlatFinencialsUnitRateTextBox.Text));
                        updateCommand.Parameters.AddWithValue("@FlatId", flatId);

                        con.Open();
                        updateCommand.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Financial details updated successfully.");
                    }
                }
                else
                {
                    string insertQuery = "INSERT INTO FlatFinancialsTable (rent_amount, service_charge, cleaning_charge, water_bill, postpaid_gas_bill, miscellaneous, latest_meter_reading, electricity_per_unit_rate, flat_id) VALUES (@RentAmount, @ServiceCharge, @CleaningCharge, @WaterBill, @GasBill, @Miscellaneous, @MeterReading, @UnitRate, @FlatId)";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, con))
                    {
                        insertCommand.Parameters.AddWithValue("@RentAmount", double.Parse(ownerFlatFinencialsRentTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@ServiceCharge", double.Parse(ownerFlatFinencialsServiceChargeTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@CleaningCharge", double.Parse(ownerFlatFinencialsCleaningChargeTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@WaterBill", double.Parse(ownerFlatFinencialsWaterBillTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@GasBill", double.Parse(ownerFlatFinencialsGasBillTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@Miscellaneous", double.Parse(ownerFlatFinencialsMiscellaneousTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@MeterReading", double.Parse(ownerFlatFinencialsMeterReadingTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@UnitRate", double.Parse(ownerFlatFinencialsUnitRateTextBox.Text));
                        insertCommand.Parameters.AddWithValue("@FlatId", flatId);

                        con.Open();
                        insertCommand.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Financial details inserted successfully.");
                    }
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(ownerFlatFinencialsRentTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsServiceChargeTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsCleaningChargeTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsWaterBillTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsGasBillTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsMiscellaneousTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsMeterReadingTextBox.Text) ||
                string.IsNullOrWhiteSpace(ownerFlatFinencialsUnitRateTextBox.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (!double.TryParse(ownerFlatFinencialsRentTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsServiceChargeTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsCleaningChargeTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsWaterBillTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsGasBillTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsMiscellaneousTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsMeterReadingTextBox.Text, out _) ||
                !double.TryParse(ownerFlatFinencialsUnitRateTextBox.Text, out _))
            {
                MessageBox.Show("Please enter valid numeric values.");
                return false;
            }

            return true;
        }
    }
}
