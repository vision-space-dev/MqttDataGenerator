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
        
        
        //with milli format - 2024-12-26 15:19:44.624
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }


        public Position()
        {
            
        }
        
        public Position(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Z: {Z}";
        }
    }
}