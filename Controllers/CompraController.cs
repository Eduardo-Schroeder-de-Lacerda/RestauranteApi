using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/compras")]
    public class CompraController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Compra>>> Get([FromServices] DataContext context)
        {
            var compras = await context.Compras.ToListAsync();
            return compras;
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
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Estoque>> Put(
            int id, 
            [FromServices] DataContext context,
            [FromBody] Estoque model
        )
        {
            var estoqueToUpdate = await context.Estoques
            .FirstOrDefaultAsync(x => x.Id == id);
            
            estoqueToUpdate.Quantidade += model.Quantidade;
            await context.SaveChangesAsync();
            return estoqueToUpdate;
        }
    }
}