using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
