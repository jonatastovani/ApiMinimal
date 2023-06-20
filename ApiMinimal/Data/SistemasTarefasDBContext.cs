using ApiMinimal.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiMinimal.Data
{
    public class SistemasTarefasDBContext : DbContext
    {
        public SistemasTarefasDBContext(DbContextOptions<SistemasTarefasDBContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
