using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPFAppDeneme
{
    public partial class ErrorDetailsWindow : Window
    {
        private Dictionary<string, string> errorUrls = new Dictionary<string, string>();

        public ErrorDetailsWindow(List<string> errors)
        {
            InitializeComponent();

            
            foreach (var error in errors)
            {
                ErrorListBox.Items.Add(error);
            }

            
            errorUrls["Has a missing configuration file."] = "https://stackoverflow.com/questions/45807518/missing-app-config-file-and-option-on-add-new-item-does-not-show-configuratio";
            errorUrls["Encountered a runtime exception."] = "https://stackoverflow.com/questions/9898444/java-lang-runtimeexception-unable-to-start-activity-componentinfo";
            errorUrls["Failed to load required resources."] = "https://stackoverflow.com/questions/52310552/failed-to-load-resources";
            errorUrls["Performance Issues."] = "https://stackoverflow.com/questions/78315170/typo3-frontend-performance-issues-slow-page-loading";
        }

        private void ErrorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedError = ErrorListBox.SelectedItem as string;
            if (selectedError != null && errorUrls.ContainsKey(selectedError))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = errorUrls[selectedError],
                    UseShellExecute = true
                });
            }
        }
    }
}
