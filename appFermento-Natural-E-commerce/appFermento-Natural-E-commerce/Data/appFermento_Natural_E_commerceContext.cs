using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using appFermento_Natural_E_commerce.Models;

namespace appFermento_Natural_E_commerce.Data
{
    public class appFermento_Natural_E_commerceContext : DbContext
    {
        public appFermento_Natural_E_commerceContext (DbContextOptions<appFermento_Natural_E_commerceContext> options)
            : base(options)
        {
        }

        public DbSet<appFermento_Natural_E_commerce.Models.UsuarioModel> UsuarioModel { get; set; } = default!;
    }
}
