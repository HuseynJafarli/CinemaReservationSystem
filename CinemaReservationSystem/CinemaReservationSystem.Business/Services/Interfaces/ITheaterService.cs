using CinemaReservationSystem.Business.DTOs.TheaterDTOs;
using CinemaReservationSystem.Core.Entities;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Interfaces
{
    public interface ITheaterService
    {
        Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, TheaterUpdateDto dto);
        Task<TheaterGetDto> GetByIdAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<Theater, bool>> predicate);
        Task<ICollection<TheaterGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
        Task<TheaterGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes);
    }
}
