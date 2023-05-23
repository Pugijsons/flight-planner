﻿using FlightPlanner.Data;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class CleanupController : BaseApiController
    {
        private readonly IFlightPlannerDbContext _context;
        public CleanupController(IFlightPlannerDbContext context)
        { 
            _context = context;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);
            _context.SaveChanges();
            return Ok();
        }
    }
}
