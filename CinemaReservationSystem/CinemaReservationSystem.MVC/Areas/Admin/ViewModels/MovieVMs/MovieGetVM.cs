using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.ShowTimeVMs;

namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.MovieVMs
{
    public record MovieGetVM(int Id, string Title, string Description, int Duration,double Rating, bool IsDeleted, DateTime CreatedDate,
                             DateTime ModifiedDate, string Genre, DateTime ReleaseDate, ICollection<ShowTimeGetVM>? ShowTimes);
}
