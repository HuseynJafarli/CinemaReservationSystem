using CinemaReservationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationSystem.Data.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.AppUserId)
                .IsRequired();

            builder.Property(x => x.ShowTimeId)
                .IsRequired();

            builder.Property(x => x.ReservationDate)
                .IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ShowTime)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ShowTimeId);
            
        }
    }
}
