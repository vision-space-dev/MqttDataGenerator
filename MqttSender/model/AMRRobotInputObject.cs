namespace MqttSender.model
{
    public class AMRRobotInputObject
    {
        public AMRRobotInputObject(string robotSid, string robotModelName, string robotName,
            float maxX, float maxY, float maxZ, float minX, float minY, float minZ,
            int messagesPerSeconds, int messageDelaySeconds, int locationVariantValue,
            string eventType, int runTimeSeconds)
        {
            this.RobotSid = robotSid;
            this.RobotModelName = robotModelName;
            this.RobotName = robotName;
            this.MaxX = maxX;
            this.MaxY = maxY;
            this.MaxZ = maxZ;
            this.MinX = minX;
            this.MinY = minY;
            this.MinZ = minZ;
            this.MessagesPerSeconds = messagesPerSeconds;
            this.MessageDelaySeconds = messageDelaySeconds;
            this.LocationVariantValue = locationVariantValue;
            this.EventType = eventType;
            this.RunTimeSeconds = runTimeSeconds;
        }
        
        public string RobotSid { get; }
        public string RobotModelName { get; }
        public string RobotName { get; }
        public float MinX { get; }
        public float MinY { get; }
        public float MinZ { get; }
        public float MaxX { get; }
        public float MaxY { get; }
        public float MaxZ { get; }
        
        public int MessagesPerSeconds { get; }
        
        public int MessageDelaySeconds { get; }
        
        public int LocationVariantValue { get; }
        
        public string EventType { get; }
        
        public int RunTimeSeconds { get; }
        
        public bool IsValidInputs()
        {
            // Ensure required string fields are not null or empty
            if (string.IsNullOrEmpty(RobotSid) ||
                string.IsNullOrEmpty(RobotModelName) ||
                string.IsNullOrEmpty(RobotName) ||
                string.IsNullOrEmpty(EventType))
            {
                return false;
            }

            // Ensure coordinates are within a realistic range
            if (MinX > MaxX || MinY > MaxY || MinZ > MaxZ)
            {
                return false;
            }

            // Ensure numeric values are positive and logical
            if (MessagesPerSeconds < 0 ||
                MessageDelaySeconds < 0 ||
                LocationVariantValue < 0 ||
                RunTimeSeconds < 0)
            {
                return false;
            }

            // Add more specific business-validation rules as needed here

            return true;
        }
    }
}