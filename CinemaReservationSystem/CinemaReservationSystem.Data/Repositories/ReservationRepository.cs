using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using CinemaReservationSystem.Data.Contexts;

namespace CinemaReservationSystem.Data.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
