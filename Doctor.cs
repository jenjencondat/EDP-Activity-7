using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicInfoSys.Forms
{
    public partial class Doctor : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;uid=root;pwd=jenjen0414;database=clinicinfosys"; // Update with your MySQL connection string

        public Doctor()
        {
            InitializeComponent();
            PopulateDataGridView();
            PopulateGenderComboBox();
        }

        private void PopulateDataGridView()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "SELECT * FROM Doctors";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
                dataGridViewDoctor.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void PopulateGenderComboBox()
        {
            // Add "Male" and "Female" options to the GenderComboBox
            GenderComboBox.Items.Add("Male");
            GenderComboBox.Items.Add("Female");
        }


        // Add a global variable to track the edited row index
        private int editedRowIndex = -1;



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Enable editing of the selected row
            dataGridViewDoctor.BeginEdit(true);

            // Store the index of the edited row
            editedRowIndex = e.RowIndex;
        }


        private void button10_Click(object sender, EventArgs e)
        {
            // Activate the selected row in the database
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Get the ID and status of the selected row
                int selectedRowID = Convert.ToInt32(dataGridViewDoctor.CurrentRow.Cells["DoctorID"].Value);
                string status = dataGridViewDoctor.CurrentRow.Cells["Status"].Value.ToString();

                if (status == "Inactive")
                {
                    string query = "UPDATE Doctors SET status = 'Active' WHERE DoctorID = @id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", selectedRowID);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update the status of the selected row in the DataGridView
                        dataGridViewDoctor.CurrentRow.Cells["Status"].Value = "Active";

                        MessageBox.Show("Account activated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No records were updated.");
                    }
                }
                else
                {
                    MessageBox.Show("The selected account is already active.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void UpdateRecord(int rowIndex)
        {
            try
    {
        // Check if DataGridView is in edit mode
        if (dataGridViewDoctor.IsCurrentRowDirty)
        {
            dataGridViewDoctor.EndEdit(); // End edit mode
        }

        // Check if the specified row index is valid
        if (rowIndex >= 0 && rowIndex < dataGridViewDoctor.Rows.Count)
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();

            // Construct the UPDATE query
            StringBuilder queryBuilder = new StringBuilder("UPDATE Doctors SET ");
            for (int i = 0; i < dataGridViewDoctor.Columns.Count; i++)
            {
                queryBuilder.Append($"{dataGridViewDoctor.Columns[i].Name} = @{dataGridViewDoctor.Columns[i].Name}");
                if (i < dataGridViewDoctor.Columns.Count - 1)
                {
                    queryBuilder.Append(", ");
                }
            }
            queryBuilder.Append(" WHERE DoctorID = @id");

            MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), connection);

            // Set parameter values for each column in the DataGridView
            for (int i = 0; i < dataGridViewDoctor.Columns.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@{dataGridViewDoctor.Columns[i].Name}", dataGridViewDoctor.Rows[rowIndex].Cells[i].Value);
            }

            // Set the parameter value for the WHERE clause (DoctorID)
            cmd.Parameters.AddWithValue("@id", dataGridViewDoctor.Rows[rowIndex].Cells["DoctorID"].Value);

            // Execute the UPDATE query
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                // If the update was successful, update the corresponding row in the DataGridView
                foreach (DataGridViewCell cell in dataGridViewDoctor.Rows[rowIndex].Cells)
                {
                    cell.Value = cell.OwningRow.Cells[cell.ColumnIndex].Value;
                }

                MessageBox.Show("Record updated successfully.");
            }
            else
            {
                MessageBox.Show("No records were updated.");
            }
        }
        else
        {
            MessageBox.Show("Invalid row index.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
    finally
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
}


        private void button7_Click(object sender, EventArgs e)
        {
            // Update changes in the DataGridView back to the database
            // Check if a row is selected
            if (dataGridViewDoctor.SelectedRows.Count > 0)
            {
                // Get the index of the selected row
                int rowIndex = dataGridViewDoctor.SelectedRows[0].Index;

                // Call the UpdateRecord method with the row index
                UpdateRecord(rowIndex);
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Delete the selected row from the database
            // Check if a row is selected
            if (dataGridViewDoctor.SelectedRows.Count > 0)
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        connection = new MySqlConnection(connectionString);
                        connection.Open();

                        // Construct the DELETE query
                        string query = "DELETE FROM Doctors WHERE DoctorID = @id";

                        MySqlCommand cmd = new MySqlCommand(query, connection);

                        // Set the parameter value for the WHERE clause (DoctorID)
                        cmd.Parameters.AddWithValue("@id", dataGridViewDoctor.SelectedRows[0].Cells["DoctorID"].Value);

                        // Execute the DELETE query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record deleted successfully.");

                            // Remove the selected row from the DataGridView
                            dataGridViewDoctor.Rows.Remove(dataGridViewDoctor.SelectedRows[0]);
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Deactivate the selected row in the database
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                // Get the ID of the selected row
                int selectedRowID = Convert.ToInt32(dataGridViewDoctor.CurrentRow.Cells["DoctorID"].Value);

                string query = "UPDATE Doctors SET status = 'Inactive' WHERE DoctorID = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", selectedRowID);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Update the status of the selected row in the DataGridView
                    dataGridViewDoctor.CurrentRow.Cells["Status"].Value = "Inactive";

                    MessageBox.Show("Account deactivated successfully.");
                }
                else
                {
                    MessageBox.Show("No records were updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO Doctors (DFirstName, DLastName, Gender, DContactNum, Address, BirthDate, DSpecialization, Username, Password) " +
                "VALUES (@FirstName, @LastName, @Gender, @ContactNumber, @Address, @BirthDate, @Specialization, @Username, @Password)";


                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Assign values from UI controls to parameters
                cmd.Parameters.AddWithValue("@FirstName", DocFirstNameTextBox.Text);
                cmd.Parameters.AddWithValue("@LastName", DocLastNameTextBox.Text);
                cmd.Parameters.AddWithValue("@Gender", GenderComboBox.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ContactNumber", ContactNumberTextBox.Text);
                cmd.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                cmd.Parameters.AddWithValue("@BirthDate", BirthDatetextBox.Text); // Ensure the correct format
                cmd.Parameters.AddWithValue("@Specialization", SpecializationTextBox.Text);
                cmd.Parameters.AddWithValue("@Username", DusernametextBox.Text);
                cmd.Parameters.AddWithValue("@Password", DPasswordtextBox.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record added successfully.");
                    // Refresh the DataGridView to reflect the changes
                    PopulateDataGridView();

                    // Clear textboxes and combo box
                    DocFirstNameTextBox.Clear();
                    DocLastNameTextBox.Clear();
                    GenderComboBox.SelectedIndex = -1; // Clear selected item
                    ContactNumberTextBox.Clear();
                    AddressTextBox.Clear();
                    BirthDatetextBox.Clear();
                    SpecializationTextBox.Clear();
                    DusernametextBox.Clear();
                    DPasswordtextBox.Clear();

                }
                else
                {
                    MessageBox.Show("Failed to add record.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void GenderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                bool found = false;
                // Iterate through each row in the DataGridView
                foreach (DataGridViewRow row in dataGridViewDoctor.Rows)
                {
                    // Reset row style to default
                    row.DefaultCellStyle.BackColor = Color.White;

                    // Check if the row is in edit mode or is the new row
                    if (!row.Selected && !row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Check if the cell value contains the search text
                            if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                            {
                                // If a match is found, highlight the row, set found to true, and scroll to the row
                                row.DefaultCellStyle.BackColor = Color.LightYellow;
                                found = true;
                                dataGridViewDoctor.FirstDisplayedScrollingRowIndex = row.Index;
                                break;
                            }
                        }
                    }
                }
                // If no match is found, show a message
                if (!found)
                {
                    MessageBox.Show("Information not found.");
                }
            }
            else
            {
                // If search box is empty, reset all row styles to default
                foreach (DataGridViewRow row in dataGridViewDoctor.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void GoSearchButton_Click(object sender, EventArgs e)
        {
            // Trigger the search when the Go button is clicked
            SearchBox_TextChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Prompt the user if they are sure they want to log out
    DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Close the current form (Doctor form) and show the login form
                this.Hide();
                LogInForm loginForm = new LogInForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }
    }
}
