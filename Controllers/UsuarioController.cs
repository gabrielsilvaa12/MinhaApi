using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [ApiController] // Define a rota como Controller de API
    [Route("api/[controller]")] // api/Produto
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _contextDb;

        public UsuarioController(AppDbContext contextDb)
        {
            _contextDb = contextDb;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var usuarios = await _contextDb.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contextDb.Usuarios.Add(usuario);
            await _contextDb.SaveChangesAsync();

            return Ok("Usuario criado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            Usuario? usuario = await _contextDb.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound($"Usuario com o id {id} não foi encontrado");

            }

            _contextDb.Usuarios.Remove(usuario);
            await _contextDb.SaveChangesAsync();
            return Ok("Usuario deletado com sucesso");

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {

            Usuario? usuario = await _contextDb.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound($"Usuario com o id {id} não foi encontrado");
            }

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Usuario usuario)
        {

            if (id != usuario.Id)
            {
                return BadRequest("O id enviado nao corresponde ao id do usuario no banco de dados");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool exist = await _contextDb.Usuarios.AnyAsync(p => p.Id == id);

            if (!exist)
            {
                return NotFound($"O usuario com o id {id} não foi encontrado");
            }

            _contextDb.Entry(usuario).State = EntityState.Modified;
            await _contextDb.SaveChangesAsync();

            return Ok("Usuario atualizado com sucesso!!!!!!");
        }

    }
}
