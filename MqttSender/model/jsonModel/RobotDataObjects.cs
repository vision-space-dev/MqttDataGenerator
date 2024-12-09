namespace MqttSender.model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Payload
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public Dimensions Dimensions { get; set; }
    }

    public class Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Battery
    {
        [JsonProperty("level")]
        public double Level { get; set; }
        
        [JsonProperty("charging")]
        public bool Charging { get; set; }
        
        [JsonProperty("voltage")]
        public double Voltage { get; set; }
        
        [JsonProperty("current")]
        public double Current { get; set; }
        
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
        
        [JsonProperty("health")]
        public string Health { get; set; }
    }

    public class RobotData
    {
        
        [JsonProperty("robotId")]
        public string RobotId { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("robot-type")]
        public string RobotType { get; set; }
        
        [JsonProperty("robot-model")]
        public string RobotModel { get; set; }
        
        [JsonProperty("position")]
        public Position Position { get; set; }
        
        [JsonProperty("battery")]
        public Battery Battery { get; set; }
        
        [JsonProperty("tasks")]
        public List<RobotTask> Tasks { get; set; }
    }

    public class RobotEvent
    {
        
        [JsonProperty("eventType")]
        public string EventType { get; set; }
        
        [JsonProperty("robotData")]
        public RobotData RobotData { get; set; }
    }

    public class RobotDataCollection
    {
        [JsonProperty("robot-data")]
        public List<RobotEvent> RobotData { get; set; }
    }
}