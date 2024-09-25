namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ReservationVMs
{
    public record ReservationUpdateVM(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

}
