using SistemaDeCadastros.Enums;
using SistemaDeCadastros.Helper;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeCadastros.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do usuário")]
        [EmailAddress(ErrorMessage = "Informe um E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Escolha o perfil do usuário")]
        public Perfil? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
		{
            return Senha == senha.GerarHash();
		}

        // método de extensão
        public void SenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
