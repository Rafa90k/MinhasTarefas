using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasTarefas.Models;

namespace MinhasTarefas.Data.Map;

public class UsuarioMap : IEntityTypeConfiguration<UsuariosModel>
{
    public void Configure(EntityTypeBuilder<UsuariosModel> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
    }
}