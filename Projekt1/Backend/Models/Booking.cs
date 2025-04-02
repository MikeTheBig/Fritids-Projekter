namespace Backend.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public BookingStatus Status { get; set; } 
        public int ShowId { get; set; }
        public Show? Show { get; set; }
        public List<Seat> Seats { get; set; } = new();  
    }
}