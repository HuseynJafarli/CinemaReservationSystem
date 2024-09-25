using CinemaReservationSystem.Business.DTOs.ShowTimeDTOs;

namespace CinemaReservationSystem.Business.DTOs.TheaterDTOs
{
    public record TheaterGetDto(int Id, string Name, string Location, int TotalSeats, ICollection<ShowTimeGetDto>? ShowTimes,
                                DateTime CreatedDate, DateTime ModifiedDate);
}
