namespace CinemaReservationSystem.Business.DTOs.TheaterDTOs
{
    public record TheaterCreateDto(string Name, string Location, int TotalSeats, bool IsDeleted);
}
