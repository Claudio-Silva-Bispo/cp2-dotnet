using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        // Criar um vendedor
        public VendedorEntity? Criar(VendedorEntity vendedor)
        {
            try
            {
                _context.Add(vendedor);
                _context.SaveChanges();

                return vendedor;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel salvar o vendedor ");
            }

        }

        // Procurar somente pelo ID
        public VendedorEntity? ConsultarId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                return vendedor;
            }
            return null;
        }

        // Procurar tudo
        public IEnumerable<VendedorEntity>? ConsultarTodos()
        {
            var vendedores = _context.Vendedor.ToList();

            if (vendedores.Any())
                return vendedores;

            return null;
        }

        // Atualizar um vendedor
        public VendedorEntity? Editar(VendedorEntity vendedor)
        {
            try
            {
                var vendedores = _context.Vendedor.Find(vendedor.Id);

                if (vendedor is not null)
                {
                    vendedor.Nome = vendedor.Nome;
                    vendedor.Email = vendedor.Email;
                    vendedor.Telefone = vendedor.Telefone;
                    vendedor.DataNascimento = vendedor.DataNascimento;
                    vendedor.Endereco = vendedor.Endereco;
                    vendedor.DataContratacao = vendedor.DataContratacao;
                    vendedor.ComissaoPercentual = vendedor.ComissaoPercentual;
                    vendedor.MetaMensal = vendedor.MetaMensal;

                    _context.Update(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o cliente
                throw new Exception("Não foi possivel localizar o vendedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Deletar um vendedor
        public VendedorEntity? Deletar(int id)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(id);

                if (vendedor is not null)
                {
                    _context.Remove(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o cliente
                throw new Exception("Não foi possivel localizar o vendedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}
