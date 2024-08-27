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
                // Doğruysa yeni pencereyi aç
                AppCreatorWindow appCreatorWindow = new AppCreatorWindow();
                appCreatorWindow.Show();
                this.Close(); // Mevcut pencereyi kapat
            }
            else
            {
                // Hatalı giriş uyarısı
                MessageBox.Show("Username or Password is incorrect.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    // Predefined credentials (make sure they match exactly)
                    string correctUsername = "admin";
                    string correctPassword = "password123";

                    // Retrieve entered credentials and trim any extra spaces
                    string enteredUsername = UsernameTextBox.Text.Trim();
                    string enteredPassword = PasswordBox.Password.Trim();

                    // Debugging: Show what the input values are
                    MessageBox.Show($"Entered Username: '{enteredUsername}'\nEntered Password: '{enteredPassword}'", "Debug Info");

                    // Temporary simple validation for debugging
                    if (enteredUsername.Equals(correctUsername) && enteredPassword.Equals(correctPassword))
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.DialogResult = true; // Close the login window
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
            // Create an instance of the AdminAddingWindow
            AdminAddingWindow adminWindow = new AdminAddingWindow();

            // Show the AdminAddingWindow
            adminWindow.ShowDialog();
        }
    }
        }
    




