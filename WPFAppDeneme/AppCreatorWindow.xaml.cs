using System;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace WPFAppDeneme
{
    public partial class AppCreatorWindow : Window
    {
        public AppCreatorWindow()
        {
            InitializeComponent();
        }

        private void CreateAppButton_Click(object sender, RoutedEventArgs e)
        {
            string appName = AppNameTextBox.Text;
            string selectedCategory = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();
            string creationDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm"); // Tarih formatı: Gün-Ay-Yıl Saat:Dakika

            try
            {
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not installed.");
                    return;
                }

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ApplicationsList.xlsx";
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

                    // Başlıkları ekleyin
                    worksheet.Cells[1, 1] = "Application Name";
                    worksheet.Cells[1, 2] = "Category";
                    worksheet.Cells[1, 3] = "Creation Date"; // Yeni sütun: Kayıt Tarihi
                }

                // Son satırı bulup yeni veriyi ekleyin
                int lastRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Excel.XlDirection.xlUp).Row + 1;

                worksheet.Cells[lastRow, 1] = appName;
                worksheet.Cells[lastRow, 2] = selectedCategory;
                worksheet.Cells[lastRow, 3] = creationDate; // Kayıt tarihini ekleyin

                // Hücre genişliğini otomatik ayarla
                worksheet.Columns["A:C"].AutoFit();

                workbook.SaveAs(filePath);
                workbook.Close(false);
                excelApp.Quit();

                MessageBox.Show("Application created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to Excel: " + ex.Message);
            }

            // Formu temizleyin
            AppNameTextBox.Clear();
            CategoryComboBox.SelectedIndex = 0;
        }
    }
}
