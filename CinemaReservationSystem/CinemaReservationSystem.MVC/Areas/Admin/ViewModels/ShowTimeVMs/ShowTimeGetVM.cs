using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ReservationVMs;

namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ShowTimeVMs
{
    public record ShowTimeGetVM(int Id, DateTime StartTime, DateTime EndTime, bool IsDeleted, int MovieId, int TheaterId, string MovieTitle,
                                string TheaterName, DateTime CreatedDate, DateTime ModifiedDate, ICollection<ReservationGetVM>? Reservations);
}
