using CinemaReservationSystem.Business.DTOs.ReservationDTOs;

namespace CinemaReservationSystem.Business.DTOs.ShowTimeDTOs
{
    public record ShowTimeGetDto(int Id, DateTime StartTime, DateTime EndTime, bool IsDeleted, int MovieId, int TheaterId, string MovieTitle,
                                 string TheaterName, DateTime CreatedDate, DateTime ModifiedDate, ICollection<ReservationGetDto>? Reservations);
}
