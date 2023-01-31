using System.Net;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefas.Models;
using MinhasTarefas.Repositorios.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace MinhasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        //[SwaggerResponse((HttpStatusCode.OK))]
        //[SwaggerResponse((HttpStatusCode.BadRequest))]
        //[SwaggerResponse((HttpStatusCode.InternalServerError))]
        
        public async Task <ActionResult<List<UsuariosModel>>> BuscarTodosUsuarios()
        {
            List<UsuariosModel> usuariosModels = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuariosModels);
        }

        [HttpGet]
        [Route("BuscarUsuarioPorId")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<UsuariosModel>> BuscarUsuarioPorId(int id)
        {
            UsuariosModel usuariosModel = await _usuarioRepositorio.BuscarUsuarioPorId(id);
            return Ok(usuariosModel);
        }

        [HttpPost]
        [Route("AdicionarUsuario")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]
        public async Task<ActionResult<UsuariosModel>> AdicionarUsuario([FromBody] UsuariosModel usuariosModel)
        {
            usuariosModel = await _usuarioRepositorio.AdicionarUsuario(usuariosModel);
            return Ok(usuariosModel);
        }

        [HttpPut]
        [Route("AtualizarUsuario")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<UsuariosModel>> AtualizarUsuario([FromBody] UsuariosModel usuariosModel, int id)
        {
            try
            {
                usuariosModel.Id = id;
                UsuariosModel usuarios = await _usuarioRepositorio.AtualizarUsuario(usuariosModel, id);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                string retorbno = $"Ocorreu um erro ao excluir o usuario {ex.Message}";
                return BadRequest(retorbno);
            }
            
        }

        [HttpDelete]
        [Route("ApagarUsuario")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<UsuariosModel>> ApagarUsuario(int id)
        {
            try
            {
                bool apagado = await _usuarioRepositorio.ApagarUsuario(id);
                return Ok(apagado);
            }
            catch (Exception ex)
            {
                string retorbno = $"Ocorreu um erro ao excluir o usuario {ex.Message}";
                return BadRequest(retorbno);
            }
        }

    }
}