using ApiMinimal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiMinimal.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.description).HasMaxLength(1000);
            builder.Property(x => x.status).IsRequired();
            builder.Property(x => x.usuarioId);

            builder.HasOne(x => x.usuario);
        }
    }
}
