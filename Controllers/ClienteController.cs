using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _appContext;

        public ClienteController(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            List<Cliente> clientes = await _appContext.Clientes.
                Include(cliente => cliente.Enderecos).
                ToListAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente) {
            if (!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            _appContext.Clientes.Add(cliente);
            await _appContext.SaveChangesAsync();
            return Ok("Cliente criado com sucesso");
        }
    }
}
