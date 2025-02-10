using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class TenantPaymentDetails : Form
    {
        private string username;
        private int tenantId;
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public TenantPaymentDetails(string username)
        {
            InitializeComponent();
            this.username = username;
            LoadTenantId();
            PopulatePaymentTypeComboBox();
        }

        private void LoadTenantId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT tenant_Id FROM TenantTable WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    tenantId = (int)cmd.ExecuteScalar();
                }
            }
        }

        private void PopulatePaymentTypeComboBox()
        {
            tenantpaymentpaymenttypecombobox.Items.Clear();
            tenantpaymentpaymenttypecombobox.Items.Add("All");
            tenantpaymentpaymenttypecombobox.Items.Add("Cash");
            tenantpaymentpaymenttypecombobox.Items.Add("Online");
            tenantpaymentpaymenttypecombobox.SelectedIndex = 0;
        }

        private void FilterPayments()
        {
            string paymentTypeFilter = tenantpaymentpaymenttypecombobox.SelectedItem?.ToString() ?? "All";

            string query = "SELECT p.* FROM PaymentTable p " +
                           "JOIN TenantTable t ON p.payment_by = t.tenant_Id " +
                           "WHERE t.tenant_Id = @tenantId";

            if (paymentTypeFilter != "All")
            {
                query += " AND p.payment_type = @paymentType";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    if (paymentTypeFilter != "All")
                    {
                        cmd.Parameters.AddWithValue("@paymentType", paymentTypeFilter);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        paymentH0istorydataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        private void TenantPaymentDetails_Load(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void paymentH0istorydataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tenantpaymentpaymenttypecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPayments();
        }

        private void ownerrecivedpaymentcashentrybutton_Click(object sender, EventArgs e)
        {
            TenantPayment t = new TenantPayment(username);
            t.Show();
            this.Hide();
        }

        private void ownerrecivedpaymentbackbutton_Click(object sender, EventArgs e)
        {
            TenantDashBoard t = new TenantDashBoard(username);
            t.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
