using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ShowTimeVMs;

namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.TheaterVMs
{
    public record TheaterGetVM(int Id, string Name, string Location, int TotalSeats, ICollection<ShowTimeGetVM>? ShowTimes,
                               DateTime CreatedDate, DateTime ModifiedDate, bool IsDeleted);
}
