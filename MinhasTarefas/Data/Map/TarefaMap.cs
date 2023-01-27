using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasTarefas.Models;

namespace MinhasTarefas.Data.Map;

public class TarefaMap : IEntityTypeConfiguration<TarefasModel>
{
    public void Configure(EntityTypeBuilder<TarefasModel> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Descricao).HasMaxLength(1000);
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.UsuarioId);

        builder.HasOne(x => x.Usuario);
    }
}
