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
    public partial class ManagerOccupationHistory : Form
    {
        private string userName;
        private string connectionString = "your_connection_string_here"; // Update with your actual connection string

        public ManagerOccupationHistory(string username)
        {
            InitializeComponent();
            this.userName = username;
            LoadManagerHouseTable();
        }

        private void managerprofileoccupationhistorybackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void ManagerOccupationHistory_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadManagerHouseTable()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                string query = "SELECT manager_id, house_id, start_date, end_date FROM ManagerHouseTable";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
