using AutoMapper;
using CinemaReservationSystem.Business.DTOs.TheaterDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Implementations
{
    public class TheaterService: ITheaterService
    {
        private readonly IMapper mapper;
        private readonly ITheaterRepository theaterRepository;

        public TheaterService(IMapper mapper, ITheaterRepository theaterRepository)
        {
            this.mapper = mapper;
            this.theaterRepository = theaterRepository;
        }
        public async Task<TheaterGetDto> CreateAsync(TheaterCreateDto dto)
        {
            Theater theater = mapper.Map<Theater>(dto);
            theater.CreatedDate = DateTime.Now;
            theater.ModifiedDate = DateTime.Now;
            theater.IsDeleted = false;

            await theaterRepository.CreateAsync(theater);
            await theaterRepository.CommitAsync();

            TheaterGetDto getDto = mapper.Map<TheaterGetDto>(theater);

            return getDto;
        }
        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await theaterRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            theaterRepository.Delete(data);
            await theaterRepository.CommitAsync();
        }

        public async Task<ICollection<TheaterGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            var datas = await theaterRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException();

            ICollection<TheaterGetDto> dtos = mapper.Map<ICollection<TheaterGetDto>>(datas);
            return dtos;
        }

        public async Task<TheaterGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await theaterRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            TheaterGetDto dto = mapper.Map<TheaterGetDto>(data);

            return dto;
        }

        public async Task<TheaterGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Theater, bool>>? expression = null, params string[] includes)
        {
            var data = await theaterRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException();

            TheaterGetDto dto = mapper.Map<TheaterGetDto>(data);

            return dto;
        }

        public async Task<bool> IsExistAsync(Expression<Func<Theater, bool>>? expression = null)
        {
            return await theaterRepository.Table.AnyAsync(expression);
        }


        public async Task UpdateAsync(int? id, TheaterUpdateDto dto)
        {
            if (id < 1 || id is null) throw new InvalidIdException();

            var data = await theaterRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException();

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await theaterRepository.CommitAsync();
        }
    }
}
