using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MqttSender.model;
using Newtonsoft.Json;

namespace MqttSender.manager
{
    //Todo: make this singleton
    public class PresetSaveManager<T>
    {
        private static SaveFileDialog saveFileDialog = new SaveFileDialog {
            Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            DefaultExt = "json",
            FileName = "PresetData",
            AddExtension = true
        };
        
        private static PresetSaveManager<T> _instance;

        // Lock object for thread safety
        private static readonly object _lock = new object();
        
        // Private constructor to prevent external instantiation
        private PresetSaveManager() { }

        // Public static property to access the singleton instance
        public static PresetSaveManager<T> GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new PresetSaveManager<T>();
                        }
                    }
                }
                return _instance;
            }
        }
        
        
        //There will be multiple robots having list of tasks
        public void SaveRobotData(List<T> robotData, string filePath)
        {
            if (robotData == null || robotData.Count == 0)
            {
                Console.WriteLine("No data to save!");
                throw new ArgumentException("No robot data provided to save.");
            }

            var robotEvents = new List<RobotEvent>();

            foreach (var robot in robotData)
            {
                if (robot == null)
                {
                    Console.WriteLine("Encountered a null robot instance, skipping.");
                    continue;
                }
                
                if (robot is AmrRobot amrRobot)
                {
                    //Original position is the very fist origin of the task
                    var tasks = amrRobot.GetRobotTasks();

                    Position originPosition = null;
                    if (tasks == null || tasks.Count == 0)
                    {
                        Console.WriteLine("Robot has no tasks, skipping.");
                        tasks = new LinkedList<RobotTask>(); // Use an empty task list to avoid null issues
                        originPosition = new Position(0, 0, 0);
                    }
                    else
                    {
                        originPosition = tasks.First.Value.Origin;
                    }
                    
                    
                    
                     // Map AmrRobot (or similar type) to RobotData
                    RobotData robotDataObject = new RobotData
                    {
                        RobotId = amrRobot.GetRobotSid(),
                        Status = "pending",
                        RobotType = "AMR_ROBOT",
                        RobotModel = amrRobot.GetRobotModelName(),
                        Position = originPosition,
                        Tasks = tasks.Select(task => new RobotTask
                        {
                            TaskId = task.TaskId,
                            Type = task.Type,
                            Priority = task.Priority,
                            StartTime = task.StartTime,
                            EstimatedEndTime = task.EstimatedEndTime,
                            Status = task.Status,
                            MoveTimeInSeconds = task.MoveTimeInSeconds,
                            IdleTimeInSeconds = task.IdleTimeInSeconds,
                            Origin = task.Origin,
                            TargetLocation = task.TargetLocation
                        }).ToList()
                    };

                    robotEvents.Add(new RobotEvent
                    {
                        EventType = "REGISTER_NEW_ROBOT",
                        RobotData = robotDataObject
                    });
                }
            }

            // Wrap in RobotDataCollection for the serialization format:
            RobotDataCollection dataCollection = new RobotDataCollection
            {
                RobotData = robotEvents
            };

            try
            {
                // Serialize and save the JSON to the provided file path
                string jsonData = JsonConvert.SerializeObject(dataCollection, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonData);

                Console.WriteLine($"File successfully saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
                throw; // Re-throw the exception for outer handlers
            }
        }
    }
}