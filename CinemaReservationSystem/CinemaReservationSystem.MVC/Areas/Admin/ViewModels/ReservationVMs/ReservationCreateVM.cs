namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ReservationVMs
{
    public record ReservationCreateVM(DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted);

}
