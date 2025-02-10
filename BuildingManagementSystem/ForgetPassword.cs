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
    public partial class ForgetPassword : Form
    {
        SqlConnection con =
        new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Rahat\Archive\HouseManagementSystem.mdf;Integrated Security=True;Connect Timeout=30");

        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void resetInfor()
        {
            forgetpasstextbox.Text = "";
            forgetpageconfirmtextbox.Text = "";
            phonenumtextbox.Text = "";
            forgetpagetextbox.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginpassshowcheckbox_CheckedChanged(object sender, EventArgs e)
        {
            forgetpagetextbox.UseSystemPasswordChar = false;
            forgetpageconfirmtextbox.UseSystemPasswordChar = false;
            forgetpagetextbox.PasswordChar = loginpassshowcheckbox.Checked ? '\0' : '•';
            forgetpageconfirmtextbox.PasswordChar = loginpassshowcheckbox.Checked ? '\0' : '•';
        }

        private void forgetpasstextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            if (forgetpageconfirmtextbox.Text == "" || forgetpagetextbox.Text == "" || forgetpasstextbox.Text == "" || phonenumtextbox.Text == "")
            {
                MessageBox.Show("Please fill in all the fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (forgetpageconfirmtextbox.Text != forgetpagetextbox.Text)
            {
                MessageBox.Show("Passwords do not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();

                        if (forgetuserchoosecomboBox.SelectedIndex == 0)
                        {
                            string query = "UPDATE OwnerTable SET [password] = @password WHERE [email] = @email AND [phone] = @phone";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@password", forgetpagetextbox.Text);
                                cmd.Parameters.AddWithValue("@email", forgetpasstextbox.Text);
                                cmd.Parameters.AddWithValue("@phone", phonenumtextbox.Text);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Password updated successfully", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    resetInfor();
                                }
                                else
                                {
                                    MessageBox.Show("No matching record found. Please check your email and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else if (forgetuserchoosecomboBox.SelectedIndex == 1)
                        {
                            string query = "UPDATE ManagerTable SET [password] = @password WHERE [email] = @email AND [phone] = @phone";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@password", forgetpagetextbox.Text);
                                cmd.Parameters.AddWithValue("@email", forgetpasstextbox.Text);
                                cmd.Parameters.AddWithValue("@phone", phonenumtextbox.Text);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Password updated successfully", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    resetInfor();
                                }
                                else
                                {
                                    MessageBox.Show("No matching record found. Please check your email and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else if (forgetuserchoosecomboBox.SelectedIndex == 2)
                        {
                            string query = "Update TenantTable SET [password] = @password WHERE [email] = @email AND [phone] = @phone";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@password", forgetpagetextbox.Text);
                                cmd.Parameters.AddWithValue("@email", forgetpasstextbox.Text);
                                cmd.Parameters.AddWithValue("@phone", phonenumtextbox.Text);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Password updated successfully", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    resetInfor();
                                }
                                else
                                {
                                    MessageBox.Show("No matching record found. Please check your email and phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void ForgetPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
