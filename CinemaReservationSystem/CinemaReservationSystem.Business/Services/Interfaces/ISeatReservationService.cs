using CinemaReservationSystem.Business.DTOs.SeatReservationDTOs;
using CinemaReservationSystem.Core.Entities;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Interfaces
{
    public interface ISeatReservationService
    {
        Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, SeatReservationUpdateDto dto);
        Task<SeatReservationGetDto> GetByIdAsync(int id);
        Task<ICollection<SeatReservationGetDto>> GetByExpressionAsync(bool asNoTracking = false,Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
        Task<SeatReservationGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes);
    }
}
