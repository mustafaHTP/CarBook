using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<About> Abouts { get; set; }
        DbSet<Banner> Banners { get; set; }
        DbSet<BlogCategory> BlogCategories { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Car> Cars { get; set; }
        DbSet<CarDescription> CarDescriptions { get; set; }
        DbSet<CarFeature> CarFeatures { get; set; }
        DbSet<CarReservationPricing> CarReservationPricings { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<FooterAddress> FooterAddresses { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Model> Models { get; set; }
        DbSet<ReservationPricing> ReservationPricings { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<SocialMedia> SocialMedias { get; set; }
        DbSet<Testimonial> Testimonials { get; set; }
    }
}
