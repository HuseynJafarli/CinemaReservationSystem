using AutoMapper;
using CinemaReservationSystem.Business.DTOs.MovieDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;
        private readonly IMovieRepository movieRepository;

        public MovieService(IMapper mapper, IMovieRepository movieRepository)
        {
            this.mapper = mapper;
            this.movieRepository = movieRepository;
        }
        public async Task<MovieGetDto> CreateAsync(MovieCreateDto dto)
        {
            Movie movie = mapper.Map<Movie>(dto);
            movie.CreatedDate = DateTime.Now;
            movie.ModifiedDate = DateTime.Now;
            movie.IsDeleted = false;

            await movieRepository.CreateAsync(movie);
            await movieRepository.CommitAsync();

            MovieGetDto getDto = mapper.Map<MovieGetDto>(movie);

            return getDto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");
            var data = await movieRepository.GetByIdAsync(id);
            if(data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");
            movieRepository.Delete(data);
            await movieRepository.CommitAsync();
        }

        public async Task<ICollection<MovieGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var datas = await movieRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            ICollection<MovieGetDto> dtos = mapper.Map<ICollection<MovieGetDto>>(datas);
            return dtos;

        }

        public async Task<MovieGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");
            ;
            var data = await movieRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");
            MovieGetDto dto = mapper.Map<MovieGetDto>(data);
            return dto;
        }

        public async Task<MovieGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var data = await movieRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            MovieGetDto dto = mapper.Map<MovieGetDto>(data);
            return dto;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Movie, bool>>? expression = null)
        {
            return await movieRepository.Table.AnyAsync(expression);
        }

        public async Task UpdateAsync(int? id, MovieUpdateDto dto)
        {
            if (id < 1 || id is null) throw new InvalidIdException(400, "", "Id cant be less than 1 or null");

            var data = await movieRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException(404, "", "Movie Not Found");

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await movieRepository.CommitAsync();
        }
    }
}
