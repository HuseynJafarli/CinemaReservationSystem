namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.SeatReservationVMs
{
    public record SeatReservationUpdateVM(int SeatNumber, bool IsBooked, int ReservationId, bool IsDeleted);
}
