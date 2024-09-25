using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.SeatReservationVMs;

namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ReservationVMs
{
    public record ReservationGetVM(int Id, DateTime ReservationDate, string AppUserId, int ShowTimeId, bool IsDeleted, DateTime CreatedDate,
                                   DateTime ModifiedDate, ICollection<SeatReservationGetVM>? SeatReservations);
}
