using CinemaReservationSystem.MVC.ApiResponseMessages;
using CinemaReservationSystem.MVC.Areas.Admin.ViewModels.MovieVMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace CinemaReservationSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly RestClient restClient;
        public MovieController()
        {
            restClient = new RestClient("https://localhost:7295/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("Movies", Method.Get);
            var response = await restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(request);

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
        public async Task<IActionResult> Create(MovieCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var movieRequest = new RestRequest("Movies", Method.Post);
            movieRequest.AddJsonBody(vm);

            var movieResponse = await restClient.ExecuteAsync<ApiResponseMessage<object>>(movieRequest);

            if (movieResponse == null || !movieResponse.IsSuccessful)
            {
                var errorMessage = movieResponse?.Data?.ErrorMessage;
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var movieRequest = new RestRequest($"Movies/{id}", Method.Get);
            var movieResponse = await restClient.ExecuteAsync<ApiResponseMessage<MovieGetVM>>(movieRequest);

            if (movieResponse == null || !movieResponse.IsSuccessful)
            {
                string errorMessage = movieResponse?.Data?.ErrorMessage;
                ViewBag.Err = errorMessage;
                return View();
            }

            MovieUpdateVM vm = new MovieUpdateVM(
                movieResponse.Data.Data.Title,
                movieResponse.Data.Data.Description,
                movieResponse.Data.Data.Duration,
                movieResponse.Data.Data.Rating,
                movieResponse.Data.Data.ReleaseDate,
                movieResponse.Data.Data.Genre,
                movieResponse.Data.Data.IsDeleted
            );

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, MovieUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var movieRequest = new RestRequest($"Movies/{id}", Method.Put);

            movieRequest.AddJsonBody(new
            {
                vm.Title,
                vm.Description,
                vm.IsDeleted,
                vm.Genre,
                vm.Duration,
                vm.Rating,
                vm.ReleaseDate
            });

            var movieResponse = await restClient.ExecuteAsync<ApiResponseMessage<object>>(movieRequest);

            if (!movieResponse.IsSuccessful)
            {
                string errorMessage = movieResponse?.Data?.ErrorMessage;
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"Movies/{id}", Method.Delete);
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

