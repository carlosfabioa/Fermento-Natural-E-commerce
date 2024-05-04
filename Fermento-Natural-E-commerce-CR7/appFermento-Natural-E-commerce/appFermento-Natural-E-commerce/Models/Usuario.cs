using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace appFermento_Natural_E_commerce.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string senha { get; set; }

        [Required]
        public string endereço { get; set; }

        [Required]
        [Phone]
        [StringLength(14)]
        public string celular { get; set; }
    }
}
