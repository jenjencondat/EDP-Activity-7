using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClinicInfoSys.Forms
{
    public partial class PasswordRecovery : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=127.0.0.1;uid=root;pwd=jenjen0414;database=clinicinfosys";
        private string role;

        public PasswordRecovery(string role)
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            this.role = role;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            string userEmail = EnterEmailAccTextBox.Text;
            string secu1Answer = Sec1textBox.Text;
            string secu2Answer = Sec2textBox.Text;

            try
            {
                connection.Open();

                string query = $"SELECT Secu1_Answer, Secu2_Answer FROM users WHERE email = @userEmail AND role = @role";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@userEmail", userEmail);
                command.Parameters.AddWithValue("@role", role);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string storedSecu1Answer = reader.GetString("Secu1_Answer");
                    string storedSecu2Answer = reader.GetString("Secu2_Answer");

                    if (secu1Answer == storedSecu1Answer && secu2Answer == storedSecu2Answer)
                    {
                        // Answers matched, allow password reset
                        PasswordResetForm resetPasswordForm = new PasswordResetForm(userEmail);
                        resetPasswordForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Security answers do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email address not found or does not match the specified role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // Close the password recovery form
            this.Close();

            // Show the login form
            LogInForm loginForm = new LogInForm();
            loginForm.Show();
        }
    }
}
