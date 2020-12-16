using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/clientes")]
    public class ClienteController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clientes.ToListAsync();
            return clientes;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post(
            [FromServices] DataContext context,
            [FromBody] Cliente model
        )
        {
            if (ModelState.IsValid)
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("deleteCliente/{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id, 
        [FromServices] DataContext context,
        bool? saveChangesError = false)
        {
            var produtoToRemove = await context.Clientes
            .FirstOrDefaultAsync(a => a.Id == id);
            
            context.Remove(produtoToRemove);
            await context.SaveChangesAsync();
            return produtoToRemove;
        }

        [HttpPut]
        [Route("updateCliente/{id:int}")]
        public async Task<ActionResult<Cliente>> Update(
        int id, 
        [FromServices] DataContext context,
        [FromBody] Cliente model)
        {
            var fornecedorToUpdate = await context.Clientes
            .FirstOrDefaultAsync(x => x.Id == id);
            
            fornecedorToUpdate.Nome = model.Nome;
            await context.SaveChangesAsync();
            return fornecedorToUpdate;
        }
        [HttpGet]
        [Route("getCliente/{id:int}")]
        public async Task<ActionResult<Cliente>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var cliente = await context.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return cliente;
        }
    }
}