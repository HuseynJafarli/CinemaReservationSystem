using CinemaReservationSystem.API.ApiResponses;
using CinemaReservationSystem.Business.DTOs.ReservationDTOs;
using CinemaReservationSystem.Business.DTOs.TheaterDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly ITheaterService theaterService;

        public TheatersController(ITheaterService theaterService)
        {
            this.theaterService = theaterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ICollection<TheaterGetDto> data = null;
            try
            {
                data = await theaterService.GetByExpressionAsync(true, null);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(new ApiResponse<ICollection<TheaterGetDto>>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity could not be found",
                    Data = data
                });
            }
            return Ok(new ApiResponse<ICollection<TheaterGetDto>>
            {
                StatusCode = StatusCodes.Status200OK,
                Data = data
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TheaterGetDto data = null;
            try
            {
                data = await theaterService.GetByIdAsync(id);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest(new ApiResponse<TheaterGetDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity could not be found",
                    Data = data
                });
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<TheaterGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = "Id is not valid",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }
            return Ok(new ApiResponse<TheaterGetDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Data = data
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TheaterCreateDto dto)
        {
            try
            {
                var data = await theaterService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TheaterUpdateDto dto)
        {
            try
            {
                await theaterService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<TheaterUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = "Id is not valid",
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<TheaterUpdateDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<TheaterUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }
            return Ok(new ApiResponse<TheaterUpdateDto>
            {
                StatusCode = StatusCodes.Status200OK,
                Data = dto
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await theaterService.DeleteAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = "Id is not valid",
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }

            return Ok();
        }


    }
}
