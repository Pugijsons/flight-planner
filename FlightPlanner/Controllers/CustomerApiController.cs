using FlightPlanner.Models;
using FlightPlanner.Storage;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : Controller
    {
        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirport(string search)
        {
            var result = FlightStorage.SearchAirport(search);
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
            var result = FlightStorage.SearchFlight(search);
            return Ok(result);
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult SearchFlightById(int id)
        {
            if(FlightStorage.SearchFlightById(id) == null) 
            { 
                return NotFound(); 
            }
            return Ok(FlightStorage.SearchFlightById(id));
        }
    }
}
