using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicInfoSys.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ClinicInfoSys
{
    class MainProgram
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Initialize database connection
            MySqlConnectionManager connectionManager = new MySqlConnectionManager();

            // Proceed with the rest of your application logic
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm()); // main form
        }
    }
}

namespace ClinicInfoSys
{
    internal class MySqlConnectionManager
    {
        MySqlConnection conn; // Declare a MySqlConnection variable

        public MySqlConnectionManager()
        {
            // Constructor to initialize the MySqlConnectionManager
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=jenjen0414;database=clinicinfosys";

            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                // Connection established successfully, proceed with database operations
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Handle connection error
            }
        }
    }
}
