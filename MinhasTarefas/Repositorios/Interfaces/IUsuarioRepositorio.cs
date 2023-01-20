using MinhasTarefas.Models;

namespace MinhasTarefas.Repositorios.Interfaces;

public interface IUsuarioRepositorio
{
    Task<List<UsuariosModel>> BuscarTodosUsuarios();
    
    Task<UsuariosModel> BuscarUsuarioPorId(int id);

    Task<UsuariosModel> AdicionarUsuario(UsuariosModel usuariosModel);

    Task<UsuariosModel> AtualizarUsuario(UsuariosModel usuariosModel, int id);

    Task<bool> ApagarUsuario(int id);

}