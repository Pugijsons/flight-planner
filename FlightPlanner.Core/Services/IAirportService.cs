using FlightPlanner.Models;

namespace FlightPlanner.Core.Services
{
    public interface IAirportService
    {
        public Airport[] SearchAirports(string search);
    }
}
