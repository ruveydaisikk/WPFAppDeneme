using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFAppDeneme.Models;

namespace WPFAppDeneme
{
    public partial class MainWindow : Window
    {
        private string counterFilePath = "userCount.txt";

        public MainWindow()
        {
            InitializeComponent();
            UpdateDailyLoginCount();

        }
        private void UpdateDailyLoginCount()
        {
            int dailyUserCount = 0;
            DateTime lastLoginDate = DateTime.MinValue;

            // Read the current count and last login date from the file, if it exists
            if (File.Exists(counterFilePath))
            {
                string[] lines = File.ReadAllLines(counterFilePath);
                if (lines.Length >= 2)
                {
                    int.TryParse(lines[0], out dailyUserCount);
                    DateTime.TryParse(lines[1], out lastLoginDate);
                }
            }

            // Get today's date
            DateTime currentDate = DateTime.Now.Date;

            // Check if the current date is different from the last login date
            if (currentDate > lastLoginDate)
            {
                dailyUserCount = 1;  // Reset count for a new day
                lastLoginDate = currentDate;
            }
            else
            {
                dailyUserCount++; // Increment for the same day
            }

            // Save the updated count and last login date back to the file
            File.WriteAllLines(counterFilePath, new string[] { dailyUserCount.ToString(), lastLoginDate.ToString() });

            // Update the TextBlock to display the daily login count
            UserCountTextBlock.Text = $"Daily Login: {dailyUserCount}";
        }
    
    private void EngineeringTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://en.wikipedia.org/wiki/Engineering")
            {
                UseShellExecute = true
            });

        }
        private void PluginsTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://wordpress.org/plugins/",
                UseShellExecute = true
            });
        }

        private void ProductivityTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.investopedia.com/terms/p/productivity.asp",
                UseShellExecute = true
            });
        }

        private void SuggestionsTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://mail.google.com/",
                UseShellExecute = true
            });
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search...")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black; // Metin rengi değiştirilebilir
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Search...";
                SearchBox.Foreground = Brushes.Gray; // Yer tutucu metin rengini geri getir
            }

        }
        private void AdminTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // LoginWindow'u oluşturup açın
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

        }
        private void OpenRequestForm_Click(object sender, RoutedEventArgs e)
        {
            RequestFormWindow requestFormWindow = new RequestFormWindow();
            requestFormWindow.ShowDialog();

        }
        private void CheckForErrors_Click(object sender, RoutedEventArgs e)
        {
            // Example: List of error messages
            List<string> errorMessages = new List<string>();

            // Simulate checking for errors in the apps (this would be your actual logic)
            errorMessages.Add("App A has a missing configuration file.");
            errorMessages.Add("App B encountered a runtime exception.");
            errorMessages.Add("App C failed to load required resources.");

            // If there are errors, show the ErrorDetailsWindow
            if (errorMessages.Count > 0)
            {
                ErrorDetailsWindow errorWindow = new ErrorDetailsWindow(errorMessages);
                errorWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("No errors found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ViewErrors_Click(object sender, RoutedEventArgs e)
        {
            // Example error data
            string appName = "App A";
            string errorDetails = "Error 1: Issue with loading resources.\nError 2: Unexpected null reference.";

            // Open the error report window with the app name and error details
            ErrorReportWindow errorWindow = new ErrorReportWindow(appName, errorDetails);
            errorWindow.ShowDialog();
        }
    
    }
}