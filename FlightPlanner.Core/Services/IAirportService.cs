using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Models;

namespace FlightPlanner.Core.Services
{
    public interface IAirportService
    {
        public Airport[] SearchAirports(string search);
    }
}
