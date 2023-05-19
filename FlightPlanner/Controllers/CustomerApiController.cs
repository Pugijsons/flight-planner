using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations;
using FlightPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerApiController : BaseApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ISearchRequestValidation _searchRequestValidation;
        public CustomerApiController(ICustomerService customerService, IMapper mapper, ISearchRequestValidation searchRequestValidation) 
        {
            _customerService = customerService;
            _mapper = mapper;
            _searchRequestValidation = searchRequestValidation;
        }

        [HttpGet]
        [Route("airports")]
        public IActionResult SearchAirports(string search)
        {
            var result = _customerService.SearchAirports(search);
            if (result == null)
            {
                return NotFound();
            }
            List<ReplyAirport> returnList = new List<ReplyAirport>();
            foreach (var item in result)
            {
                returnList.Add(_mapper.Map<ReplyAirport>(item));
            }
            return Ok(returnList);
        }

        [HttpPost]
        [Route("flights/search")]
        public IActionResult SearchFlights(SearchFlightRequest request)
        {
            if (_searchRequestValidation.IsSearchRequestValid(request))
            {
                return BadRequest();
            }

            return Ok(_customerService.SearchFlights(request));
        }

        [HttpGet]
        [Route("flights/{id}")]
        public IActionResult SearchFlightById(int id)
        {
            var flight = _customerService.GetFlightById(id);
            if (flight == null) 
            { 
                return NotFound(); 
            }
            return Ok(_mapper.Map<ReplyFlight>(flight));
        }
    }
}