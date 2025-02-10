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
    public partial class ManagerPaymentDetailsCashEntry : Form
    {
        private string userName;

        public ManagerPaymentDetailsCashEntry(string username)
        {
            InitializeComponent();
            this.userName = username;
        }

        private void managercashentrybackbutton_Click(object sender, EventArgs e)
        {
            ManagerPaymentDetails managerPaymentDetails = new ManagerPaymentDetails(userName);
            managerPaymentDetails.Show();
            this.Hide();
        }

        private void ManagerPaymentDetailsCashEntry_Load(object sender, EventArgs e)
        {
            PopulateManagerCashEntryHouseNumComboBox();
        }

        private void managercashentryhousenumcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateManagerCashEntryFlatNumComboBox();
        }

        private void managercashentryflatnumcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateManagerCashEntryPayeeComboBox();
        }

        private void managercashentrypayeecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PopulateManagerCashEntryHouseNumComboBox();
        }

        private void managercashentrypaymentamounttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void managercashentryconfirmbutton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    var selectedItem = managercashentrypayeecombobox.SelectedItem;
                    if (selectedItem == null)
                    {
                        MessageBox.Show("Please select a payee.");
                        return;
                    }

                    string tenantId = selectedItem.ToString();
                    int flatId = GetFlatId(con, transaction, tenantId);
                    if (flatId == -1)
                    {
                        MessageBox.Show("Flat ID not found for the selected tenant.");
                        return;
                    }

                    float paymentAmount = float.Parse(managercashentrypaymentamounttextbox.Text);
                    UpdateTenantDue(con, transaction, tenantId, flatId, paymentAmount);
                    InsertPayment(con, transaction, tenantId, paymentAmount);

                    transaction.Commit();
                    MessageBox.Show($"Payment of amount {paymentAmount} was successful.\nInvoice number: {GenerateRandomInvoiceNumber()}");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private int GetFlatId(SqlConnection con, SqlTransaction transaction, string tenantId)
        {
            string query = "SELECT flat_id FROM FlatOccupationTable WHERE tenant_id = @tenantId";
            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@tenantId", tenantId);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                return -1;
            }
        }

        private void UpdateTenantDue(SqlConnection con, SqlTransaction transaction, string tenantId, int flatId, float paymentAmount)
        {
            string query = "SELECT due FROM TenantDueTable WHERE tenant_Id = @tenantId AND flat_id = @flatId";
            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@tenantId", tenantId);
                cmd.Parameters.AddWithValue("@flatId", flatId);
                object result = cmd.ExecuteScalar();

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
            }
        }

        private void InsertPayment(SqlConnection con, SqlTransaction transaction, string tenantId, float paymentAmount)
        {
            string invoiceNumber = GenerateRandomInvoiceNumber();
            string query = "INSERT INTO PaymentTable (amount, time, payment_type, invoice_num, payment_by) VALUES (@amount, @time, @payment_type, @invoice_num, @payment_by)";
            using (SqlCommand cmd = new SqlCommand(query, con, transaction))
            {
                cmd.Parameters.AddWithValue("@amount", paymentAmount);
                cmd.Parameters.AddWithValue("@time", DateTime.Now);
                cmd.Parameters.AddWithValue("@payment_type", "Cash");
                cmd.Parameters.AddWithValue("@invoice_num", invoiceNumber);
                cmd.Parameters.AddWithValue("@payment_by", tenantId);
                cmd.ExecuteNonQuery();
            }
        }

        private void PopulateManagerCashEntryPayeeComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT manager_Id FROM ManagerTable WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);
                        int managerId = (int)cmd.ExecuteScalar();

                        var selectedHouse = managercashentryhousenumcombobox.SelectedItem;
                        var selectedFlat = managercashentryflatnumcombobox.SelectedItem;

                        if (selectedHouse != null && selectedFlat != null)
                        {
                            query = "SELECT tenant_id FROM FlatOccupationTable WHERE flat_id = @flatId AND house_id = @houseId AND (move_out_date IS NULL OR move_out_date >= @today)";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@flatId", selectedFlat.ToString());
                            cmd.Parameters.AddWithValue("@houseId", selectedHouse.ToString());
                            cmd.Parameters.AddWithValue("@today", DateTime.Today);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                managercashentrypayeecombobox.Items.Clear();
                                while (reader.Read())
                                {
                                    managercashentrypayeecombobox.Items.Add(reader["tenant_id"].ToString());
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

        private void PopulateManagerCashEntryHouseNumComboBox()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT manager_Id FROM ManagerTable WHERE username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);
                        int managerId = (int)cmd.ExecuteScalar();

                        query = "SELECT house_id FROM ManagerHouseTable WHERE manager_id = @managerId";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@managerId", managerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            managercashentryhousenumcombobox.Items.Clear();
                            while (reader.Read())
                            {
                                managercashentryhousenumcombobox.Items.Add(reader["house_id"].ToString());
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

        private void PopulateManagerCashEntryFlatNumComboBox()
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
                        var selectedItem = managercashentryhousenumcombobox.SelectedItem;
                        if (selectedItem != null)
                        {
                            cmd.Parameters.AddWithValue("@houseId", selectedItem.ToString());

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                managercashentryflatnumcombobox.Items.Clear();
                                while (reader.Read())
                                {
                                    managercashentryflatnumcombobox.Items.Add(reader["flat_id"].ToString());
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
    }
}
