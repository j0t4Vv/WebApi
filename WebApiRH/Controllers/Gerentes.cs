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
    public class Gerentes : ControllerBase
    {
        private readonly RH_bdContext _context;

        public Gerentes(RH_bdContext context)
        {
            _context = context;
        }

        // GET: api/Gerentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gerente>>> GetGerentes()
        {
          if (_context.Gerentes == null)
          {
              return NotFound();
          }
            return await _context.Gerentes.ToListAsync();
        }

        // GET: api/Gerentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gerente>> GetGerente(int id)
        {
          if (_context.Gerentes == null)
          {
              return NotFound();
          }
            var gerente = await _context.Gerentes.FindAsync(id);

            if (gerente == null)
            {
                return NotFound();
            }

            return gerente;
        }

        // PUT: api/Gerentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGerente(int id, Gerente gerente)
        {
            if (id != gerente.IdGerente)
            {
                return BadRequest();
            }

            _context.Entry(gerente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerenteExists(id))
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

        // POST: api/Gerentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gerente>> PostGerente(Gerente gerente)
        {
          if (_context.Gerentes == null)
          {
              return Problem("Entity set 'RH_bdContext.Gerentes'  is null.");
          }
            _context.Gerentes.Add(gerente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGerente", new { id = gerente.IdGerente }, gerente);
        }

        // DELETE: api/Gerentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGerente(int id)
        {
            if (_context.Gerentes == null)
            {
                return NotFound();
            }
            var gerente = await _context.Gerentes.FindAsync(id);
            if (gerente == null)
            {
                return NotFound();
            }

            _context.Gerentes.Remove(gerente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GerenteExists(int id)
        {
            return (_context.Gerentes?.Any(e => e.IdGerente == id)).GetValueOrDefault();
        }
    }
}
