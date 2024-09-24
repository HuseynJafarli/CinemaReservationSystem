using CinemaReservationSystem.Business.DTOs.ShowTimeDTOs;

namespace CinemaReservationSystem.Business.DTOs.MovieDTOs
{
    public record MovieGetDto(int Id, string Title, string? Description, int Duration, double? Rating, bool IsDeleted, DateTime CreatedDate,
                             DateTime ModifiedDate, string Genre, DateTime ReleaseDate, ICollection<ShowTimeGetDto>? ShowTimes);
}
