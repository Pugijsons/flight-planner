using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class AirportValidation : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return flight.From != null && flight.To != null;
        }
    }
}
