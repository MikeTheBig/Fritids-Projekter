namespace Backend.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MovieTitle { get; set; } = null!; 
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int TotalSeats { get; set; }
        public int AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = new();
    }
}