namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.TheaterVMs
{
    public record TheaterCreateVM(string Name, string Location, int TotalSeats, bool IsDeleted);
}
