﻿using System;
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
    /// SuccessWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class SuccessWindow : Window
    {
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public SuccessWindow()
        {
            InitializeComponent();
        }
   
    }
}
