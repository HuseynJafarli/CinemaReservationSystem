using CinemaReservationSystem.Business.DTOs.ReservationDTOs;
using CinemaReservationSystem.Core.Entities;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Interfaces
{
    public interface IReservationService
    {
        Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, ReservationUpdateDto dto);
        Task<ReservationGetDto> GetByIdAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<Reservation, bool>>? expression = null);
        Task<ICollection<ReservationGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation,bool>>? expression = null , params string[] includes);
        Task<ReservationGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation,bool>>? expression = null , params string[] includes);
    }
}
