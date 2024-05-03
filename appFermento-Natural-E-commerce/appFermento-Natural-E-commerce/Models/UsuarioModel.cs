using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFermento_Natural_E_commerce.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int id { get; set; }
        [MaxLength(100)]
        public string nome { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(100)]
        public string senha { get; set; }

    }
}
