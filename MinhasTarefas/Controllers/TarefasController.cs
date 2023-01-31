using System.Net;
using Microsoft.AspNetCore.Mvc;
using MinhasTarefas.Models;
using MinhasTarefas.Repositorios;
using MinhasTarefas.Repositorios.Interfaces;
using Swashbuckle.Swagger.Annotations;

namespace MinhasTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TarefasController : ControllerBase
    {
        private readonly ITarefaRepositorio _tarefasRepositorio;

        public TarefasController(ITarefaRepositorio tarefasRepositorio)
        {
            _tarefasRepositorio = tarefasRepositorio;
        }
        [HttpGet]
        [Route("BuscarTodasTarefas")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<List<TarefasModel>>> BuscarTodosUsuarios()
        {
            List<TarefasModel> tarefasModel = await _tarefasRepositorio.BuscarTodasTarefas();
            return Ok(tarefasModel);
        }

        [HttpGet]
        [Route("BuscarTarefasPorId")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<TarefasModel>> BuscarTarefasPorId(int id)
        {
            TarefasModel tarefasModel = await _tarefasRepositorio.BuscarTarefaPorId(id);
            return Ok(tarefasModel);
        }

        [HttpPost]
        [Route("AdicionarTarefa")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]
        public async Task<ActionResult<TarefasModel>> AdicionarTarefa([FromBody] TarefasModel tarefasModel)
        {
            tarefasModel = await _tarefasRepositorio.AdicionarTarefa(tarefasModel);
            return Ok(tarefasModel);
        }

        [HttpPut]
        [Route("AtualizarTarefa/{id}")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<UsuariosModel>> AtualizarTarefa([FromBody] TarefasModel tarefasModel, int id)
        {
            try
            {
                tarefasModel.Id = id;
                TarefasModel tarefas = await _tarefasRepositorio.AtualizarTarefa(tarefasModel, id);
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                string retorno = $"Ocorreu um erro ao excluir o usuario {ex.Message}";
                return BadRequest(retorno);
            }
            
        }

        [HttpDelete]
        [Route("ApagarTarefa")]
        [SwaggerResponse((HttpStatusCode.OK))]
        [SwaggerResponse((HttpStatusCode.BadRequest))]
        [SwaggerResponse((HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<TarefasModel>> ApagarTarefa(int id)
        {
            try
            {
                bool apagado = await _tarefasRepositorio.ApagarTarefa(id);
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