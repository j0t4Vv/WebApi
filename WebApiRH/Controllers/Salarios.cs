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
    public class Salarios : ControllerBase
    {
        private readonly RH_bdContext _context;

        public Salarios(RH_bdContext context)
        {
            _context = context;
        }

        // GET: api/Salarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salario>>> GetSalarios()
        {
          if (_context.Salarios == null)
          {
              return NotFound();
          }
            return await _context.Salarios.ToListAsync();
        }

        // GET: api/Salarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salario>> GetSalario(int id)
        {
          if (_context.Salarios == null)
          {
              return NotFound();
          }
            var salario = await _context.Salarios.FindAsync(id);

            if (salario == null)
            {
                return NotFound();
            }

            return salario;
        }

        // PUT: api/Salarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalario(int id, Salario salario)
        {
            if (id != salario.IdSalario)
            {
                return BadRequest();
            }

            _context.Entry(salario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalarioExists(id))
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

        // POST: api/Salarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salario>> PostSalario(Salario salario)
        {
          if (_context.Salarios == null)
          {
              return Problem("Entity set 'RH_bdContext.Salarios'  is null.");
          }
            _context.Salarios.Add(salario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalario", new { id = salario.IdSalario }, salario);
        }

        // DELETE: api/Salarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalario(int id)
        {
            if (_context.Salarios == null)
            {
                return NotFound();
            }
            var salario = await _context.Salarios.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }

            _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalarioExists(int id)
        {
            return (_context.Salarios?.Any(e => e.IdSalario == id)).GetValueOrDefault();
        }
    }
}
