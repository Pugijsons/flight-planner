using FlightPlanner.Models;
using FlightPlanner.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController]
    [Authorize]
    public class AdminApiController : BaseApiController
    {
        private static readonly object locker = new object();
        public AdminApiController(FlightPlannerDbContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlights(int id)
        {
            var flight = FlightStorageOperations.FetchFlight(_context, id);

            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult AddFlight(Flight flight)
        {
            lock (locker)
            {
                if (FlightStorageOperations.CheckFlight(flight) || FlightStorageOperations.CheckSameAirport(flight) || FlightStorageOperations.CheckTime(flight))
                {
                    return BadRequest();
                }

                if (FlightStorageOperations.CheckFlightDuplicate(_context, flight))
                {
                    return Conflict();
                }
   
                _context.Flights.Add(flight);
                _context.SaveChanges();
                return Created("", flight);
            }
         }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var flight = FlightStorageOperations.FetchFlight(_context, id);
            if (flight == null)
            {
                return Ok();
            }
            _context.Flights.Remove(flight);
            _context.SaveChanges();
            return Ok();
        }
    }
}
