using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhasTarefas.Data;
using MinhasTarefas.Models;
using MinhasTarefas.Repositorios.Interfaces;

namespace MinhasTarefas.Repositorios;

public class TarefaRepositorio : ITarefaRepositorio
{
    private readonly TarefasDbContext _dbContext;
    public TarefaRepositorio(TarefasDbContext tarefasDbContext)
    {
        _dbContext = tarefasDbContext;
    }

    public async Task<List<TarefasModel>> BuscarTodasTarefas()
    {
        return await _dbContext.TarefasModels.ToListAsync();
    }

    public async Task<TarefasModel> BuscarTarefaPorId(int id)
    {
        return await _dbContext.TarefasModels.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TarefasModel> AdicionarTarefa(TarefasModel tarefasModel)
    {
       await _dbContext.TarefasModels.AddAsync(tarefasModel);
       await _dbContext.SaveChangesAsync();
        return tarefasModel;
    }

    public async Task<TarefasModel> AtualizarTarefa(TarefasModel tarefasModel, int id)
    {
        TarefasModel tarefaPorId = await BuscarTarefaPorId(id);

       if (tarefaPorId == null)
       {
           throw new Exception($"Tarefa do Id de numero: {id} não foi encontrado!");
       }

        tarefaPorId.Nome = tarefaPorId.Nome;
        tarefasModel.Descricao = tarefasModel.Descricao;
        tarefasModel.Status = tarefasModel.Status;
        tarefaPorId.UsuarioId = tarefaPorId.UsuarioId;

        _dbContext.TarefasModels.Update(tarefaPorId);
      await _dbContext.SaveChangesAsync();

       return tarefaPorId;
    }

    public async Task<bool> ApagarTarefa(int id)
    {
        TarefasModel tarefaPorId = await BuscarTarefaPorId(id);

        if (tarefaPorId == null)
        {
            throw new Exception($"Tarefa do Id de numero: {id} não foi encontrado!");
        }

        _dbContext.TarefasModels.Remove(tarefaPorId);
       await _dbContext.SaveChangesAsync();

        return true;
    }
}