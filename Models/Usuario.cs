using System.ComponentModel.DataAnnotations;

namespace MinhaAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do Usuario é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do Usuario deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sobrenome do Usuario é obrigatório.")]
        [StringLength(100, ErrorMessage = "O sobrenome do Usuario deve ter no máximo 100 caracteres.")]
        public string Sobrenome { get; set; } = string.Empty;


        [Required(ErrorMessage = "O email do Usuario é obrigatório.")]
        [StringLength(50, ErrorMessage = "O email do Usuario deve ter no máximo 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O senha do Usuario é obrigatório.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "O senha do Usuario deve ter no máximo 100 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}
