using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Models
{
    public class Endereco
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O logradouro é um campo obrigatório")]
        [StringLength(200, ErrorMessage = "O logradouro deve ter no máximo 200 caracteres")]
        public string Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "O bairro deve ter no máximo 100 caracteres")]
        public string Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "A cidade deve ter no máximo 100 caracteres")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "O estado deve ter no máximo 50 caracteres")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é um campo obrigatório")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "O CEP deve ter entre 8 e 9 caracteres")]
        public string CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número é um campo obrigatório")]
        [StringLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres")]
        public string Numero { get; set; } = string.Empty;


        public string? Complemento { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore]
        public Cliente? Cliente { get; set; } // Navegação para o cliente associado
    }
}
