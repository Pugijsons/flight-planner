using FlightPlanner.Models;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace FlightPlanner.Storage
{
    public class FlightStorage
    {
        private static List<Flight> _flights = new List<Flight>();
        private static int _id;
        public static Flight GetFlight(int id)
        {
            return _flights.SingleOrDefault(x => x.Id == id);
        }

        public static Flight AddFlight(Flight flight)
        {
            lock (_flights)
            {
                flight.Id = _id++;
                _flights.Add(flight);
                return flight;
            }
        }

        public static void DeleteFlight(int id)
        {
            lock (_flights)
            {
                var flightToDelete = _flights.FirstOrDefault(x => x.Id == id);
                _flights.Remove(flightToDelete);
            }
        }

        public static bool CheckFlightDuplicate(Flight flight) 
        {
            lock (_flights)
            {
                return _flights.Any(f => f.To.Equals(flight.To) && f.From.Equals(flight.From) && f.Carrier == flight.Carrier && f.DepartureTime == flight.DepartureTime && f.ArrivalTime == flight.ArrivalTime);
            }
        }

        public static bool CheckFlight(Flight flight)
        {
            if (flight.To == null || flight.From == null) 
            {
                return true;
            }

            if(string.IsNullOrEmpty(flight.To.Country) || string.IsNullOrEmpty(flight.To.AirportCode) || string.IsNullOrEmpty(flight.To.City) || 
                string.IsNullOrEmpty(flight.From.Country) || string.IsNullOrEmpty(flight.From.AirportCode) || string.IsNullOrEmpty(flight.From.City) || 
                string.IsNullOrEmpty(flight.DepartureTime) || string.IsNullOrEmpty(flight.ArrivalTime) || string.IsNullOrEmpty(flight.Carrier))
                {
                    return true;
                }
            return false;
        }

        public static bool CheckSameAirport(Flight flight)
        {
            if(flight.From.Equals(flight.To))
            {
                return true;
            }
            return false;
        }

        public static bool CheckTime(Flight flight)
        {
            DateTime depart = DateTime.Parse(flight.DepartureTime);
            DateTime arrival = DateTime.Parse(flight.ArrivalTime);
            if(DateTime.Compare(depart,arrival) >= 0)
            {
                return true;
            }
            return false;
        }

        public static void Clear()
        {
            _flights.Clear();
        }

        public static Airport[] SearchAirport(string search)
        {
               List<Airport> returnList = new List<Airport>();
                foreach (Flight flight in _flights)
                {
                    if (flight.From.Compare(search))
                    {
                        returnList.Add(flight.From);
                    }

                    if (flight.To.Compare(search))
                    {
                        returnList.Add(flight.To);
                    }
                }
                return returnList.ToArray();
        }

        public static PageResult SearchFlight(SearchFlightRequest search)
        {
                List<Flight> returnList = new List<Flight>();
                foreach (Flight flight in _flights)
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

        public static Flight SearchFlightById(int id)
        {
            return _flights.FirstOrDefault(x => x.Id == id);
        }
    }
}
