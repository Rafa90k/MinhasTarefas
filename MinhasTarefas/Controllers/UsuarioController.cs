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
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]
        
        public async Task <ActionResult<List<UsuariosModel>>> BuscarTodosUsuarios()
        {
            List<UsuariosModel> usuariosModels = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuariosModels);
        }

        [HttpGet("{id}")]
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

    }
}