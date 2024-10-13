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
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // Criar um vendedor
        [HttpPost]
        [Produces<VendedorEntity>]
        [SwaggerOperation(Summary = "Criar um vendedor", Description = "Este endpoint será responsável por criar um novo vendedor na base de dados.")]
        public IActionResult Post([FromBody] VendedorDto vendedor)
        {
            try
            {
                var objModel = _applicationService.Criar(vendedor);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados do vendedor");
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

        // Consultar a lista de todos os vendedores
        [HttpGet]
        [Produces<IEnumerable<VendedorEntity>>]
        [SwaggerOperation(Summary = "Consulta todos os vendedores", Description = "Este endpoint retorna uma lista completa de todos os vendedores cadastrados.")]
        public IActionResult Get()
        {
            var objModel = _applicationService.ConsultarTodos();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do vendedor");
        }

        // Consultar por ID
        [HttpGet("{id}")]
        [Produces<VendedorEntity>]
        [SwaggerOperation(Summary = "Consultar um único vendedores", Description = "Este endpoint retorna os dados de um único vendedor.")]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ConsultarId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do vendedor");
        }

        // Editar os dados de um vendedor
        [HttpPut("{id}")]
        [Produces<VendedorEntity>]
        [SwaggerOperation(Summary = "Atualizar dados de um vendedor", Description = "Este endpoint possui responsabilidade de atualizar os dados de um vendedor, como nome, email, telefone, data de nascimento, endereço, comissão, meta e data de contratação.")]
        public IActionResult Put(int id, [FromBody] VendedorDto vendedorDto)
        {
            try
            {
                var objModel = _applicationService.Editar(id, vendedorDto);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possivel salvar os dados do vendedor");
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

        // Deletar um vendedor
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletar um vendedor", Description = "Este endpoint deleta um vendedor, apenas informar o ID.")]
        [Produces<VendedorEntity>]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.Deletar(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados vendedor");
        }
    }
}
