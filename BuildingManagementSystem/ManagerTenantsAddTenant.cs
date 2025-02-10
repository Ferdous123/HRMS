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
    public partial class ManagerTenantsAddTenant : Form
    {

        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");


        public ManagerTenantsAddTenant(string username)
        {
            InitializeComponent();
            this.userName = username;
        }


        private void PopulateHouseNumberComboBox()
        {
            con.Open();
            string query = @"
            SELECT h.house_id, h.address 
            FROM HouseTable h
            INNER JOIN ManagerHouseTable oh ON h.house_id = oh.house_id
            INNER JOIN ManagerTable o ON oh.manager_id = o.manager_id
            WHERE o.username = @username";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable houseTable = new DataTable();
                adapter.Fill(houseTable);
                manageraddtenantshousenumbercombobox.DataSource = houseTable;
                manageraddtenantshousenumbercombobox.DisplayMember = "address";
                manageraddtenantshousenumbercombobox.ValueMember = "house_id";
            }
            con.Close();
        }

        private void PopulateFlatNumberComboBox()
        {
            var selectedRow = manageraddtenantshousenumbercombobox.SelectedValue as DataRowView;
            if (selectedRow != null)
            {
                int house_id = Convert.ToInt32(selectedRow["house_id"]);
                DateTime moveInDate = manageraddtenantsmovingdateTimePicker.Value;
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
                        manageraddtenantsflatnumbercombobox.DataSource = flatTable;
                        manageraddtenantsflatnumbercombobox.DisplayMember = "flat_id";
                        manageraddtenantsflatnumbercombobox.ValueMember = "flat_id";
                    }
                }
            }
        }




        private void ManagerTenantsAddTenant_Load(object sender, EventArgs e)
        {
            PopulateHouseNumberComboBox();
        }

        private void manageraddtenantsusernametextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void manageraddtenantshousenumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateFlatNumberComboBox();
        }

        private void manageraddtenantsflatnumbercombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageraddtenantsmovingdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            PopulateFlatNumberComboBox();
        }

        private void manageraddtenantsconfirmbutton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(manageraddtenantsusernametextbox.Text, out int tenant_id) &&
               int.TryParse(manageraddtenantshousenumbercombobox.SelectedValue.ToString(), out int house_id) &&
               int.TryParse(manageraddtenantsflatnumbercombobox.SelectedValue.ToString(), out int flat_id))
            {
                DateTime moveInDate = manageraddtenantsmovingdateTimePicker.Value;

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
        private void manageraddtenantsbackbutton_Click(object sender, EventArgs e)
        {
            ManagerTenants managerTenants = new ManagerTenants(userName);
            managerTenants.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
