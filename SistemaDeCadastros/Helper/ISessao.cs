using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Helper
{
	public interface ISessao
	{
		void CriarSessaoUsuario(UsuarioModel usuario);
		void RemoverSessaoUsuario();
		UsuarioModel BuscarSessaoUsuario();

	}
}
