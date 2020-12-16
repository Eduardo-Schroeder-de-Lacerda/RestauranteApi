using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class Produto
    { 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        public string Nome { get; set; }

        [MaxLength(1024, ErrorMessage="Este campo deve conter até 1024 caractéres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="O preço deve ser maior que zero")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Categoria Inválida")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } 

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Fornecedor Inválido")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; } 
    }
}