using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _applicationService;

        public FornecedorController(IFornecedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // Criar um fornecedor
        [HttpPost]
        [Produces<FornecedorEntity>]
        public IActionResult Post([FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.Criar(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados do fornecedor");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        // Consultar todo os fornecedores
        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os fornecedores", Description = "Este endpoint retorna uma lista completa de todos os fornecedores cadastrados.")]
        [Produces<IEnumerable<FornecedorEntity>>]
        public IActionResult Get()
        {
            var objModel = _applicationService.ConsultarTodos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do fornecedor");
        }

        // Consultar um fornecedor por ID
        [HttpGet("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ConsultarId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do fornecedor");
        }

        // Atualizar os dados de um fornecedor
        [HttpPut("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Put(int id, [FromBody] FornecedorDto entity)
        {
            try
            {
                var objModel = _applicationService.Editar(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados do fornecedor");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        // Deletar um fornecedor
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.Deletar(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados do fornecedor");
        }
    }
}
