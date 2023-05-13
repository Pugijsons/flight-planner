using FlightPlanner.Models;
using FlightPlanner.Storage;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : BaseApiController
    {
        public CustomerApiController(FlightPlannerDbContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirport(string search)
        {
            var result = FlightStorageOperations.SearchAirport(_context, search);
            if(result == null) 
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlight(SearchFlightRequest search)
        {
            if(string.IsNullOrEmpty(search.To) || string.IsNullOrEmpty(search.From) || search.To == search.From)
            {
                return BadRequest();
            }
            var result = FlightStorageOperations.SearchFlight(_context, search);
            return Ok(result);
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult SearchFlightById(int id)
        {
            var flight = FlightStorageOperations.FetchFlight(_context, id);
            if (flight == null) 
            { 
                return NotFound(); 
            }
            return Ok(flight);
        }
    }
}
