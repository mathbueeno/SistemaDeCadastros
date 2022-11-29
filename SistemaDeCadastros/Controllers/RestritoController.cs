using Microsoft.AspNetCore.Mvc;
using SistemaDeCadastros.Filters;

namespace SistemaDeCadastros.Controllers
{
    [PaginaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
