using System.Collections.Generic;
using FlightPlanner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController]
    [Authorize]
    public class AdminApiController : BaseApiController
    {
        private readonly IFlightService _flightService;
        private static readonly object locker = new object();
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidate> _validator;

        public AdminApiController(
            IFlightService flightService,
            IMapper mapper,
            IEnumerable<IValidate> validator) 
        {
            _flightService = flightService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult GetFlights(int id)
        {
            var flight = _flightService.GetFullFlight(id);

            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPut]
        [Route("flights")]
        public IActionResult AddFlight(AddFlightRequest request)
        {
            lock (locker)
            {
                var flight = _mapper.Map<Flight>(request);
                if (!_validator.All(validator => validator.IsValid(flight)))
                {
                    return BadRequest();
                }

                if (_flightService.FlightExists(flight))
                {
                    return Conflict();
                }

                _flightService.Create(flight);
                return Created("", _mapper.Map<AddFlightRequest>(flight));
            }
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _flightService.GetFullFlight(id);
            if (flight == null)
            {
                return Ok();
            }
            _flightService.Delete(flight);
            return Ok();
        }
    }
}
