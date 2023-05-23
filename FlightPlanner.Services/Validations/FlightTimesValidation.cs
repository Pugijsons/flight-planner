using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class FlightTimesValidation : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.ArrivalTime) && !string.IsNullOrEmpty(flight?.DepartureTime);
        }
    }
}
