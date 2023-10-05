using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIServicosResidencia.Context;
using APIServicosResidencia.Modelo;
using Microsoft.Win32;

namespace APIServicosResidencia.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NomeClientesController : ControllerBase
    {
        private readonly ConnectionDb _context;

        public NomeClientesController(ConnectionDb context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NomeCliente>>> GetNomeClientes()
        {
          if (_context.NomeClientes == null)
          {
              return NotFound("Clientes nao encontrados");
          }
            return await _context.NomeClientes.ToListAsync();
        }

        // GET: api/NomeClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NomeCliente>> GetNomeCliente(int id)
        {
          if (_context.NomeClientes == null)
          {
              return NotFound("Registro nao encontrados");
          }
            var nomeCliente = await _context.NomeClientes.FindAsync(id);

            if (nomeCliente == null)
            {
                return NotFound("Não foi possivel localizar o registro");
            }

            return nomeCliente;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutNomeCliente(int id, NomeCliente nomeCliente)
        {
            if (id != nomeCliente.NomeClienteId)
            {
                return BadRequest("Nao foi possivel modificar o registro, identificação nao localizada");
            }

            _context.Entry(nomeCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomeClienteExists(id))
                {
                    return NotFound("Registro nao existente");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

           [HttpPost]
        public async Task<ActionResult<NomeCliente>> PostNomeCliente(NomeCliente nomeCliente)
        {
          if (_context.NomeClientes == null)
          {
              return Problem("Nome do serviço nao pode ser em branco");
            }
            _context.NomeClientes.Add(nomeCliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomeCliente", new { id = nomeCliente.NomeClienteId }, nomeCliente);
        }

        // DELETE: api/NomeClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomeCliente(int id)
        {
            if (_context.NomeClientes == null)
            {
                return NotFound("Registro nao encontrado para remoção");
            }
            var nomeCliente = await _context.NomeClientes.FindAsync(id);
            if (nomeCliente == null)
            {
                return NotFound();
            }

            _context.NomeClientes.Remove(nomeCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomeClienteExists(int id)
        {
            return (_context.NomeClientes?.Any(e => e.NomeClienteId == id)).GetValueOrDefault();
        }
    }
}
