﻿using System;
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
    public class Cargos : ControllerBase
    {
        private readonly RH_bdContext _context;

        public Cargos(RH_bdContext context)
        {
            _context = context;
        }

        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
          if (_context.Cargos == null)
          {
              return NotFound();
          }
            return await _context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
          if (_context.Cargos == null)
          {
              return NotFound();
          }
            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo == null)
            {
                return NotFound();
            }

            return cargo;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargo(int id, Cargo cargo)
        {
            if (id != cargo.IdCargo)
            {
                return BadRequest();
            }

            _context.Entry(cargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoExists(id))
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

        // POST: api/Cargos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cargo>> PostCargo(Cargo cargo)
        {
          if (_context.Cargos == null)
          {
              return Problem("Entity set 'RH_bdContext.Cargos'  is null.");
          }
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargo", new { id = cargo.IdCargo }, cargo);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            if (_context.Cargos == null)
            {
                return NotFound();
            }
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }

            _context.Cargos.Remove(cargo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoExists(int id)
        {
            return (_context.Cargos?.Any(e => e.IdCargo == id)).GetValueOrDefault();
        }
    }
}
