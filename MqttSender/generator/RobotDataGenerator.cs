using System;
using System.Collections.Generic;
using MqttSender.model;
using Newtonsoft.Json;
using static Newtonsoft.Json.Formatting;

namespace MqttSender.generator
{
    public class RobotDataGenerator
    {
        private Random _random = new Random();

        public Position GenerateRandomPosition(AMRRobotInputObject amrInputObject)
        {
            
            return new Position
            {
                Orientation = 0, // Assuming starting orientation
                Timestamp = DateTime.Now
            };
        }
        
public string GenerateRobotDataJson(List<AMRRobotInputObject> amrInputObjects)
        {
            var robotDataCollection = new RobotDataCollection
            {
                RobotData = new List<RobotEvent>()
            };

            foreach (var amrInput in amrInputObjects)
            {
                var position = GenerateRandomPosition(amrInput);
                
                var robotData = new RobotData
                {
                    RobotId = amrInput.RobotSid,
                    Status = "active", // Example status
                    RobotType = "AMR_ROBOT", // Assuming AMR for all
                    RobotModel = amrInput.RobotModelName,
                    Position = position,
                    Battery = new Battery // Example Battery data
                    {
                        Level = 80.0,
                        Charging = false,
                        Voltage = 24.0,
                        Current = 5.0,
                        Temperature = 35.0,
                        Health = "Good"
                    },
                    Tasks = new List<RobotTask>(), // Can add tasks if needed
                };

                var robotEvent = new RobotEvent
                {
                    EventType = amrInput.EventType,
                    RobotData = robotData
                };

                robotDataCollection.RobotData.Add(robotEvent);
            }

            return JsonConvert.SerializeObject(robotDataCollection, Indented);
        }
    }
}