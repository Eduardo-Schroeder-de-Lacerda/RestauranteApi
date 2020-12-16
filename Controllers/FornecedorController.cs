using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RestauranteApi.Controllers
{
    [Route("v1/fornecedores")]
    public class FornecedorController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Fornecedor>>> Get([FromServices] DataContext context)
        {
            var fornecedores = await context.Fornecedores.ToListAsync();
            return fornecedores;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Fornecedor>> Post(
            [FromServices] DataContext context,
            [FromBody] Fornecedor model
        )
        {
            if (ModelState.IsValid)
            {
                context.Fornecedores.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("deleteFornecedor/{id:int}")]
        public async Task<ActionResult<Fornecedor>> Delete( int id, 
        [FromServices] DataContext context,
        bool? saveChangesError = false)
        {
            var fornecedorToRemove = await context.Fornecedores
            .FirstOrDefaultAsync(a => a.Id == id);
            context.Remove(fornecedorToRemove);
            await context.SaveChangesAsync();
            return fornecedorToRemove;
        }

        [HttpPut]
        [Route("updateFornecedor/{id:int}")]
        public async Task<ActionResult<Fornecedor>> Update(
        int id, 
        [FromServices] DataContext context,
        [FromBody] Fornecedor model)
        {
            var fornecedorToUpdate = await context.Fornecedores
            .FirstOrDefaultAsync(x => x.Id == id);
            
            fornecedorToUpdate.Nome = model.Nome;
            fornecedorToUpdate.Marca = model.Marca;
            fornecedorToUpdate.Email = model.Email;
            await context.SaveChangesAsync();
            return fornecedorToUpdate;
        }

        [HttpGet]
        [Route("getFornecedor/{id:int}")]
        public async Task<ActionResult<Fornecedor>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var fornecedor = await context.Fornecedores
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return fornecedor;
        }
    }
}