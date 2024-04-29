using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicInfoSys.Forms
{
    public partial class PasswordResetForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=127.0.0.1;uid=root;pwd=jenjen0414;database=clinicinfosys";
        private string userEmail;

        // Constructor that accepts the username
        public PasswordResetForm(string userEmail)
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            this.userEmail = userEmail;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordResetForm_Load(object sender, EventArgs e)
        {

        }

        private void ShowPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility based on checkbox state
            textBox1.UseSystemPasswordChar = !ShowPassCheckBox.Checked;
            textBox2.UseSystemPasswordChar = !ShowPassCheckBox.Checked;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text;
            string reEnterNewPassword = textBox2.Text;

            if (newPassword != reEnterNewPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                // Update the user's password in the database
                string query = "UPDATE users SET Password = @newPassword WHERE Email = @userEmail";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@newPassword", newPassword);
                command.Parameters.AddWithValue("@userEmail", userEmail);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Password successfully reset.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to reset password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // Close the password reset form
            this.Close();

            // Show the login form
            LogInForm loginForm = new LogInForm();
            loginForm.Show();
        }
    }
}
