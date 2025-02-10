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
    public partial class Login : Form
    {
        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");
         
        public Login()
        {
            InitializeComponent();
            UpdateFinancials();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loginpassshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            loginpasstext.UseSystemPasswordChar = false;
            loginpasstext.PasswordChar = loginpassshowcheckbox.Checked ? '\0' : '*';
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (loginusernametext.Text == "" || loginpasstext.Text == "")
            {
                MessageBox.Show("Please enter username and password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string userName = loginusernametext.Text;
                string password = loginpasstext.Text;

                con.Open();

                string query = @"SELECT 'Owner' AS UserType, username FROM OwnerTable WHERE username = @username AND password = @password
                UNION 
                SELECT 'Tenant' AS UserType, username FROM TenantTable WHERE username = @username AND password = @password
                UNION
                SELECT 'Manager' AS UserType, username FROM ManagerTable WHERE username = @username AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string userType = reader["UserType"].ToString();
                            string username = reader["username"].ToString();

                            if (userType == "Owner")
                            {
                                OwnerDashboard ownerDashboard = new OwnerDashboard(username);
                                ownerDashboard.Show();
                                this.Hide();
                            }
                            else if (userType == "Tenant")
                            {
                                TenantDashBoard tenantDashboard = new TenantDashBoard(username);
                                tenantDashboard.Show();
                                this.Hide();
                            }
                            else if (userType == "Manager")
                            {
                                ManagerDashBoard managerDashboard = new ManagerDashBoard(username);
                                managerDashboard.Show();
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                }
            }
        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            Registration newRegistration = new Registration();
            newRegistration.Show();
            this.Hide();
        }

        private void loginforget_Click(object sender, EventArgs e)
        {
            ForgetPassword newForgetPassword = new ForgetPassword();
            newForgetPassword.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void UpdateFinancials()
        {
            Console.WriteLine("Updating financials...");
            con.Open();
            bool changesMade = false;

            try
            {
                // Check last update date
                string checkUpdateQuery = "SELECT last_update_date FROM UpdateTrackerTable WHERE Id = 1";
                DateTime? lastUpdateDate = null;

                using (SqlCommand cmd = new SqlCommand(checkUpdateQuery, con))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        lastUpdateDate = (DateTime)result;
                    }
                }

                if (lastUpdateDate == null || lastUpdateDate.Value.Month < DateTime.Now.Month)
                {
                    int monthsPassed = lastUpdateDate == null ? 1 : ((DateTime.Now.Year - lastUpdateDate.Value.Year) * 12) + DateTime.Now.Month - lastUpdateDate.Value.Month;

                    // Get all active flat occupations
                    string getOccupationsQuery = @"
            SELECT fo.tenant_id, fo.flat_id
            FROM FlatOccupationTable fo
            WHERE (fo.move_out_date IS NULL OR fo.move_out_date > GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(getOccupationsQuery, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tenantId = reader.GetInt32(0);
                            int flatId = reader.GetInt32(1);

                            // Sum up charges from FlatFinancialsTable
                            string getFinancialsQuery = @"
                    SELECT rent_amount, service_charge, cleaning_charge, water_bill, postpaid_gas_bill, miscellaneous
                    FROM FlatFinancialsTable
                    WHERE flat_id = @flat_id";

                            double totalCharges = 0;

                            using (SqlCommand financialsCmd = new SqlCommand(getFinancialsQuery, con))
                            {
                                financialsCmd.Parameters.AddWithValue("@flat_id", flatId);

                                using (SqlDataReader financialsReader = financialsCmd.ExecuteReader())
                                {
                                    if (financialsReader.Read())
                                    {
                                        totalCharges = (financialsReader.GetDouble(0) + financialsReader.GetDouble(1) + financialsReader.GetDouble(2) +
                                                        financialsReader.GetDouble(3) + financialsReader.GetDouble(4) + financialsReader.GetDouble(5)) * monthsPassed;
                                    }
                                }
                            }

                            // Get electricity bill for the previous month
                            string getElectricBillQuery = @"
                    SELECT postpaid_electric_bill
                    FROM ElectricBillTable
                    WHERE flat_id = @flat_id AND MONTH(billing_month) = MONTH(DATEADD(MONTH, -1, GETDATE()))";

                            double electricBill = 0;

                            using (SqlCommand electricBillCmd = new SqlCommand(getElectricBillQuery, con))
                            {
                                electricBillCmd.Parameters.AddWithValue("@flat_id", flatId);

                                var result = electricBillCmd.ExecuteScalar();
                                if (result != null)
                                {
                                    electricBill = (double)result;
                                }
                            }

                            totalCharges += electricBill;

                            // Update TenantDueTable
                            string updateTenantDueQuery = @"
                    IF EXISTS (SELECT 1 FROM TenantDueTable WHERE tenant_id = @tenant_id)
                    BEGIN
                        UPDATE TenantDueTable
                        SET due_amount = due_amount + @total_charges
                        WHERE tenant_id = @tenant_id
                    END
                    ELSE
                    BEGIN
                        INSERT INTO TenantDueTable (tenant_id, due_amount)
                        VALUES (@tenant_id, -@total_charges)
                    END";

                            using (SqlCommand updateTenantDueCmd = new SqlCommand(updateTenantDueQuery, con))
                            {
                                updateTenantDueCmd.Parameters.AddWithValue("@tenant_id", tenantId);
                                updateTenantDueCmd.Parameters.AddWithValue("@total_charges", totalCharges);

                                int rowsAffected = updateTenantDueCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    changesMade = true;
                                }
                            }
                        }
                    }

                    // Update the last update date in UpdateTrackerTable
                    string updateTrackerQuery = @"
            IF EXISTS (SELECT 1 FROM UpdateTrackerTable WHERE Id = 1)
            BEGIN
                UPDATE UpdateTrackerTable
                SET last_update_date = GETDATE()
                WHERE Id = 1
            END
            ELSE
            BEGIN
                INSERT INTO UpdateTrackerTable (Id, last_update_date)
                VALUES (1, GETDATE())
            END";

                    using (SqlCommand updateTrackerCmd = new SqlCommand(updateTrackerQuery, con))
                    {
                        int rowsAffected = updateTrackerCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            changesMade = true;
                        }
                    }

                    if (changesMade)
                    {
                        MessageBox.Show("Financials updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }



    }
}
