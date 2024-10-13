using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.API.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public DateTime DataContratacao { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public Decimal ComissaoPercentual { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }
       
        
        
        
        
    }
}
