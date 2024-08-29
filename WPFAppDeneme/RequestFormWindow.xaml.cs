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
    public partial class RequestFormWindow : Window
    {
        public RequestFormWindow()
        {
            InitializeComponent();
            OpenDatePicker.SelectedDate = System.DateTime.Today; 
        }

        private void SubmitRequest_Click(object sender, RoutedEventArgs e)
        {
            string appName = AppNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            string openDate = OpenDatePicker.SelectedDate.HasValue ? OpenDatePicker.SelectedDate.Value.ToShortDateString() : OpenDatePicker.Text;

            string selectedCategories = "";
            if (MaterialCheckBox.IsChecked == true) selectedCategories += "Material ";
            if (StructuralCheckBox.IsChecked == true) selectedCategories += "Structural ";
            if (ThermalCheckBox.IsChecked == true) selectedCategories += "Thermal ";
            if (MechanicalCheckBox.IsChecked == true) selectedCategories += "Mechanical ";

            
            MessageBox.Show($"Application Name: {appName}\nOpening Date: {openDate}\nDescription: {description}\nCategories: {selectedCategories}", "Request Form");

            this.Close(); 
        }

        private void CancelRequest_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
