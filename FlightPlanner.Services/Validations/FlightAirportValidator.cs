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
