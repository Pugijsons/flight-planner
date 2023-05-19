using System.Collections.Generic;
using FlightPlanner.Models;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetFullFlight(int id);
        bool FlightExists(Flight flight);
        List<Flight> SearchFlights(SearchFlightRequest  request);
    }
}
