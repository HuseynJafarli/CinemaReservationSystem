using CinemaReservationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaReservationSystem.Data.Configurations
{
    public class TheaterConfiguration : IEntityTypeConfiguration<Theater>
    {
        public void Configure(EntityTypeBuilder<Theater> builder)
        {
            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(x => x.TotalSeats)
                .IsRequired();

        }
    }
}
