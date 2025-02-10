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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to resign after this month? This action is non-reversible.", "Confirm Resignation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string query = "SELECT house_id, start_date, end_date FROM ManagerHouseTable WHERE manager_id = (SELECT manager_id FROM ManagerTable WHERE username = @username)";
                List<int> houseIds = new List<int>();

                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", userName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                houseIds.Add((int)reader["house_id"]);
                            }
                        }
                    }

                    if (houseIds.Count == 0)
                    {
                        MessageBox.Show("No records found for the manager.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int selectedHouseId = houseIds.Count == 1 ? houseIds[0] : ShowHouseSelectionDialog(houseIds);

                    if (selectedHouseId != -1)
                    {
                        string updateQuery = "UPDATE ManagerHouseTable SET end_date = @end_date WHERE manager_id = (SELECT manager_id FROM ManagerTable WHERE username = @username) AND house_id = @house_id";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                        {
                            updateCmd.Parameters.AddWithValue("@end_date", DateTime.Now.AddMonths(1));
                            updateCmd.Parameters.AddWithValue("@username", userName);
                            updateCmd.Parameters.AddWithValue("@house_id", selectedHouseId);

                            updateCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Resignation processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private int ShowHouseSelectionDialog(List<int> houseIds)
        {
            using (Form selectionForm = new Form())
            {
                selectionForm.Text = "Select House";
                selectionForm.Size = new Size(300, 200);

                ListBox listBox = new ListBox();
                listBox.Dock = DockStyle.Fill;
                listBox.SelectionMode = SelectionMode.One;
                listBox.DataSource = houseIds;

                Button selectButton = new Button();
                selectButton.Text = "Select";
                selectButton.Dock = DockStyle.Bottom;
                selectButton.DialogResult = DialogResult.OK;

                selectionForm.Controls.Add(listBox);
                selectionForm.Controls.Add(selectButton);

                if (selectionForm.ShowDialog() == DialogResult.OK)
                {
                    return (int)listBox.SelectedItem;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
