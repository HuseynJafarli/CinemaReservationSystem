using CinemaReservationSystem.Business.DTOs.ShowTimeDTOs;
using CinemaReservationSystem.Core.Entities;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, ShowTimeUpdateDto dto);
        Task<ShowTimeGetDto> GetByIdAsync(int id);
        Task<ICollection<ShowTimeGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
        Task<ShowTimeGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes);
    }
}
