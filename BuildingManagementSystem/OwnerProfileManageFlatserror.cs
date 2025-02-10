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
                    ownerprofilemanageflatshouseidcombobox.Items.Add(house_Id);
                }
            }
            con.Close();
        }

        private void ownerprofilemanageflatshouseidcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addflatsfloornumcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void manageflatsupdatebutton_Click(object sender, EventArgs e)
        {
            
        }




private void label11_Click(object sender, EventArgs e)
        {

        }

        private void ownerprofilemanageflatshouseidcombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (ownerprofilemanageflatshouseidcombobox.SelectedItem != null)
            {
                int house_id = Convert.ToInt32(ownerprofilemanageflatshouseidcombobox.SelectedItem.ToString());
                con.Open();
                string query = @"SELECT flat_id FROM HouseFlatTable WHERE house_id = @house_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@house_id", house_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    addflatsfloornumcombobox.Items.Clear();
                    while (reader.Read())
                    {
                        int flat_Id = Convert.ToInt32(reader["flat_id"]);
                        addflatsfloornumcombobox.Items.Add(flat_Id);
                    }
                }
                con.Close();
            }
        }

        private void manageflatsfloornumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addflatsfloornumcombobox.SelectedItem != null)
            {
                int flat_id = Convert.ToInt32(addflatsfloornumcombobox.SelectedItem.ToString());
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
                            addflatsnumofbedroomscombobox.Text = reader["number_of_bedrooms"].ToString();
                            addflatsnumofbathroomcombobox.Text = reader["number_of_bathrooms"].ToString();
                            manageflatsfloornumbercombobox.Text = reader["floor_number"].ToString();
                            addflatsviewcombobox.Text = reader["view"].ToString();
                            addflatsfurnishedstatuscombobox.Text = reader["furnished_status"].ToString();
                            addflatsflatdesignationtextbox.Text = reader["flat_designation"].ToString();
                        }
                    }
                }
                con.Close();
            }
        }



        private void addflatsfloornumcombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (addflatsfloornumcombobox.SelectedItem != null)
            {
                int flat_id = Convert.ToInt32(addflatsfloornumcombobox.SelectedItem.ToString());
                con.Open();
                string query = @"SELECT availability_status, size, number_of_bedrooms, number_of_bathrooms, floor_number, [view], furnished_status, flat_designation FROM FlatTable WHERE flat_id = @flat_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@flat_id", flat_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        addflatsavalabilitystatuscombobox.Text = reader["availability_status"].ToString();
                        manageflatssizecombobox.Text = reader["size"].ToString();
                        addflatsnumofbedroomscombobox.Text = reader["number_of_bedrooms"].ToString();
                        addflatsnumofbathroomcombobox.Text = reader["number_of_bathrooms"].ToString();
                        addflatsfloornumcombobox.Text = reader["floor_number"].ToString();
                        addflatsviewcombobox.Text = reader["view"].ToString();
                        addflatsfurnishedstatuscombobox.Text = reader["furnished_status"].ToString();
                        addflatsflatdesignationtextbox.Text = reader["flat_designation"].ToString();
                    }
                }
                con.Close();
            }
        }

        private void addflatsflatdesignationtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addflatsavalabilitystatuscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageflatssizecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addflatsnumofbedroomscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addflatsfurnishedstatuscombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addflatsnumofbathroomcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addflatsviewcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageflatsupdatebutton_Click_1(object sender, EventArgs e)
        {
            if (addflatsfloornumcombobox.SelectedItem == null)
            {
                MessageBox.Show("Please select a flat to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (addflatsavalabilitystatuscombobox.Text == "" || manageflatssizecombobox.Text == "" || addflatsnumofbedroomscombobox.Text == "" || addflatsnumofbathroomcombobox.Text == "" || addflatsfloornumcombobox.Text == "" || addflatsviewcombobox.Text == "" || addflatsfurnishedstatuscombobox.Text == "" || addflatsflatdesignationtextbox.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                con.Open();
                int flat_id = Convert.ToInt32(addflatsfloornumcombobox.SelectedItem.ToString());
                string query = @"UPDATE FlatTable SET availability_status = @availability_status, size = @size, number_of_bedrooms = @number_of_bedrooms, number_of_bathrooms = @number_of_bathrooms, floor_number = @floor_number, [view] = @view, furnished_status = @furnished_status, flat_designation = @flat_designation WHERE flat_id = @flat_id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@availability_status", addflatsavalabilitystatuscombobox.Text);
                    cmd.Parameters.AddWithValue("@size", manageflatssizecombobox.Text);
                    cmd.Parameters.AddWithValue("@number_of_bedrooms", addflatsnumofbedroomscombobox.Text);
                    cmd.Parameters.AddWithValue("@number_of_bathrooms", addflatsnumofbathroomcombobox.Text);
                    cmd.Parameters.AddWithValue("@floor_number", addflatsfloornumcombobox.Text);
                    cmd.Parameters.AddWithValue("@view", addflatsviewcombobox.Text);
                    cmd.Parameters.AddWithValue("@furnished_status", addflatsfurnishedstatuscombobox.Text);
                    cmd.Parameters.AddWithValue("@flat_designation", addflatsflatdesignationtextbox.Text);
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
    }
}