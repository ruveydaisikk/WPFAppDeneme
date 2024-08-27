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
using Newtonsoft.Json;
using System.IO;

namespace WPFAppDeneme
{
    /// <summary>
    /// AppCreatorWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class AppCreatorWindow : Window
    {
        public AppCreatorWindow()
        {
            InitializeComponent();
        }
        private void CreateAppButton_Click(object sender, RoutedEventArgs e)
        {
            string appName = AppNameTextBox.Text;
            string category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!string.IsNullOrEmpty(appName) && !string.IsNullOrEmpty(category))
            {
                MessageBox.Show($"Application '{appName}' created under the '{category}' category.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Load existing apps and add the new one
                var apps = LoadApps() ?? new List<App>();
                apps.Add(new App { Name = appName, Category = category });

                // Save to JSON file
                SaveApps(apps);
            }
            else
            {
                MessageBox.Show("Please enter all details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     

public void SaveApps(List<App> apps)
    {
        string json = JsonConvert.SerializeObject(apps, Formatting.Indented);
        File.WriteAllText("apps.json", json);
    }

    public List<App> LoadApps()
    {
        if (File.Exists("apps.json"))
        {
            string json = File.ReadAllText("apps.json");
            return JsonConvert.DeserializeObject<List<App>>(json);
        }
        return new List<App>();
    }


}
}
