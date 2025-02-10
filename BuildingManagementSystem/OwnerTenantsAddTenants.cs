using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerTenantsAddTenants : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerTenantsAddTenants()
        {
            InitializeComponent();
        }

        public OwnerTenantsAddTenants(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void OwnerTenantsAddTenants_Load(object sender, EventArgs e)
        {
            PopulateHouseNumberComboBox();
        }

        private void PopulateHouseNumberComboBox()
        {
            con.Open();
            string query = @"
            SELECT h.house_id, h.address 
            FROM HouseTable h
            INNER JOIN OwnerHouseTable oh ON h.house_id = oh.house_id
            INNER JOIN OwnerTable o ON oh.owner_id = o.owner_id
            WHERE o.username = @username";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable houseTable = new DataTable();
                adapter.Fill(houseTable);
                addtenantshousenumbercombobox.DataSource = houseTable;
                addtenantshousenumbercombobox.DisplayMember = "address";
                addtenantshousenumbercombobox.ValueMember = "house_id";
            }
            con.Close();
        }

        private void addtenantshousenumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFlatNumberComboBox();
        }

        private void PopulateFlatNumberComboBox()
        {
            var selectedRow = addtenantshousenumbercombobox.SelectedValue as DataRowView;
            if (selectedRow != null)
            {
                int house_id = Convert.ToInt32(selectedRow["house_id"]);
                DateTime moveInDate = dateTimePicker1.Value;
                string query = @"
                SELECT f.flat_id 
                FROM FlatTable f
                INNER JOIN HouseFlatTable hf ON f.flat_id = hf.flat_id
                WHERE hf.house_id = @house_id
                AND NOT EXISTS (
                    SELECT 1 
                    FROM FlatOccupationTable fo 
                    WHERE fo.flat_id = f.flat_id 
                    AND (fo.move_out_date IS NULL OR fo.move_out_date > @move_in_date)
                )";

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@house_id", house_id);
                        cmd.Parameters.AddWithValue("@move_in_date", moveInDate);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable flatTable = new DataTable();
                        adapter.Fill(flatTable);
                        addtenantsflatnumbercombobox.DataSource = flatTable;
                        addtenantsflatnumbercombobox.DisplayMember = "flat_id";
                        addtenantsflatnumbercombobox.ValueMember = "flat_id";
                    }
                }
            }
        }

        private void addtenantsconfirmbutton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(addtenantsusernametextbox.Text, out int tenant_id) &&
                int.TryParse(addtenantshousenumbercombobox.SelectedValue.ToString(), out int house_id) &&
                int.TryParse(addtenantsflatnumbercombobox.SelectedValue.ToString(), out int flat_id))
            {
                DateTime moveInDate = dateTimePicker1.Value;

                string query = @"
            INSERT INTO FlatOccupationTable (tenant_id, flat_id, move_in_date, move_out_date, house_id)
            VALUES (@tenant_id, @flat_id, @move_in_date, NULL, @house_id)";

                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tenant_id", tenant_id);
                        cmd.Parameters.AddWithValue("@flat_id", flat_id);
                        cmd.Parameters.AddWithValue("@move_in_date", moveInDate);
                        cmd.Parameters.AddWithValue("@house_id", house_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tenant added successfully!");
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }




        private void addtenantsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerTenants ownerTenants = new OwnerTenants(userName);
            ownerTenants.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            PopulateFlatNumberComboBox();
        }



        private void addtenantsflatnumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void addtenantsusernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
