using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class FlightAirportValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return flight?.To.AirportCode.ToLower().Trim() != flight?.From.AirportCode.ToLower().Trim();
        }
    }
}
