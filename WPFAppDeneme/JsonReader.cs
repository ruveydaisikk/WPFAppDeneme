using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WPFAppDeneme
{
    public class JsonReader
    {
        public void LoadJsonFile()
        {
            try
            {
                string jsonContent = File.ReadAllText("path/to/your/file.json");
                // Process the JSON content
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
