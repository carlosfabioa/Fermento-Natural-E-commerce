using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFermento_Natural_E_commerce.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um email válido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, ErrorMessage = "A senha deve ter no mínimo {2} caracteres.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "A senha deve conter pelo menos uma letra e um número.")]
        public string senha { get; set; }


        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string endereço { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório.")]
        [Phone(ErrorMessage = "Por favor, insira um número de celular válido.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O número de celular deve ter 11 dígitos.")]
        public string celular { get; set; }
    }
}
