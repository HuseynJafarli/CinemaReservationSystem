using CinemaReservationSystem.Business.Services.Implementations;
using CinemaReservationSystem.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaReservationSystem.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITheaterService, TheaterService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IShowTimeService, ShowTimeService>();
            services.AddScoped<ISeatReservationService, SeatReservationService>();
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
