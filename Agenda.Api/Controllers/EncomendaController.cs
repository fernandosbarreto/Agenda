using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncomendaController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Encomenda> _dbSet;

        public EncomendaController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Encomenda>();
        }
//O Get serve para solicitar os dados (buscar dados no banco)
        [HttpGet]
        public IActionResult Get()
        {
            var Encomendas = _dbSet
            .Include(o => o.Doce)
            .ThenInclude(o => o.TpDoce)
            .Include(o => o.Cliente)
                .ToList();
            return Ok(Encomendas);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Encomenda = _dbSet
                .Include(o => o.Doce)
                .Include(o => o.Cliente)
                .FirstOrDefault(o => o.Id == id);

            if (Encomenda != null)
                return Ok(Encomenda);
            else
                return NotFound();
        }

//O post serve para CADASTRAR informações
        [HttpPost]
        public IActionResult Post([FromBody] Encomenda Encomenda)
        {
            try
            {
                Encomenda.Id = 0;

                _dbSet.Add(Encomenda);

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
            var Encomenda = _dbSet.FirstOrDefault(o => o.Id == id);

            if (Encomenda == null)
                return NoContent();

            _dbSet.Remove(Encomenda);

            _agendaDbContext.SaveChanges();

            return NoContent();
        }
// O put serve para dar UPDATE (Atualizar informações)
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Encomenda Encomenda)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                Encomenda.Id = id;
                _dbSet.Update(Encomenda);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}