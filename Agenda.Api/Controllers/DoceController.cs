using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoceController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Doce> _dbSet;

        public DoceController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Doce>();
        }
//O Get serve para solicitar os dados (buscar dados no banco)
        [HttpGet]
        public IActionResult Get()
        {
            var Doces = _dbSet
            .Include(o => o.TpDoce)
                .ToList();
            return Ok(Doces);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Doce = _dbSet
                .Include(o => o.TpDoce)
                // .Include(o => o.Endereco)
                .FirstOrDefault(o => o.Id == id);

            if (Doce != null)
                return Ok(Doce);
            else
                return NotFound();
        }
//O post serve para CADASTRAR informações
        [HttpPost]
        public IActionResult Post([FromBody] Doce Doce)
        {
            try
            {
                Doce.Id = 0;

                _dbSet.Add(Doce);

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
            var Doce = _dbSet.FirstOrDefault(o => o.Id == id);

            if (Doce == null)
                return NoContent();

            _dbSet.Remove(Doce);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }
// O put serve para dar UPDATE (Atualizar informações)
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Doce Doce)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                Doce.Id = id;
                _dbSet.Update(Doce);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}