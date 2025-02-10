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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace BuildingManagementSystem
{
    public partial class TenantDashBoard : Form
    {
        private string dues= "0";
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public TenantDashBoard(string username)
        {
            InitializeComponent();
            tenantprofilepanel.Visible = false;
            this.userName = username;
        }

        private void tenantnamelabel_Click(object sender, EventArgs e)
        {

        }

        private void changepasswordbutton_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Show();
            this.Hide();
        }

        private void tenantprofilepanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tenantprofilebutton_Click(object sender, EventArgs e)
        {
            string query = "SELECT name, username, email, phone FROM TenantTable WHERE username = @username";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label5.Text = $"Name : {reader["name"].ToString()}";
                            label6.Text = $"User Name :{reader["username"].ToString()}";
                            label7.Text = $"Email : {reader["email"].ToString()}";
                            label8.Text = $"Phone Number : {reader["phone"].ToString()}";
                        }
                        else
                        {
                            MessageBox.Show("Tenant data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            tenantprofilepanel.Visible = true;
        }

        private void tenantmymanagerbutton_Click(object sender, EventArgs e)
        {
            tenantprofilepanel.Visible = false;
            TenantTotalFlatRented tenantTotalFlatRented = new TenantTotalFlatRented(userName);
            tenantTotalFlatRented.Show();
            this.Hide();
        }

        private void tenantpaymentbutton_Click(object sender, EventArgs e)
        {
            new TenantPayment(userName).Show();
            this.Hide();
        }

        private void tenantdashboardbutton_Click(object sender, EventArgs e)
        {
            tenantprofilepanel.Visible = false;
        }

        private void tenantlogoutbutton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void tenantnoticebutton_Click(object sender, EventArgs e)
        {
            TenantNotice tenantNotice = new TenantNotice(userName);
            tenantNotice.Show();
            this.Hide();
        }

        private void tenanttotalflatrentedbutton_Click(object sender, EventArgs e)
        {
            TenantTotalFlatRented tenantTotalFlatRented = new TenantTotalFlatRented(userName);
            tenantTotalFlatRented.Show();
            this.Hide();
        }

        private void tenantelectricbillentrybutton_Click(object sender, EventArgs e)
        {
            TenantElectricBillDetails tenantElectricBillDetails = new TenantElectricBillDetails(userName);
            tenantElectricBillDetails.Show();
            this.Hide();
        }

        private void tenantupcomingduesbutton_Click(object sender, EventArgs e)
        {
            string queryTenantId = "SELECT tenant_Id FROM TenantTable WHERE username = @username";
            string queryFlatId = "SELECT flat_id FROM FlatOccupationTable WHERE tenant_id = @tenantId AND move_out_date IS NULL";
            string queryFinancials = "SELECT rent_amount, service_charge, cleaning_charge, water_bill, postpaid_gas_bill, miscellaneous FROM FlatFinancialsTable WHERE flat_id = @flatId";
            string queryPreviousDues = "SELECT due FROM TenantDueTable WHERE tenant_Id = @tenantId AND flat_id = @flatId";
            string queryElectricBill = "SELECT postpaid_electric_bill FROM ElectricBillTable WHERE flat_id = @flatId AND billing_month = @lastMonth";

            try
            {
                con.Open();

                // Get tenant_Id
                int tenantId;
                using (SqlCommand cmd = new SqlCommand(queryTenantId, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    tenantId = (int)cmd.ExecuteScalar();
                }

                // Get flat_id
                int flatId;
                using (SqlCommand cmd = new SqlCommand(queryFlatId, con))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        flatId = (int)result;
                    }
                    else
                    {
                        MessageBox.Show("No flat found for the given tenant.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }


                // Get financial details
                double rentAmount = 0, serviceCharge = 0, cleaningCharge = 0, waterBill = 0, gasBill = 0, miscellaneous = 0;
                using (SqlCommand cmd = new SqlCommand(queryFinancials, con))
                {
                    cmd.Parameters.AddWithValue("@flatId", flatId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rentAmount = reader.GetDouble(0);
                            serviceCharge = reader.GetDouble(1);
                            cleaningCharge = reader.GetDouble(2);
                            waterBill = reader.GetDouble(3);
                            gasBill = reader.GetDouble(4);
                            miscellaneous = reader.GetDouble(5);
                        }
                    }
                }

                // Get previous dues
                double previousDues = 0;
                using (SqlCommand cmd = new SqlCommand(queryPreviousDues, con))
                {
                    cmd.Parameters.AddWithValue("@tenantId", tenantId);
                    cmd.Parameters.AddWithValue("@flatId", flatId);
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        previousDues = (double)result;
                    }
                }


                double electricBill = 0;
                using (SqlCommand cmd = new SqlCommand(queryElectricBill, con))
                {
                    cmd.Parameters.AddWithValue("@flatId", flatId);
                    cmd.Parameters.AddWithValue("@lastMonth", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-01"));
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        electricBill = (double)result;
                    }
                }

                // Calculate total dues
                double totalDues = rentAmount + serviceCharge + cleaningCharge + waterBill + gasBill + miscellaneous + previousDues + electricBill;

                // Display total dues
                MessageBox.Show("Your upcoming (approximate) dues are: " + totalDues.ToString("F2"), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }


        private void TenantDashBoard_Load(object sender, EventArgs e)
        {
            string query = "SELECT name, username FROM TenantTable WHERE username = @username";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tenantnamelabel.Text = $"Name : {reader["name"].ToString()}";
                            tenantusernamlabel.Text = $"UserName :{reader["username"].ToString()}";
                        }
                        else
                        {
                            MessageBox.Show("Tenant data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            tenantprofilepanel.Visible = false;
        }

        private void paymentDetailsButton_Click(object sender, EventArgs e)
        {
            new TenantPaymentDetails(userName).Show();
            this.Hide();
        }
    }
}
