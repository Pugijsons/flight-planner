using FlightPlanner.Core.Models;

namespace FlightPlanner.Models
{
    public class ReplyFlight : Entity
    {
        public ReplyAirport From { get; set; }
        public ReplyAirport To { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
