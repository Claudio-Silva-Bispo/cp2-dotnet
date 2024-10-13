using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _vendedorRepository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _vendedorRepository = repository;
        }

        public VendedorEntity? Criar(VendedorDto vendedor)
        {
            var Vendedor = new VendedorEntity
            {
                Nome = vendedor.Nome,
                Email = vendedor.Email,
                Telefone = vendedor.Telefone,
                DataNascimento = vendedor.DataNascimento,
                Endereco = vendedor.Endereco,
                DataContratacao = vendedor.DataContratacao,
                ComissaoPercentual = vendedor.ComissaoPercentual,
                MetaMensal = vendedor.MetaMensal,
                CriadoEm = vendedor.CriadoEm
            };

            return _vendedorRepository.Criar(Vendedor);
        }

        public VendedorEntity? ConsultarId(int id)
        {
            return _vendedorRepository.ConsultarId(id);
        }

        public IEnumerable<VendedorEntity>? ConsultarTodos()
        {
            return _vendedorRepository.ConsultarTodos();
        }

        public VendedorEntity? Editar(int id, VendedorDto vendedor)
        {
            var Vendedor = new VendedorEntity { 
                Id = id,    
                Nome = vendedor.Nome,
                Email = vendedor.Email,
                Telefone = vendedor.Telefone,
                DataNascimento = vendedor.DataNascimento,
                Endereco = vendedor.Endereco,
                DataContratacao = vendedor.DataContratacao,
                ComissaoPercentual = vendedor.ComissaoPercentual,
                MetaMensal = vendedor.MetaMensal,

                // Não pode atualizar data de criação - regra de negócio.
                //CriadoEm = vendedor.CriadoEm
            };

            return _vendedorRepository.Editar(Vendedor);
        }

        public VendedorEntity? Deletar(int id)
        {
            return _vendedorRepository.Deletar(id);
        }
     
    }
    }

