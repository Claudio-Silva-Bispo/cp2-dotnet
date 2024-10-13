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
        [SwaggerOperation(Summary = "Criar um fornecedor", Description = "Este endpoint será responsável por criar um novo fornecedor na base de dados.")]
        public IActionResult Post([FromBody] FornecedorDto fornecedorDto)
        {
            try
            {
                var objModel = _applicationService.Criar(fornecedorDto);

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
        [SwaggerOperation(Summary = "Consultar um único fornecedor", Description = "Este endpoint retorna os dados de um único fornecedor.")]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ConsultarId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel obter os dados do fornecedor");
        }

        // Atualizar os dados de um fornecedor
        [HttpPut("{id}")]        
        [SwaggerOperation(Summary = "Atualiza os dados de um fornecedor.", Description = "Este endpoint atualiza as informações de um fornecedor com base no ID fornecido, sendo nome, telefone, entre outros.")]        
        [Produces(typeof(FornecedorEntity))]        
        public IActionResult Put(int id, [FromBody] FornecedorDto fornecedorDto)        {            
            try{                
                var fornecedor = _applicationService.Editar(id, fornecedorDto);                
                return Ok(fornecedor);            
            }            
            catch (Exception ex){                
                return BadRequest(new {Error = ex.Message,                    
                status = HttpStatusCode.BadRequest,                
                        });            
                    }        
                } 

        // Deletar um fornecedor
        [HttpDelete("{id}")]
        [Produces<FornecedorEntity>]
        [SwaggerOperation(Summary = "Deletar um fornecedor", Description = "Este endpoint deleta um fornecedor, apenas informar o ID.")]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.Deletar(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possivel deletar os dados do fornecedor");
        }
    }
}
