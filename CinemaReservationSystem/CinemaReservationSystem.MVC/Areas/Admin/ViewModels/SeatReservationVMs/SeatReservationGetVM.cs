namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.SeatReservationVMs
{
    public record SeatReservationGetVM(int Id, int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted,
                                       DateTime CreatedDate, DateTime ModifiedDate);
}
