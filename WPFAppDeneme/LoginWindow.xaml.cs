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
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Kullanıcı adı ve şifre kontrolü
            if (username == "admin" && password == "1234")
            {
               
                AppCreatorWindow appCreatorWindow = new AppCreatorWindow();
                appCreatorWindow.Show();
                this.Close(); // Mevcut pencereyi kapat
            }
            else
            {
           
                MessageBox.Show("Username or Password is incorrect.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string correctUsername = "admin";
            string correctPassword = "password123";

            
            string enteredUsername = UsernameTextBox.Text.Trim();
            string enteredPassword = PasswordBox.Password.Trim();

            MessageBox.Show($"Entered Username: '{enteredUsername}'\nEntered Password: '{enteredPassword}'", "Debug Info");

            
            if (enteredUsername.Equals(correctUsername) && enteredPassword.Equals(correctPassword))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true; 
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Please contact support at support@example.com for password recovery.", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void ForgotPasswordButton_Click(object sender, RoutedEventArgs e)
        {

            PasswordResetWindow passwordResetWindow = new PasswordResetWindow();
            passwordResetWindow.ShowDialog();
        }
        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {

            AdminAddingWindow adminWindow = new AdminAddingWindow();

            adminWindow.ShowDialog();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            PasswordBox.Visibility = Visibility.Collapsed;
            ShowPasswordTextBox.Visibility = Visibility.Visible;
            ShowPasswordTextBox.Text = PasswordBox.Password;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Visibility = Visibility.Visible;
            ShowPasswordTextBox.Visibility = Visibility.Collapsed;
            PasswordBox.Password = ShowPasswordTextBox.Text;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (ShowPasswordTextBox.Visibility == Visibility.Visible)
            {
                ShowPasswordTextBox.Text = PasswordBox.Password;
            }
        }

        private void ShowPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Password = ShowPasswordTextBox.Text;
            }
        }
    }

 
}





