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
    public partial class ManagerNotice : Form
    {
        private string userName;
        private int managerId;
        private SqlConnection con;
        private Dictionary<int, string> houseDictionary;
        private Dictionary<int, string> flatDictionary;
        private Dictionary<int, string> tenantDictionary;

        public ManagerNotice(string username)
        {
            InitializeComponent();
            this.userName = username;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
            FetchManagerId();
            PopulateHouseComboBox();
            PopulateNoticeGrid();
        }

        private void FetchManagerId()
        {
            string query = "SELECT manager_Id FROM ManagerTable WHERE username = @username";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                con.Open();
                managerId = (int)cmd.ExecuteScalar();
                con.Close();
            }
        }

        private void PopulateHouseComboBox()
        {
            houseDictionary = new Dictionary<int, string>();
            string query = @"
                SELECT h.house_Id, h.house_num 
                FROM HouseTable h
                INNER JOIN ManagerHouseTable mh ON h.house_Id = mh.house_id
                WHERE mh.manager_id = @managerId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@managerId", managerId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int houseId = reader.GetInt32(0);
                        string houseNum = reader.GetString(1);
                        houseDictionary.Add(houseId, houseNum);
                        managernoticehousenumbercombobox.Items.Add(houseNum);
                    }
                }
                con.Close();
            }
        }

        private void managernoticehousenumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managernoticehousenumbercombobox.SelectedItem != null)
            {
                int selectedHouseId = GetSelectedHouseId();
                PopulateFlatComboBox(selectedHouseId);
            }
        }

        private int GetSelectedHouseId()
        {
            string selectedHouseNum = managernoticehousenumbercombobox.SelectedItem.ToString();
            foreach (var pair in houseDictionary)
            {
                if (pair.Value == selectedHouseNum)
                {
                    return pair.Key;
                }
            }
            return -1;
        }

        private void PopulateFlatComboBox(int houseId)
        {
            flatDictionary = new Dictionary<int, string>();
            string query = @"
                SELECT f.flat_Id, f.flat_designation 
                FROM FlatTable f
                INNER JOIN HouseFlatTable hf ON f.flat_Id = hf.flat_id
                WHERE hf.house_id = @houseId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@houseId", houseId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int flatId = reader.GetInt32(0);
                        string flatDesignation = reader.GetString(1);
                        flatDictionary.Add(flatId, flatDesignation);
                        managernoticeflatnumbercombobox.Items.Add(flatDesignation);
                    }
                }
                con.Close();
            }
        }

        private void managernoticeflatnumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (managernoticeflatnumbercombobox.SelectedItem != null)
            {
                int selectedFlatId = GetSelectedFlatId();
                PopulateReceiverComboBox(selectedFlatId);
            }
        }

        private int GetSelectedFlatId()
        {
            string selectedFlatDesignation = managernoticeflatnumbercombobox.SelectedItem.ToString();
            foreach (var pair in flatDictionary)
            {
                if (pair.Value == selectedFlatDesignation)
                {
                    return pair.Key;
                }
            }
            return -1;
        }

        private void PopulateReceiverComboBox(int flatId)
        {
            tenantDictionary = new Dictionary<int, string>();
            string query = @"
                SELECT t.tenant_Id, t.name 
                FROM TenantTable t
                INNER JOIN FlatOccupationTable fo ON t.tenant_Id = fo.tenant_id
                WHERE fo.flat_id = @flatId AND fo.move_out_date IS NULL";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@flatId", flatId);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int tenantId = reader.GetInt32(0);
                        string tenantName = reader.GetString(1);
                        tenantDictionary.Add(tenantId, tenantName);
                        managernoticechoosesendercombobox.Items.Add(tenantName);
                    }
                }
                con.Close();
            }
        }

        private void managernoticesendbutton_Click(object sender, EventArgs e)
        {
            if (managernoticechoosesendercombobox.SelectedItem == null || string.IsNullOrWhiteSpace(managernoticechoosesendercombobox.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a tenant to send the notice to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(managernoticemultilinetextbox.Text))
            {
                MessageBox.Show("Please enter a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedTenantName = managernoticechoosesendercombobox.SelectedItem.ToString();
            int tenantId = GetSelectedTenantId(selectedTenantName);
            string messageText = managernoticemultilinetextbox.Text;
            DateTime currentTime = DateTime.Now;
            string readStatus = "Unread";
            string priority = "Normal";

            string insertQuery = @"
                INSERT INTO NoticeTable (sent_by, sent_by_user_type, sent_to, sent_to_user_type, message_text, time, read_status, priority)
                VALUES (@sent_by, @sent_by_user_type, @sent_to, @sent_to_user_type, @message_text, @time_sent, @read_status, @priority)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@sent_by", managerId);
                cmd.Parameters.AddWithValue("@sent_by_user_type", "Manager");
                cmd.Parameters.AddWithValue("@sent_to", tenantId);
                cmd.Parameters.AddWithValue("@sent_to_user_type", "Tenant");
                cmd.Parameters.AddWithValue("@message_text", messageText);
                cmd.Parameters.AddWithValue("@time_sent", currentTime);
                cmd.Parameters.AddWithValue("@read_status", readStatus);
                cmd.Parameters.AddWithValue("@priority", priority);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Notice sent successfully!");
            PopulateNoticeGrid(); // Refresh the grid after sending a notice
        }

        private int GetSelectedTenantId(string tenantName)
        {
            foreach (var pair in tenantDictionary)
            {
                if (pair.Value == tenantName)
                {
                    return pair.Key;
                }
            }
            return -1;
        }

        private void managernoticemultilinetextbox_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 495;
            if (managernoticemultilinetextbox.Text.Length > maxLength)
            {
                MessageBox.Show("The message cannot exceed 495 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                managernoticemultilinetextbox.Text = managernoticemultilinetextbox.Text.Substring(0, maxLength);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event if needed
        }

        private void managernoticebbackbutton_Click(object sender, EventArgs e)
        {
            ManagerDashBoard managerDashBoard = new ManagerDashBoard(userName);
            managerDashBoard.Show();
            this.Hide();
        }

        private void ManagerNotice_Load(object sender, EventArgs e)
        {
            PopulateNoticeGrid();
        }


        private void PopulateNoticeGrid()
        {
            string query = @"
        SELECT * 
        FROM NoticeTable 
        WHERE sent_by = @managerId 
        OR (sent_to = @managerId AND sent_to_user_type = 'Manager')";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@managerId", managerId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }


        private void managernoticechoosesendercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle sender combo box selection change if needed
        }
    }
}
