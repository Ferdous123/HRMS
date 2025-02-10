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
    public partial class ManagerDashBoard : Form
    {
        private string userName;

        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public ManagerDashBoard(String username)
        {
            InitializeComponent();
            managerprofilepanel.Visible = false;
            this.userName = username;
        }

        private void managerprofilepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managerprofilebutton_Click(object sender, EventArgs e)
        {
            string query = "SELECT name, username, email, phone FROM ManagerTable WHERE username = @username";

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

            managerprofilepanel.Visible = true;
        }

        private void managertenantsbutton_Click(object sender, EventArgs e)
        {
            managerprofilepanel.Visible = false;
            ManagerTenants managerTenants = new ManagerTenants(userName);
            managerTenants.Show();
            this.Hide();
        }

        private void managerdashboardbutton_Click(object sender, EventArgs e)
        {
            managerprofilepanel.Visible = false;
        }

        private void managerdashboardlogoutbbutton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void manageoccupationhistrybutton_Click(object sender, EventArgs e)
        {
            ManagerOccupationHistory managerOccupationHistory = new ManagerOccupationHistory(userName);
            managerOccupationHistory.Show();
            this.Hide();
        }

        private void managerchangepasswordbutton_Click(object sender, EventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.Show();
            this.Hide();
        }

        private void manageremptyflatsbutton_Click(object sender, EventArgs e)
        {
            ManagerEmptyFlats managerEmptyFlats = new ManagerEmptyFlats(userName);
            managerEmptyFlats.Show();
            this.Hide();
        }

        private void managerpaymentdetailsbbutton_Click(object sender, EventArgs e)
        {
            ManagerPaymentDetails managerPaymentDetails = new ManagerPaymentDetails(userName);
            managerPaymentDetails.Show();
            this.Hide();
        }

        private void managerelectricbillentrybutton_Click(object sender, EventArgs e)
        {
            ManagerElectricBillEntry managerElectricBillEntry = new ManagerElectricBillEntry(userName);
            managerElectricBillEntry.Show();
            this.Hide();
        }

        private void managernoticebutton_Click(object sender, EventArgs e)
        {
            ManagerNotice managerNotice = new ManagerNotice(userName);
            managerNotice.Show();
            this.Hide();
        }

        private void managerelectricbillentrybutton_Click_1(object sender, EventArgs e)
        {
            ManagerElectricBillEntry managerElectricBillEntry = new ManagerElectricBillEntry(userName);
            managerElectricBillEntry.Show();
            this.Hide();
        }

        private void managerflatfinencialsbutton_Click(object sender, EventArgs e)
        {
            ManagerFlatFinencial managerFlatFinencial = new ManagerFlatFinencial(userName);
            managerFlatFinencial.Show();
            this.Hide();
        }

        private void managerlogbutton_Click(object sender, EventArgs e)
        {
            ManagerLog managerLog = new ManagerLog(userName);
            managerLog.Show();
            this.Hide();
        }

        private void managertotalduesbutton_Click(object sender, EventArgs e)
        {
            ManagerTotalDues managerTotalDues = new ManagerTotalDues(userName);
            managerTotalDues.Show();
            this.Hide();
        }

        private void ManagerDashBoard_Load(object sender, EventArgs e)
        {
            string query = "SELECT name, username FROM ManagerTable WHERE username = @username";

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
                            managernamelabel.Text = $"Name : {reader["name"].ToString()}";
                            managerusernamelabel.Text = $"UserName :{reader["username"].ToString()}";
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

            managerprofilepanel.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void managerratinglabel_Click(object sender, EventArgs e)
        {

        }
    }
}
