using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validations;
using FlightPlanner.Models;
using FlightPlanner.Services.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanner.Services
{
    public static class DependencyResolutionUtils
    {
        public static void RegisterValidations(this IServiceCollection services)
        {
            services.AddScoped<IValidate, FlightValidation>();
            services.AddScoped<IValidate, FlightCarrierValidation>();
            services.AddScoped<IValidate, FlightTimesValidation>();
            services.AddScoped<IValidate, AirportValidation>();
            services.AddScoped<IValidate, AirportPropsValidation>();
            services.AddScoped<IValidate, FlightTimesIntervalValidator>();
            services.AddScoped<IValidate, FlightAirportValidator>();
            services.AddScoped<ISearchRequestValidation, SearchRequestValidation>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDbService, DbService>();
            services.AddScoped<IEntityService<Flight>, EntityService<Flight>>();
            services.AddScoped<IEntityService<Airport>, EntityService<Airport>>();
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAirportService, AirportService>();
        }
    }
}
