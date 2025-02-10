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
    public partial class OwnerProfileManageHouses : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerProfileManageHouses(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void managehousesaddhousebutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageHousesAddHouse ownerProfileManageHousesAddHouse = new OwnerProfileManageHousesAddHouse(userName);
            ownerProfileManageHousesAddHouse.Show();
            this.Hide();
        }

        private void managehousesbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void OwnerProfileManageHouses_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT house_id FROM OwnerHouseTable WHERE owner_id = (SELECT owner_Id FROM OwnerTable WHERE username = @username)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int house_Id = Convert.ToInt32(reader["house_id"]);
                    ownerprofilemanagehousehouseidcombobox.Items.Add(house_Id);
                }
            }
            con.Close();
        }

        private void ownerprofilemanagehousehouseidcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ownerprofilemanagehousehouseidcombobox.SelectedItem != null)
            {
                int house_id = Convert.ToInt32(ownerprofilemanagehousehouseidcombobox.SelectedItem.ToString());
                con.Open();
                string query = @"SELECT house_num, address, flat_count, lift, area FROM HouseTable WHERE house_id = @house_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", house_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        managehousehousenumbertextbox.Text = reader["house_num"].ToString();
                        ownerprofilemanagehouseaddresscombobox.Text = reader["address"].ToString();
                        managehouseflatcounttextbox.Text = reader["flat_count"].ToString();
                        managehouseliftcombobox.Text = reader["lift"].ToString();
                        managehouseareacombobox.Text = reader["area"].ToString();
                    }
                }
                con.Close();
            }
        }

        private void ownerprofilemanagehouseaddresscombobox_TextChanged(object sender, EventArgs e)
        {
            // Handle the event when the address text is changed
        }

        private void managehousesupdatebutton_Click(object sender, EventArgs e)
        {
            if (ownerprofilemanagehousehouseidcombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a house to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (managehousehousenumbertextbox.Text == "" || ownerprofilemanagehouseaddresscombobox.Text == "" || managehouseflatcounttextbox.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(managehouseflatcounttextbox.Text, out int n))
            {
                MessageBox.Show("Flat count must be a number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();
                int house_id = Convert.ToInt32(ownerprofilemanagehousehouseidcombobox.SelectedItem.ToString());
                string query = @"UPDATE HouseTable SET house_num = @houseNumber, address = @address, flat_count = @flatCount, lift = @lift, area = @area WHERE house_id = @house_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@houseNumber", managehousehousenumbertextbox.Text);
                    cmd.Parameters.AddWithValue("@address", ownerprofilemanagehouseaddresscombobox.Text);
                    cmd.Parameters.AddWithValue("@flatCount", managehouseflatcounttextbox.Text);
                    cmd.Parameters.AddWithValue("@lift", managehouseliftcombobox.Text);
                    cmd.Parameters.AddWithValue("@area", managehouseareacombobox.Text);
                    cmd.Parameters.AddWithValue("@house_id", house_id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("House updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}