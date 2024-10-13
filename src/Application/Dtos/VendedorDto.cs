using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class VendedorDto
    {

        // Nome: Nome do vendedor (tipo: string, campo obrigatório)
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = null!;

        // Email: Email do vendedor (tipo: string, campo obrigatório).
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres.")]
        public string Email { get; set; } = null!;

        // Telefone: Telefone de contato do vendedor (tipo: string, campo obrigatório).
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O formato do telefone é inválido.")]
        public string Telefone { get; set; } = null!;

        // DataNascimento: Data de nascimento do vendedor (tipo: DateTime).
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "A data de nascimento deve ser entre 1900 e 2100.")]
        public DateTime DataNascimento { get; set; }

        // Endereco: Endereço do vendedor (tipo: string).
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public string? Endereco { get; set; }

        // DataContratacao: Data de contratação do vendedor (tipo: DateTime).
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "A data de nascimento deve ser entre 1900 e 2100.")]
        public DateTime DataContratacao { get; set; }

        // ComissaoPercentual: Percentual de comissão do vendedor (tipo: decimal).
        public Decimal ComissaoPercentual { get; set; }

        // MetaMensal: Meta mensal do vendedor (tipo: decimal).
        public Decimal MetaMensal { get; set; }

        // CriadoEm: Data de criação do registro (tipo: DateTime).
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "A data de nascimento deve ser entre 1900 e 2100.")]
        public DateTime CriadoEm { get; set; }

    }
}
