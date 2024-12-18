using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using WebRentaCar2.Models;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;

namespace WebRentaCar2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            CocheRepository cocheRepository = new CocheRepository();
            CocheCEN cocheCEN = new CocheCEN(cocheRepository);
            IList<CocheEN> listaCoches = cocheCEN.ObtenerCoches(0, -1);
            return View(listaCoches);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode == 404)
                {
                    ViewData["ErrorMessage"] = "La p�gina que est� buscando no existe.";
                }
                else
                {
                    ViewData["ErrorMessage"] = "Se ha producido un error al procesar su solicitud.";
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Se ha producido un error al procesar su solicitud.";
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
