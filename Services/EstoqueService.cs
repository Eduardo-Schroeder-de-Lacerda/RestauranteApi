using System;
using Microsoft.EntityFrameworkCore;
using RestauranteApi.Models;
using RestauranteApi.Data;
using System.Threading.Tasks;

namespace RestauranteApi.Services
{
    public class EstoqueService
    {
        private readonly DataContext _context;
        public EstoqueService(DataContext context)
        {
            _context = context;
        }
        public async Task<Estoque> FindEstoqueById(int id){
            return await _context.Estoques.FirstOrDefaultAsync(x => x.Produto.Id == id);
        }
    }
}