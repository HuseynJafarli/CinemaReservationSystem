using CinemaReservationSystem.MVC.ApiResponseMessages;
using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.TheaterVMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CinemaReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheaterController : Controller
    {
        private readonly RestClient restClient;
        public TheaterController()
        {
            restClient = new RestClient("https://localhost:7295/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("Theaters", Method.Get);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return View();
            }

            return View(response.Data.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TheaterCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest("Theaters", Method.Post);
            request.AddJsonBody(vm);

            var response = await restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (response == null || !response.IsSuccessful)
            {
                var errorMessage = response?.Data?.ErrorMessage ;
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest($"Theaters/{id}", Method.Get);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<TheaterGetVM>>(request);

            if (response == null || !response.IsSuccessful || response.Data == null || response.Data.Data == null)
            {
                string errorMessage = response?.Data?.ErrorMessage ;
                ViewBag.Err = errorMessage;
                return View();
            }

            TheaterUpdateVM vm = new TheaterUpdateVM(
                response.Data.Data.Name,
                response.Data.Data.Location,
                response.Data.Data.TotalSeats,
                response.Data.Data.IsDeleted
            );
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TheaterUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest($"Theaters/{id}", Method.Put);

            request.AddJsonBody(new
            {
                vm.Name,
                vm.Location,
                vm.TotalSeats,
                vm.IsDeleted
            });

            var response = await restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (!response.IsSuccessful)
            {
                string errorMessage = response?.Data?.ErrorMessage ;
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"Theaters/{id}", Method.Delete);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
