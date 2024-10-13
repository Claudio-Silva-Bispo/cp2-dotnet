using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? Criar(VendedorEntity vendedor);
        VendedorEntity? ConsultarId(int id);
        IEnumerable<VendedorEntity>? ConsultarTodos();
        VendedorEntity? Editar(VendedorEntity vendedor);
        VendedorEntity? Deletar(int id);

    }
}
