using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Models;

namespace FlightPlanner.Core.Services
{
    public interface ICustomerService
    { 
        public Airport[] SearchAirports(string search);
        public PageResult SearchFlights(SearchFlightRequest request);

        public Flight GetFlightById(int id);
    }
}
