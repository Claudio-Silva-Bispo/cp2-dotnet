using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _fornecedorRepository = repository;
        }

        public FornecedorEntity? Criar(FornecedorDto fornecedor)
        {
            var Fornecedor = new FornecedorEntity
            {
                Nome = fornecedor.Nome,
                CNPJ = fornecedor.CNPJ,
                Endereco = fornecedor.Endereco,
                Telefone = fornecedor.Telefone,
                Email = fornecedor.Email,
                CriadoEm = fornecedor.CriadoEm
            };

            return _fornecedorRepository.Criar(Fornecedor);
        }

        public FornecedorEntity? ConsultarId(int id)
        {
            return _fornecedorRepository.ConsultarId(id);
        }

        public IEnumerable<FornecedorEntity>? ConsultarTodos()
        {
            return _fornecedorRepository.ConsultarTodos();
        }

        public FornecedorEntity? Editar(int id, FornecedorDto fornecedor)
        {
            var Fornecedor = new FornecedorEntity { 
                Id = id,    
                Nome = fornecedor.Nome,
                CNPJ = fornecedor.CNPJ,
                Endereco = fornecedor.Endereco,
                Telefone = fornecedor.Telefone,
                Email = fornecedor.Email,
                CriadoEm = fornecedor.CriadoEm
            };

            return _fornecedorRepository.Editar(Fornecedor);
        }

        public FornecedorEntity? Deletar(int id)
        {
            return _fornecedorRepository.Deletar(id);
        }
     
    }
}
