namespace CinemaReservationSystem.Business.DTOs.MovieDTOs
{
    public record MovieUpdateDto(string Title, string? Description, int Duration, double? Rating, bool IsDeleted, string Genre, DateTime ReleaseDate);
}
