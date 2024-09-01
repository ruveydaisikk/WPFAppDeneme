using System;
using System.Windows;
using System.Windows.Controls;
using Excel = Microsoft.Office.Interop.Excel;

namespace WPFAppDeneme
{
    public partial class ErrorReportWindow : Window
    {
        private string errorDetails;

        public ErrorReportWindow(string appName)
        {
            InitializeComponent();
        }

        public ErrorReportWindow(string appName, string errorDetails) : this(appName)
        {
            this.errorDetails = errorDetails;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string category = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();
            string errorDetails = ErrorDetailsBox.Text;

            try
            {
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not installed.");
                    return;
                }

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ErrorReports.xlsx";
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

                    
                    worksheet.Cells[1, 1] = "Category";
                    worksheet.Cells[1, 2] = "Error Details";
                }

             
                int lastRow = worksheet.Cells[worksheet.Rows.Count, 1].End(Excel.XlDirection.xlUp).Row + 1;

             
                worksheet.Cells[lastRow, 1] = category;
                worksheet.Cells[lastRow, 2] = errorDetails;

                
                workbook.SaveAs(filePath);
                workbook.Close(false);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to Excel: " + ex.Message);
            }

            MessageBox.Show("Error report saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
