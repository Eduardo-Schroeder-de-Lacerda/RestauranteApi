using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Produto Inválido")]
        public double Salario { get; set; }
    }
}