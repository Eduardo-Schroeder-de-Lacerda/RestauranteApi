using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Quantidade Inválida")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Produto Inválido")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }  

        [Required(ErrorMessage = "Campo obrigatório")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; } 

    }
}