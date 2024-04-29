using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using OfficeOpenXml.Drawing;

namespace ClinicInfoSys.Forms
{
    public partial class Report : Form
    { 

        public Report()
        {
            InitializeComponent();
            comboBoxReportType.SelectedIndexChanged += comboBoxReportType_SelectedIndexChanged;
            btnExport.Click += btnExport_Click;
            // Set the LicenseContext to suppress the license exception
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void comboBoxReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReportType = comboBoxReportType.SelectedItem.ToString();

            switch (selectedReportType)
            {
                case "Appointments":
                    DisplayAppointmentsData();
                    break;
                case "Patients":
                    DisplayPatientsData();
                    break;
                case "Doctors":
                    DisplayDoctorsData();
                    break;
                case "Treatments":
                    DisplayTreatmentsData();
                    break;
                default:
                    MessageBox.Show("Invalid report type selected.");
                    break;
            }
        }
        private void DisplayAppointmentsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=jenjen0414;database=clinicinfosys;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM appointments", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportlist.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying recent login data: " + ex.Message);
            }
        }
        private void DisplayPatientsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=jenjen0414;database=clinicinfosys;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM patients", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportlist.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying recent login data: " + ex.Message);
            }
        }
        private void DisplayDoctorsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=jenjen0414;database=clinicinfosys;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM doctors", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportlist.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying recent login data: " + ex.Message);
            }
        }
        private void DisplayTreatmentsData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=jenjen0414;database=clinicinfosys;"))
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM treatments", conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        reportlist.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying recent login data: " + ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Instantiate the login form
                LogInForm loginForm = new LogInForm();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        // Sheet 1: Report data
                        ExcelWorksheet ws1 = excelPackage.Workbook.Worksheets.Add("Sheet1");


                        // Save the logo image to a temporary file with a valid image extension
                        string tempLogoPath = System.IO.Path.GetTempFileName();
                        tempLogoPath = System.IO.Path.ChangeExtension(tempLogoPath, ".png");

                        // Access the PictureBox from the login form
                        loginForm.JENLoginPicture.Image.Save(tempLogoPath, System.Drawing.Imaging.ImageFormat.Png);

                        // Add the logo image to cell A3 with size 50px
                        ExcelPicture logoPicture = ws1.Drawings.AddPicture("Logo", new System.IO.FileInfo(tempLogoPath));
                        logoPicture.SetPosition(1, 0, 0, 0); // Position at cell A3 with size 50px
                        logoPicture.SetSize(70, 70);

                        // Get the brand name from Label
                        string brandName = loginForm.SystemName.Text;


                        // Insert brand name into cell B3 and set font
                        ws1.Cells["B3"].Value = brandName;
                        ws1.Cells["B3"].Style.Font.Name = "Palatino Linotype";
                        ws1.Cells["B3"].Style.Font.Size = 20.8f;
                        ws1.Cells["B3"].Style.Font.Bold = true;

                        // Add signature placeholder
                        ws1.Cells["B5"].Value = "Signature: ______________________";

                        // Export DataGridView data to Sheet 1
                        DataTable dt = (DataTable)reportlist.DataSource;
                        ws1.Cells["A7"].LoadFromDataTable(dt, true);

                        // Adjust column width for date and time columns
                        for (int i = 1; i <= dt.Columns.Count; i++)
                        {
                            DataColumn column = dt.Columns[i - 1];
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                int rowIndex = j + 7; // Adjust for header rows
                                if (DateTime.TryParse(dt.Rows[j][column].ToString(), out DateTime value))
                                {
                                    if (value.TimeOfDay.TotalSeconds > 0) // If time component is present
                                    {
                                        ws1.Cells[rowIndex, i].Style.Numberformat.Format = "h:mm:ss";
                                    }
                                    else // If only date component is present
                                    {
                                        ws1.Cells[rowIndex, i].Style.Numberformat.Format = "dd-mm-yyyy";
                                    }
                                }
                            }

                            // Auto fit column width after formatting
                            ws1.Column(i).AutoFit();
                        }
                        // Format last row separately
                        int lastRowIndex = dt.Rows.Count + 7; // Adjust for header rows
                        for (int i = 1; i <= dt.Columns.Count; i++)
                        {
                            DataColumn column = dt.Columns[i - 1];
                            if (DateTime.TryParse(dt.Rows[dt.Rows.Count - 1][column].ToString(), out DateTime value))
                            {
                                if (value.TimeOfDay.TotalSeconds > 0) // If time component is present
                                {
                                    ws1.Cells[lastRowIndex, i].Style.Numberformat.Format = "h:mm:ss";
                                }
                                else // If only date component is present
                                {
                                    ws1.Cells[lastRowIndex, i].Style.Numberformat.Format = "dd-mm-yyyy";
                                }
                            }
                        }
                        // Generate the chart
                        ExcelWorksheet ws2 = excelPackage.Workbook.Worksheets.Add("Sheet2");

                        // Create the chart
                        var chart = ws2.Drawings.AddChart("Chart", OfficeOpenXml.Drawing.Chart.eChartType.ColumnClustered);
                        chart.Title.Text = "Data Chart";
                        chart.SetPosition(1, 0, 4, 0);
                        chart.SetSize(600, 400);
                        chart.Series.Add(ws1.Cells["A7:A" + (7 + reportlist.RowCount - 1)], ws1.Cells["B7:B" + (7 + reportlist.RowCount - 1)]);

                        // Save Excel file
                        excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Data exported successfully!");

                        // Save Excel file
                        excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Data exported successfully!");

                        // Dispose the SaveFileDialog
                        saveFileDialog.Dispose();

                        // Delete the temporary logo file
                        System.IO.File.Delete(tempLogoPath);
                    }
                }
            }
            catch (LicenseException)
            {
                MessageBox.Show("EPPlus license is invalid. Please make sure you are using a valid license.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message);
            }
        }
    }
}