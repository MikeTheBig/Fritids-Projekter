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

    }
    };