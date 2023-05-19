using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Models;

namespace FlightPlanner.Core.Validations
{
    public interface ISearchRequestValidation
    {
        bool IsSearchRequestValid(SearchFlightRequest request);
    }
}
