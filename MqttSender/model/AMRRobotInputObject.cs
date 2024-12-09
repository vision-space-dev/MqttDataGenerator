using System;
using System.Collections.Generic;

namespace MqttSender.model
{
    public class AMRRobotInputObject
    {
        public AMRRobotInputObject(string robotSid, string robotModelName, string robotName,
            int messagesPerSeconds, int messageDelaySeconds, int locationVariantValue,
            string eventType, int runTimeSeconds)
        {
            this.RobotSid = robotSid;
            this.RobotModelName = robotModelName;
            this.RobotName = robotName;
            this.MessagesPerSeconds = messagesPerSeconds;
            this.MessageDelaySeconds = messageDelaySeconds;
            this.LocationVariantValue = locationVariantValue;
            this.EventType = eventType;
            this.RunTimeSeconds = runTimeSeconds;
        }
        
        public string RobotSid { get; }
        public string RobotModelName { get; }
        public string RobotName { get; }
        
        public int MessagesPerSeconds { get; }
        
        public int MessageDelaySeconds { get; }
        
        public int LocationVariantValue { get; }
        
        public string EventType { get; }
        
        public int RunTimeSeconds { get; }
        
        public bool IsValidInputs()
        {
            List<string> nullOrEmptyFields = new List<string>();

            // Check required string fields for null or empty
            if (string.IsNullOrEmpty(RobotSid))
            {
                nullOrEmptyFields.Add(nameof(RobotSid));
            }
            if (string.IsNullOrEmpty(RobotModelName))
            {
                nullOrEmptyFields.Add(nameof(RobotModelName));
            }
            if (string.IsNullOrEmpty(RobotName))
            {
                nullOrEmptyFields.Add(nameof(RobotName));
            }
            if (string.IsNullOrEmpty(EventType))
            {
                nullOrEmptyFields.Add(nameof(EventType));
            }

            // Log null or empty fields
            if (nullOrEmptyFields.Count > 0)
            {
                Console.WriteLine("Null or empty fields detected: " + string.Join(", ", nullOrEmptyFields));
                return false;
            }

            // Ensure numeric values are positive and logical
            if (MessagesPerSeconds < 0 ||
                MessageDelaySeconds < 0 ||
                LocationVariantValue < 0 ||
                RunTimeSeconds < 0)
            {
                Console.WriteLine("Invalid numeric values detected.");
                return false;
            }

            // Add more specific business-validation rules as needed here

            return true;
        }
    }
}