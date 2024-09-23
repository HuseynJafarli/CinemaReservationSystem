using Microsoft.AspNetCore.Identity;

namespace CinemaReservationSystem.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
