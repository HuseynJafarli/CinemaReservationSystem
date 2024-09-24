namespace CinemaReservationSystem.Business.DTOs.ReservationDTOs
{
    public record ReservationUpdateDto(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

}
