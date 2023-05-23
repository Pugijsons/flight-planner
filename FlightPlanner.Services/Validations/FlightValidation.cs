using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class FlightValidation : IValidate
    {
        public bool IsValid(Flight flight)
        {
            return flight != null;
        }
    }
}
