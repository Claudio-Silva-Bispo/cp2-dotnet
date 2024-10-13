using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IVendedorApplicationService
    {
        VendedorEntity? Criar(VendedorDto vendedorDto);
        VendedorEntity? ConsultarId(int id);
        IEnumerable<VendedorEntity>? ConsultarTodos();
        VendedorEntity? Editar(int id, VendedorDto vendedorDto);
        VendedorEntity? Deletar(int id);
    }
}
