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
using OfficeOpenXml;
using Newtonsoft.Json;
using ClosedXML.Excel;


namespace WPFAppDeneme
{
    public partial class MainWindow : Window
    {
        private string counterFilePath = "userCount.txt";
        private List<string> appNames = new List<string>
        {
            "DELTA",
            "BASE",
            "OMEGA",
            "FIRTREE",
            "ALPHA"
        };
        public MainWindow()
        {
            InitializeComponent();
            UpdateDailyLoginCount();

            ReadAndDisplayJson();

        }
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) // Check if the Enter key is pressed
            {
                string searchQuery = SearchBox.Text.ToLower(); // Get the search query in lowercase

                foreach (var child in AppsPanel.Children)
                {
                    if (child is Border appBorder)
                    {
                        var stackPanel = appBorder.Child as StackPanel;
                        var appNameTextBlock = stackPanel.Children.OfType<TextBlock>().FirstOrDefault();

                        if (appNameTextBlock != null)
                        {
                            string appName = appNameTextBlock.Text.ToLower(); // Convert app name to lowercase
                            appBorder.Visibility = appName.Contains(searchQuery) ? Visibility.Visible : Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        private void ShowApplicationData_Click(object sender, RoutedEventArgs e)
        {
            ReadAndDisplayJson();
        }
        public class ApplicationData
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Page { get; set; }
            public string Version { get; set; }
            public DateTime CreationDate { get; set; }
            public string Category { get; set; }
            public List<string> Categories { get; set; }
        }

        private void ReadAndDisplayJson()
        {
            string jsonFilePath = @"C:\Users\vahde\source\repos\WPFAppDeneme\WPFAppDeneme\bin\Debug\json-schema1.json";

            try
            {
                string jsonData = File.ReadAllText(jsonFilePath);

                var settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-dd"
                };

                List<ApplicationData> applications = JsonConvert.DeserializeObject<List<ApplicationData>>(jsonData, settings);

                string message = "Uygulama Bilgileri:\n";
                foreach (var app in applications)
                {
                    // Categories özelliğinin null olup olmadığını kontrol et ve boş bir liste ata
                    if (app.Categories == null)
                    {
                        app.Categories = new List<string>();
                    }

                    // JSON'daki değeri okuduğundan emin ol
                    string categories = app.Categories.Any() ? string.Join(", ", app.Categories) : string.Empty;
                    message += $"Name: {app.Name}\nDescription: {app.Description}\nPage: {app.Page}\nVersion: {app.Version}\nCreation Date: {app.CreationDate.ToShortDateString()}\nCategory: {app.Category}\n\n";
                }

                MessageBox.Show(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void OpenApplicationPage(string pageName)
        {
            Window pageWindow = null;

            switch (pageName)
            {
                case "DeltaPage":
                    pageWindow = new DeltaPage(); // Assuming DeltaPage is a Window or Page
                    break;
                case "BasePage":
                    pageWindow = new BasePage();
                    break;
                case "AlphaPage":
                    pageWindow = new AlphaPage();
                    break;
                default:
                    MessageBox.Show("Page not found");
                    return;
            }

            pageWindow?.Show();
        }
    
    private void UpdateDailyLoginCount()
            {
                int dailyUserCount = 0;
                DateTime lastLoginDate = DateTime.MinValue;


                if (File.Exists(counterFilePath))
                {
                    string[] lines = File.ReadAllLines(counterFilePath);
                    if (lines.Length >= 2)
                    {
                        int.TryParse(lines[0], out dailyUserCount);
                        DateTime.TryParse(lines[1], out lastLoginDate);
                    }
                }


                DateTime currentDate = DateTime.Now.Date;


                if (currentDate > lastLoginDate)
                {
                    dailyUserCount = 1;
                    lastLoginDate = currentDate;
                }
                else
                {
                    dailyUserCount++;
                }


                File.WriteAllLines(counterFilePath, new string[] { dailyUserCount.ToString(), lastLoginDate.ToString() });


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
                    SearchBox.Foreground = Brushes.Black;
                }
            }

            private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(SearchBox.Text))
                {
                    SearchBox.Text = "Search...";
                    SearchBox.Foreground = Brushes.Gray;
                }

            }
            private void AdminTextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
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

                List<string> errorMessages = new List<string>
    {

            "Has a missing configuration file.",
            "Encountered a runtime exception.",
            "Failed to load required resources.",
            "Performance Issues."
    };


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

                string appName = "App A";
                string errorDetails = "Error 1: Issue with loading resources.\nError 2: Unexpected null reference.";

                ErrorReportWindow errorWindow = new ErrorReportWindow(appName, errorDetails);
                errorWindow.ShowDialog();
            }
            private void GoToTEIPage_Click(object sender, RoutedEventArgs e)
            {

                TEIPage teiPage = new TEIPage();

                teiPage.Show();
            }
            private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true
                });


                e.Handled = true;
            }

            public void SaveUserDataToExcel(string username, string password)
            {

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("User Data");


                    worksheet.Cells[1, 1].Value = "Username";
                    worksheet.Cells[1, 2].Value = "Password";


                    worksheet.Cells[2, 1].Value = username;


                    string hiddenPassword = new string('*', password.Length);

                    worksheet.Cells[2, 2].Value = hiddenPassword;

                    // Excel dosyasını kaydet
                    var file = new FileInfo(@"C:\path_to_your_file\UserData.xlsx");
                    package.SaveAs(file);

                }
            }
        private void DeltaBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DeltaPage deltaPage = new DeltaPage();
            deltaPage.Show();  // Show the DeltaPage window
        }


        private class AlphaPage : Window
        {
        }
    }
    }

