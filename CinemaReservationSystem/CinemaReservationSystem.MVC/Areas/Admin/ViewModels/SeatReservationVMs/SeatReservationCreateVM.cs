namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.SeatReservationVMs
{
    public record SeatReservationCreateVM(int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);
}
