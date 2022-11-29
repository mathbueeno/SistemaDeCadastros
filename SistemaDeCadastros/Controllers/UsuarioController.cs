using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Filters;
using SistemaDeCadastros.Models;
using SistemaDeCadastros.Repositorios;

namespace SistemaDeCadastros.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        // MÉTODOS


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("CriarContato", usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar o seu usuário, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não conseguimos apagar o seu usuário!";
                }


                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o seu usuário, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };

                   usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = $"Usuário editado com sucesso! ";
                    return RedirectToAction("Index");
                }

                return View("EditarUsuario", usuarioSemSenhaModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos editar o seu usuário, tente novamente! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }


    }


   



}
