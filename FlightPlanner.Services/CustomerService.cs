using System.Linq;
using FlightPlanner.Models;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAirportService _airportService;
        private readonly IFlightService _flightService;

        public CustomerService(IFlightService flightService, IAirportService airportService)
        {
            _flightService = flightService;
            _airportService = airportService;
        }

        public Flight GetFlightById(int id)
        {
            return _flightService.GetFullFlight(id);
        }

        public Airport[] SearchAirports(string search)
        {
            return _airportService.SearchAirports(search);
        }

        public PageResult SearchFlights(SearchFlightRequest request)
        {
            var returnList = _flightService.SearchFlights(request);
            PageResult result = new PageResult();
            result.Items = returnList.ToArray();
            result.TotalItems = returnList.Count();
            result.Page = 0;
            return result;
        }
    }

}
