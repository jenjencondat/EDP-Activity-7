using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicInfoSys.Forms
{
    public partial class LogInForm : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;uid=root;pwd=jenjen0414;database=clinicinfosys";
        // Public properties to expose controls
        public PictureBox JENLoginPicture => jenloginpicture;
        public Label SystemName => systemName;
        public LogInForm()
        {
            InitializeComponent();

            // Populate the combo box with roles
            comboBoxRole.Items.Add("Admin");
            comboBoxRole.Items.Add("Doctor");
            // Select the first item by default
            comboBoxRole.SelectedIndex = 0;

            // Initialize database connection
            connection = new MySqlConnection(connectionString);
        }

        private void buttonLogIn_Click_1(object sender, EventArgs e)
        {
            // Retrieve username and password from text boxes
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            string role = comboBoxRole.SelectedItem.ToString();

            // Perform basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Authenticate user
            bool isAuthenticated = AuthenticateUser(username, password, role);

            // Handle authentication result
            if (isAuthenticated)
            {
                // Authentication successful
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceed to open main application form or dashboard form
                // Replace MainForm with the name of your main form
                Dashboard mainForm = new Dashboard();
                mainForm.Show();
                this.Hide(); // Hide the login form
            }
            else
            {
                // Authentication failed
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to authenticate user
        private bool AuthenticateUser(string username, string password, string role)
        {
            try
            {
                connection.Open();

                string query = "SELECT * FROM users WHERE username=@username AND password=@password AND role=@role";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@role", role);

                MySqlDataReader reader = command.ExecuteReader();
                bool result = reader.HasRows;

                reader.Close();
                connection.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void ForgotPassLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the Password Recovery Form and pass the role
            PasswordRecovery passwordRecoveryForm = new PasswordRecovery(comboBoxRole.SelectedItem.ToString());
            passwordRecoveryForm.Show();
            this.Hide(); // Optionally, hide the Log In Form
        }
    }
}
