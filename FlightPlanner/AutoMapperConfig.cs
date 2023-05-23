using AutoMapper;
using FlightPlanner.Models;

namespace FlightPlanner
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AddFlightRequest, Flight>();
                    cfg.CreateMap<Flight, AddFlightRequest>();
                    cfg.CreateMap<AddAirportRequest, Airport>()
                        .ForMember(d => d.AirportCode, opt => opt.MapFrom(s => s.Airport))
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Airport, AddAirportRequest>()
                        .ForMember(d => d.Airport, opt => opt.MapFrom(s => s.AirportCode));
                    cfg.CreateMap<Airport, ReplyAirport>()
                        .ForMember(d => d.Airport, opt => opt.MapFrom(s => s.AirportCode));
                    cfg.CreateMap<Flight, ReplyFlight>()
                        .ForMember(d => d.To, opt => opt.MapFrom((s => s.To)));
                }
            );

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}
