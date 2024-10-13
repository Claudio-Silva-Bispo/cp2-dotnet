using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CP2.API.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        [Required]
        public string? CNPJ { get; set; }
        public string? Endereco { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        public string? Email { get; set; }
        public DateTime CriadoEm { get; set; }

    }
}
