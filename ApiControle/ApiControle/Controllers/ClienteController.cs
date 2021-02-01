using ApiControle.Persistence;
using ApiControle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiControle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _context.Clientes.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> CreateClientes([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(long id)
        {
            var todosIds = await _context.Clientes.FindAsync(id);
            if (todosIds == null)
            {
                return NotFound();
            }
            return todosIds;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteProduto(long id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return clientes;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Cliente clientes)
        {
            if (id != clientes.Id)
            {
                return BadRequest();
            }
            _context.Entry(clientes).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExiste(id))
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
        private bool ClienteExiste(long id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
