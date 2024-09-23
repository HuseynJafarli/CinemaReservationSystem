using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;

namespace CinemaReservationSystem.Data.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context)
        {
        }
    }
}
