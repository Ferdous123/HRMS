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
    public partial class OwnerOccupiedFlats : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerOccupiedFlats(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void owneroccupiedflatsbackbutton_Click(object sender, EventArgs e)
        {
            OwnerDashboard ownerDashboard = new OwnerDashboard(userName);
            ownerDashboard.Show();
            this.Hide();
        }

        private void OwnerOccupiedFlats_Load(object sender, EventArgs e)
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
                            owneroccupiedflatschoosehousecombobox.Items.Add(house_Id);
                        }
                    }
                }
            }
            con.Close();

            // Add Remove Tenant button column
            DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
            removeButtonColumn.Name = "Action";
            removeButtonColumn.HeaderText = "Action";
            removeButtonColumn.Text = "Remove Tenant";
            removeButtonColumn.UseColumnTextForButtonValue = true;
            flatsDataGridView.Columns.Add(removeButtonColumn);
            flatsDataGridView.CellClick += FlatsDataGridView_CellClick;
        }

        private void owneroccupiedflatschoosehousecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            int house_id = Convert.ToInt32(owneroccupiedflatschoosehousecombobox.SelectedItem.ToString());
            string query = @"
    SELECT 
        fo.flat_id,
        fo.move_in_date,
        fo.move_out_date,
        h.address 
    FROM 
        FlatOccupationTable fo
    INNER JOIN 
        HouseFlatTable hf ON fo.flat_id = hf.flat_id
    INNER JOIN 
        HouseTable h ON hf.house_id = h.house_id
    WHERE 
        hf.house_id = @house_id
        AND fo.move_out_date IS NULL";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@house_id", house_id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable flatsTable = new DataTable();
                adapter.Fill(flatsTable);
                flatsDataGridView.DataSource = flatsTable;
            }
            con.Close();
        }



        private void FlatsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == flatsDataGridView.Columns["Action"].Index && e.RowIndex >= 0)
            {
                int flat_id = Convert.ToInt32(flatsDataGridView.Rows[e.RowIndex].Cells["flat_id"].Value);
                DialogResult result = MessageBox.Show("Are you sure you want to remove the tenant?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    con.Open();
                    string query = @"UPDATE FlatOccupationTable SET move_out_date = @move_out_date WHERE flat_id = @flat_id AND move_out_date IS NULL";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@move_out_date", DateTime.Now.AddDays(-1));
                        cmd.Parameters.AddWithValue("@flat_id", flat_id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Tenant has been removed.");
                        }
                        else
                        {
                            MessageBox.Show("No tenant found to remove.");
                        }
                    }
                    con.Close();
                }
            }
        }
    }
}
