using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class ShowController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ShowController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Show
    [HttpGet]
    [Authorize(Roles = "Admin")] // Allow access to Admin and User roles
    public async Task<ActionResult<IEnumerable<Show>>> GetShows()
    {
        return await _context.Shows
            .Include(s => s.Movie) // Include related Movie
            .ToListAsync();
    }

    // GET: api/Show/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Show>> GetShow(int id)
    {
        var show = await _context.Shows
            .Include(s => s.Movie)
            .FirstOrDefaultAsync(s => s.ShowId == id);

        if (show == null)
        {
            return NotFound();
        }

        return show;
    }

    // POST: api/Show
    [HttpPost]
    public async Task<ActionResult<Show>> CreateShow(Show show)
    {
        _context.Shows.Add(show);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShow), new { id = show.ShowId }, show);
    }

    // PUT: api/Show/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShow(int id, Show show)
    {
        if (id != show.ShowId)
        {
            return BadRequest();
        }

        _context.Entry(show).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Shows.Any(s => s.ShowId == id))
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

    // DELETE: api/Show/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteShow(int id)
    {
        var show = await _context.Shows.FindAsync(id);
        if (show == null)
        {
            return NotFound();
        }

        _context.Shows.Remove(show);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}