using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;
using CinemaReservationSystem.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaReservationSystem.Data
{
    public static class ServiceRegistration
    {

        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<ITheaterRepository, TheaterRepository>();
            services.AddScoped<ISeatReservationRepository, SeatReservationRepository>();
            services.AddScoped<IShowTimeRepository, ShowTimeRepository>();


            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
        }
    }
}
