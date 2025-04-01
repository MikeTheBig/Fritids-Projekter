using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class AuditoriumController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AuditoriumController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Auditorium>>> GetAuditoriums()
    {
        return await _context.Auditoriums.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Auditorium>> GetAuditorium(int id)
    {
        var auditorium = await _context.Auditoriums.FindAsync(id);

        if (auditorium == null)
        {
            return NotFound();
        }

        return auditorium;
    }

    [HttpPost]
    public async Task<ActionResult<Auditorium>> CreateAuditorium(Auditorium auditorium)
    {
        _context.Auditoriums.Add(auditorium);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAuditorium), new { id = auditorium.AuditoriumId }, auditorium);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuditorium(int id, Auditorium auditorium)
    {
        if (id != auditorium.AuditoriumId)
        {
            return BadRequest();
        }

        _context.Entry(auditorium).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Auditoriums.Any(a => a.AuditoriumId == id))
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
    public async Task<IActionResult> DeleteAuditorium(int id)
    {
        var auditorium = await _context.Auditoriums.FindAsync(id);
        if (auditorium == null)
        {
            return NotFound();
        }

        _context.Auditoriums.Remove(auditorium);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}