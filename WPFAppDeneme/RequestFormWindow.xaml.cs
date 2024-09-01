using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace WPFAppDeneme
{
    public partial class RequestFormWindow : System.Windows.Window
    {
        public RequestFormWindow()
        {
            InitializeComponent();
            OpenDatePicker.Text = "Select a date";
        }
        private void OpenDatePicker_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OpenDatePicker.SelectedDate.HasValue)
            {
                OpenDatePicker.Text = OpenDatePicker.SelectedDate.Value.ToShortDateString();
            }
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            string appName = AppNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string openDate = OpenDatePicker.SelectedDate.HasValue ? OpenDatePicker.SelectedDate.Value.ToShortDateString() : OpenDatePicker.Text;

            string selectedCategories = "";
            if (MaterialCheckBox.IsChecked == true) selectedCategories += "Material ";
            if (StructuralCheckBox.IsChecked == true) selectedCategories += "Structural ";
            if (ThermalCheckBox.IsChecked == true) selectedCategories += "Thermal ";
            if (MechanicalCheckBox.IsChecked == true) selectedCategories += "Mechanical ";

            try
            {
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel yüklü değil.");
                    return;
                }

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ApplicationRequest.xlsx";
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;

                if (System.IO.File.Exists(filePath))
                {
                    // Eğer dosya zaten varsa, mevcut dosyayı aç
                    workbook = excelApp.Workbooks.Open(filePath);
                    worksheet = workbook.Worksheets[1];
                }
                else
                {
                    // Eğer dosya yoksa, yeni bir dosya oluştur
                    workbook = excelApp.Workbooks.Add();
                    worksheet = workbook.Worksheets[1];

                    // Başlıkları ekle
                    worksheet.Cells[1, 1] = "Application Name";
                    worksheet.Cells[1, 2] = "Opening Date";
                    worksheet.Cells[1, 3] = "Request Description";
                    worksheet.Cells[1, 4] = "Categories";
                }

                // Mevcut son satırı bul
                int lastRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Excel.XlDirection.xlUp).Row;

                // Yeni veriyi ekle
                worksheet.Cells[lastRow + 1, 1] = appName;
                worksheet.Cells[lastRow + 1, 2] = openDate;
                worksheet.Cells[lastRow + 1, 3] = description;
                worksheet.Cells[lastRow + 1, 4] = selectedCategories.Trim();

                workbook.SaveAs(filePath);
                workbook.Close(false);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel'e kaydetme hatası: " + ex.Message);
            }

            MessageBox.Show($"Form başarıyla kaydedildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private void CancelRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}