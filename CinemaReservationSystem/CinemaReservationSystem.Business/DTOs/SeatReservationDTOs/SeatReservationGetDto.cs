namespace CinemaReservationSystem.Business.DTOs.SeatReservationDTOs
{
    public record SeatReservationGetDto(int Id, string SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted,
                                        DateTime CreatedDate, DateTime ModifiedDate);
}
