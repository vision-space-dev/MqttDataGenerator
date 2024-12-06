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
            float rangeX = amrInputObject.MaxX - amrInputObject.MinX;
            float rangeY = amrInputObject.MaxY - amrInputObject.MinY;
            float rangeZ = amrInputObject.MaxZ - amrInputObject.MinZ;
            
            float newX = amrInputObject.MinX + (float)(_random.NextDouble() * rangeX);
            float newY = amrInputObject.MinY + (float)(_random.NextDouble() * rangeY);
            float newZ = amrInputObject.MinZ + (float)(_random.NextDouble() * rangeZ);
            
            newX = ApplyVariation(newX, amrInputObject.LocationVariantValue);
            newY = ApplyVariation(newY, amrInputObject.LocationVariantValue);
            newZ = ApplyVariation(newZ, amrInputObject.LocationVariantValue);

            return new Position
            {
                X = newX,
                Y = newY,
                Z = newZ,
                Orientation = 0, // Assuming starting orientation
                Timestamp = DateTime.Now
            };
        }
        
        private float ApplyVariation(float value, int variantValue)
        {
            // Adjust the position value with a small variation
            float variation = (float)(_random.NextDouble() * variantValue / 100.0);
            return value + variation;
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
                    Status = "Active", // Example status
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
                    Tasks = new List<Task>(), // Can add tasks if needed
                    Sensors = new Dictionary<string, Sensor>() // Example sensor data
                    {
                        { "Sensor1", new Sensor {
                            Status = "Operational",
                            Range = 50,
                            DataFrequency = 1,
                            CurrentTemperature = 25,
                            Unit = "Celsius",
                            CurrentHumidity = 40
                        }}
                    }
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