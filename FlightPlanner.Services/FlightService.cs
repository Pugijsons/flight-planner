using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public Flight GetFullFlight(int id)
        {
            return _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .SingleOrDefault(f => f.Id == id);
        }

        public bool FlightExists(Flight flight)
        {
            return _context.Flights.Any(f =>
                f.To.AirportCode == flight.To.AirportCode
                && f.From.AirportCode == flight.From.AirportCode
                && f.Carrier == flight.Carrier
                && f.DepartureTime == flight.DepartureTime
                && f.ArrivalTime == flight.ArrivalTime);
        }

        public List<Flight> SearchFlights(SearchFlightRequest request)
        {
            return _context.Flights.Where(c => c.To.AirportCode == request.To && c.From.AirportCode == request.From).ToList();
        }
    }
}
