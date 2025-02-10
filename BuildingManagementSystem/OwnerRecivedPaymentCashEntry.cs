using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BuildingManagementSystem
{
    public partial class OwnerRecivedPaymentCashEntry : Form
    {
        private string userName;

        public OwnerRecivedPaymentCashEntry(string username)
        {
            InitializeComponent();
            userName = username;
            ownercashentryhousenumcombobox.SelectedIndexChanged += ownercashentryhousenumcombobox_SelectedIndexChanged;

        }

        private void OwnerRecivedPaymentCashEntry_Load(object sender, EventArgs e)
        {
            PopulateOwnerCashEntryHouseNumComboBox();
        }

        private void ownercashentrybackbutton_Click(object sender, EventArgs e)
        {
            OwnerRecivedPayment ownerRecivedPayment = new OwnerRecivedPayment(userName);
            ownerRecivedPayment.Show();
            this.Hide();
        }

        private void ownercashentrypayeecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOwnerCashEntryHouseNumComboBox();
        }

        private void ownercashentryhousenumcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOwnerCashEntryFlatNumComboBox();
        }

        private void ownercashentryflatnumcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOwnerCashEntryPayeeComboBox();
        }

        private void ownercashentrypaymentamounttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    var selectedItem = ownercashentrypayeecombobox.SelectedItem;
                    if (selectedItem == null)
                    {
                        MessageBox.Show("Please select a payee.");
                        return;
                    }

                    string tenantId = selectedItem.ToString();
                    string query = "SELECT flat_id FROM FlatOccupationTable WHERE tenant_id = @tenantId";
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

                    query = "SELECT due FROM TenantDueTable WHERE tenant_Id = @tenantId AND flat_id = @flatId";
                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@tenantId", tenantId);
                        cmd.Parameters.AddWithValue("@flatId", flatId);
                        object result = cmd.ExecuteScalar();

                        float paymentAmount = float.Parse(ownercashentrypaymentamounttextbox.Text);

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

        private void PopulateOwnerCashEntryPayeeComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT owner_Id FROM OwnerTable WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);
                        int ownerId = (int)cmd.ExecuteScalar();

                        var selectedHouse = ownercashentryhousenumcombobox.SelectedItem;
                        var selectedFlat = ownercashentryflatnumcombobox.SelectedItem;

                        if (selectedHouse != null && selectedFlat != null)
                        {
                            query = "SELECT tenant_id FROM FlatOccupationTable WHERE flat_id = @flatId AND house_id = @houseId AND (move_out_date IS NULL OR move_out_date >= @today)";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@flatId", selectedFlat.ToString());
                            cmd.Parameters.AddWithValue("@houseId", selectedHouse.ToString());
                            cmd.Parameters.AddWithValue("@today", DateTime.Today);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                ownercashentrypayeecombobox.Items.Clear();
                                while (reader.Read())
                                {
                                    ownercashentrypayeecombobox.Items.Add(reader["tenant_id"].ToString());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select both house and flat.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void PopulateOwnerCashEntryHouseNumComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT owner_Id FROM OwnerTable WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);
                        int ownerId = (int)cmd.ExecuteScalar();

                        query = "SELECT house_id FROM OwnerHouseTable WHERE owner_id = @ownerId";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@ownerId", ownerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            ownercashentryhousenumcombobox.Items.Clear();
                            while (reader.Read())
                            {
                                ownercashentryhousenumcombobox.Items.Add(reader["house_id"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void PopulateOwnerCashEntryFlatNumComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT flat_id, flat_designation FROM FlatTable WHERE flat_id IN (SELECT flat_id FROM HouseFlatTable WHERE house_id = @houseId)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        var selectedItem = ownercashentryhousenumcombobox.SelectedItem;
                        if (selectedItem != null)
                        {
                            cmd.Parameters.AddWithValue("@houseId", selectedItem.ToString());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                ownercashentryflatnumcombobox.Items.Clear();
                                while (reader.Read())
                                {
                                    ownercashentryflatnumcombobox.Items.Add(reader["flat_id"].ToString());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select a house number.");
                        }
                    }
                }
                catch (Exception ex)
                {
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

        private void ownercashentryconfirmbutton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    var selectedItem = ownercashentrypayeecombobox.SelectedItem;
                    if (selectedItem == null)
                    {
                        MessageBox.Show("Please select a payee.");
                        return;
                    }

                    string tenantId = selectedItem.ToString();
                    string query = "SELECT flat_id FROM FlatOccupationTable WHERE tenant_id = @tenantId";
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

                    query = "SELECT due FROM TenantDueTable WHERE tenant_Id = @tenantId AND flat_id = @flatId";
                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@tenantId", tenantId);
                        cmd.Parameters.AddWithValue("@flatId", flatId);
                        object result = cmd.ExecuteScalar();

                        float paymentAmount = float.Parse(ownercashentrypaymentamounttextbox.Text);

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
    }
}
