using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/categorias")]
    public class CategoryController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody] Categoria model
        )
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
        [HttpGet]
        [Route("getCategoria/{id:int}")]
        public async Task<ActionResult<Categoria>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var categorias = await context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return categorias;
        }
    }
}