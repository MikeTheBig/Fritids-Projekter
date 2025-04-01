using Microsoft.EntityFrameworkCore;
using Backend.Models;
using BCrypt.Net;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // Tilføj dine entiteter her
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Auditorium> Auditoriums { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }

        // Flyt OnModelCreating ind i klassen
                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Title = "Inception",
                    Description = "A mind-bending thriller about dreams within dreams.",
                    DurationInMinutes = 148
                },
                new Movie
                {
                    MovieId = 2,
                    Title = "The Matrix",
                    Description = "A hacker discovers the shocking truth about his reality.",
                    DurationInMinutes = 136
                }
            );
        
            // Seed Auditoriums
            modelBuilder.Entity<Auditorium>().HasData(
                new Auditorium
                {
                    AuditoriumId = 1,
                    Name = "Auditorium A",
                    SeatCount = 100 // Brug SeatCount i stedet for TotalSeats
                },
                new Auditorium
                {
                    AuditoriumId = 2,
                    Name = "Auditorium B",
                    SeatCount = 80
                }
            );
        
            // Seed Shows
modelBuilder.Entity<Show>().HasData(
    new Show
    {
        ShowId = 1,
        MovieId = 1,
        AuditoriumId = 1,
        StartDate = new DateTime(2025, 4, 1, 18, 0, 0), // Hardkodet dato og tid
        MovieTitle = "Inception" // Tilføj denne egenskab
    },
    new Show
    {
        ShowId = 2,
        MovieId = 2,
        AuditoriumId = 2,
        StartDate = new DateTime(2025, 4, 2, 20, 0, 0), // Hardkodet dato og tid
        MovieTitle = "The Matrix" // Tilføj denne egenskab
    }
);
        
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin",
                    Password = "$2a$11$K7tih2DcSVCdM9LTf5lmne41uEffe6LXZHT7AmV4mGc4/vbB1NIiG", // Hashed password
                    Role = "Admin"
                },
                new User
                {
                    UserId = 2,
                    Username = "user",
                    Password = "$2a$11$ymlFcuiFXHLSXD3yEvFp5uFrvkf8FIT6wn/nQYDYgb7B.O0T4oTYS", // Hashed password
                    Role = "User"
                }
            );
        
            // Seed Bookings
modelBuilder.Entity<Booking>().HasData(
    new Booking
    {
        BookingId = 1,
        ShowId = 1,
        UserId = 1,
        StartDate = new DateTime(2025, 4, 1, 18, 0, 0), // Hardkodet dato og tid
        EndDate = new DateTime(2025, 4, 1, 20, 0, 0),   // Hardkodet dato og tid
        CustomerName = "John Doe",
        CustomerEmail = "johndoe@example.com",
        Status = BookingStatus.Confirmed // Assuming BookingStatus is an enum
    },
    new Booking
    {
        BookingId = 2,
        ShowId = 2,
        UserId = 2,
        StartDate = new DateTime(2025, 4, 2, 20, 0, 0), // Hardkodet dato og tid
        EndDate = new DateTime(2025, 4, 2, 22, 0, 0),   // Hardkodet dato og tid
        CustomerName = "Jane Smith",
        CustomerEmail = "janesmith@example.com",
        Status = BookingStatus.Pending // Assuming BookingStatus is an enum
    }
);
        // Seed Seats
        modelBuilder.Entity<Seat>().HasData(
            new Seat { SeatId = 1, Row = "A", SeatNumber = 1, Booking = null },
            new Seat { SeatId = 2, Row = "A", SeatNumber = 2, Booking = null },
            new Seat { SeatId = 3, Row = "B", SeatNumber = 1, Booking = null },
            new Seat { SeatId = 4, Row = "B", SeatNumber = 2, Booking = null }
        );
        }
    }
}