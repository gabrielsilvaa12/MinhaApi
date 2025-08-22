using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;

namespace MinhaAPI.Controllers
{
    [ApiController] // Define a rota como Controller de API
    [Route("api/[controller]")] // api/Produto

    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _contextDb;

        public ProdutoController(AppDbContext contextDb)
        {
            _contextDb = contextDb;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {

            var produtos = await _contextDb.Produtos.ToListAsync();
            return Ok(produtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Produto produto) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _contextDb.Produtos.Add(produto);
            await _contextDb.SaveChangesAsync();

            return Ok("Produto criado com sucesso");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) {

            var produto = await _contextDb.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound($"Produto com o id {id} não foi encontrado");

            }

            _contextDb.Produtos.Remove(produto);
            await _contextDb.SaveChangesAsync();
            return Ok("Produto deletado com sucesso");

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id) {

            Produto? produto = await _contextDb.Produtos.FindAsync(id);

            if (produto == null)
            { 
                return NotFound($"Produto com o id {id} não foi encontrado");
            }

            return Ok(produto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Produto produto) {

            if (id != produto.Id) {
                return BadRequest("O id enviado nao corresponde ao id do produto no banco de dados");
            }
            
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool exist = await _contextDb.Produtos.AnyAsync(p => p.Id == id);

            if(!exist)
            {
                return NotFound($"O produto com o id {id} não foi encontrado");
            }

            _contextDb.Entry(produto).State = EntityState.Modified;
            await _contextDb.SaveChangesAsync();

            return Ok("Produto atualizado com sucesso!!!!!!");
        }

    }
}
