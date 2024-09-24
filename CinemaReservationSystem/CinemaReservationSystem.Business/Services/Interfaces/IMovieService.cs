using CinemaReservationSystem.Business.DTOs.MovieDTOs;
using CinemaReservationSystem.Core.Entities;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieGetDto> CreateAsync(MovieCreateDto dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, MovieUpdateDto dto);
        Task<MovieGetDto> GetByIdAsync(int id);
        Task<bool> IsExistAsync(Expression<Func<Movie, bool>>? expression = null);
        Task<ICollection<MovieGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
        Task<MovieGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
    }
}
