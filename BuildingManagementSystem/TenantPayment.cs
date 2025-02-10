using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class TenantPayment : Form
    {
        private string username;

        public TenantPayment(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void amounttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            new TenantDashBoard(username).Show();
            this.Hide();
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Retrieve tenant_id using username
                    string query = "SELECT tenant_Id FROM TenantTable WHERE username = @username";
                    int tenantId;

                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            tenantId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Tenant ID not found for the given username.");
                            return;
                        }
                    }

                    // Retrieve flat_id using tenant_id
                    query = "SELECT flat_id FROM FlatOccupationTable WHERE tenant_id = @tenantId";
                    int flatId;

                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@tenantId", tenantId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            flatId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Flat ID not found for the selected tenant.");
                            return;
                        }
                    }

                    // Retrieve and update due amount
                    query = "SELECT due FROM TenantDueTable WHERE tenant_Id = @tenantId AND flat_id = @flatId";
                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@tenantId", tenantId);
                        cmd.Parameters.AddWithValue("@flatId", flatId);
                        object result = cmd.ExecuteScalar();

                        float paymentAmount = float.Parse(amounttextbox.Text);

                        if (result != null && result != DBNull.Value)
                        {
                            float due = Convert.ToSingle(result);
                            due -= paymentAmount;

                            query = "UPDATE TenantDueTable SET due = @due WHERE tenant_Id = @tenantId AND flat_id = @flatId";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@due", due);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            query = "INSERT INTO TenantDueTable (tenant_Id, flat_id, due) VALUES (@tenantId, @flatId, @due)";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@due", -paymentAmount);
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into PaymentTable
                        string invoiceNumber = GenerateRandomInvoiceNumber();
                        query = "INSERT INTO PaymentTable (amount, time, payment_type, invoice_num, payment_by) VALUES (@amount, @time, @payment_type, @invoice_num, @payment_by)";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@amount", paymentAmount);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        cmd.Parameters.AddWithValue("@payment_type", "Cash");
                        cmd.Parameters.AddWithValue("@invoice_num", invoiceNumber);
                        cmd.Parameters.AddWithValue("@payment_by", tenantId);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();

                        MessageBox.Show($"Payment of amount {paymentAmount} was successful.\nInvoice number: {invoiceNumber}");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private string GenerateRandomInvoiceNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
