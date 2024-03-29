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
    public class Historicos : ControllerBase
    {
        private readonly RH_bdContext _context;

        public Historicos(RH_bdContext context)
        {
            _context = context;
        }

        // GET: api/Historicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historico>>> GetHistoricos()
        {
          if (_context.Historicos == null)
          {
              return NotFound();
          }
            return await _context.Historicos.ToListAsync();
        }

        // GET: api/Historicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historico>> GetHistorico(int id)
        {
          if (_context.Historicos == null)
          {
              return NotFound();
          }
            var historico = await _context.Historicos.FindAsync(id);

            if (historico == null)
            {
                return NotFound();
            }

            return historico;
        }

        // PUT: api/Historicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorico(int id, Historico historico)
        {
            if (id != historico.IdHistorico)
            {
                return BadRequest();
            }

            _context.Entry(historico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoricoExists(id))
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

        // POST: api/Historicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historico>> PostHistorico(Historico historico)
        {
          if (_context.Historicos == null)
          {
              return Problem("Entity set 'RH_bdContext.Historicos'  is null.");
          }
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorico", new { id = historico.IdHistorico }, historico);
        }

        // DELETE: api/Historicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorico(int id)
        {
            if (_context.Historicos == null)
            {
                return NotFound();
            }
            var historico = await _context.Historicos.FindAsync(id);
            if (historico == null)
            {
                return NotFound();
            }

            _context.Historicos.Remove(historico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoricoExists(int id)
        {
            return (_context.Historicos?.Any(e => e.IdHistorico == id)).GetValueOrDefault();
        }
    }
}
