using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFermento_Natural_E_commerce.Models
{
	[Table ("usuario")]
	public class Usuario
	{
		[Key]
        public int id { get; set; }
		public string nome { get; set; }
		public string email { get; set; }
		public string senha { get; set; }
		public string endereço { get; set; }
		public int celular { get; set; }
	}
}
