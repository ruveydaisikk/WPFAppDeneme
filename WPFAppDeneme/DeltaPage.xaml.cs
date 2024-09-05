using System.Windows;
using OfficeOpenXml;
using System.IO;
using System;

namespace WPFAppDeneme
{
    public partial class DeltaPage : Window
    {
        public DeltaPage()
        {
            InitializeComponent();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Dosya yolunu kontrol et ve oluştur
            string directoryPath = @"C:\PathToSave";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\DeltaSettings.xlsx";
           
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet;
                if (package.Workbook.Worksheets["Settings"] != null)
                {
                    worksheet = package.Workbook.Worksheets["Settings"];
                }
                else
                {
                    worksheet = package.Workbook.Worksheets.Add("Settings");
                }

                worksheet.Cells[1, 1].Value = "Setting Name";
                worksheet.Cells[1, 2].Value = "Setting Value";

                worksheet.Cells[2, 1].Value = "Operation Mode";
                worksheet.Cells[2, 2].Value = "Manual"; // Örneğin, seçili olan değeri buraya yazabilirsiniz

                package.Save();
            }

            // Dosyanın oluşturulup oluşturulmadığını kontrol et
            if (File.Exists(filePath))
            {
                MessageBox.Show($"Settings saved to Excel successfully at {filePath}!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to save settings to Excel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
