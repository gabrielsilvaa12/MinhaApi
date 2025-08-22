
using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email do cliente é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF do cliente é um campo obrigatório")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 14 caracteres")]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "O telefone do cliente é um campo obrigatório")]
        [StringLength(14, MinimumLength =11,ErrorMessage = "O telefone deve ter no máximo 15 caracteres")]
        public string Telefone { get; set; } = string.Empty;

        public List<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
