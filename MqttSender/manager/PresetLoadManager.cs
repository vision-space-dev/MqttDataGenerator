using System;
using System.IO;
using MqttSender.model;
using Newtonsoft.Json;

namespace MqttSender.manager
{
    //Todo: make this generic or identify type based on provided robot type
    public class PresetLoadManager
    {
        private static PresetLoadManager _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Private constructor to prevent external instantiation
        private PresetLoadManager() { }

        // Public static property to access the singleton instance
        public static PresetLoadManager GetInstance
        {
            get
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
        }

        public RobotManager<AmrRobot> ReflectAmrRobotData(RobotDataCollection robotDataCollection)
        {
            RobotManager<AmrRobot> amrRobotManager = new RobotManager<AmrRobot>();
            amrRobotManager.GetRobots().Clear();
            foreach (RobotEvent robotEvent in robotDataCollection.RobotData)
            {
                string eventType = robotEvent.EventType;
                RobotData robotData = robotEvent.RobotData;

                if (robotData == null)
                {
                    // Log or skip invalid RobotData here if needed
                    continue;
                }

                // Parse RobotData into AmrRobot
                AmrRobot amrRobot = new AmrRobot(
                    robotData.RobotId, // Assuming RobotId as robot SID
                    robotData.RobotModel, // Robot model name
                    robotData.RobotType // Robot name or type
                );
                
                // Add tasks to the robot (if any)
                if (robotData.Tasks != null)
                {
                    foreach (RobotTask task in robotData.Tasks)
                    {
                        amrRobot.AddTask(task);
                    }
                }
                
                //Load location and facilityId if present

                Location locationData = robotEvent.RobotData.Location;
                if (locationData!= null)
                {
                    if (locationData.locationSid != null)
                    {
                        amrRobot.SetLocationId(robotEvent.RobotData.Location.locationSid); 
                    }
                    if (locationData.facility != null && locationData.facility.facilitySid != null)
                    {
                        amrRobot.SetFacilityId(robotEvent.RobotData.Location.facility.facilitySid);   
                    }
                }
                
                
                amrRobotManager.AddRobot(amrRobot.GetRobotSid(), amrRobot);

            }

            return amrRobotManager;
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