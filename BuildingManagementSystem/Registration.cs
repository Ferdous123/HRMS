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
    public partial class Registration : Form
    {
        SqlConnection con = 
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public Registration()
        {
            InitializeComponent();
        }

        private void resetInfor()
        {
            registrationfullname.Text = "";
            registrationusername.Text = "";
            registrationemail.Text = "";
            registrationphonenum.Text = "";
            registrationpass.Text = "";
            registrationconpass.Text = "";
        }

        private void signinbutton_Click(object sender, EventArgs e)
        {
            Login newLogin = new Login();
            newLogin.Show();
            this.Hide();
        }

        private void registrationpassshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            registrationpass.UseSystemPasswordChar = false;
            registrationconpass.UseSystemPasswordChar = false;
            registrationpass.PasswordChar = registrationpassshowcheckbox.Checked ? '\0' : '*';
            registrationconpass.PasswordChar = registrationpassshowcheckbox.Checked ? '\0' : '*';
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if(registrationfullname.Text == "" || registrationusername.Text == "" || registrationemail.Text == "" || registrationphonenum.Text == "" || registrationpass.Text == "" || registrationconpass.Text == "")
            {
                MessageBox.Show("Please fill in all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (registrationpass.Text != registrationconpass.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!registrationphonenum.Text.StartsWith("+88"))
            {
                MessageBox.Show("Phone number must start with +88", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!registrationemail.Text.Contains("@") || !registrationemail.Text.Contains(".com"))
            {
                MessageBox.Show("Invalid email address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if(con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();

                        if (registrationcomboBox.SelectedIndex == 0)
                        {
                            string selectUsername = "SELECT COUNT(owner_Id) FROM OwnerTable WHERE username = @username";

                            using (SqlCommand cmd = new SqlCommand(selectUsername, con))
                            {
                                cmd.Parameters.AddWithValue("@username", registrationusername.Text);
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    resetInfor();
                                    return;
                                }
                                else
                                {
                                    string insertData = "INSERT INTO OwnerTable " + " (username, name, email, phone, password) " +
                                        " VALUES (@username, @name, @email, @phone, @password)";
                                    using (SqlCommand cmd2 = new SqlCommand(insertData, con))
                                    {
                                        cmd2.Parameters.AddWithValue("@username", registrationusername.Text);
                                        cmd2.Parameters.AddWithValue("@name", registrationfullname.Text);
                                        cmd2.Parameters.AddWithValue("@email", registrationemail.Text);
                                        cmd2.Parameters.AddWithValue("@phone", registrationphonenum.Text);
                                        cmd2.Parameters.AddWithValue("@password", registrationpass.Text);
                                        cmd2.ExecuteNonQuery();
                                        MessageBox.Show("Owner Registration Successful", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        resetInfor();
                                    }
                                }
                            }
                        }
                        else if (registrationcomboBox.SelectedIndex == 1)
                        {
                            string selectUsername = "SELECT COUNT(manager_Id) FROM ManagerTable WHERE username = @username";

                            using (SqlCommand cmd = new SqlCommand(selectUsername, con))
                            {
                                cmd.Parameters.AddWithValue("@username", registrationusername.Text);
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    resetInfor();
                                    return;
                                }
                                else
                                {
                                    string insertData = "INSERT INTO ManagerTable " + " (username, name, email, phone, password) " +
                                        " VALUES (@username, @name, @email, @phone, @password)";
                                    using (SqlCommand cmd2 = new SqlCommand(insertData, con))
                                    {
                                        cmd2.Parameters.AddWithValue("@username", registrationusername.Text);
                                        cmd2.Parameters.AddWithValue("@name", registrationfullname.Text);
                                        cmd2.Parameters.AddWithValue("@email", registrationemail.Text);
                                        cmd2.Parameters.AddWithValue("@phone", registrationphonenum.Text);
                                        cmd2.Parameters.AddWithValue("@password", registrationpass.Text);
                                        cmd2.ExecuteNonQuery();
                                        MessageBox.Show("Manager Registration Successful", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        resetInfor();
                                    }
                                }
                            }
                        }
                        else if (registrationcomboBox.SelectedIndex == 2)
                        {
                            string selectUsername = "SELECT COUNT(tenant_Id) FROM TenantTable WHERE username = @username";

                            using (SqlCommand cmd = new SqlCommand(selectUsername, con))
                            {
                                cmd.Parameters.AddWithValue("@username", registrationusername.Text);
                                int count = (int)cmd.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    resetInfor();
                                    return;
                                }
                                else
                                {
                                    string insertData = "INSERT INTO TenantTable " + " (username, name, email, phone, password) " +
                                        " VALUES (@username, @name, @email, @phone, @password)";
                                    using (SqlCommand cmd2 = new SqlCommand(insertData, con))
                                    {
                                        cmd2.Parameters.AddWithValue("@username", registrationusername.Text);
                                        cmd2.Parameters.AddWithValue("@name", registrationfullname.Text);
                                        cmd2.Parameters.AddWithValue("@email", registrationemail.Text);
                                        cmd2.Parameters.AddWithValue("@phone", registrationphonenum.Text);
                                        cmd2.Parameters.AddWithValue("@password", registrationpass.Text);
                                        cmd2.ExecuteNonQuery();
                                        MessageBox.Show("Tenant Registration Successful", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        resetInfor();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}
