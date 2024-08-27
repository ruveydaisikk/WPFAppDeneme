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
    public partial class AdminAddingWindow : Window
    {
        public AdminAddingWindow()
        {
            InitializeComponent();
        }

        private void AddAdminButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the admin details from the UI
            string username = UsernameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Add logic here to save the new admin (e.g., to a database, file, etc.)
            // For simplicity, we'll show a success message
            MessageBox.Show($"Admin '{username}' added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Optionally, clear the input fields after adding the admin
            UsernameTextBox.Clear();
            EmailTextBox.Clear();
            PasswordBox.Clear();
        }
    }
}
