using FlightPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace FlightPlanner.Storage
{
    public class FlightStorageOperations
    {
        public static Flight FetchFlight(FlightPlannerDbContext context, int id)
        {
            return context.Flights.Include(f => f.From)
                 .Include(f => f.To)
                 .SingleOrDefault(f => f.Id == id);
        }

        public static bool CheckFlightDuplicate(FlightPlannerDbContext context, Flight flight)
        {
            return context.Flights.Any(f =>
            f.To.AirportCode == flight.To.AirportCode
            && f.From.AirportCode == flight.From.AirportCode
            && f.Carrier == flight.Carrier
            && f.DepartureTime == flight.DepartureTime
            && f.ArrivalTime == flight.ArrivalTime);
        }

        public static bool CheckFlight(Flight flight)
        {
                if (flight.To == null || flight.From == null)
                {
                    return true;
                }

            if (string.IsNullOrEmpty(flight.To.Country) || string.IsNullOrEmpty(flight.To.AirportCode) || string.IsNullOrEmpty(flight.To.City) ||
                string.IsNullOrEmpty(flight.From.Country) || string.IsNullOrEmpty(flight.From.AirportCode) || string.IsNullOrEmpty(flight.From.City) ||
                string.IsNullOrEmpty(flight.DepartureTime) || string.IsNullOrEmpty(flight.ArrivalTime) || string.IsNullOrEmpty(flight.Carrier))
            {
                return true;
            }
            return false;
        }

        public static bool CheckSameAirport(Flight flight)
        {
            if (flight.From.Equals(flight.To))
            {
                return true;
            }
            return false;
        }

        public static bool CheckTime(Flight flight)
        {
            DateTime depart = DateTime.Parse(flight.DepartureTime);
            DateTime arrival = DateTime.Parse(flight.ArrivalTime);
            if (DateTime.Compare(depart, arrival) >= 0)
            {
                return true;
            }
            return false;
        }

        public static Airport[] SearchAirport(FlightPlannerDbContext context, string search)
        {
            var flights = context.Flights.
                Include(f => f.From)
                .Include(f => f.To)
                .ToList();

            var returnList = flights
                .SelectMany(flight => new[] { flight.From, flight.To })
                .Where(airport => airport != null && airport.Compare(search))
                .Distinct()
                .ToArray();

            return returnList;
        }

        public static PageResult SearchFlight(FlightPlannerDbContext context, SearchFlightRequest search)
        {
            var flights = context.Flights.
               Include(f => f.From)
               .Include(f => f.To)
               .ToList();
            List<Flight> returnList = new List<Flight>();
            foreach (Flight flight in flights)
            {
                if (search.To.Equals(flight.To.AirportCode) && search.From.Equals(flight.From.AirportCode))
                {
                    returnList.Add(flight);
                }
            }
            PageResult result = new PageResult();
            result.Items = returnList.ToArray();
            result.TotalItems = returnList.Count();
            result.Page = 0;
            return result;
        }
    }
}
