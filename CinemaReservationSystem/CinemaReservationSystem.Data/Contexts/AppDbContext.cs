﻿using CinemaReservationSystem.Core.Entities;
using CinemaReservationSystem.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaReservationSystem.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<ShowTime> ShowTimes { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
