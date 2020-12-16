using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/produtos")]
    public class ProdutoController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Produto>>> Get([FromServices] DataContext context)
        {
            var produtos = await context.Produtos.Include(x => x.Categoria).ToListAsync();
            produtos = await context.Produtos.Include(x => x.Fornecedor).ToListAsync();
            return produtos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Produto>> Post(
            [FromServices] DataContext context,
            [FromBody] Produto model
        )
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("deleteProduto/{id:int}")]
        public async Task<ActionResult<Produto>> Delete(int id, 
        [FromServices] DataContext context,
        bool? saveChangesError = false)
        {
            var produtoToRemove = await context.Produtos
            .FirstOrDefaultAsync(a => a.Id == id);
            
            context.Remove(produtoToRemove);
            await context.SaveChangesAsync();
            return produtoToRemove;
        }

        [HttpPut]
        [Route("updateProduto/{id:int}")]
        public async Task<ActionResult<Produto>> Update(
        int id, 
        [FromServices] DataContext context,
        [FromBody] Produto model)
        {
            var fornecedorToUpdate = await context.Produtos
            .FirstOrDefaultAsync(x => x.Id == id);
            
            fornecedorToUpdate.Nome = model.Nome;
            fornecedorToUpdate.Descricao = model.Descricao;
            fornecedorToUpdate.Preco = model.Preco;
            await context.SaveChangesAsync();
            return fornecedorToUpdate;
        }
        [HttpGet]
        [Route("getPorduto/{id:int}")]
        public async Task<ActionResult<Produto>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var produto = await context.Produtos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }
    }
}