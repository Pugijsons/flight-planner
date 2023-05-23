using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class FlightCarrierValidation : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight.Carrier);
        }
    }
}
