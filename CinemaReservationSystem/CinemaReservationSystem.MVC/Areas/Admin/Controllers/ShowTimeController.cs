using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowTimeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
