using System;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;
using System.Security.Cryptography;
using System.Text;
using OfficeOpenXml;
using System.IO;
using System.Linq;

namespace WPFAppDeneme
{
    public partial class AdminAddingWindow : Window
    {
        public AdminAddingWindow()
        {
            InitializeComponent();
        }

        private void SaveUserDataToExcel(string username, string password)
        {
            // Excel dosya yolu
            string filePath = "KullaniciVerileri.xlsx";

            // EPPlus kütüphanesi ile Excel dosyasını aç veya oluştur
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Sheet1");

                int row = 1;  // Veriyi ekleyeceğiniz satır numarası
                int col = 1;  // Veriyi ekleyeceğiniz sütun numarası

                // Kullanıcı adı ekle
                worksheet.Cells[row, col].Value = username;
                worksheet.Cells[row, col + 1].Style.Numberformat.Format = ";;;";


                // Parolayı gizlemek için yıldız işareti ekle
                string hiddenPassword = new string('*', password.Length);
                worksheet.Cells[row, col + 1].Value = hiddenPassword;

                // Excel dosyasını kaydet
                package.Save();
            }
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
                // Hash the password
                string hashedPassword = HashPassword(password);
                // Encode the hashed password
                string encodedPassword = EncodePassword(hashedPassword);

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
                worksheet.Cells[lastRow, 3] = encodedPassword;

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


    private string HashPassword(string password)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
      

private string EncodePassword(string hashedPassword)
{
    // Encode the hashed password using Base64 or another encoding method
    byte[] bytes = Encoding.UTF8.GetBytes(hashedPassword);
    return Convert.ToBase64String(bytes);

        }
    }
}
