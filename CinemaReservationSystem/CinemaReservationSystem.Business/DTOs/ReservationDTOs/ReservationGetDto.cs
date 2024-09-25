using CinemaReservationSystem.Business.DTOs.SeatReservationDTOs;

namespace CinemaReservationSystem.Business.DTOs.ReservationDTOs
{
    public record ReservationGetDto(int Id, DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted, DateTime CreatedDate,
                                    DateTime ModifiedDate, ICollection<SeatReservationGetDto>? SeatReservations);
}
