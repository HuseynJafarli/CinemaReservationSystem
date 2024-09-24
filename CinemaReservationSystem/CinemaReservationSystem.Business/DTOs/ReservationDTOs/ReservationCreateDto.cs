namespace CinemaReservationSystem.Business.DTOs.ReservationDTOs
{
    public record ReservationCreateDto(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);
}
