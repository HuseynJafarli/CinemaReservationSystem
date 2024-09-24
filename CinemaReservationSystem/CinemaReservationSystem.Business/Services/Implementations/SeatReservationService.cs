using AutoMapper;
using CinemaReservationSystem.Business.DTOs.SeatReservationDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Implementations
{
    public class SeatReservationService: ISeatReservationService
    {
        private readonly IMapper mapper;
        private readonly ISeatReservationRepository seatReservationRepository;

        public SeatReservationService(IMapper mapper, ISeatReservationRepository seatReservationRepository)
        {
            this.mapper = mapper;
            this.seatReservationRepository = seatReservationRepository;
        }
        public async Task<SeatReservationGetDto> CreateAsync(SeatReservationCreateDto dto)
        {
            SeatReservation seatReservation = mapper.Map<SeatReservation>(dto);
            seatReservation.CreatedDate = DateTime.Now;
            seatReservation.ModifiedDate = DateTime.Now;
            seatReservation.IsDeleted = false;

            await seatReservationRepository.CreateAsync(seatReservation);
            await seatReservationRepository.CommitAsync();

            SeatReservationGetDto getDto = mapper.Map<SeatReservationGetDto>(seatReservation);

            return getDto;
        }
        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await seatReservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            seatReservationRepository.Delete(data);
            await seatReservationRepository.CommitAsync();
        }
        public async Task<ICollection<SeatReservationGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            var datas = await seatReservationRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException();

            ICollection<SeatReservationGetDto> dtos = mapper.Map<ICollection<SeatReservationGetDto>>(datas);
            return dtos;
        }
        public async Task<SeatReservationGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await seatReservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            SeatReservationGetDto dto = mapper.Map<SeatReservationGetDto>(data);

            return dto;
        }
        public async Task<SeatReservationGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<SeatReservation, bool>>? expression = null, params string[] includes)
        {
            var data = await seatReservationRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException();

            SeatReservationGetDto dto = mapper.Map<SeatReservationGetDto>(data);

            return dto;
        }
        public async Task UpdateAsync(int? id, SeatReservationUpdateDto dto)
        {
            if (id < 1 || id is null) throw new InvalidIdException();

            var data = await seatReservationRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException();

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await seatReservationRepository.CommitAsync();
        }
    }
}
