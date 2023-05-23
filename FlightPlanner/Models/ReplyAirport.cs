using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FlightPlanner.Models
{
    public class ReplyAirport
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Airport { get; set; }
    }
}
