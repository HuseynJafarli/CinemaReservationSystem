﻿namespace CinemaReservationSystem.Business.DTOs.ShowTimeDTOs
{
    public record ShowTimeCreateDto(DateTime StartTime, DateTime EndTime, int MovieId, int TheaterId, bool IsDeleted);
}
