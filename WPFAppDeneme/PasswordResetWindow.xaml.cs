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



namespace WPFAppDeneme  // Ensure this matches the XAML namespace
{
    public partial class PasswordResetWindow : Window
    {
        public PasswordResetWindow()
        {
            InitializeComponent();
        }

        private void ResetPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            // Simulate the password reset process

            // Show the success window
            SuccessWindow successWindow = new SuccessWindow();
            successWindow.Show();

            // Close the Password Reset window
            this.Close();
        }
    }
}


