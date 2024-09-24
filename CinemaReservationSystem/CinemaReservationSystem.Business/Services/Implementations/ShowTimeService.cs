using AutoMapper;
using CinemaReservationSystem.Business.DTOs.ShowTimeDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Implementations
{
    public class ShowTimeService : IShowTimeService
    {
        private readonly IShowTimeRepository showTimeRepository;
        private readonly IMapper mapper;

        public ShowTimeService(IShowTimeRepository showTimeRepository, IMapper mapper)
        {
            this.showTimeRepository = showTimeRepository;
            this.mapper = mapper;
        }
        public async Task<ShowTimeGetDto> CreateAsync(ShowTimeCreateDto dto)
        {
            ShowTime data = mapper.Map<ShowTime>(dto);
            data.CreatedDate = DateTime.Now;
            data.ModifiedDate = DateTime.Now;
            data.IsDeleted = false;
            if (data == null) throw new Exception();

            await showTimeRepository.CreateAsync(data);
            await showTimeRepository.CommitAsync();

            ShowTimeGetDto mapped = mapper.Map<ShowTimeGetDto>(data);
            return mapped;
        }

        public async Task DeleteAsync(int id)
        {
            if(id < 1) throw new InvalidIdException();
            var data = await showTimeRepository.GetByIdAsync(id);
            if(data == null) throw new EntityNotFoundException();
            showTimeRepository.Delete(data);
            await showTimeRepository.CommitAsync();
        }

        public async Task<ICollection<ShowTimeGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            var datas = await showTimeRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException();
            ICollection<ShowTimeGetDto> dtos = mapper.Map<ICollection<ShowTimeGetDto>>(datas);
            return dtos;
        }

        public async Task<ShowTimeGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await showTimeRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            ShowTimeGetDto dto = mapper.Map<ShowTimeGetDto>(data);

            return dto;
        }

        public async Task<ShowTimeGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<ShowTime, bool>>? expression = null, params string[] includes)
        {
            var data = await showTimeRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException();

            ShowTimeGetDto dto = mapper.Map<ShowTimeGetDto>(data);

            return dto;
        }

        public async Task UpdateAsync(int? id, ShowTimeUpdateDto dto)
        {
            if(id < 1 || id == null) throw new InvalidIdException();
            var data = await showTimeRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException();

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await showTimeRepository.CommitAsync();
        }
    }
}
