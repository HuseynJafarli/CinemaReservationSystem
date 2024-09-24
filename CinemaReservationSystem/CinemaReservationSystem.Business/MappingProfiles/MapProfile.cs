using AutoMapper;
using CinemaReservationSystem.Business.DTOs.MovieDTOs;
using CinemaReservationSystem.Business.DTOs.ReservationDTOs;
using CinemaReservationSystem.Business.DTOs.SeatReservationDTOs;
using CinemaReservationSystem.Business.DTOs.ShowTimeDTOs;
using CinemaReservationSystem.Business.DTOs.TheaterDTOs;
using CinemaReservationSystem.Core.Entities;

namespace CinemaReservationSystem.Business.MappingProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Movie, MovieGetDto>().ReverseMap();
            CreateMap<MovieCreateDto, Movie>().ReverseMap();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();

            CreateMap<Reservation, ReservationGetDto>().ReverseMap();
            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();
            CreateMap<ReservationUpdateDto, Reservation>().ReverseMap();

            CreateMap<SeatReservation, SeatReservationGetDto>().ReverseMap();
            CreateMap<SeatReservationCreateDto, SeatReservation>().ReverseMap();
            CreateMap<SeatReservationUpdateDto, SeatReservation>().ReverseMap();

            CreateMap<ShowTime, ShowTimeGetDto>().ReverseMap();
            CreateMap<ShowTimeCreateDto, ShowTime>().ReverseMap();
            CreateMap<ShowTimeUpdateDto, ShowTime>().ReverseMap();

            CreateMap<Theater, TheaterGetDto>().ReverseMap();
            CreateMap<TheaterCreateDto, Theater>().ReverseMap();
            CreateMap<TheaterUpdateDto, Theater>().ReverseMap();
        }
    }
}
