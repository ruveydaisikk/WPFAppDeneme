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


using System.Diagnostics;
using System.Windows.Navigation;

namespace WPFAppDeneme
    {
        public partial class ErrorDetailsWindow : Window
        {
        private List<string> errorMessages;

        public ErrorDetailsWindow(Dictionary<string, string> errorMessagesWithLinks)
            {
                InitializeComponent();
                ErrorListBox.ItemsSource = errorMessagesWithLinks;
            }

        public ErrorDetailsWindow(List<string> errorMessages)
        {
            this.errorMessages = errorMessages;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
            {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
                e.Handled = true;
            }
        }
  

}

