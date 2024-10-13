using System.ComponentModel.DataAnnotations;

namespace CP2.API.Application.Dtos
{
    public class FornecedorDto
    {   
        // Nome: Nome do fornecedor (tipo: string).
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Campo deve ter no minimo 5 caracteres")]
        public string Nome { get; set; } = string.Empty;
        
        // CNPJ: CNPJ do fornecedor (tipo: string, campo obrigatório).
        [Required(ErrorMessage = $"Campo {nameof(CNPJ)} é obrigatorio")]
        public string CNPJ { get; set; } = string.Empty;

        // Endereco: Endereço do fornecedor (tipo: string).
        public string? Endereco { get; set; }

        // Telefone: Telefone de contato do fornecedor (tipo: string, campo obrigatório).
        [Required(ErrorMessage = $"Campo {nameof(Telefone)} é obrigatorio")]
        [Phone(ErrorMessage = "O formato do telefone é inválido.")]
        public string? Telefone { get; set; }

        // Email: Email do fornecedor (tipo: string, campo obrigatório).
        [Required(ErrorMessage = $"Campo {nameof(Email)} é obrigatorio")]
        [EmailAddress(ErrorMessage = "O Email não é valido")]
        public string Email { get; set; } = string.Empty;

        // CriadoEm: Data de criação do registro (tipo: DateTime)
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-12-31", ErrorMessage = "A data de nascimento deve ser entre 1900 e 2100.")]
        public DateTime CriadoEm { get; set; }
    }
}
