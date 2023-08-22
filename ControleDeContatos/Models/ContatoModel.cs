using System.ComponentModel.DataAnnotations;  

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")] 
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "Número de celular inválido")]
        public string Celular { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
