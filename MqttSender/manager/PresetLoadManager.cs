using System;
using System.IO;
using MqttSender.model;
using Newtonsoft.Json;

namespace MqttSender.manager
{
    public class PresetLoadManager
    {
        private static PresetLoadManager _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Private constructor to prevent external instantiation
        private PresetLoadManager() { }

        // Public static property to access the singleton instance
        public static PresetLoadManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PresetLoadManager();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Loads and parses the JSON file into a RobotDataCollection object.
        /// </summary>
        /// <param name="filePath">Path to the JSON file</param>
        /// <returns>Deserialized RobotDataCollection object</returns>
        public RobotDataCollection LoadPresetData(string filePath)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    throw new ArgumentException("The file path cannot be null or empty.");
                }

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file at path {filePath} was not found.");
                }

                string jsonContent = File.ReadAllText(filePath);

                // Deserialize the JSON content into RobotDataCollection
                var robotDataCollection = JsonConvert.DeserializeObject<RobotDataCollection>(jsonContent);

                if (robotDataCollection == null || robotDataCollection.RobotData == null)
                {
                    throw new Exception("The JSON file is empty or not in the expected format.");
                }

                return robotDataCollection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while loading preset data: {ex.Message}");
                return null;
            }
        }
    }
}