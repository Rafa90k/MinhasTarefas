using System.Net;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefas.Models;
using Swashbuckle.Swagger.Annotations;

namespace MinhasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]
        
        public ActionResult<List<UsuariosModel>> BuscarTodosUsuarios()
        {
            return Ok();
        }
    }
}