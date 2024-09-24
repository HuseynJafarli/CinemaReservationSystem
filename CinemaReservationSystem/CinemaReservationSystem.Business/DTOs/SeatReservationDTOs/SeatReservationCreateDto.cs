namespace CinemaReservationSystem.Business.DTOs.SeatReservationDTOs
{
    public record SeatReservationCreateDto(string SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);

}
