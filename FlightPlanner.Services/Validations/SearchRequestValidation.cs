using FlightPlanner.Core.Validations;
using FlightPlanner.Models;

namespace FlightPlanner.Services.Validations
{
    public class SearchRequestValidation : ISearchRequestValidation
    {
        public bool IsSearchRequestValid(SearchFlightRequest request)
        {
            return string.IsNullOrEmpty(request.To) || string.IsNullOrEmpty(request.From) || request.To == request.From;
        }
    }
}
