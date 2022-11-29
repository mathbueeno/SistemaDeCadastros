using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Data;
using SistemaDeCadastros.Helper;
using SistemaDeCadastros.Models;
using SistemaDeCadastros.Repositorios;

namespace SistemaDeCadastros.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

       
		public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
		{
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
		}

        public IActionResult Index()
        {
            // se o usuário estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }


        public IActionResult Sair()
		{
            _sessao.RemoverSessaoUsuario();
                return RedirectToAction("Index", "Login");
		}


        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
		{
			try
			{
				if (ModelState.IsValid)
				{
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null)
					{
						if (usuario.SenhaValida(loginModel.Senha))
						{
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");

                        }

                        TempData["MensagemErro"] = $"A senha do usuário é inválida. Por favor, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"A senha ou usuário estão inválidos. Por favor, tente novamente.";
                }

                return View("Index");

            }
            catch (Exception erro)
			{

                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
		}
    }
}
