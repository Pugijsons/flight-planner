using System;
using System.Text.Json.Serialization;

namespace FlightPlanner.Models
{
    public class Airport 
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonPropertyName("airport")]
        public string AirportCode { get; set; }

        public bool Equals (Airport otherAirport)
        {
            return AirportCode.ToLower().Trim() == otherAirport.AirportCode.ToLower().Trim();
        }

        public bool Compare(string search)
        {
            if (Country.ToLower().Contains(search.ToLower().Trim()) || City.ToLower().Contains(search.ToLower().Trim()) || AirportCode.ToLower().Contains(search.ToLower().Trim()))
            {
                return true;
            }
            return false;
        }
    }
}
