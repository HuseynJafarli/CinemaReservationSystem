namespace CinemaReservationSystem.Core.Entities
{
    public class SeatReservation: BaseEntity
    {
        public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

    }
}
