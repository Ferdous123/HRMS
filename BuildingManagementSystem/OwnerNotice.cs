using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerNotice : Form
    {
        private string userName;
        private string receiver;
        private SqlConnection con;
        private int userId;
        private string userType;

        public OwnerNotice(string sender, string receiver)
        {
            InitializeComponent();
            userName = sender;
            this.receiver = receiver;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
            PopulateReceiverComboBox();
            PopulateHouseAndFlatComboBoxes(receiver);
            FetchCurrentUserDetails();
            PopulateNoticeGrid();
        }

        public OwnerNotice(string sender)
        {
            InitializeComponent();
            userName = sender;
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
            InitializeForSender();
            FetchCurrentUserDetails();
            PopulateNoticeGrid();
        }


        private void FetchCurrentUserDetails()
        {
            string query = @"
    SELECT tenant_Id AS id, 'Tenant' AS userType FROM TenantTable WHERE username = @username
    UNION
    SELECT manager_Id AS id, 'Manager' AS userType FROM ManagerTable WHERE username = @username
    UNION
    SELECT owner_Id AS id, 'Owner' AS userType FROM OwnerTable WHERE username = @username";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = Convert.ToInt32(reader["id"]);
                            userType = reader["userType"].ToString();
                        }
                    }
                }
            }
        }


        private void InitializeForSender()
        {
            PopulateSenderComboBox();
            PopulateHouseNumberComboBox();
            PopulateHouseAndFlatComboBoxes(userName);
        }

        private void PopulateReceiverComboBox()
        {
            ownernoticechoosesendercombobox.Items.Clear();
            try
            {
                con.Open();
                string query = "SELECT name FROM TenantTable WHERE tenant_Id = @tenant_id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tenant_id", receiver);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ownernoticechoosesendercombobox.Items.Add(reader["name"].ToString());
                        ownernoticechoosesendercombobox.SelectedIndex = 0;
                        ownernoticechoosesendercombobox.Items.Add("Others");
                    }
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void PopulateHouseAndFlatComboBoxes(string identifier)
        {
            try
            {
                con.Open();
                int tenantId;
                if (!int.TryParse(identifier, out tenantId))
                {
                    return;
                }
                string query = @"
            SELECT 
                ht.house_num, 
                ft.flat_designation 
            FROM 
                FlatOccupationTable fot
            JOIN 
                HouseTable ht ON fot.house_id = ht.house_Id
            JOIN 
                FlatTable ft ON fot.flat_id = ft.flat_Id
            WHERE 
                fot.tenant_id = @tenantId OR fot.tenant_id IN (SELECT tenant_id FROM TenantTable WHERE username = @identifier)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    cmd.Parameters.AddWithValue("@identifier", identifier);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ownernoticehousenumbercombobox.Items.Add(reader["house_num"].ToString());
                        ownernoticeflatnumbercombobox.Items.Add(reader["flat_designation"].ToString());
                    }
                    if (ownernoticehousenumbercombobox.Items.Count > 0) ownernoticehousenumbercombobox.SelectedIndex = 0;
                    if (ownernoticeflatnumbercombobox.Items.Count > 0) ownernoticeflatnumbercombobox.SelectedIndex = 0;
                }
            }
            finally
            {
                con.Close();
            }
        }


        private void ownernoticebbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void OwnerNotice_Load(object sender, EventArgs e)
        {

        }

        private void PopulateSenderComboBox()
        {
            ownernoticechoosesendercombobox.Items.Clear();
            ownernoticechoosesendercombobox.Items.Add("All");
            ownernoticechoosesendercombobox.Items.Add("All Manager");
            ownernoticechoosesendercombobox.Items.Add("All Owner");
            ownernoticechoosesendercombobox.Items.Add("All Tenants");

            string query = @"
            SELECT name 
            FROM (
                SELECT name FROM TenantTable
                UNION
                SELECT name FROM ManagerTable
            ) AS Users";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ownernoticechoosesendercombobox.Items.Add(reader["name"].ToString());
                    }
                }
            }
        }


        private void PopulateHouseNumberComboBox()
        {
            string query = @"
            SELECT h.house_num 
            FROM HouseTable h
            INNER JOIN OwnerHouseTable oh ON h.house_id = oh.house_id
            INNER JOIN OwnerTable o ON oh.owner_id = o.owner_id
            WHERE o.username = @username";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ownernoticehousenumbercombobox.Items.Clear();
                    while (reader.Read())
                    {
                        ownernoticehousenumbercombobox.Items.Add(reader["house_num"].ToString());
                    }
                    if (ownernoticehousenumbercombobox.Items.Count > 0)
                    {
                        ownernoticehousenumbercombobox.SelectedIndex = 0;
                    }
                }
            }
        }



        private void ownernoticehousenumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ownernoticeflatnumbercombobox.Items.Clear();
            PopulateFlatNumberComboBox();
        }


        private void PopulateFlatNumberComboBox()
        {
            if (ownernoticehousenumbercombobox.SelectedItem != null)
            {
                string selectedHouseNum = ownernoticehousenumbercombobox.SelectedItem.ToString();
                string fetchHouseIdQuery = @"
                SELECT h.house_Id 
                FROM HouseTable h
                INNER JOIN OwnerHouseTable oh ON h.house_Id = oh.house_id
                INNER JOIN OwnerTable o ON oh.owner_id = o.owner_Id
                WHERE h.house_num = @house_num AND o.username = @username";

                int house_id = 0;

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(fetchHouseIdQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@house_num", selectedHouseNum);
                        cmd.Parameters.AddWithValue("@username", userName);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            house_id = Convert.ToInt32(reader["house_id"]);
                        }
                    }
                }

                if (house_id > 0)
                {
                    string query = @"
            SELECT f.flat_designation 
            FROM FlatTable f
            INNER JOIN HouseFlatTable hf ON f.flat_Id = hf.flat_id
            WHERE hf.house_id = @house_id";

                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@house_id", house_id);
                            SqlDataReader reader = cmd.ExecuteReader();
                            ownernoticeflatnumbercombobox.Items.Clear();
                            while (reader.Read())
                            {
                                ownernoticeflatnumbercombobox.Items.Add(reader["flat_designation"].ToString());
                            }
                            if (ownernoticeflatnumbercombobox.Items.Count > 0)
                            {
                                ownernoticeflatnumbercombobox.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
        }




        private void PopulateSenderComboBox(int flat_id, int house_id)
        {
            ownernoticechoosesendercombobox.Items.Clear();
            ownernoticechoosesendercombobox.Items.Add("All");
            ownernoticechoosesendercombobox.Items.Add("All Owner");
            ownernoticechoosesendercombobox.Items.Add("All Tenants");

            string tenantQuery = @"
            SELECT t.name 
            FROM TenantTable t
            INNER JOIN FlatOccupationTable fo ON t.tenant_id = fo.tenant_id
            WHERE fo.flat_id = @flat_id AND fo.move_out_date IS NULL";

            string managerQuery = @"
            SELECT m.name 
            FROM ManagerTable m
            INNER JOIN ManagerHouseTable mh ON m.manager_Id = mh.manager_id
            WHERE mh.house_id = @house_id AND mh.end_date IS NULL";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand tenantCmd = new SqlCommand(tenantQuery, con))
                {
                    tenantCmd.Parameters.AddWithValue("@flat_id", flat_id);
                    using (SqlDataReader reader = tenantCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ownernoticechoosesendercombobox.Items.Add(reader["name"].ToString());
                        }
                    }
                }

                using (SqlCommand managerCmd = new SqlCommand(managerQuery, con))
                {
                    managerCmd.Parameters.AddWithValue("@house_id", house_id);
                    using (SqlDataReader reader = managerCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ownernoticechoosesendercombobox.Items.Add(reader["name"].ToString());
                        }
                    }
                }
            }
        }



        private void ownernoticeflatnumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownernoticeflatnumbercombobox.SelectedItem != null && ownernoticehousenumbercombobox.SelectedItem != null)
            {
                string selectedFlatDesignation = ownernoticeflatnumbercombobox.SelectedItem.ToString();
                string selectedHouseNum = ownernoticehousenumbercombobox.SelectedItem.ToString();

                int flat_id = 0;
                int house_id = 0;

                // Fetch house_id based on selected house number and username
                string fetchHouseIdQuery = @"
                SELECT h.house_Id 
                FROM HouseTable h
                INNER JOIN OwnerHouseTable oh ON h.house_Id = oh.house_id
                INNER JOIN OwnerTable o ON oh.owner_id = o.owner_Id
                WHERE h.house_num = @house_num AND o.username = @username";

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(fetchHouseIdQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@house_num", selectedHouseNum);
                        cmd.Parameters.AddWithValue("@username", userName);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            house_id = Convert.ToInt32(reader["house_Id"]);
                        }
                    }
                }

                // Fetch flat_id based on selected flat designation and house_id
                if (house_id > 0)
                {
                    string fetchFlatIdQuery = @"
                    SELECT f.flat_Id 
                    FROM FlatTable f
                    INNER JOIN HouseFlatTable hf ON f.flat_Id = hf.flat_id
                    WHERE f.flat_designation = @flat_designation AND hf.house_id = @house_id";

                    using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(fetchFlatIdQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@flat_designation", selectedFlatDesignation);
                            cmd.Parameters.AddWithValue("@house_id", house_id);
                            SqlDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                flat_id = Convert.ToInt32(reader["flat_Id"]);
                            }
                        }
                    }
                }

                if (flat_id > 0 && house_id > 0)
                {
                    PopulateSenderComboBox(flat_id, house_id);
                }
                else
                {
                    MessageBox.Show("Invalid flat or house number selected.");
                }
            }
        }




        private void ownernoticechoosesendercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownernoticechoosesendercombobox.SelectedItem != null && ownernoticechoosesendercombobox.SelectedItem.ToString() == "Others")
            {
                ownernoticeflatnumbercombobox.Items.Clear();
                ownernoticeflatnumbercombobox.Items.Add("");
                ownernoticehousenumbercombobox.Items.Clear();
                ownernoticehousenumbercombobox.Items.Add("");
                InitializeForSender();
            }
        }

        private void ownernoticesendbutton_Click(object sender, EventArgs e)
        {
            if (ownernoticechoosesendercombobox.SelectedItem == null || string.IsNullOrWhiteSpace(ownernoticechoosesendercombobox.SelectedItem.ToString()))
            {
                MessageBox.Show("Please select a user to send the notice to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(ownernoticemultilinetextbox.Text))
            {
                MessageBox.Show("Please enter a message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedUser = ownernoticechoosesendercombobox.SelectedItem.ToString();
            string messageText = ownernoticemultilinetextbox.Text;
            DateTime currentTime = DateTime.Now;
            int sentToId = 0;
            int senderId = 0;
            string senderUserType = "";
            string sentToUserType = "";
            string readStatus = "Unread"; // Default read status
            string priority = "Normal"; // Default priority

            // Determine the user type and fetch the corresponding ID for the sender
            string fetchSenderIdQuery = @"
    SELECT tenant_Id AS id, 'Tenant' AS userType FROM TenantTable WHERE username = @username
    UNION
    SELECT manager_Id AS id, 'Manager' AS userType FROM ManagerTable WHERE username = @username
    UNION
    SELECT owner_Id AS id, 'Owner' AS userType FROM OwnerTable WHERE username = @username";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(fetchSenderIdQuery, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            senderId = Convert.ToInt32(reader["id"]);
                            senderUserType = reader["userType"].ToString();
                        }
                    }
                }
            }

            // Determine the user type and fetch the corresponding ID for the selected user
            string fetchIdQuery = @"
    SELECT tenant_Id AS id, 'Tenant' AS userType FROM TenantTable WHERE name = @name
    UNION
    SELECT manager_Id AS id, 'Manager' AS userType FROM ManagerTable WHERE name = @name
    UNION
    SELECT owner_Id AS id, 'Owner' AS userType FROM OwnerTable WHERE name = @name";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(fetchIdQuery, con))
                {
                    cmd.Parameters.AddWithValue("@name", selectedUser);
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
                    cmd.Parameters.AddWithValue("@sent_by", senderId);
                    cmd.Parameters.AddWithValue("@sent_by_user_type", senderUserType);
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
        }




        private void ownernoticemultilinetextbox_TextChanged(object sender, EventArgs e)
        {
            const int maxLength = 495;
            if (ownernoticemultilinetextbox.Text.Length > maxLength)
            {
                MessageBox.Show("The message cannot exceed 495 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ownernoticemultilinetextbox.Text = ownernoticemultilinetextbox.Text.Substring(0, maxLength);
            }
        }

        private void noticeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PopulateNoticeGrid()
        {
            string query = @"
            SELECT * 
            FROM NoticeTable 
            WHERE (sent_by = @userId AND sent_by_user_type = @userType) 
               OR (sent_to = @userId AND sent_to_user_type = @userType)";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@userType", userType);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    noticeDataGridView.DataSource = dataTable;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
