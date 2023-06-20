using ApiMinimal.Data.Map;
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

        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
