using CinemaReservationSystem.API.ApiResponses;
using CinemaReservationSystem.Business.DTOs.SeatReservationDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatReservationsController : ControllerBase
    {
        private readonly ISeatReservationService seatReservationService;

        public SeatReservationsController(ISeatReservationService seatReservationService)
        {
            this.seatReservationService = seatReservationService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<SeatReservationGetDto>>
            {
                Data = await seatReservationService.GetByExpressionAsync(true, null, "Reservation"),
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeatReservationCreateDto dto)
        {
            SeatReservationGetDto movie = null;
            try
            {
                movie = await seatReservationService.CreateAsync(dto);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            SeatReservationGetDto dto = null;
            try
            {
                dto = await seatReservationService.GetByIdAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }

            return Ok(new ApiResponse<SeatReservationGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK,
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeatReservationUpdateDto dto)
        {
            try
            {
                await seatReservationService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<SeatReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                });
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await seatReservationService.DeleteAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
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
