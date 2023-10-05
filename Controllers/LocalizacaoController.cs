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
    public class LocalizacaoController : ControllerBase
    {
        private readonly ConnectionDb _context;

        public LocalizacaoController(ConnectionDb context)
        {
            _context = context;
        }

        // GET: api/Localizacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localizacao>>> GetLocalizacaCliente()
        {
          if (_context.LocalizacaCliente == null)
          {
              return NotFound("Serviços não encontrados");
            }
            return await _context.LocalizacaCliente.ToListAsync();
        }

        // GET: api/Localizacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> GetLocalizacao(int id)
        {
          if (_context.LocalizacaCliente == null)
          {
              return NotFound("Numero de identificação nao encontrado");
            }
            var localizacao = await _context.LocalizacaCliente.FindAsync(id);

            if (localizacao == null)
            {
                return NotFound("Não foi possivel localizar o registro");
            }

            return localizacao;
        }

          [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalizacao(int id, Localizacao localizacao)
        {
            if (id != localizacao.LocalizacaoId)
            {
                return BadRequest("Nao foi possivel modificar o registro, identificação nao localizada");
            }

            _context.Entry(localizacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalizacaoExists(id))
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
        public async Task<ActionResult<Localizacao>> PostLocalizacao(Localizacao localizacao)
        {
          if (_context.LocalizacaCliente == null)
          {
              return Problem("Nome do serviço nao pode ser em branco");
            }
            _context.LocalizacaCliente.Add(localizacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalizacao", new { id = localizacao.LocalizacaoId }, localizacao);
        }

        // DELETE: api/Localizacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalizacao(int id)
        {
            if (_context.LocalizacaCliente == null)
            {
                return NotFound();
            }
            var localizacao = await _context.LocalizacaCliente.FindAsync(id);
            if (localizacao == null)
            {
                return NotFound("Registro nao encontrado para remoção");
            }

            _context.LocalizacaCliente.Remove(localizacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalizacaoExists(int id)
        {
            return (_context.LocalizacaCliente?.Any(e => e.LocalizacaoId == id)).GetValueOrDefault();
        }
    }
}
