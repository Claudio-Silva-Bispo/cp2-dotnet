using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity? Criar(FornecedorEntity fornecedor);
        FornecedorEntity? ConsultarId(int id);
        IEnumerable<FornecedorEntity>? ConsultarTodos();
        FornecedorEntity? Editar(FornecedorEntity fornecedor);
        FornecedorEntity? Deletar(int id);
        
    }
}
