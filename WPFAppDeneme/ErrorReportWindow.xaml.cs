using System;
using System.Collections.Generic;
using System.IO;
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

namespace WPFAppDeneme
{
    public partial class ErrorReportWindow : Window
    {
        private string _appName;

        public ErrorReportWindow(string appName, string errorDetails)
        {
            InitializeComponent();
            _appName = appName;
            Title = $"Error Report for {_appName}";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected category
            string selectedCategory = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();

            // Get the error details
            string errorDetails = ErrorDetailsBox.Text;

            // Save the error details and category
            string fileName = $"{_appName}_Errors.txt";
            string content = $"Category: {selectedCategory}\n\nError Details:\n{errorDetails}";
            File.WriteAllText(fileName, content);

            MessageBox.Show("Error details saved successfully.");
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}