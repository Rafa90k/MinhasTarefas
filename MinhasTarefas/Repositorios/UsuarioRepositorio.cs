using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Data;
using MinhasTarefas.Models;
using MinhasTarefas.Repositorios.Interfaces;

namespace MinhasTarefas.Repositorios;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly TarefasDbContext _dbContext;
    public UsuarioRepositorio(TarefasDbContext tarefasDbContext)
    {
        _dbContext = tarefasDbContext;
    }

    public async Task<List<UsuariosModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.UsuariosModels.ToListAsync();
    }

    public async Task<UsuariosModel> BuscarUsuarioPorId(int id)
    {
        return await _dbContext.UsuariosModels.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UsuariosModel> AdicionarUsuario(UsuariosModel usuariosModel)
    {
       await _dbContext.UsuariosModels.AddAsync(usuariosModel);
       await _dbContext.SaveChangesAsync();
        return usuariosModel;
    }

    public async Task<UsuariosModel> AtualizarUsuario(UsuariosModel usuariosModel, int id)
    {
       UsuariosModel usuarioPorId = await BuscarUsuarioPorId(id);

       if (usuarioPorId == null)
       {
           throw new Exception($"Usuario do Id de numero: {id} não foi encontrado!");
       }

       usuarioPorId.Nome = usuariosModel.Nome;
       usuarioPorId.Email = usuariosModel.Email;

       _dbContext.UsuariosModels.Update(usuarioPorId);
      await _dbContext.SaveChangesAsync();

       return usuarioPorId;
    }

    public async Task<bool> ApagarUsuario(int id)
    {
        UsuariosModel usuarioPorId = await BuscarUsuarioPorId(id);

        if (usuarioPorId == null)
        {
            throw new Exception($"Usuario do Id de numero: {id} não foi encontrado!");
        }

        _dbContext.UsuariosModels.Remove(usuarioPorId);
       await _dbContext.SaveChangesAsync();

        return true;
    }
}