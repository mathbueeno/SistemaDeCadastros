using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastros.Models
{
    public class ContatoModel
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string NomeContato { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        [EmailAddress(ErrorMessage ="Informe um E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Telefone")]
        [Phone(ErrorMessage ="Informe um número de Telefone válido")]
        public string Telefone { get; set; }
    }
}
