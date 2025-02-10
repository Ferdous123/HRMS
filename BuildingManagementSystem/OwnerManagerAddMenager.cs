using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerManagerAddMenager : Form
    {
        private string userName;
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
        private Dictionary<string, int> houseDictionary = new Dictionary<string, int>();

        public OwnerManagerAddMenager(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void OwnerManagerAddMenager_Load(object sender, EventArgs e)
        {
            PopulateHouseComboBox(userName);
        }

        private void PopulateHouseComboBox(string username)
        {
            string query = @"
                SELECT h.house_Id, h.house_num
                FROM OwnerHouseTable oh
                JOIN OwnerTable o ON oh.owner_id = o.owner_Id
                JOIN HouseTable h ON oh.house_id = h.house_Id
                WHERE o.username = @username";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        addmanagerhousenumbercombobox.Items.Clear();
                        houseDictionary.Clear();
                        while (reader.Read())
                        {
                            string houseNum = reader["house_num"].ToString();
                            int houseId = (int)reader["house_Id"];
                            addmanagerhousenumbercombobox.Items.Add(houseNum);
                            houseDictionary[houseNum] = houseId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void ownermanageraddmanagerbackbutton_Click(object sender, EventArgs e)
        {
            OwnerManager ownerManager = new OwnerManager(userName);
            ownerManager.Show();
            this.Hide();
        }

        private void addmanagerusernametextbbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addmanagerhousenumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ownermanageraddmanagerconfirmbutton_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(addmanagerusernametextbbox.Text))
            {
                MessageBox.Show("Please enter the manager's username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (addmanagerhousenumbercombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a house number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string managerUsername = addmanagerusernametextbbox.Text;
            string selectedHouseNum = addmanagerhousenumbercombobox.SelectedItem.ToString();
            int selectedHouseId = houseDictionary[selectedHouseNum];
            DateTime startDate = DateTime.Today;

            // Get manager ID from ManagerTable using manager's username
            int managerId = GetManagerIdByUsername(managerUsername);
            if (managerId == -1)
            {
                MessageBox.Show("Manager not found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert into ManagerHouseTable
            string query = @"
        INSERT INTO ManagerHouseTable (manager_id, house_id, start_date)
        VALUES (@manager_id, @house_id, @start_date)";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@manager_id", managerId);
                    cmd.Parameters.AddWithValue("@house_id", selectedHouseId);
                    cmd.Parameters.AddWithValue("@start_date", startDate);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Manager has been assigned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private int GetManagerIdByUsername(string username)
        {
            string query = "SELECT manager_Id FROM ManagerTable WHERE username = @username";
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return -1;

        }
    }
}

