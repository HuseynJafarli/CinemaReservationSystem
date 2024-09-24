namespace CinemaReservationSystem.Business.DTOs.MovieDTOs
{
    public record MovieCreateDto(string Title, string? Description, int Duration, double? Rating, DateTime ReleaseDate, string Genre, bool IsDeleted);
}
