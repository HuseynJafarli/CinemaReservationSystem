namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.MovieVMs
{
    public record MovieCreateVM(string Title, string Description, int Duration,double Rating, DateTime ReleaseDate, string Genre, bool IsDeleted);
}
