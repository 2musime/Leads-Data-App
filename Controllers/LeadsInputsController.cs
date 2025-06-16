using LeadsAPI.Data;
using LeadsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsInputsController : ControllerBase
    {
        private readonly LeadsDbContext _context;

        public LeadsInputsController(LeadsDbContext context)
        {
            _context = context;
        }

        // GET: api/LeadsInputs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadsInput>>> GetLeadsInputs()
        {
            return await _context.LeadsInputs.ToListAsync();
        }

        // GET: api/LeadsInputs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeadsInput>> GetLeadsInput(int id)
        {
            var lead = await _context.LeadsInputs.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        // POST: api/LeadsInputs
        [HttpPost]
        public async Task<ActionResult<LeadsInput>> PostLeadsInput(LeadsInput lead)
        {
            _context.LeadsInputs.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeadsInput), new { id = lead.Id }, lead);
        }

        // PUT: api/LeadsInputs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLeadsInput(int id, LeadsInput lead)
        {
            if (id != lead.Id)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadsInputExists(id))
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

        // DELETE: api/LeadsInputs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeadsInput(int id)
        {
            var lead = await _context.LeadsInputs.FindAsync(id);
            if (lead == null)
            {
                return NotFound();
            }

            _context.LeadsInputs.Remove(lead);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool LeadsInputExists(int id)
        {
            return _context.LeadsInputs.Any(e => e.Id == id);
        }
    }
}
