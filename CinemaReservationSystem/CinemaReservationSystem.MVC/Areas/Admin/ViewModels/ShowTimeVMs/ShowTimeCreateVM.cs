namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ShowTimeVMs
{
    public record ShowTimeCreateVM(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted);
}
