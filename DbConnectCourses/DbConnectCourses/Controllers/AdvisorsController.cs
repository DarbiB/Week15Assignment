using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbConnectCourses.Data;
using DbConnectCourses.Models;
using Microsoft.AspNetCore.Authorization;

namespace DbConnectCourses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorsController : ControllerBase
    {
        private readonly CoursesContext _context;

        public AdvisorsController(CoursesContext context)
        {
            _context = context;
        }


        [Authorize]
        // GET: api/Advisors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advisor>>> GetAdvisors()
        {
          if (_context.Advisors == null)
          {
              return NotFound();
          }
            return await _context.Advisors.ToListAsync();
        }

        // GET: api/Advisors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advisor>> GetAdvisor(string id)
        {
          if (_context.Advisors == null)
          {
              return NotFound();
          }
            var advisor = await _context.Advisors.FindAsync(id);

            if (advisor == null)
            {
                return NotFound();
            }

            return advisor;
        }

        // PUT: api/Advisors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvisor(string id, Advisor advisor)
        {
            if (id != advisor.AdvisorId)
            {
                return BadRequest();
            }

            _context.Entry(advisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisorExists(id))
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

        // POST: api/Advisors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Advisor>> PostAdvisor(Advisor advisor)
        {
          if (_context.Advisors == null)
          {
              return Problem("Entity set 'CoursesContext.Advisors'  is null.");
          }
            _context.Advisors.Add(advisor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AdvisorExists(advisor.AdvisorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAdvisor", new { id = advisor.AdvisorId }, advisor);
        }

        // DELETE: api/Advisors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(string id)
        {
            if (_context.Advisors == null)
            {
                return NotFound();
            }
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }

            _context.Advisors.Remove(advisor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvisorExists(string id)
        {
            return (_context.Advisors?.Any(e => e.AdvisorId == id)).GetValueOrDefault();
        }
    }
}
