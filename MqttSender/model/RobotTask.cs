﻿using System;
using Newtonsoft.Json;

namespace MqttSender.model
{
    public class RobotTask
    {
        [JsonProperty("taskId")]
        public string TaskId { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("priority")]
        public string Priority { get; set; }
        
        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }
        
        [JsonProperty("estimatedEndTime")]
        public DateTime EstimatedEndTime { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("origin")]
        public Position Origin { get; set; }
        
        [JsonProperty("targetLocation")]
        public Position TargetLocation { get; set; }
        
        [JsonProperty("payload")]
        public Payload Payload { get; set; }
        public int moveTimeSeconds { get; set; }
        public int workTimeSeconds { get; set; }
        
        public RobotTask() {
            this.Priority = MsgPriority.REGULAR_MESSAGE;
            this.Status = "pending";
        }
    }
}