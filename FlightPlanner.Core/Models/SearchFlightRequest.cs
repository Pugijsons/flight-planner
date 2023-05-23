namespace FlightPlanner.Models
{
    public class SearchFlightRequest
    {
        public string To { get; set; }
        public string From { get; set; }
        public string? Date { get; set; }
    }
}
