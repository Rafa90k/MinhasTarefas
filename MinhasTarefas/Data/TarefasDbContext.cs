using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Models;

namespace MinhasTarefas.Data;

public class TarefasDbContext : DbContext
{
    public TarefasDbContext(DbContextOptions <TarefasDbContext> options) : base(options)
    {
    }
    
    public DbSet<UsuariosModel> UsuariosModels { get; set; }
    public DbSet<TarefasModel> TarefasModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
}