using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using WebRentaCar2.Models;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;

namespace WebRentaCar2.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger) {
			_logger = logger;
		}

		public IActionResult Index() {
			CocheRepository cocheRepository = new CocheRepository();
			CocheCEN cocheCEN = new CocheCEN(cocheRepository);
			IList<CocheEN> listaCoches = cocheCEN.ObtenerCoches(0, -1);
			return View(listaCoches);
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
