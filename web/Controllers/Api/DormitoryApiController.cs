using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Filters;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/dormitory")]
    [ApiController]
    [ApiKeyAuth]
    public class DormitoryApiController : ControllerBase
    {
        private readonly EMIContext _context;

        public DormitoryApiController(EMIContext context)
        {
            _context = context;
        }

        // GET: api/DormitoryApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dormitory>>> GetDormitories()
        {
          if (_context.Dormitories == null)
          {
              return NotFound();
          }
            return await _context.Dormitories.ToListAsync();
        }

        // GET: api/DormitoryApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dormitory>> GetDormitory(int id)
        {
          if (_context.Dormitories == null)
          {
              return NotFound();
          }
            var dormitory = await _context.Dormitories.FindAsync(id);

            if (dormitory == null)
            {
                return NotFound();
            }

            return dormitory;
        }

        // PUT: api/DormitoryApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDormitory(int id, Dormitory dormitory)
        {
            if (id != dormitory.DormitoryID)
            {
                return BadRequest();
            }

            _context.Entry(dormitory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DormitoryExists(id))
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

        // POST: api/DormitoryApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dormitory>> PostDormitory(Dormitory dormitory)
        {
          if (_context.Dormitories == null)
          {
              return Problem("Entity set 'EMIContext.Dormitories'  is null.");
          }
            _context.Dormitories.Add(dormitory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDormitory", new { id = dormitory.DormitoryID }, dormitory);
        }

        // DELETE: api/DormitoryApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDormitory(int id)
        {
            if (_context.Dormitories == null)
            {
                return NotFound();
            }
            var dormitory = await _context.Dormitories.FindAsync(id);
            if (dormitory == null)
            {
                return NotFound();
            }

            _context.Dormitories.Remove(dormitory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DormitoryExists(int id)
        {
            return (_context.Dormitories?.Any(e => e.DormitoryID == id)).GetValueOrDefault();
        }
    }
}
