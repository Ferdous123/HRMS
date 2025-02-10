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
    public partial class OwnerProfileManageHousesAddHousesAddFlats : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");


        public OwnerProfileManageHousesAddHousesAddFlats(String userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void OwnerProfileManageHousesAddHousesAddFlats_Load(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT owner_Id FROM OwnerTable WHERE username = @username";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int owner_Id = Convert.ToInt32(reader["owner_Id"]);
                    reader.Close();

                    string query2 = @"SELECT house_id FROM OwnerHouseTable WHERE owner_id = @owner_id";
                    using (SqlCommand cmd2 = new SqlCommand(query2, con))
                    {
                        cmd2.Parameters.AddWithValue("@owner_id", owner_Id);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            int house_Id = Convert.ToInt32(reader2["house_id"]);
                            addflatschoosehousecombobox.Items.Add(house_Id);
                        }
                    }
                }
            }
            con.Close();
        }

        private void addflatsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageFlats ownerProfileManageFlats = new OwnerProfileManageFlats(userName);
            ownerProfileManageFlats.Show();
            this.Hide();
        }

        private void addflatschooseflatcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addflatschoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void addflatsconfirmbutton_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            try
            {
                con.Open();

                int house_id = Convert.ToInt32(addflatschoosehousecombobox.SelectedItem.ToString());

                // Check the flat_count from HouseTable
                string flatCountQuery = "SELECT flat_count FROM HouseTable WHERE house_id = @house_id";
                int flatCount;
                using (SqlCommand flatCountCmd = new SqlCommand(flatCountQuery, con))
                {
                    flatCountCmd.Parameters.AddWithValue("@house_id", house_id);
                    flatCount = (int)flatCountCmd.ExecuteScalar();
                }

                // Get the count of house_id in HouseFlatTable
                string houseFlatCountQuery = "SELECT COUNT(*) FROM HouseFlatTable WHERE house_id = @house_id";
                int houseFlatCount;
                using (SqlCommand houseFlatCountCmd = new SqlCommand(houseFlatCountQuery, con))
                {
                    houseFlatCountCmd.Parameters.AddWithValue("@house_id", house_id);
                    houseFlatCount = (int)houseFlatCountCmd.ExecuteScalar();
                }

                // Check if there is room for more flats
                if (flatCount - houseFlatCount <= 0)
                {
                    MessageBox.Show("All flats are already entered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                transaction = con.BeginTransaction();

                // Check if the house_id and flat_designation combination already exists
                string flat_designation = addflatsflatdesignationtextbox.Text;
                string checkQuery = "SELECT COUNT(*) FROM FlatTable WHERE flat_designation = @flat_designation AND flat_id IN (SELECT flat_id FROM HouseFlatTable WHERE house_id = @house_id)";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction))
                {
                    checkCmd.Parameters.AddWithValue("@house_id", house_id);
                    checkCmd.Parameters.AddWithValue("@flat_designation", flat_designation);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Flat with this designation already exists in this house. If you want to modify flat details, go to Manage Flats.",
                                        "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        transaction.Rollback();
                        return;
                    }
                }

                string query2 = @"
            INSERT INTO FlatTable (availability_status, size, number_of_bedrooms, number_of_bathrooms, 
                                   floor_number, [view], furnished_status, flat_designation) 
            VALUES (@availability_status, @size, @number_of_bedrooms, @number_of_bathrooms, 
                    @floor_number, @view, @furnished_status, @flat_designation);
            SELECT SCOPE_IDENTITY();";

                int newFlatId;
                using (SqlCommand cmd2 = new SqlCommand(query2, con, transaction))
                {
                    cmd2.Parameters.AddWithValue("@availability_status", addflatsavalabilitystatuscombobox.Text);
                    cmd2.Parameters.AddWithValue("@size", addflatssizecombobox.Text);
                    cmd2.Parameters.AddWithValue("@number_of_bedrooms", addflatsnumofbedroomscombobox.Text);
                    cmd2.Parameters.AddWithValue("@number_of_bathrooms", addflatsnumofbathroomcombobox.Text);
                    cmd2.Parameters.AddWithValue("@floor_number", addflatsfloornumcombobox.Text);
                    cmd2.Parameters.AddWithValue("@view", addflatsviewcombobox.Text);
                    cmd2.Parameters.AddWithValue("@furnished_status", addflatsfurnishedstatuscombobox.Text);
                    cmd2.Parameters.AddWithValue("@flat_designation", flat_designation);

                    newFlatId = Convert.ToInt32(cmd2.ExecuteScalar());
                }

                // Insert into HouseFlatTable
                string query = @"INSERT INTO HouseFlatTable (house_id, flat_id) VALUES (@house_id, @flat_id)";
                using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@house_id", house_id);
                    cmd.Parameters.AddWithValue("@flat_id", newFlatId);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Flat Added Successfully");

                // Prompt the user to edit flat financial details
                DialogResult result = MessageBox.Show("Do you want to edit the financial details for this flat now?", "Edit Financial Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OwnerFlatFinencial ownerFlatFinencial = new OwnerFlatFinencial(userName);
                    ownerFlatFinencial.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                if (ex.Number == 2627 || ex.Number == 2601) // Primary Key or Unique Constraint Violation
                {
                    MessageBox.Show("Flat already exists. If you want to modify flat details, go to Manage Flats.",
                                    "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                con.Close();
            }
        }

        private void addflatsNextbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
