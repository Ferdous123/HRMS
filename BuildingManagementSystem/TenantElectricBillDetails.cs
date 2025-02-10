using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class TenantElectricBillDetails : Form
    {
        private string userName;
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public TenantElectricBillDetails(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void TenantElectricBillDetails_Load(object sender, EventArgs e)
        {
            PopulateElectricBills();
        }

        private void PopulateElectricBills()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT eb.* 
                    FROM dbo.ElectricBillTable eb 
                    JOIN dbo.FlatOccupationTable fo ON eb.flat_id = fo.flat_id 
                    JOIN dbo.TenantTable tt ON fo.tenant_id = tt.tenant_id 
                    WHERE tt.username = @username";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void tenantelectricbilldetailsbackbutton_Click(object sender, EventArgs e)
        {
            TenantDashBoard tenantDashBoard = new TenantDashBoard(userName);
            tenantDashBoard.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
