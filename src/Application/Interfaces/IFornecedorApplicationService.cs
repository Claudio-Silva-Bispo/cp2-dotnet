using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        FornecedorEntity? Criar(FornecedorDto fornecedorDto);
        FornecedorEntity? ConsultarId(int id);
        IEnumerable<FornecedorEntity>? ConsultarTodos();
        FornecedorEntity? Editar(int id, FornecedorDto fornecedorDto);
        FornecedorEntity? Deletar(int id);

    }
}
