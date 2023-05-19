using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class FlightTimesIntervalValidator : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return DateTime.TryParse(flight?.DepartureTime, out var departureTime) &&
            DateTime.TryParse(flight?.ArrivalTime, out var arrivalTime) &&
            arrivalTime > departureTime;
        }
    }
}
