using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using RestauranteApi.Services;


namespace RestauranteApi.Controllers
{
    [Route("v1/vendas")]
    public class VendaController : Controller
    {
        
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Venda>>> Get([FromServices] DataContext context)
        {
            var vendas = await context.Vendas.ToListAsync();
            return vendas;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Venda>> Post(
            [FromServices] DataContext context,
            [FromBody] Venda model
        )
        {
            if (ModelState.IsValid)
            {
                context.Vendas.Add(model);
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
            
            estoqueToUpdate.Quantidade -= model.Quantidade;
            await context.SaveChangesAsync();
            return estoqueToUpdate;
            
        }
    }
}