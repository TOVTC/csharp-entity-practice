using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeReleaseReportService;

namespace PracticeReleaseReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseReportsController : ControllerBase
    {
        private readonly ReportsDbContext _context;

        public ReleaseReportsController(ReportsDbContext context)
        {
            _context = context;
        }

        // GET: api/ReleaseReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReleaseReport>>> GetReleaseReports()
        {
          if (_context.ReleaseReports == null)
          {
              return NotFound();
          }
            return await _context.ReleaseReports.ToListAsync();
        }

        // GET: api/ReleaseReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReleaseReport>> GetReleaseReport(int id)
        {
          if (_context.ReleaseReports == null)
          {
              return NotFound();
          }
            var releaseReport = await _context.ReleaseReports.FindAsync(id);

            if (releaseReport == null)
            {
                return NotFound();
            }

            return releaseReport;
        }

        // PUT: api/ReleaseReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReleaseReport(int id, ReleaseReport releaseReport)
        {
            if (id != releaseReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(releaseReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseReportExists(id))
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

        // POST: api/ReleaseReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReleaseReport>> PostReleaseReport(ReleaseReport releaseReport)
        {
          if (_context.ReleaseReports == null)
          {
              return Problem("Entity set 'ReportsDbContext.ReleaseReports'  is null.");
          }
            _context.ReleaseReports.Add(releaseReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReleaseReport", new { id = releaseReport.Id }, releaseReport);
        }

        // DELETE: api/ReleaseReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReleaseReport(int id)
        {
            if (_context.ReleaseReports == null)
            {
                return NotFound();
            }
            var releaseReport = await _context.ReleaseReports.FindAsync(id);
            if (releaseReport == null)
            {
                return NotFound();
            }

            _context.ReleaseReports.Remove(releaseReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReleaseReportExists(int id)
        {
            return (_context.ReleaseReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
