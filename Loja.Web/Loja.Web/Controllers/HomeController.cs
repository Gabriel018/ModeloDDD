using Loja.Data.Repositories;
using Loja.Data.Repositories.IRepository;
using Loja.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Loja.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClienteRepository _clienterepository;

        public HomeController(ILogger<HomeController> logger, IClienteRepository cliente)
        {
            _logger = logger;
            _clienterepository = cliente;
        }

        public async Task<IActionResult> Index()
        {
            var cliente = await _clienterepository.ObterTodos();

            return View(cliente);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
