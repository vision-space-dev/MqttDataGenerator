namespace MqttSender.model
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Sensor
    {
        public string Status { get; set; }
        public double Range { get; set; }
        public int DataFrequency { get; set; }
        public List<string> Data { get; set; }
        public string Resolution { get; set; }
        public string ImageFeedURL { get; set; }
        public int FrameRate { get; set; }
        public bool ObstacleDetected { get; set; }
        public double CurrentTemperature { get; set; }
        public string Unit { get; set; }
        public int CurrentHumidity { get; set; }
    }

    public class Task
    {
        public string TaskId { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public string Status { get; set; }
        public Position Origin { get; set; }
        public Position TargetLocation { get; set; }
        public Payload Payload { get; set; }
    }

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

    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Orientation { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Battery
    {
        public double Level { get; set; }
        public bool Charging { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double Temperature { get; set; }
        public string Health { get; set; }
    }

    public class RobotData
    {
        public string RobotId { get; set; }
        public string Status { get; set; }
        public string RobotType { get; set; }
        public string RobotModel { get; set; }
        public Position Position { get; set; }
        public Battery Battery { get; set; }
        public List<Task> Tasks { get; set; }
        public Dictionary<string, Sensor> Sensors { get; set; }
        // Additional properties can be added here for Maintenance, Network, etc.
    }

    public class RobotEvent
    {
        public string EventType { get; set; }
        public RobotData RobotData { get; set; }
    }

    public class RobotDataCollection
    {
        public List<RobotEvent> RobotData { get; set; }
    }
}