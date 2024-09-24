using CinemaReservationSystem.API.ApiResponses;
using CinemaReservationSystem.Business.DTOs.ReservationDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaReservationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponse<ICollection<ReservationGetDto>>
            {
                Data = await reservationService.GetByExpressionAsync(true,null, "ShowTime"),
                ErrorMessage = null,
                PropertyName = null,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateDto dto)
        {
            ReservationGetDto movie = null;
            try
            {
                movie = await reservationService.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ReservationGetDto dto = null;
            try
            {
                dto = await reservationService.GetByIdAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<ReservationGetDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<ReservationGetDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ReservationGetDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok(new ApiResponse<ReservationGetDto>
            {
                Data = dto,
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReservationUpdateDto dto)
        {
            try
            {
                await reservationService.UpdateAsync(id, dto);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<ReservationUpdateDto>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = "Id is not valid",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<ReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<ReservationUpdateDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }
            return Ok(new ApiResponse<ReservationUpdateDto>
            {
                StatusCode = StatusCodes.Status200OK,
                ErrorMessage = null,
                Data = dto
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await reservationService.DeleteAsync(id);
            }
            catch (InvalidIdException ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = ex.StatusCode,
                    ErrorMessage = "Id is not valid",
                    Data = null
                });
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    ErrorMessage = "Entity not found",
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<object>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    ErrorMessage = ex.Message,
                    Data = null
                });
            }

            return Ok();

        }
    }
}

