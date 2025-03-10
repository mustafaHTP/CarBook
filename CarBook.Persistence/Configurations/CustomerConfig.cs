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
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com" },
                new Customer { Id = 3, FirstName = "Michael", LastName = "Brown", Email = "michaelbrown@example.com" },
                new Customer { Id = 4, FirstName = "Emily", LastName = "Davis", Email = "emilydavis@example.com" },
                new Customer { Id = 5, FirstName = "David", LastName = "Wilson", Email = "davidwilson@example.com" },
                new Customer { Id = 6, FirstName = "Sarah", LastName = "Miller", Email = "sarahmiller@example.com" },
                new Customer { Id = 7, FirstName = "James", LastName = "Anderson", Email = "jamesanderson@example.com" },
                new Customer { Id = 8, FirstName = "Jessica", LastName = "Taylor", Email = "jessicataylor@example.com" },
                new Customer { Id = 9, FirstName = "Robert", LastName = "Moore", Email = "robertmoore@example.com" },
                new Customer { Id = 10, FirstName = "Emma", LastName = "Clark", Email = "emmaclark@example.com" }
            );

        }
    }
}
