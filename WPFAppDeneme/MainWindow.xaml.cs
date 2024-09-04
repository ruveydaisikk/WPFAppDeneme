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

        public MainWindow()
        {
            InitializeComponent();
            UpdateDailyLoginCount();
         
                PopulateAppData();
            
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
                // JSON dosyasının yolunu belirtin.
                string jsonFilePath = @"C:\Users\vahde\source\repos\WPFAppDeneme\WPFAppDeneme\json-schema1.json";

                try
                {
                    string jsonData = File.ReadAllText(jsonFilePath);

                    // JSON stringini deserialize ederek C# objesine çevirin.
                    JsonFileFormat jsonFileFormat = JsonConvert.DeserializeObject<JsonFileFormat>(jsonData);

                    // Verileri kullanın.
                    MessageBox.Show($"Name: {jsonFileFormat.Name}\nVersions: {string.Join(", ", jsonFileFormat.Versions)}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}");
                }
            }
        private void PopulateAppData()
        {
            string jsonFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json-schema1.json");

            try
            {
                var appDataList = JsonReader.LoadAppDataFromJson(jsonFilePath);

                foreach (var appData in appDataList)
                {
                    Border border = new Border
                    {
                        Background = (SolidColorBrush)new BrushConverter().ConvertFromString(appData.Color),
                        CornerRadius = new CornerRadius(5),
                        Width = 100,
                        Height = 100,
                        Margin = new Thickness(10)
                    };

                    StackPanel stackPanel = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    Rectangle rectangle = new Rectangle
                    {
                        Width = 40,
                        Height = 40,
                        Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString(appData.Color)),
                        Margin = new Thickness(5)
                    };

                    TextBlock nameTextBlock = new TextBlock
                    {
                        Text = appData.Name,
                        Foreground = Brushes.Black,
                        FontSize = 16,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    TextBlock versionTextBlock = new TextBlock
                    {
                        Text = appData.Version,
                        Foreground = Brushes.Gray,
                        FontSize = 10,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    stackPanel.Children.Add(rectangle);
                    stackPanel.Children.Add(nameTextBlock);
                    stackPanel.Children.Add(versionTextBlock);
                    border.Child = stackPanel;

                    AppsPanel.Children.Add(border);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
