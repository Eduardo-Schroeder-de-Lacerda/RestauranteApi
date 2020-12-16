using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class Fornecedor
    { 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        public string Nome { get; set; }

        [MaxLength(60, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        [MinLength(3, ErrorMessage="Este campo deve conter entre 3 e 60 caractéres")]
        public string Marca { get; set; }  

        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string Email { get; set; }        
    }
}