using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Filters;
using SistemaDeCadastros.Models;
using SistemaDeCadastros.Repositorios;

namespace SistemaDeCadastros.Controllers
{
    [PaginaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }


        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        // recebe o id por parâmetro para editar
        public IActionResult EditarContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarContato(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }



        [HttpGet]
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não conseguimos apagar o seu contato!";
                }

                
                return RedirectToAction("Index");
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos apagar o seu contato, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("CriarContato", contato);
            } 
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar o seu contato, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = $"Contato editado com sucesso! ";
                    return RedirectToAction("Index");
                }

                return View("EditarContato", contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos editar o contato, tente novamente! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }
    }
}
