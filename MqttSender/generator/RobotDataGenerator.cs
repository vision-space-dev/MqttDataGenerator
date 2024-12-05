using System.Collections.Generic;
using MqttSender.model;
using Newtonsoft.Json;
using static Newtonsoft.Json.Formatting;

namespace MqttSender.generator
{
    public class RobotDataGenerator
    {
        public string GenerateRobotDataJson(List<RobotData> robots)
        {
            var robotDataCollection = new RobotDataCollection
            {
                RobotData = new List<RobotEvent>()
            };

            foreach (var robot in robots)
            {
                robotDataCollection.RobotData.Add(new RobotEvent
                {
                    EventType = "REGISTER_NEW_ROBOT",
                    RobotData = robot
                });
            }

            return JsonConvert.SerializeObject(robotDataCollection, Indented);
        }
    }
}