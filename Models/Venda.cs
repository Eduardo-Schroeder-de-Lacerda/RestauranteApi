using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, int.MaxValue, ErrorMessage="Quantidade Inválida")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Produto Inválido")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }  

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Funcionário Inválido")]
        public int funcionarioId { get; set; }
        public Funcionario Funcionario { get; set; } 

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Cliente Inválido")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } 

        [Required(ErrorMessage = "Campo obrigatório")]
        public string TipoPagamento { get; set; } 
    }
}