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

namespace WPFAppDeneme
{
    /// <summary>
    /// EntryPage.xaml etkileşim mantığı
    /// </summary>
    public partial class EntryPage : Window
    {
        public EntryPage()
        {
            InitializeComponent();
        }
        private void EnterEngineering_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); 
        }
        

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void EnterAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnterProductivity_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EnterPlugins_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
