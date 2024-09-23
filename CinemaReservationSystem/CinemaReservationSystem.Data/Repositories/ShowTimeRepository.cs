using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;

namespace CinemaReservationSystem.Data.Repositories
{
    public class ShowTimeRepository : GenericRepository<ShowTime>, IShowTimeRepository
    {
        public ShowTimeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
