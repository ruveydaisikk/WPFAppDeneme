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

using System.Windows.Threading;

    namespace WPFAppDeneme
    {
    public partial class EntryWindow : Window
    {
        public EntryWindow()
        {
            InitializeComponent();

            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void MainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close(); 
        }
    
    private void Timer_Tick(object sender, EventArgs e)
        {
            
            (sender as DispatcherTimer).Stop();

           
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }
       
    }
}