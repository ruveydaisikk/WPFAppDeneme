using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace WPFAppDeneme
{
    public partial class AdminAddingWindow : Window
    {
        public AdminAddingWindow()
        {
            InitializeComponent();
        }

        private void AddAdminButton_Click(object sender, RoutedEventArgs e)
        {
            
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not installed.");
                    return;
                }

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AdminList.xlsx";
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;

                if (System.IO.File.Exists(filePath))
                {
                    workbook = excelApp.Workbooks.Open(filePath);
                    worksheet = workbook.Sheets[1];
                }
                else
                {
                    workbook = excelApp.Workbooks.Add();
                    worksheet = workbook.Worksheets[1];

                    
                    worksheet.Cells[1, 1] = "Username";
                    worksheet.Cells[1, 2] = "Email";
                    worksheet.Cells[1, 3] = "Password";
                }

               
                int lastRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Excel.XlDirection.xlUp).Row + 1;

            
                worksheet.Cells[lastRow, 1] = username;
                worksheet.Cells[lastRow, 2] = email;
                worksheet.Cells[lastRow, 3] = password;

             
                workbook.SaveAs(filePath);
                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show($"Admin '{username}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to Excel: " + ex.Message);
            }

            UsernameTextBox.Clear();
            EmailTextBox.Clear();
            PasswordBox.Clear();
        }
    }
}
