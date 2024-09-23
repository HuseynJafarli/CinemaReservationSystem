using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;

namespace CinemaReservationSystem.Data.Repositories
{
    public class SeatReservationRepository : GenericRepository<SeatReservation>, ISeatReservationRepository
    {
        public SeatReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
