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
    public partial class OwnerDashboard : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public OwnerDashboard(String userName)
        {
            InitializeComponent();
            ownerprofilepanel.Visible = false;
            this.userName = userName;
        }

        private void ownerlogoutbutton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void profilebutton_Click(object sender, EventArgs e)
        {
            string query = "SELECT name, username, email, phone FROM OwnerTable WHERE username = @username";

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
                            MessageBox.Show("Owner data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            ownerprofilepanel.Visible = true;
        }

        private void managerbutton_Click(object sender, EventArgs e)
        {
            ownerprofilepanel.Visible = false;
            OwnerManager ownerManager = new OwnerManager(userName);
            ownerManager.Show();
            this.Hide();
        }

        private void tenantsbutton_Click(object sender, EventArgs e)
        {
            ownerprofilepanel.Visible = false;
            OwnerTenants ownerTenants = new OwnerTenants(userName);
            ownerTenants.Show();
            this.Hide();
        }

        private void dashboardbutton_Click(object sender, EventArgs e)
        {
            ownerprofilepanel.Visible = false;
        }

        private void changepasswordbutton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("You will be logged out for this operation. Do you want to continue?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                ForgetPassword forgetPassword = new ForgetPassword();
                forgetPassword.Show();
                this.Hide();
            }
        }

        private void noticebutton_Click(object sender, EventArgs e)
        {
            OwnerNotice ownerNotice = new OwnerNotice(userName);
            ownerNotice.Show();
            this.Hide();
        }

        private void ownerprofilepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managehousesbutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageHouses ownerProfileManageHouses = new OwnerProfileManageHouses(userName);
            ownerProfileManageHouses.Show();
            this.Hide();
        }

        private void manageflatsbutton_Click(object sender, EventArgs e)
        {
            OwnerProfileManageFlats ownerProfileManageFlats = new OwnerProfileManageFlats(userName);
            ownerProfileManageFlats.Show();
            this.Hide();
        }

        private void recivedpaymentbutton_Click(object sender, EventArgs e)
        {
            OwnerRecivedPayment ownerRecivedPayment = new OwnerRecivedPayment(userName);
            ownerRecivedPayment.Show();
            this.Hide();
        }

        private void logbutton_Click(object sender, EventArgs e)
        {
            OwnerLogs ownerLogs = new OwnerLogs(userName);
            ownerLogs.Show();
            this.Hide();
        }

        private void flatfinencialbutton_Click(object sender, EventArgs e)
        {
            OwnerFlatFinencial ownerFlatFinencial = new OwnerFlatFinencial(userName);
            ownerFlatFinencial.Show();
            this.Hide();
        }

        private void occupiedflatsbutton_Click(object sender, EventArgs e)
        {
            OwnerOccupiedFlats ownerOccupiedFlats = new OwnerOccupiedFlats(userName);
            ownerOccupiedFlats.Show();
            this.Hide();
        }

        private void electricbillentrybutton_Click(object sender, EventArgs e)
        {
            OwnerElectricBillEntry ownerElectricBillEntry = new OwnerElectricBillEntry(userName);
            ownerElectricBillEntry.Show();
            this.Hide();
        }

        private void OwnerDashboard_Load(object sender, EventArgs e)
        {
            string query = "SELECT name, username FROM OwnerTable WHERE username = @username";

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
                            ownernamelabel.Text = $"Name : {reader["name"].ToString()}";
                            ownerusernamlabel.Text = $"UserName :{reader["username"].ToString()}";
                        }
                        else
                        {
                            MessageBox.Show("Owner data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            ownerprofilepanel.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void barchart_Click(object sender, EventArgs e)
        {

        }


    }


}

