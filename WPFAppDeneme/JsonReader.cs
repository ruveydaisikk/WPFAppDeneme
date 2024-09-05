using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

using System.Windows;
using System.Windows.Media;


namespace WPFAppDeneme
{
    public class JsonReader
    {
        public void LoadJsonFile()
        {
            try
            {
                string jsonContent = File.ReadAllText(@"C:\Users\vahde\source\repos\WPFAppDeneme\WPFAppDeneme\json-schema1.json");  ///dosya yolunu tam olarak nasıl 
                // 
                Console.WriteLine("File read successfully.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("The JSON file could not be found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public class JsonFileFormat
        {
            public string Color { get; set; }
            public string Name { get; set; }
            public List<string> Versions { get; set; }
        
        }
       

        public static List<AppData> LoadAppDataFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("JSON dosyası bulunamadı.", filePath);
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<AppData>>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception("JSON dosyası okunurken hata oluştu: " + ex.Message);
            }
        }
    }

    public class AppData
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
    }
}
