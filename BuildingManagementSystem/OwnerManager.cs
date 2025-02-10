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
    public partial class OwnerManager : Form
    {

        private string userName;
        private SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerManager(string username)
        {
            InitializeComponent();
            this.userName = username;
            PopulateHouseComboBox(userName);
        }

        private void OwnerManager_Load(object sender, EventArgs e)
        {
        }

        private void PopulateHouseComboBox(string username)
        {
            string query = @"
                SELECT oh.house_id
                FROM OwnerHouseTable oh
                JOIN OwnerTable o ON oh.owner_id = o.owner_Id
                WHERE o.username = @username";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ownermanagerchoosehousecombobox.Items.Clear();
                        while (reader.Read())
                        {
                            ownermanagerchoosehousecombobox.Items.Add(reader["house_id"].ToString());
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

        private void DisplayManagerInfo()
        {
            if (ownermanagerchoosehousecombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a house.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedStatus = ownermanagerstatuscombobox.SelectedItem.ToString();
            DateTime today = DateTime.Today;
            int selectedHouseId = int.Parse(ownermanagerchoosehousecombobox.SelectedItem.ToString());
            string query = @"
        SELECT m.name, m.phone, mh.start_date, mh.end_date
        FROM ManagerHouseTable mh
        JOIN ManagerTable m ON mh.manager_id = m.manager_Id
        WHERE mh.house_id = @house_id";

            if (selectedStatus == "Active Managers")
            {
                query += " AND mh.start_date<=@today AND (mh.end_date >= @today OR mh.end_date IS NULL)";
            }
            else if (selectedStatus == "Past Managers")
            {
                query += " AND mh.end_date < @today";
            }

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", selectedHouseId);
                    cmd.Parameters.AddWithValue("@today", today);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        managerDataGridView.DataSource = dataTable;
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


        private void ownermanagerstatuscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayManagerInfo();
        }

        private void ownermanagerchoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ownermanagerbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void ownermanageraddmanagerbutton_Click(object sender, EventArgs e)
        {
            OwnerManagerAddMenager ownerManagerAddMenager = new OwnerManagerAddMenager(userName);
            ownerManagerAddMenager.Show();
            this.Hide();
        }























        

        

        private void managerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
