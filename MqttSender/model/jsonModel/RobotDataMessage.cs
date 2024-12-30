using Newtonsoft.Json;

namespace MqttSender.model
{
    public class RobotDataMessage
    {
        [JsonProperty("robot-data")]
        public RobotDataEntry[] RobotData { get; set; }
    }
    
    public class RobotDataEntry
    {
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("robotData")]
        public RobotData RobotData { get; set; }
    }
}