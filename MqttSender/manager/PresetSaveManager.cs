using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MqttSender.model;
using Newtonsoft.Json;

namespace MqttSender.manager
{
    //Todo: make this singleton
    public class PresetSaveManager
    {
        private static SaveFileDialog saveFileDialog = new SaveFileDialog {
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            DefaultExt = "json",
            FileName = "PresetData",
            AddExtension = true
        };
        
        private static string filePath = saveFileDialog.FileName;
        
        private static PresetSaveManager _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Private constructor to prevent external instantiation
        private PresetSaveManager() { }

        // Public static property to access the singleton instance
        public static PresetSaveManager GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new PresetSaveManager();
                        }
                    }
                }
                return _instance;
            }
        }
        
        
        //There will be multiple robots having list of tasks
        public static void SaveRobotData(List<RobotData> robotData)
        {
            if (robotData == null || robotData.Count == 0)
            {
                Console.WriteLine("No data to save!");
                return;
            }
            
            // Show the dialog to get file path from the user
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Use stream writing for efficient handling of large data
                    using (var writer = new StreamWriter(filePath))
                    {
                        foreach (var singleData in robotData)
                        {
                            // Serialize and write each robot's data to the file
                            string jsonData = JsonConvert.SerializeObject(singleData, Formatting.Indented);
                            writer.WriteLine(jsonData);
                        }
                    }

                    Console.WriteLine($"File successfully saved to {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File save cancelled.");
            } 
        }
    }
}