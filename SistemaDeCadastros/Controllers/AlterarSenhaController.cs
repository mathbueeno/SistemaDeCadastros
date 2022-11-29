using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Helper;
using SistemaDeCadastros.Models;
using SistemaDeCadastros.Repositorios;

namespace SistemaDeCadastros.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                UsuarioModel usuario = _sessao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuario.Id;

                if (ModelState.IsValid)
                {
                    
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos alterar sua senha, tente novamente! Detalhe do erro: {erro.Message}";
                return View("Index", alterarSenhaModel);
            }
        }
    }
}
