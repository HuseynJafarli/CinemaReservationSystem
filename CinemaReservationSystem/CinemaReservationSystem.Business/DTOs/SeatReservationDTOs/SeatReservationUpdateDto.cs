namespace CinemaReservationSystem.Business.DTOs.SeatReservationDTOs
{
    public record SeatReservationUpdateDto(string SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);

}
