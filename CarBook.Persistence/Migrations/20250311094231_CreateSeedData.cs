using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description", "ImageUrl", "Title" },
                values: new object[] { 1, "Welcome to CarBook, your ultimate destination for seamless car booking and rental services. Whether you're looking for a vehicle for a business trip, a weekend getaway, or daily commuting, CarBook provides a hassle-free experience with a wide selection of cars to suit your needs.  Our platform is designed with convenience in mind, offering easy online reservations, competitive pricing, and a user-friendly interface. We connect customers with trusted rental providers, ensuring reliability, safety, and transparency in every booking.  At CarBook, we prioritize customer satisfaction by providing detailed vehicle information, flexible booking options, and secure payment methods. Our goal is to make car rentals more accessible and stress-free, so you can focus on the journey ahead.  Book your car today and experience the road with confidence!", "website-template/images/about.jpg", "Welcome to Carbook" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AppUserRole", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, 2, "admin@mail.com", "Admin", "Admin", "admin123" },
                    { 2, 1, "user@mail.com", "User", "User", "user123" }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "Description", "Title", "VideoDescription", "VideoUrl" },
                values: new object[] { 1, "Rent a car in minutes with CarBook", "Fast & Easy Way To Rent A Car", "Easy steps for renting a car", "https://www.youtube.com/watch?v=ZUL0qFMYme8" });

            migrationBuilder.InsertData(
                table: "BlogAuthors",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe is an experienced automotive journalist with a passion for performance cars and cutting-edge technology. With over a decade of writing about the latest in car reviews, industry trends, and innovations, he brings a unique perspective to the world of automotive content.", "/website-template/images/person_1.jpg", "John Doe" },
                    { 2, "Robert Williams is a seasoned automotive writer with a passion for classic cars and vintage vehicles. With a keen eye for detail and a deep knowledge of automotive history, she brings a unique perspective to the world of car journalism.", "/website-template/images/person_2.jpg", "Robert Williams" }
                });

            migrationBuilder.InsertData(
                table: "BlogCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Car Trends" },
                    { 2, "Car Technology" },
                    { 3, "Electric Car" },
                    { 4, "Car Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "BlogTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Tech" },
                    { 3, "Trend" },
                    { 4, "Interesting" },
                    { 5, "Future of Cars" },
                    { 6, "Concept Cars" },
                    { 7, "Hybrid Cars" },
                    { 8, "Iconic" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ford" },
                    { 2, "Mercedes" },
                    { 3, "Range Rover" },
                    { 4, "McLaren" },
                    { 5, "BMW" },
                    { 6, "Alfa Romeo" },
                    { 7, "Jeep" },
                    { 8, "Audi" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "Message", "Name", "SendDate", "Subject" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "I would like to inquire about booking a sedan for a weekend trip. Please let me know the availability and pricing details.", "John Doe", new DateTime(2024, 10, 22, 5, 25, 0, 0, DateTimeKind.Unspecified), "Booking Inquiry - Sedan" },
                    { 2, "jane.smith@example.com", "I'm interested in renting an SUV for a family vacation next month. Could you provide information on availability and the rental terms?", "Jane Smith", new DateTime(2024, 11, 27, 13, 35, 0, 0, DateTimeKind.Unspecified), "Car Rental Request - SUV" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "johndoe@example.com", "John", "Doe" },
                    { 2, "janesmith@example.com", "Jane", "Smith" },
                    { 3, "michaelbrown@example.com", "Michael", "Brown" },
                    { 4, "emilydavis@example.com", "Emily", "Davis" },
                    { 5, "davidwilson@example.com", "David", "Wilson" },
                    { 6, "sarahmiller@example.com", "Sarah", "Miller" },
                    { 7, "jamesanderson@example.com", "James", "Anderson" },
                    { 8, "jessicataylor@example.com", "Jessica", "Taylor" },
                    { 9, "robertmoore@example.com", "Robert", "Moore" },
                    { 10, "emmaclark@example.com", "Emma", "Clark" }
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ABS" },
                    { 2, "Airbag" },
                    { 3, "Wifi" },
                    { 4, "GPS" },
                    { 5, "Car Kit" },
                    { 6, "Seat Belt" },
                    { 7, "Child Seat" },
                    { 8, "Bluetooth" },
                    { 9, "Onboard Computer" },
                    { 10, "Remote central locking" },
                    { 11, "Music" },
                    { 12, "Climate control" },
                    { 13, "Airconditions" }
                });

            migrationBuilder.InsertData(
                table: "FooterAddresses",
                columns: new[] { "Id", "Address", "Description", "Email", "Phone" },
                values: new object[] { 1, "123 Auto Lane, Car City, CC 12345, USA", "Carbook - Your go-to platform for all things related to cars, from buying to selling and beyond.", "contact@carbook.com", "+1 123 456 7890" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Los Angeles International Airport (LAX)" },
                    { 2, "John F. Kennedy International Airport (JFK)" },
                    { 3, "O'Hare International Airport (ORD)" },
                    { 4, "Miami International Airport (MIA)" },
                    { 5, "Dallas/Fort Worth International Airport (DFW)" },
                    { 6, "Denver International Airport (DEN)" }
                });

            migrationBuilder.InsertData(
                table: "RentalPeriods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "hour" },
                    { 2, "day" },
                    { 3, "week" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "IconUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Convenient rides to and from the airport with timely pickups and drop-offs.", "flaticon-route", "Airport Transfer" },
                    { 2, "Explore the city's landmarks and attractions with personalized car tours.", "flaticon-transportation", "City Tour" },
                    { 3, "Plan your long-distance journeys with comfortable and reliable outstation cabs.", "flaticon-route", "Outstation Rides" },
                    { 4, "Travel in style and comfort with our premium car selection.", "flaticon-suv", "Luxury Cars" },
                    { 5, "Book a car with a driver for a flexible duration, charged on an hourly basis.", "flaticon-car", "Hourly Rentals" },
                    { 6, "Seamless transportation for weddings, parties, and other special occasions.", "flaticon-route", "Event Transport" },
                    { 7, "Safe and reliable transportation services for students.", "flaticon-backpack", "School Pickup and Drop" },
                    { 8, "Professional transportation solutions for your business travel needs.", "flaticon-handshake", "Corporate Travel" }
                });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "ImageUrl", "Name", "Title" },
                values: new object[,]
                {
                    { 1, "I've always had a passion for classic cars, and the way they combine craftsmanship and style is unmatched. The '67 Mustang will always be my favorite.", "/website-template/images/person_1.jpg", "Roger Scott", "Car Enthusiast" },
                    { 2, "Modern cars are a marvel of engineering, with all the tech and safety features. I’m fascinated by electric vehicles and how they’re changing the landscape of the industry.", "/website-template/images/person_2.jpg", "Emily Brown", "Automotive Engineer" },
                    { 3, "There's nothing like the satisfaction of restoring an old car. The sound of a perfectly tuned engine is music to my ears.", "/website-template/images/person_3.jpg", "John Doe", "Mechanic" },
                    { 4, "I’ve been covering racing for over a decade. The speed, the skill, and the technology behind motorsport are absolutely thrilling to witness.", "/website-template/images/person_4.jpg", "Anna Smith", "Motorsport Journalist" },
                    { 5, "For me, cars are more than just transportation. They represent history and craftsmanship. Owning a piece of automotive history, like a Ferrari 250 GTO, is a dream come true.", "/website-template/images/person_1.jpg", "Michael Johnson", "Car Collector" },
                    { 6, "I believe in the future of electric cars and their potential to transform our cities and reduce our carbon footprint. It’s exciting to see how fast the technology is advancing.", "/website-template/images/person_2.jpg", "Sophia Davis", "Sustainability Advocate" },
                    { 7, "Designing cars is about balancing aesthetics, functionality, and performance. It's thrilling to see the latest models on the road, knowing we had a hand in creating them.", "/website-template/images/person_3.jpg", "James Wilson", "Car Designer" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BlogAuthorId", "BlogCategoryId", "Content", "CoverImageUrl", "CreatedDate", "Description", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, "The history of cars is a long and interesting one. It all started with the invention of the wheel, and has evolved into the modern vehicles we see on the road today.", "https://images.nationalgeographic.org/image/upload/t_edhub_resource_key_image/v1638892232/EducationHub/photos/packard-model-b-automobile.jpg", new DateTime(2024, 7, 30, 16, 20, 0, 0, DateTimeKind.Unspecified), "The history of cars is a long and interesting one.", "Car History" },
                    { 2, 2, 1, "Formula 1 is a dangerous sport, and accidents are a common occurrence. However, some accidents are more serious than others, and can have a lasting impact on the drivers involved.", "https://i.dunya.com/storage/files/images/2023/03/02/formula-1-YPIe_cover.jpg", new DateTime(2024, 8, 12, 11, 55, 0, 0, DateTimeKind.Unspecified), "Formula 1 is a dangerous sport, and accidents are a common occurrence.", "Formula 1 Accident" },
                    { 3, 1, 2, "Electric vehicles (EVs) have come a long way from their early prototypes to the modern, high-performance machines we see today. Advances in battery technology, charging infrastructure, and sustainability efforts have made EVs a practical choice for consumers worldwide.", "https://www.currencytransfer.com/wp-content/uploads/2022/11/ev-2-edit.min_.jpg", new DateTime(2024, 9, 17, 20, 40, 0, 0, DateTimeKind.Unspecified), "A look at how electric cars have evolved and their impact on the automotive industry.", "The Evolution of Electric Cars" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "GT500" },
                    { 2, 2, "SLK55" },
                    { 3, 4, "P1" },
                    { 4, 3, "Evoque" },
                    { 5, 5, "M3" },
                    { 6, 6, "8C Spider" },
                    { 7, 2, "CLE 300" },
                    { 8, 7, "Wrangler Rubicon" },
                    { 9, 2, "GT Coupe" },
                    { 10, 2, "A180" },
                    { 11, 8, "A1" }
                });

            migrationBuilder.InsertData(
                table: "BlogComments",
                columns: new[] { "Id", "BlogId", "Content", "CreatedDate", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The history of cars is fascinating! It's amazing to see how far we've come in such a short time. I’m curious about the future developments in car technology.", new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@email.com", "John Doe" },
                    { 2, 2, "Formula 1 accidents are terrifying. The risks drivers face are unimaginable, and it's always shocking to see how they walk away from such crashes.", new DateTime(2024, 2, 5, 14, 30, 0, 0, DateTimeKind.Unspecified), "janesmith@email.com", "Jane Smith" },
                    { 3, 3, "Electric cars are definitely the future. The advancements in battery technology make them more practical than ever. It's great to see the industry moving towards sustainability.", new DateTime(2024, 3, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "carlosrivera@email.com", "Carlos Rivera" },
                    { 4, 3, "The development of electric vehicles is impressive. It’s exciting to think about the impact these cars will have on the environment and the way we drive.", new DateTime(2024, 4, 15, 18, 45, 0, 0, DateTimeKind.Unspecified), "sarahlee@email.com", "Sarah Lee" },
                    { 5, 2, "Formula 1 accidents may be common, but they always leave a lasting impression. Every time something happens, it makes you appreciate the skill and bravery of the drivers even more.", new DateTime(2024, 5, 20, 22, 10, 0, 0, DateTimeKind.Unspecified), "mikejohnson@email.com", "Mike Johnson" },
                    { 6, 3, "I’ve always been fascinated by how electric vehicles have evolved. The shift from fossil fuels to electricity is one of the most important movements in the auto industry.", new DateTime(2024, 6, 25, 7, 5, 0, 0, DateTimeKind.Unspecified), "emilygreen@email.com", "Emily Green" }
                });

            migrationBuilder.InsertData(
                table: "BlogTagClouds",
                columns: new[] { "Id", "BlogId", "BlogTagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 },
                    { 3, 3, 2 },
                    { 4, 3, 5 },
                    { 5, 3, 3 },
                    { 6, 1, 6 },
                    { 7, 3, 7 },
                    { 8, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BigImageUrl", "CoverImageUrl", "FuelType", "Km", "Luggage", "ModelId", "SeatCount", "TransmissionType" },
                values: new object[,]
                {
                    { 1, "/bigImageUrl", "/website-template/images/car-4.jpg", 1, 250, (byte)2, 1, (byte)2, 1 },
                    { 2, "/bigImageUrl", "/website-template/images/car-1.jpg", 1, 50, (byte)3, 2, (byte)2, 2 },
                    { 3, "/bigImageUrl", "/website-template/images/car-3.jpg", 1, 0, (byte)1, 3, (byte)2, 2 },
                    { 4, "/bigImageUrl", "/website-template/images/car-2.jpg", 2, 1000, (byte)6, 4, (byte)4, 2 },
                    { 5, "/bigImageUrl", "/website-template/images/car-5.jpg", 1, 100, (byte)4, 5, (byte)4, 1 },
                    { 6, "/bigImageUrl", "/website-template/images/car-6.jpg", 1, 0, (byte)2, 6, (byte)2, 2 },
                    { 7, "/bigImageUrl", "/website-template/images/car-7.jpg", 1, 0, (byte)2, 7, (byte)2, 1 },
                    { 8, "/bigImageUrl", "/website-template/images/car-8.jpg", 1, 850, (byte)6, 8, (byte)4, 2 },
                    { 9, "/bigImageUrl", "/website-template/images/car-10.jpg", 1, 0, (byte)1, 9, (byte)2, 1 },
                    { 10, "/bigImageUrl", "/website-template/images/car-11.jpg", 2, 800, (byte)4, 10, (byte)4, 2 },
                    { 11, "/bigImageUrl", "/website-template/images/car-12.jpg", 1, 1249, (byte)4, 11, (byte)4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CarDescriptions",
                columns: new[] { "Id", "CarId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "A legendary American muscle car, the GT500 boasts supercharged V8 power and a racing heritage rooted in Carroll Shelby’s performance legacy." },
                    { 2, 2, "A compact roadster with a hand-built AMG V8, blending luxury with raw performance in a retractable hardtop design." },
                    { 3, 3, "A groundbreaking hybrid hypercar, the P1 combines F1-inspired aerodynamics with electric-assisted twin-turbo V8 power for extreme performance." },
                    { 4, 4, "A stylish luxury SUV that redefined urban off-roading, known for its sleek design and advanced terrain response system." },
                    { 5, 5, "A high-performance sports sedan, the M3 has dominated track and street alike since the 1980s with its precision engineering and aggressive styling." },
                    { 6, 6, "An exclusive Italian roadster featuring a Ferrari-derived V8, hand-crafted design, and an unmistakable exhaust note." },
                    { 7, 7, "A refined coupe that merges sporty dynamics with cutting-edge technology, positioned between luxury and performance." },
                    { 8, 8, "An off-road icon, the Rubicon is designed for extreme terrain with its rugged build, locking differentials, and legendary 4x4 capabilities." },
                    { 9, 9, "A front-mid-engine sports car developed by AMG, delivering thrilling performance with a powerful twin-turbo V8." },
                    { 10, 10, "A premium compact hatchback that offers advanced tech, efficient performance, and the luxury appeal of the Mercedes-Benz brand." },
                    { 11, 11, "A stylish and compact city car that delivers German engineering, premium features, and agile handling in a small package." }
                });

            migrationBuilder.InsertData(
                table: "CarFeatures",
                columns: new[] { "Id", "Available", "CarId", "FeatureId" },
                values: new object[,]
                {
                    { 1, true, 1, 1 },
                    { 2, true, 1, 2 },
                    { 3, false, 1, 3 },
                    { 4, true, 1, 4 },
                    { 5, true, 1, 5 },
                    { 6, true, 1, 6 },
                    { 7, false, 1, 7 },
                    { 8, true, 1, 8 },
                    { 9, false, 1, 9 },
                    { 10, true, 1, 10 },
                    { 11, true, 1, 11 },
                    { 12, true, 1, 12 },
                    { 13, false, 1, 13 },
                    { 14, true, 2, 1 },
                    { 15, true, 2, 2 },
                    { 16, true, 2, 3 },
                    { 17, true, 2, 4 },
                    { 18, false, 2, 5 },
                    { 19, true, 2, 6 },
                    { 20, false, 2, 7 },
                    { 21, true, 2, 8 },
                    { 22, false, 2, 9 },
                    { 23, true, 2, 10 },
                    { 24, true, 2, 11 },
                    { 25, true, 2, 12 },
                    { 26, false, 2, 13 },
                    { 27, true, 3, 1 },
                    { 28, true, 3, 2 },
                    { 29, true, 3, 3 },
                    { 30, true, 3, 4 },
                    { 31, false, 3, 5 },
                    { 32, true, 3, 6 },
                    { 33, false, 3, 7 },
                    { 34, true, 3, 8 },
                    { 35, true, 3, 9 },
                    { 36, false, 3, 10 },
                    { 37, true, 3, 11 },
                    { 38, true, 3, 12 },
                    { 39, true, 3, 13 },
                    { 40, true, 4, 1 },
                    { 41, true, 4, 2 },
                    { 42, false, 4, 3 },
                    { 43, true, 4, 4 },
                    { 44, true, 4, 5 },
                    { 45, true, 4, 6 },
                    { 46, true, 4, 7 },
                    { 47, false, 4, 8 },
                    { 48, true, 4, 9 },
                    { 49, true, 4, 10 },
                    { 50, true, 4, 11 },
                    { 51, true, 4, 12 },
                    { 52, false, 4, 13 },
                    { 53, true, 5, 1 },
                    { 54, true, 5, 2 },
                    { 55, true, 5, 3 },
                    { 56, false, 5, 4 },
                    { 57, true, 5, 5 },
                    { 58, true, 5, 6 },
                    { 59, false, 5, 7 },
                    { 60, true, 5, 8 },
                    { 61, false, 5, 9 },
                    { 62, true, 5, 10 },
                    { 63, true, 5, 11 },
                    { 64, true, 5, 12 },
                    { 65, true, 5, 13 },
                    { 66, true, 6, 1 },
                    { 67, true, 6, 2 },
                    { 68, false, 6, 3 },
                    { 69, true, 6, 4 },
                    { 70, true, 6, 5 },
                    { 71, true, 6, 6 },
                    { 72, true, 6, 7 },
                    { 73, true, 6, 8 },
                    { 74, false, 6, 9 },
                    { 75, true, 6, 10 },
                    { 76, true, 6, 11 },
                    { 77, false, 6, 12 },
                    { 78, true, 6, 13 },
                    { 79, true, 7, 1 },
                    { 80, true, 7, 2 },
                    { 81, true, 7, 3 },
                    { 82, true, 7, 4 },
                    { 83, true, 7, 5 },
                    { 84, true, 7, 6 },
                    { 85, false, 7, 7 },
                    { 86, true, 7, 8 },
                    { 87, true, 7, 9 },
                    { 88, false, 7, 10 },
                    { 89, true, 7, 11 },
                    { 90, true, 7, 12 },
                    { 91, false, 7, 13 },
                    { 92, true, 8, 1 },
                    { 93, true, 8, 2 },
                    { 94, false, 8, 3 },
                    { 95, true, 8, 4 },
                    { 96, false, 8, 5 },
                    { 97, true, 8, 6 },
                    { 98, false, 8, 7 },
                    { 99, true, 8, 8 },
                    { 100, true, 8, 9 },
                    { 101, true, 8, 10 },
                    { 102, true, 8, 11 },
                    { 103, false, 8, 12 },
                    { 104, true, 8, 13 },
                    { 105, true, 9, 1 },
                    { 106, true, 9, 2 },
                    { 107, false, 9, 3 },
                    { 108, true, 9, 4 },
                    { 109, false, 9, 5 },
                    { 110, true, 9, 6 },
                    { 111, false, 9, 7 },
                    { 112, true, 9, 8 },
                    { 113, true, 9, 9 },
                    { 114, false, 9, 10 },
                    { 115, true, 9, 11 },
                    { 116, false, 9, 12 },
                    { 117, true, 9, 13 },
                    { 118, true, 10, 1 },
                    { 119, true, 10, 2 },
                    { 120, true, 10, 3 },
                    { 121, false, 10, 4 },
                    { 122, true, 10, 5 },
                    { 123, true, 10, 6 },
                    { 124, false, 10, 7 },
                    { 125, true, 10, 8 },
                    { 126, true, 10, 9 },
                    { 127, true, 10, 10 },
                    { 128, true, 10, 11 },
                    { 129, false, 10, 12 },
                    { 130, true, 10, 13 },
                    { 131, true, 11, 1 },
                    { 132, true, 11, 2 },
                    { 133, true, 11, 3 },
                    { 134, true, 11, 4 },
                    { 135, false, 11, 5 },
                    { 136, true, 11, 6 },
                    { 137, false, 11, 7 },
                    { 138, true, 11, 8 },
                    { 139, false, 11, 9 },
                    { 140, true, 11, 10 },
                    { 141, true, 11, 11 },
                    { 142, true, 11, 12 },
                    { 143, false, 11, 13 }
                });

            migrationBuilder.InsertData(
                table: "CarReservationPricings",
                columns: new[] { "Id", "CarId", "Price", "RentalPeriodId" },
                values: new object[,]
                {
                    { 1, 1, 30.00m, 1 },
                    { 2, 1, 150.00m, 2 },
                    { 3, 1, 600.00m, 3 },
                    { 4, 2, 45.00m, 1 },
                    { 5, 2, 250.00m, 2 },
                    { 6, 2, 550.00m, 3 },
                    { 7, 3, 70.00m, 1 },
                    { 8, 3, 400.00m, 2 },
                    { 9, 3, 1000.00m, 3 },
                    { 10, 4, 35.00m, 1 },
                    { 11, 4, 110.00m, 2 },
                    { 12, 4, 320.00m, 3 },
                    { 13, 5, 40.00m, 1 },
                    { 14, 5, 110.00m, 2 },
                    { 15, 5, 650.00m, 3 },
                    { 16, 6, 45.00m, 1 },
                    { 17, 6, 130.00m, 2 },
                    { 18, 6, 700.00m, 3 },
                    { 19, 7, 50.00m, 1 },
                    { 20, 7, 220.00m, 2 },
                    { 21, 7, 1000.00m, 3 },
                    { 22, 8, 30.00m, 1 },
                    { 23, 8, 100.00m, 2 },
                    { 24, 8, 650.00m, 3 },
                    { 25, 9, 80.00m, 1 },
                    { 26, 9, 400.00m, 2 },
                    { 27, 9, 950.00m, 3 },
                    { 28, 10, 20.00m, 1 },
                    { 29, 10, 90.00m, 2 },
                    { 30, 10, 240.00m, 3 },
                    { 31, 11, 15.00m, 1 },
                    { 32, 11, 70.00m, 2 },
                    { 33, 11, 300.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "CarReviews",
                columns: new[] { "Id", "CarId", "CustomerId", "RatingStarCount", "Review", "ReviewDate" },
                values: new object[,]
                {
                    { 1, 1, 1, 5, "Amazing performance and design! The GT500 is a beast on the road.", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, 4, "Smooth drive, luxurious feel, but a bit expensive.", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, 5, "Absolutely stunning car, breathtaking speed and handling.", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 4, 4, "Great for off-roading, very comfortable and stylish.", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 5, 5, "Classic M3 experience—responsive and powerful.", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 6, 5, "A true beauty! The 8C Spider has a fantastic sound and feel.", new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 7, 3, "A stylish, comfortable ride with plenty of features. Love the performance and handling!", new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 8, 5, "The ultimate adventure vehicle! Handles rough terrains like a pro.", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 9, 4, "Great performance but a little overpriced.", new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 10, 5, "Compact and stylish, perfect for city driving.", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, 10, 4, "Compact, efficient, and fun to drive. A great city car, but could use a bit more power.", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RentalCars",
                columns: new[] { "Id", "CarId", "IsAvailable", "LocationId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, true, 2 },
                    { 3, 3, true, 3 },
                    { 4, 4, true, 4 },
                    { 5, 5, true, 5 },
                    { 6, 6, true, 6 },
                    { 7, 7, true, 1 },
                    { 8, 8, true, 2 },
                    { 9, 9, true, 3 },
                    { 10, 10, true, 4 },
                    { 11, 11, true, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abouts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Banners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogComments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogTagClouds",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarDescriptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "CarFeatures",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "CarReservationPricings",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CarReviews",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FooterAddresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RentalCars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Testimonials",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogTags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RentalPeriods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RentalPeriods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RentalPeriods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogAuthors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogAuthors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
