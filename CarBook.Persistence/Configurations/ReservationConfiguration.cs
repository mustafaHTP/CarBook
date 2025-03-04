using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarBook.Persistence.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder
                .HasOne(r => r.PickUpLocation)
                .WithMany(l => l.PickUpReservations)
                .HasForeignKey(r => r.PickUpLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(r => r.DropOffLocation)
                .WithMany(l => l.DropOffReservations)
                .HasForeignKey(r => r.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
