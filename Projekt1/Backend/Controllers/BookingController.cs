using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        return await _context.Bookings
        .Include(b => b.Show) // Include the related Seats
        .ThenInclude(s => s.Movie) // Include the related Show
        .Include(b => b.Seats) // Include the related Show
        .ToListAsync();

    }

        [HttpPost]
    public async Task<ActionResult<Booking>> CreateBooking([FromBody] Booking booking)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    
        return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingId }, booking);
    }


[HttpGet("{id}")]
    public async Task<ActionResult<Booking>> GetBooking(int id)
    {
        var booking = await _context.Bookings
            .Include(b => b.Show)
            .Include(b => b.Seats)
            .FirstOrDefaultAsync(b => b.BookingId == id);

        if (booking == null)
            return NotFound();

        return booking;
    }


[HttpPut("{id}")]
    public async Task<IActionResult> UpdateBooking(int id, Booking booking)
    {
        if (id != booking.BookingId)
            return BadRequest();

        _context.Entry(booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Bookings.Any(b => b.BookingId == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }


[HttpDelete("{id}")]
public async Task<IActionResult> DeleteBooking(int id)
{
    var booking = await _context.Bookings.FindAsync(id);
    if (booking == null)
    {
        return NotFound();
    }

    _context.Bookings.Remove(booking);
    await _context.SaveChangesAsync();
    return NoContent();
}
}
