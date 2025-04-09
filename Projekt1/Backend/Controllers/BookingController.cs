using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            // Fetch the User entity using the UserId
            var user = await _context.Users.FindAsync(booking.UserId);
            if (user == null)
            {
                return BadRequest(new { errors = new { User = new[] { "Invalid UserId." } } });
            }
        
            // Associate the User entity with the Booking
            booking.User = user;
        
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

[HttpGet("user")]
[Authorize]
public async Task<IActionResult> GetUserBookings()
{
    // Log all claims for debugging
    var claims = User.Claims.Select(c => new { c.Type, c.Value });
    foreach (var claim in claims)
    {
        Console.WriteLine($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
    }

    // Find the correct nameidentifier claim with a numeric value
    var userIdClaim = User.Claims
        .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier && int.TryParse(c.Value, out _));

    if (userIdClaim == null)
    {
        Console.WriteLine("Numeric User ID not found in token");
        return Unauthorized();
    }

    var userId = userIdClaim.Value;

    Console.WriteLine($"User ID from token: {userId}");

    if (!int.TryParse(userId, out var numericUserId))
    {
        Console.WriteLine($"Invalid User ID: {userId}");
        return BadRequest(new { errors = new { id = new[] { $"The value '{userId}' is not valid." } } });
    }

    Console.WriteLine($"Parsed User ID: {numericUserId}");

    var bookings = await _context.Bookings
        .Where(b => b.UserId == numericUserId)
        .ToListAsync();

    return Ok(bookings);
}
}
