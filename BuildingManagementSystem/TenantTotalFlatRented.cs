using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class TenantTotalFlatRented : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public TenantTotalFlatRented(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void tenanttotlflatrentedbackbutton_Click(object sender, EventArgs e)
        {
            TenantDashBoard dashboard = new TenantDashBoard(userName);
            dashboard.Show();
            this.Hide();
        }

        private void TenantTotalFlatRented_Load(object sender, EventArgs e)
        {
            LoadFlatData();
        }

        private void LoadFlatData()
        {
            con.Open();
            string query = @"
            SELECT f.*
            FROM FlatTable f
            INNER JOIN FlatOccupationTable fo ON f.flat_id = fo.flat_id
            WHERE fo.move_out_date < @today";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@today", DateTime.Now);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable flatTable = new DataTable();
                adapter.Fill(flatTable);
                dataGridView1.DataSource = flatTable;
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
