using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;

namespace CinemaReservationSystem.Data.Repositories
{
    public class TheaterRepository : GenericRepository<Theater>, ITheaterRepository
    {
        public TheaterRepository(AppDbContext context) : base(context)
        {
        }
    }
}
