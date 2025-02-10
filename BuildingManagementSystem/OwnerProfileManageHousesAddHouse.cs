using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BuildingManagementSystem
{
    public partial class OwnerProfileManageHousesAddHouse : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerProfileManageHousesAddHouse(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void addhousebackbutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageHouses ownerProfileManageHouses = new OwnerProfileManageHouses(userName);
            ownerProfileManageHouses.Show();
            this.Hide();
        }

        private void addhouseconfirmbutton_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            try
            {
                if (addhousehousenumbertextbox.Text == "" || addhouseaddresstextbox.Text == "" || addhouseflatcounttextbox.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!int.TryParse(addhouseflatcounttextbox.Text, out int n))
                {
                    MessageBox.Show("Flat count must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con.Open();
                transaction = con.BeginTransaction();

                // Check if the house number and address combination already exists
                string checkQuery = "SELECT COUNT(*) FROM HouseTable WHERE house_num = @houseNumber AND address = @address";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@houseNumber", addhousehousenumbertextbox.Text);
                    checkCmd.Parameters.AddWithValue("@address", addhouseaddresstextbox.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("House with this number and address already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }

                // Insert into HouseTable
                string query = @"INSERT INTO HouseTable (house_num, address, flat_count, lift, area) VALUES (@houseNumber, @address, @flatCount, @lift, @area);
                         SELECT SCOPE_IDENTITY();";
                int newHouseId;
                using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@houseNumber", addhousehousenumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@address", addhouseaddresstextbox.Text);
                    cmd.Parameters.AddWithValue("@flatCount", addhouseflatcounttextbox.Text);
                    cmd.Parameters.AddWithValue("@lift", addhouseliftcombobox.Text);
                    cmd.Parameters.AddWithValue("@area", addhouseareacombobox.Text);
                    newHouseId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // Get the owner_Id
                string query1 = @"SELECT owner_Id FROM OwnerTable WHERE username = @username";
                int owner_Id;
                using (SqlCommand cmd1 = new SqlCommand(query1, con, transaction))
                {
                    cmd1.Parameters.AddWithValue("@username", userName);
                    owner_Id = (int)cmd1.ExecuteScalar();
                }

                // Insert into OwnerHouseTable
                string query3 = @"INSERT INTO OwnerHouseTable (owner_id, house_id) VALUES (@owner_id, @house_id)";
                using (SqlCommand cmd3 = new SqlCommand(query3, con, transaction))
                {
                    cmd3.Parameters.AddWithValue("@owner_id", owner_Id);
                    cmd3.Parameters.AddWithValue("@house_id", newHouseId);
                    cmd3.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("House added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                if (ex.Number == 2627 || ex.Number == 2601) // Primary Key or Unique Constraint Violation
                {
                    MessageBox.Show("House already exists. If you want to modify house details, go to Manage Houses.",
                                    "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    transaction.Rollback();
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaction.Rollback();
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void OwnerProfileManageHousesAddHouse_Load(object sender, EventArgs e)
        {

        }
    }
}
