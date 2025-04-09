using Newtonsoft.Json;

namespace Backend.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string Row { get; set; } = null!;
        public int SeatNumber { get; set; }

        [JsonIgnore] // Ignorer serialisering af Booking
        public Booking? Booking { get; set; }
    }
}