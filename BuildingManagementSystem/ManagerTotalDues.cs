using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class ManagerTotalDues : Form
    {
        private string userName;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public ManagerTotalDues(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void managertotalduesbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void ManagerTotalDues_Load(object sender, EventArgs e)
        {
            LoadTotalDues();
            AddSendNoticeButtonColumn();
        }

        private void LoadTotalDues()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get manager ID from username
                    int managerId = GetManagerId(connection, userName);

                    // Get house ID from manager ID
                    int houseId = GetHouseId(connection, managerId);

                    // Get flat ID from house ID
                    int flatId = GetFlatId(connection, houseId);

                    // Get tenant ID from flat ID
                    int tenantId = GetTenantId(connection, flatId);

                    // Get dues from tenant ID
                    DataTable duesTable = GetTenantDues(connection, tenantId);

                    // Bind the data to the DataGridView
                    dataGridView1.DataSource = duesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private int GetManagerId(SqlConnection connection, string username)
        {
            using (SqlCommand command = new SqlCommand("SELECT manager_Id FROM ManagerTable WHERE username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                return (int)command.ExecuteScalar();
            }
        }

        private int GetHouseId(SqlConnection connection, int managerId)
        {
            using (SqlCommand command = new SqlCommand("SELECT house_id FROM ManagerHouseTable WHERE manager_id = @managerId", connection))
            {
                command.Parameters.AddWithValue("@managerId", managerId);
                return (int)command.ExecuteScalar();
            }
        }

        private int GetFlatId(SqlConnection connection, int houseId)
        {
            using (SqlCommand command = new SqlCommand("SELECT flat_id FROM HouseFlatTable WHERE house_id = @houseId", connection))
            {
                command.Parameters.AddWithValue("@houseId", houseId);
                return (int)command.ExecuteScalar();
            }
        }

        private int GetTenantId(SqlConnection connection, int flatId)
        {
            using (SqlCommand command = new SqlCommand("SELECT tenant_id FROM FlatOccupationTable WHERE flat_id = @flatId", connection))
            {
                command.Parameters.AddWithValue("@flatId", flatId);
                return (int)command.ExecuteScalar();
            }
        }

        private DataTable GetTenantDues(SqlConnection connection, int tenantId)
        {
            string query = @"
                SELECT 
                    t.tenant_Id AS TenantId,
                    t.name AS TenantName, 
                    f.flat_designation AS FlatDesignation, 
                    h.house_num AS HouseNumber, 
                    td.due AS DueAmount
                FROM 
                    TenantDueTable td
                JOIN 
                    TenantTable t ON td.tenant_Id = t.tenant_Id
                JOIN 
                    FlatTable f ON td.flat_id = f.flat_Id
                JOIN 
                    HouseFlatTable hf ON f.flat_Id = hf.flat_id
                JOIN 
                    HouseTable h ON hf.house_id = h.house_Id
                WHERE 
                    td.tenant_Id = @tenantId";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tenantId", tenantId);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable duesTable = new DataTable();
                    adapter.Fill(duesTable);
                    return duesTable;
                }
            }
        }

        private void AddSendNoticeButtonColumn()
        {
            DataGridViewButtonColumn sendNoticeButtonColumn = new DataGridViewButtonColumn();
            sendNoticeButtonColumn.Name = "SendNotice";
            sendNoticeButtonColumn.HeaderText = "Send Notice";
            sendNoticeButtonColumn.Text = "Send Notice";
            sendNoticeButtonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(sendNoticeButtonColumn);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["SendNotice"].Index && e.RowIndex >= 0)
            {
                ManagerNotice notice = new ManagerNotice(userName);
                notice.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
