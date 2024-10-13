using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Criar um fornecedor
        public FornecedorEntity? Criar(FornecedorEntity fornecedor)
        {
            try
            {
                _context.Add(fornecedor);
                _context.SaveChanges();

                return fornecedor;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel salvar o fornecedor ");
            }

        }

        // Procurar somente pelo ID
        public FornecedorEntity? ConsultarId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor is not null)
            {
                return fornecedor;
            }
            return null;
        }

        // Procurar tudo
        public IEnumerable<FornecedorEntity>? ConsultarTodos()
        {
            var fornecedores = _context.Fornecedor.ToList();

            if (fornecedores.Any())
                return fornecedores;

            return null;
        }

        // Atualizar um fornecedor
        public FornecedorEntity? Editar(FornecedorEntity fornecedor)
        {
            try
            {
                var fornecedors = _context.Fornecedor.Find(fornecedor.Id);

                if (fornecedor is not null)
                {
                    fornecedor.Nome = fornecedor.Nome;
                    fornecedor.CNPJ = fornecedor.CNPJ;
                    fornecedor.Endereco = fornecedor.Endereco;
                    fornecedor.Telefone = fornecedor.Telefone;
                    fornecedor.Email = fornecedor.Email;

                    // Não pode alterar a data em que foi criado.
                    // fornecedor.CriadoEm = entity.CriadoEm;

                    _context.Update(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o cliente
                throw new Exception("Não foi possivel localizar o fornecedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        // Deletar um fornecedor
        public FornecedorEntity? Deletar(int id)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor is not null)
                {
                    _context.Remove(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                //Gera um excecão para informar que nao foi possivel localizar o cliente
                throw new Exception("Não foi possivel localizar o fornecedor ");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    
        
    }

}
