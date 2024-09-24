using AutoMapper;
using CinemaReservationSystem.Business.DTOs.ReservationDTOs;
using CinemaReservationSystem.Business.Exceptions.Common;
using CinemaReservationSystem.Business.Services.Interfaces;
using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CinemaReservationSystem.Business.Services.Implementations
{
    public class ReservationService: IReservationService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly IMapper mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            this.reservationRepository = reservationRepository;
            this.mapper = mapper;
        }
        public async Task<ReservationGetDto> CreateAsync(ReservationCreateDto dto)
        {
            Reservation reservation = mapper.Map<Reservation>(dto);
            reservation.CreatedDate = DateTime.Now;
            reservation.ModifiedDate = DateTime.Now;
            reservation.IsDeleted = false;

            await reservationRepository.CreateAsync(reservation);
            await reservationRepository.CommitAsync();

            ReservationGetDto getDto = mapper.Map<ReservationGetDto>(reservation);

            return getDto;
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await reservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            reservationRepository.Delete(data);
            await reservationRepository.CommitAsync();
        }

        public async Task<ICollection<ReservationGetDto>> GetByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var datas = await reservationRepository.GetByExpression(asNoTracking, expression ,includes).ToListAsync();
            if (datas == null) throw new EntityNotFoundException();

            ICollection<ReservationGetDto> dtos = mapper.Map<ICollection<ReservationGetDto>>(datas);
            return dtos;
        }

        public async Task<ReservationGetDto> GetByIdAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await reservationRepository.GetByIdAsync(id);
            if (data == null) throw new EntityNotFoundException();

            ReservationGetDto dto = mapper.Map<ReservationGetDto>(data);

            return dto;
        }

        public async Task<ReservationGetDto> GetSingleByExpressionAsync(bool asNoTracking = false, Expression<Func<Reservation, bool>>? expression = null, params string[] includes)
        {
            var data = await reservationRepository.GetByExpression(asNoTracking,expression, includes).FirstOrDefaultAsync();
            if (data == null) throw new EntityNotFoundException();

            ReservationGetDto dto = mapper.Map<ReservationGetDto>(data);

            return dto;
        }

        public async Task UpdateAsync(int? id, ReservationUpdateDto dto)
        {
            if (id < 1 || id is null) throw new InvalidIdException();

            var data = await reservationRepository.GetByIdAsync((int)id);
            if (data == null) throw new EntityNotFoundException();

            mapper.Map(dto, data);

            data.ModifiedDate = DateTime.Now;
            await reservationRepository.CommitAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<Reservation, bool>>? expression = null)
        {
            return await reservationRepository.Table.AnyAsync(expression);
        }
    }
}
