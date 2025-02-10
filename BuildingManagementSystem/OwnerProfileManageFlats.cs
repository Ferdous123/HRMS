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
using System.Data.SqlClient;

namespace BuildingManagementSystem
{
    public partial class OwnerProfileManageFlats : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerProfileManageFlats(String userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void manageflatsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void manageflatsaddflatsbutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageHousesAddHousesAddFlats ownerProfileManageHousesAddHousesAddFlats = new OwnerProfileManageHousesAddHousesAddFlats(userName);
            ownerProfileManageHousesAddHousesAddFlats.Show();
            this.Hide();
        }

        private void OwnerProfileManageFlats_Load(object sender, EventArgs e)
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
                    manageflatschoosehousetextbox.Items.Add(house_Id);
                }
            }
            con.Close();
        }

        private void manageflatschoosehousetextbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manageflatschoosehousetextbox.SelectedItem != null)
            {
                int house_id = Convert.ToInt32(manageflatschoosehousetextbox.SelectedItem.ToString());
                con.Open();
                string query = @"SELECT flat_id FROM HouseFlatTable WHERE house_id = @house_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", house_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    manageflatschooseflatstextbox.Items.Clear();
                    while (reader.Read())
                    {
                        int flat_Id = Convert.ToInt32(reader["flat_id"]);
                        manageflatschooseflatstextbox.Items.Add(flat_Id);
                    }
                }
                con.Close();
            }
        }

        private void manageflatschooseflatstextbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (manageflatschooseflatstextbox.SelectedItem != null)
            {
                int flat_id = Convert.ToInt32(manageflatschooseflatstextbox.SelectedItem.ToString());
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                string query = @"SELECT availability_status, size, number_of_bedrooms, number_of_bathrooms, floor_number, [view], furnished_status, flat_designation FROM FlatTable WHERE flat_id = @flat_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@flat_id", flat_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            addflatsavalabilitystatuscombobox.Text = reader["availability_status"].ToString();
                            manageflatssizecombobox.Text = reader["size"].ToString();
                            manageflatsnumofbedroomscobobox.Text = reader["number_of_bedrooms"].ToString();
                            manageflatsnumofbathroomscombobox.Text = reader["number_of_bathrooms"].ToString();
                            manageflatsfloornumbercombobox.Text = reader["floor_number"].ToString();
                            manageflatsviewcombobox.Text = reader["view"].ToString();
                            manageflatsfurnishedstatuscombobox.Text = reader["furnished_status"].ToString();
                            manageflatsflatdesignationtextbox.Text = reader["flat_designation"].ToString();
                        }
                    }
                }
                con.Close();
            }
        }


        private void manageflatsupdatebutton_Click(object sender, EventArgs e)
        {
            if (manageflatsfloornumbercombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a flat to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (addflatsavalabilitystatuscombobox.Text == "" || manageflatssizecombobox.Text == "" || manageflatsnumofbedroomscobobox.Text == "" || manageflatsnumofbathroomscombobox.Text == "" || manageflatsfloornumbercombobox.Text == "" || manageflatsviewcombobox.Text == "" || manageflatsfurnishedstatuscombobox.Text == "" || manageflatsflatdesignationtextbox.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();
                int flat_id = Convert.ToInt32(manageflatschooseflatstextbox.SelectedItem.ToString());
                string query = @"UPDATE FlatTable SET availability_status = @availability_status, size = @size, number_of_bedrooms = @number_of_bedrooms, number_of_bathrooms = @number_of_bathrooms, floor_number = @floor_number, [view] = @view, furnished_status = @furnished_status, flat_designation = @flat_designation WHERE flat_id = @flat_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@availability_status", addflatsavalabilitystatuscombobox.Text);
                    cmd.Parameters.AddWithValue("@size", manageflatssizecombobox.Text);
                    cmd.Parameters.AddWithValue("@number_of_bedrooms", manageflatsnumofbedroomscobobox.Text);
                    cmd.Parameters.AddWithValue("@number_of_bathrooms", manageflatsnumofbathroomscombobox.Text);
                    cmd.Parameters.AddWithValue("@floor_number", manageflatsfloornumbercombobox.Text);
                    cmd.Parameters.AddWithValue("@view", manageflatsviewcombobox.Text);
                    cmd.Parameters.AddWithValue("@furnished_status", manageflatsfurnishedstatuscombobox.Text);
                    cmd.Parameters.AddWithValue("@flat_designation", manageflatsflatdesignationtextbox.Text);
                    cmd.Parameters.AddWithValue("@flat_id", flat_id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Flat updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void manageflatsclickherebutton_Click(object sender, EventArgs e)
        {
            OwnerFlatFinencial ownerFlatFinencial = new OwnerFlatFinencial(userName);
            ownerFlatFinencial.Show();
            this.Hide();
        }
    }
}
