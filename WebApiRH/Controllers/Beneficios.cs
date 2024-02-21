using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRH.Models;

namespace WebApiRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Beneficios : ControllerBase
    {
        private readonly RH_bdContext _context;

        public Beneficios(RH_bdContext context)
        {
            _context = context;
        }

        // GET: api/Beneficios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beneficio>>> GetBeneficios()
        {
          if (_context.Beneficios == null)
          {
              return NotFound();
          }
            return await _context.Beneficios.ToListAsync();
        }

        // GET: api/Beneficios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beneficio>> GetBeneficio(int id)
        {
          if (_context.Beneficios == null)
          {
              return NotFound();
          }
            var beneficio = await _context.Beneficios.FindAsync(id);

            if (beneficio == null)
            {
                return NotFound();
            }

            return beneficio;
        }

        // PUT: api/Beneficios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficio(int id, Beneficio beneficio)
        {
            if (id != beneficio.IdBeneficio)
            {
                return BadRequest();
            }

            _context.Entry(beneficio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficioExists(id))
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

        // POST: api/Beneficios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beneficio>> PostBeneficio(Beneficio beneficio)
        {
          if (_context.Beneficios == null)
          {
              return Problem("Entity set 'RH_bdContext.Beneficios'  is null.");
          }
            _context.Beneficios.Add(beneficio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficio", new { id = beneficio.IdBeneficio }, beneficio);
        }

        // DELETE: api/Beneficios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeneficio(int id)
        {
            if (_context.Beneficios == null)
            {
                return NotFound();
            }
            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }

            _context.Beneficios.Remove(beneficio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeneficioExists(int id)
        {
            return (_context.Beneficios?.Any(e => e.IdBeneficio == id)).GetValueOrDefault();
        }
    }
}
