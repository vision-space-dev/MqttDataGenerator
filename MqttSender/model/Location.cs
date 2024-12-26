using System;
using Newtonsoft.Json;

namespace MqttSender.model
{
    public class Location
    {
                
        [JsonProperty("location-sid")]
        public string locationSid { get; set; }
        
        /*[JsonProperty("location-name")]
        public string locationName { get; set; }
        
        [JsonProperty("location-address")]
        public string locationAddress { get; set; }
        
        [JsonProperty("phone-number")]
        public string phoneNumber { get; set; }*/
        
        [JsonProperty("facility")]
        public Facility facility { get; set; }

        public override string ToString()
        {
            return $"locationSid: {locationSid}, facility: {facility}";
        }
        
        //Todo: enalble all fields to avoid null pointer exception or constraint exception
        public class Facility
        {
            [JsonProperty("facility-sid")]
            public string facilitySid { get; set; }
            
            [JsonProperty("facility-name")]
            public string facilityName { get; set; }

            /*
            [JsonProperty("facility-description")]
            public string facilityDescription { get; set; }

            [JsonProperty("facility-width")]
            public int facilityWidth { get; set; }

            [JsonProperty("facility-length")]
            public int facilityLength { get; set; }

            [JsonProperty("facility-height")]
            public string facilityHeight { get; set; }*/
        
            public override string ToString()
            {
                return $"facilitySid: {facilitySid}";
            }
        
        }
    }
}