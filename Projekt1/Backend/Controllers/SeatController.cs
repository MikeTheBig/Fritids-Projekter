using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class SeatController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SeatController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Seat>>> GetSeats()
    {
        return await _context.Seats.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Seat>> GetSeat(int id)
    {
        var seat = await _context.Seats.FindAsync(id);

        if (seat == null)
        {
            return NotFound();
        }

        return seat;
    }

    [HttpPost]
    public async Task<ActionResult<Seat>> CreateSeat(Seat seat)
    {
        _context.Seats.Add(seat);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSeat), new { id = seat.SeatId }, seat);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSeat(int id, Seat seat)
    {
        if (id != seat.SeatId)
        {
            return BadRequest();
        }

        _context.Entry(seat).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Seats.Any(s => s.SeatId == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSeat(int id)
    {
        var seat = await _context.Seats.FindAsync(id);
        if (seat == null)
        {
            return NotFound();
        }

        _context.Seats.Remove(seat);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}