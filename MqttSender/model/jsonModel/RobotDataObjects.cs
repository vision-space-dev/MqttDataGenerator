﻿namespace MqttSender.model
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
        
        public override string ToString()
        {
            return $"Type: {Type}, Description: {Description}, Weight: {Weight}, Dimensions: [{Dimensions}]";
        }
    }

    public class Dimensions
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        
        public override string ToString()
        {
            return $"Length: {Length}, Width: {Width}, Height: {Height}";
        }
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
        
        public override string ToString()
        {
            return $"Level: {Level}, Charging: {Charging}, Voltage: {Voltage}, Current: {Current}, Temperature: {Temperature}, Health: {Health}";
        }
        
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
        
        [JsonProperty("location")]
        public Location Location { get; set; }
        
        public override string ToString()
        {
            var tasksString = Tasks != null ? string.Join(", ", Tasks) : "No Tasks";
            return $"RobotId: {RobotId}, Status: {Status}, RobotType: {RobotType}, RobotModel: {RobotModel}, Position: {Position}, Battery: [{Battery}], Tasks: [{tasksString}]";
        }
    }

    public class RobotEvent
    {
        
        [JsonProperty("eventType")]
        public string EventType { get; set; }
        
        [JsonProperty("robotData")]
        public RobotData RobotData { get; set; }
        
        public override string ToString()
        {
            return $"EventType: {EventType}, RobotData: [{RobotData}]";
        }
    }

    public class RobotDataCollection
    {
        [JsonProperty("robot-data")]
        public List<RobotEvent> RobotData { get; set; }
        
        public override string ToString()
        {
            var eventsString = RobotData != null ? string.Join("\n", RobotData) : "No Robot Events";
            return $"RobotData Collection:\n{eventsString}";
        }
    }
}