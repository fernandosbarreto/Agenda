using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TpDoceController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<TpDoce> _dbSet;

        public TpDoceController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<TpDoce>();
        }
//O Get serve para solicitar os dados (buscar dados no banco)
        [HttpGet]
        public IActionResult Get()
        {
            var TpDoces = _dbSet
            // .Include(o => o.Telefone)
                .ToList();
            return Ok(TpDoces);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var TpDoce = _dbSet
                // .Include(o => o.Telefone)
                // .Include(o => o.Endereco)
                .FirstOrDefault(o => o.Id == id);

            if (TpDoce != null)
                return Ok(TpDoce);
            else
                return NotFound();
        }
//O post serve para CADASTRAR informações
        [HttpPost]
        public IActionResult Post([FromBody] TpDoce TpDoce)
        {
            try
            {
                TpDoce.Id = 0;

                _dbSet.Add(TpDoce);

                _agendaDbContext.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, new { msg = "Erro ao executar operação" });
            }
        }
//O Delete serve para APAGAR
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var TpDoce = _dbSet.FirstOrDefault(o => o.Id == id);

            if (TpDoce == null)
                return NoContent();

            _dbSet.Remove(TpDoce);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }
// O put serve para dar UPDATE (Atualizar informações)
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TpDoce TpDoce)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                TpDoce.Id = id;
                _dbSet.Update(TpDoce);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}