using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class ManagerEmptyFlats : Form
    {
        private string userName;
        private Dictionary<int, string> houseDictionary = new Dictionary<int, string>();
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public ManagerEmptyFlats(string username)
        {
            InitializeComponent();
            this.userName = username;
            PopulateHouseComboBox();
        }

        private void manageremptyflatstsbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void ManagerEmptyFlats_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manageremptyflatschoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedHouseNum = manageremptyflatschoosehousecombobox.SelectedItem.ToString();
            int houseId = houseDictionary.FirstOrDefault(x => x.Value == selectedHouseNum).Key;
            PopulateFlatsGridView(houseId);
        }

        private void PopulateHouseComboBox()
        {
            int managerId = GetManagerId(userName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT h.house_id, h.house_num FROM ManagerHouseTable mht " +
                               "JOIN HouseTable h ON mht.house_id = h.house_Id " +
                               "WHERE mht.manager_id = @managerId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@managerId", managerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int houseId = reader.GetInt32(0);
                    string houseNum = reader.GetString(1);
                    houseDictionary[houseId] = houseNum;
                    manageremptyflatschoosehousecombobox.Items.Add(houseNum);
                }
            }
        }

        private int GetManagerId(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT manager_Id FROM ManagerTable WHERE username = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        private void PopulateFlatsGridView(int houseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT f.* FROM FlatTable f " +
                               "JOIN HouseFlatTable hft ON f.flat_Id = hft.flat_id " +
                               "WHERE hft.house_id = @houseId AND f.availability_status = 'empty'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@houseId", houseId);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable flatsTable = new DataTable();
                adapter.Fill(flatsTable);
                dataGridView1.DataSource = flatsTable;
            }
        }
    }
}
