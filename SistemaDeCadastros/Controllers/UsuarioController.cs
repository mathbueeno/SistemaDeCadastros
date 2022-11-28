using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Repositorios;

namespace SistemaDeCadastros.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio contatoRepositorio)
        {
            _usuarioRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
