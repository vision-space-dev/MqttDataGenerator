using System;
using Newtonsoft.Json;

namespace MqttSender.model
{
    public class Position
    {
        [JsonProperty("x")]
        public double X { get; set; }
        [JsonProperty("y")]
        public double Y { get; set; }
        [JsonProperty("z")]
        public double Z { get; set; }
        
        [JsonProperty("orientation")]
        public double Orientation { get; set; }
        
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}