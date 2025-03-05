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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //Create default admin and normal user
            builder.HasData(
                new { Id = 1, FirstName = "Admin", LastName = "Admin", Email = "admin@mail.com", AppUserRole = Domain.Enums.AppUserRole.Admin, Password = "admin123"},
                new { Id = 2, FirstName = "User", LastName = "User", Email = "user@mail.com", AppUserRole = Domain.Enums.AppUserRole.User, Password = "user123"});
        }
    }
}
