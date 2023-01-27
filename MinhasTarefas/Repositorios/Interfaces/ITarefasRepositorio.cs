using MinhasTarefas.Models;

namespace MinhasTarefas.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefasModel>> BuscarTodasTarefas();

        Task<TarefasModel> BuscarTarefaPorId(int id);

        Task<TarefasModel> AdicionarTarefa(TarefasModel tarefasModel);

        Task<TarefasModel> AtualizarTarefa(TarefasModel tarefasModel, int id);

        Task<bool> ApagarTarefa(int id);
    }
}
