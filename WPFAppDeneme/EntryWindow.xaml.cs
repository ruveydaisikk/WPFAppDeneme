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

            // Zamanlayıcı ile animasyon tamamlandıktan sonra ana pencereye geçiş
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // 3 saniye
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Zamanlayıcıyı durdur
            (sender as DispatcherTimer).Stop();

            // Ana pencereyi aç
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Giriş penceresini kapat
            this.Close();
        }
       
    }
}