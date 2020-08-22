using System.Linq;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        protected AgendaDbContext _agendaDbContext;
        protected DbSet<Cliente> _dbSet;

        public PessoaController(AgendaDbContext agendaDbContext)
        {
            _agendaDbContext = agendaDbContext;
            _dbSet = agendaDbContext.Set<Cliente>();
        }
//O Get serve para solicitar os dados (buscar dados no banco)
        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _dbSet.Include(o => o.Telefone)
                .ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _dbSet
                .Include(o => o.Telefone)
                // .Include(o => o.Endereco)
                .FirstOrDefault(o => o.Id == id);

            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }
//O post serve para CADASTRAR informações
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                cliente.Id = 0;

                _dbSet.Add(cliente);

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
            var cliente = _dbSet.FirstOrDefault(o => o.Id == id);

            if (cliente == null)
                return NoContent();

            _dbSet.Remove(cliente);

            _agendaDbContext.SaveChanges();
            
            return NoContent();
        }
// O put serve para dar UPDATE (Atualizar informações)
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            if (_dbSet.Any(o => o.Id == id))
            {
                cliente.Id = id;
                _dbSet.Update(cliente);

                _agendaDbContext.SaveChanges();

                return Ok();
            }

            return NoContent();
        }
    }
}