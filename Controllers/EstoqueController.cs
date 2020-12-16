using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/estoque")]
    public class EstoqueController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Estoque>>> Get([FromServices] DataContext context)
        {
            var estoques = await context.Estoques.Include(x => x.Produto.Categoria).ToListAsync();
            estoques = await context.Estoques.Include(x => x.Produto.Fornecedor).ToListAsync();
            return estoques;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Estoque>> Post(
            [FromServices] DataContext context,
            [FromBody] Estoque model
        )
        {
            if (ModelState.IsValid)
            {
                context.Estoques.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet]
        [Route("getEstoque/{id:int}")]
        public async Task<ActionResult<Estoque>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var produto = await context.Estoques
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }
    }
}