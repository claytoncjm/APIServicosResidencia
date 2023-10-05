using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIServicosResidencia.Context;
using APIServicosResidencia.Modelo;

namespace APIServicosResidencia.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NomeServicosController : ControllerBase
    {
        private readonly ConnectionDb _context;

        public NomeServicosController(ConnectionDb context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<NomeServico>>> GetTipoSeguro()
        {
            if (_context.NomeServicos == null)
            {
                return NotFound("Serviços não encontrados");
            }
            return await _context.NomeServicos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<NomeServico>> GetNomeServico(int id)
        {
            if (_context.NomeServicos == null)
            {
                return NotFound("Numero de identificação nao encontrado");
            }
            var nomeServico = await _context.NomeServicos.FirstOrDefaultAsync(s => s.NomeServicoId == id);

            if (nomeServico == null)
            {
                return NotFound("Não foi possivel localizar o registro");
            }

            return nomeServico;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNomeServico(int id, NomeServico nomeServico)
        {
            if (id != nomeServico.NomeServicoId)
            {
                return BadRequest("Nao foi possivel modificar o registro, identificação nao localizada");
            }

            _context.Entry(nomeServico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NomeServicoExists(id))
                {
                    return NotFound("Registro nao exixtente");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<NomeServico>> PostNomeServico(NomeServico nomeServico)
        {
            if (_context.NomeServicos == null)
            {
                return Problem("Nome do serviço nao pode ser em branco");
            }
            _context.NomeServicos.Add(nomeServico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNomeServico", new { id = nomeServico.NomeServicoId }, nomeServico);
        }

        // DELETE: api/NomeServicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNomeServico(int id)
        {
            if (_context.NomeServicos == null)
            {
                return NotFound();
            }
            var nomeServico = await _context.NomeServicos.FirstOrDefaultAsync(s => s.NomeServicoId == id);
            if (nomeServico == null)
            {
                return NotFound("Registro nao encontrado para remoção");
            }

            _context.NomeServicos.Remove(nomeServico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NomeServicoExists(int id)
        {
            return (_context.NomeServicos?.Any(e => e.NomeServicoId == id)).GetValueOrDefault();
        }
    }
}
