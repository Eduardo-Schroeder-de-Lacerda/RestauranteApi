using RestauranteApi.Data;
using RestauranteApi.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace RestauranteApi.Controllers
{
    [Route("v1/funcionarios")]
    public class FuncionarioController : Controller
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Funcionario>>> Get([FromServices] DataContext context)
        {
            var funcionarios = await context.Funcionarios.ToListAsync();
            return funcionarios;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Funcionario>> Post(
            [FromServices] DataContext context,
            [FromBody] Funcionario model
        )
        {
            if(model.Profissao.Equals("Cozinheiro") || 
                model.Profissao.Equals("Garçom") ||
                model.Profissao.Equals("Chapeiro") ||
                model.Profissao.Equals("Entregador")) 
            {
                if (ModelState.IsValid)
                {
                    context.Funcionarios.Add(model);
                    await context.SaveChangesAsync();

                    return model;

                } 
                else
                {
                    return BadRequest(ModelState);
                }
            }  
            else
            {
                return BadRequest("Funcionário Inválido");
            }
        }

        [HttpDelete]
        [Route("deleteFuncionario/{id:int}")]
        public async Task<ActionResult<Funcionario>> Delete(int id, 
        [FromServices] DataContext context,
        bool? saveChangesError = false)
        {
            var produtoToRemove = await context.Funcionarios
            .FirstOrDefaultAsync(a => a.Id == id);
            
            context.Remove(produtoToRemove);
            await context.SaveChangesAsync();
            return produtoToRemove;
        }

        [HttpPut]
        [Route("updateFuncionario/{id:int}")]
        public async Task<ActionResult<Funcionario>> Update(
        int id, 
        [FromServices] DataContext context,
        [FromBody] Funcionario model)
        {
            var fornecedorToUpdate = await context.Funcionarios
            .FirstOrDefaultAsync(x => x.Id == id);
            
            fornecedorToUpdate.Nome = model.Nome;
            fornecedorToUpdate.Profissao = model.Profissao;
            fornecedorToUpdate.Salario = model.Salario;
            await context.SaveChangesAsync();
            return fornecedorToUpdate;
        }
        [HttpGet]
        [Route("getFuncionario/{id:int}")]
        public async Task<ActionResult<Funcionario>> FindById(
            [FromServices] DataContext context,
            int id)
        {
            var funcionario = await context.Funcionarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return funcionario;
        }
    }
}