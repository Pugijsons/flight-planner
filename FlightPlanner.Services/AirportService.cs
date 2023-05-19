using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using FlightPlanner.Models;
using System.Linq;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport> ,IAirportService
    {
        private readonly IFlightPlannerDbContext _context;
        public AirportService(IFlightPlannerDbContext context): base(context) { 
        
            _context = context;
        }

        public Airport[] SearchAirports(string search)
        {
            search = search.ToLower().Trim();
            return _context.Airports
                .Where(airport => airport != null 
                    && airport.Country.ToLower().Contains(search) 
                    || airport.City.ToLower().Contains(search) 
                    || airport.AirportCode.ToLower().Contains(search))
                .Distinct()
                .ToArray();
        }
    }
}
