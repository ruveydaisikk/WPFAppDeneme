﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OfficeOpenXml;

namespace WPFAppDeneme
{
    /// <summary>
    /// App.xaml etkileşim mantığı
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
           
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
    

    public string Name { get; internal set; }
        public string Category { get; internal set; }
            public string Version { get; set; }
            public string Color { get; set; }
        }
}
