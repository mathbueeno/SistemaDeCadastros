using Newtonsoft.Json;
using SistemaDeCadastros.Models;

namespace SistemaDeCadastros.Helper
{
	public class Sessao : ISessao
	{
		private readonly IHttpContextAccessor _contextAccessor;

		public Sessao(IHttpContextAccessor httpContextAccessor)
		{
			_contextAccessor = httpContextAccessor;
		}
		public UsuarioModel BuscarSessaoUsuario()
		{
			string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

			if (string.IsNullOrEmpty(sessaoUsuario)) return null;

			return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

		}
													// objeto
		public void CriarSessaoUsuario(UsuarioModel usuario)
		{
			string valor = JsonConvert.SerializeObject(usuario);

			_contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
		}

		public void RemoverSessaoUsuario()
		{
			_contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
		}
	}
}
