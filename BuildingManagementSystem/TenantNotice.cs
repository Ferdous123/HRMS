using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class TenantNotice : Form
    {
        private string userName;
        private int tenantId;
        private int houseId;

        public TenantNotice(string username)
        {
            InitializeComponent();
            this.userName = username;
            LoadTenantDetails();
            PopulateSenderComboBox();
            PopulateNoticeGrid();
        }

        private void LoadTenantDetails()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                // Get tenant ID
                using (SqlCommand command = new SqlCommand("SELECT tenant_id FROM TenantTable WHERE username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", userName);
                    tenantId = (int)command.ExecuteScalar();
                }

                // Get house ID
                using (SqlCommand command = new SqlCommand("SELECT house_id FROM FlatOccupationTable WHERE tenant_id = @tenantId", connection))
                {
                    command.Parameters.AddWithValue("@tenantId", tenantId);
                    houseId = (int)command.ExecuteScalar();
                }
            }
        }

        private void PopulateSenderComboBox()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                connection.Open();
                List<string> senders = new List<string>();

                // Get owners
                using (SqlCommand command = new SqlCommand("SELECT username FROM OwnerTable INNER JOIN OwnerHouseTable ON OwnerTable.owner_id = OwnerHouseTable.owner_id WHERE house_id = @houseId", connection))
                {
                    command.Parameters.AddWithValue("@houseId", houseId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            senders.Add(reader.GetString(0));
                        }
                    }
                }

                // Get managers
                using (SqlCommand command = new SqlCommand("SELECT username FROM ManagerTable INNER JOIN ManagerHouseTable ON ManagerTable.manager_id = ManagerHouseTable.manager_id WHERE house_id = @houseId", connection))
                {
                    command.Parameters.AddWithValue("@houseId", houseId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            senders.Add(reader.GetString(0));
                        }
                    }
                }

                tenantnoticechoosesendercombobox.DataSource = senders;
            }
        }

        private void PopulateNoticeGrid()
        {
            string query = @"
            SELECT * 
            FROM NoticeTable 
            WHERE sent_by = @tenantId OR sent_to = @tenantId";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void tenantnoticebbackbutton_Click(object sender, EventArgs e)
        {
            TenantDashBoard dashboard = new TenantDashBoard(userName);
            dashboard.Show();
            this.Hide();
        }

        private void TenantNotice_Load(object sender, EventArgs e)
        {

        }

        private void tenantnoticechoosesendercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tenantnoticemultilinetextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tenantnoticesendbutton_Click(object sender, EventArgs e)
        {
            if (tenantnoticechoosesendercombobox.SelectedItem == null || string.IsNullOrWhiteSpace(tenantnoticechoosesendercombobox.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a user to send the notice to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenantnoticemultilinetextbox.Text))
            {
                MessageBox.Show("Please enter a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedUser = tenantnoticechoosesendercombobox.SelectedItem.ToString();
            string messageText = tenantnoticemultilinetextbox.Text;
            DateTime currentTime = DateTime.Now;
            int sentToId = 0;
            string sentToUserType = "";
            string readStatus = "Unread"; // Default read status
            string priority = "Normal"; // Default priority

            // Determine the user type and fetch the corresponding ID for the selected user
            string fetchIdQuery = @"
    SELECT tenant_Id AS id, 'Tenant' AS userType FROM TenantTable WHERE username = @username
    UNION
    SELECT manager_Id AS id, 'Manager' AS userType FROM ManagerTable WHERE username = @username
    UNION
    SELECT owner_Id AS id, 'Owner' AS userType FROM OwnerTable WHERE username = @username";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(fetchIdQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", selectedUser);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sentToId = Convert.ToInt32(reader["id"]);
                            sentToUserType = reader["userType"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(sentToUserType))
            {
                MessageBox.Show("Invalid user selected. Please select a valid user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Insert the notice into the NoticeTable
            string insertQuery = @"
    INSERT INTO NoticeTable (sent_by, sent_by_user_type, sent_to, sent_to_user_type, message_text, time, read_status, priority)
    VALUES (@sent_by, @sent_by_user_type, @sent_to, @sent_to_user_type, @message_text, @time_sent, @read_status, @priority)";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@sent_by", tenantId);
                    cmd.Parameters.AddWithValue("@sent_by_user_type", "Tenant");
                    cmd.Parameters.AddWithValue("@sent_to", sentToId);
                    cmd.Parameters.AddWithValue("@sent_to_user_type", sentToUserType);
                    cmd.Parameters.AddWithValue("@message_text", messageText);
                    cmd.Parameters.AddWithValue("@time_sent", currentTime);
                    cmd.Parameters.AddWithValue("@read_status", readStatus);
                    cmd.Parameters.AddWithValue("@priority", priority);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Notice sent successfully!");
            PopulateNoticeGrid(); // Refresh the grid after sending a notice
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
