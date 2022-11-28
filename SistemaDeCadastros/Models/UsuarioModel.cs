using SistemaDeCadastros.Enums;

namespace SistemaDeCadastros.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public Perfil Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
