namespace CinemaReservationSystem.MVC.Areas.Admin.ViewModels.TheaterVMs
{
    public record TheaterUpdateVM(string Name, string Location, int TotalSeats, bool IsDeleted);
}
