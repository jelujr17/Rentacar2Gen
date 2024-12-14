using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebRentaCar2.Assemblers;
using WebRentaCar2.Models;
using Rentacar2Gen.ApplicationCore.IRepository.RentaCar2;
using System.Runtime.Intrinsics.X86;

namespace WebRentaCar2.Controllers
{
    public class ValoracionController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IValoracionRepository _valoracionRepository;

        public ValoracionController(IWebHostEnvironment webHost, IValoracionRepository valoracionRepository)
        {
            _webHost = webHost;
            _valoracionRepository = valoracionRepository;
        }

        // GET: ValoracionController
        public ActionResult Index()
        {
            SessionInitialize();
            ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);

            IList<ValoracionEN> listEN = valoracionCEN.ObtenerValoraciones(0, -1);

            IEnumerable<ValoracionViewModel> listValoraciones = new ValoracionAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listValoraciones);
        }

        // GET: Valoracion/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ValoracionCEN ValoracionCEN = new ValoracionCEN(_valoracionRepository);

            ValoracionEN valoracionEN = ValoracionCEN.ObtenValoracionId(id);
            ValoracionViewModel? valoracionView = null;
            if (valoracionEN != null)
                valoracionView = new ValoracionAssembler().ConvertirENToViewModel(valoracionEN);

            SessionClose();
            return View(valoracionView);
        }

        // GET: ArticuloController/Create
        

        [HttpPost]
        [HttpPost]
        public IActionResult Create(ValoracionViewModel model)
        {
            try
            {
                SessionInitialize();

               
                    ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);

                    ValoracionEN valoracionEN = new ValoracionEN
                    {
                        Comentario = model.Comentario,
                        Valoracion = model.Valoracion,
                        TipoValoracion = (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum)model.Tipo,
                        IdDestinatario = model.IdDestinatario,
                        Usuario = model.Usuario
                    };

                    // Crear nueva valoración
                    int aux = valoracionCEN.NuevaValoracion(
                        valoracionEN.Comentario,
                        valoracionEN.Valoracion,
                        valoracionEN.TipoValoracion,
                        valoracionEN.Usuario,
                        valoracionEN.IdDestinatario);

                    // Redirigir a los detalles del destinatario
                    return RedirectToAction("Details", "Coche", new { id = model.IdDestinatario });
                

            }

            finally
            {
                // Asegurarse de cerrar la sesión
                SessionClose();
            }
        }





        // GET: ValoracionCOntroller/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ValoracionCEN ValoracionCEN = new ValoracionCEN(_valoracionRepository);

            ValoracionEN valoracionEN = ValoracionCEN.ObtenValoracionId(id);
            ValoracionViewModel valoracionView = new ValoracionAssembler().ConvertirENToViewModel(valoracionEN);

            SessionClose();
            return View(valoracionView);
        }

        // POST: ValoracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ValoracionViewModel valoracion)
        {
            try
            {
                ValoracionCEN ValoracionCEN = new ValoracionCEN(_valoracionRepository);
                ValoracionCEN.Modificar(id, valoracion.Comentario, valoracion.Valoracion, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum)valoracion.Tipo, valoracion.IdDestinatario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ValoracionController/Delete/5
        public ActionResult Delete(int id)
        {
            ValoracionCEN ValoracionCEN = new ValoracionCEN(_valoracionRepository);
            ValoracionCEN.EliminarValoracion(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ValoracionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
