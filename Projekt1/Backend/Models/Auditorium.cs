using System.ComponentModel.DataAnnotations;
namespace Backend.Models

{
    public class Auditorium
    {
        public int AuditoriumId { get; set; }
        public string Name { get; set; } = null!;

        [Range(1, 200)]
        public int SeatCount { get; set; }
        public List<Show> Shows { get; set; } = new();
    }
}