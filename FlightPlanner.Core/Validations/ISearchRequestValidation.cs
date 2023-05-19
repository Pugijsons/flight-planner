using FlightPlanner.Models;

namespace FlightPlanner.Core.Validations
{
    public interface ISearchRequestValidation
    {
        bool IsSearchRequestValid(SearchFlightRequest request);
    }
}
