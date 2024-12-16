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


namespace WebRentaCar2.Controllers
{
    public class ValoracionController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IValoracionRepository _valoracionRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ValoracionController(IWebHostEnvironment webHost, IValoracionRepository valoracionRepository, IUsuarioRepository usuarioRepository)
        {
            _webHost = webHost;
            _valoracionRepository = valoracionRepository;
            _usuarioRepository = usuarioRepository;
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
        public async Task<ActionResult> Details(int id)
        {
            SessionInitialize();
            ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);

            ValoracionEN valoracionEN = valoracionCEN.ObtenValoracionId(id);
            ValoracionViewModel? valoracionView = null;
            if (valoracionEN != null)
            {
                if (valoracionEN.Usuario == null)
                {
                    // Log or handle the case where Usuario is null
                    Console.WriteLine("Usuario is null");
                    return RedirectToAction("Index", "Coche");

                }
                valoracionView = new ValoracionAssembler().ConvertirENToViewModel(valoracionEN);
            }

            SessionClose();
            return View(valoracionView);
        }

        // GET: ArticuloController/Create


        [HttpPost]
        public IActionResult Create(ValoracionViewModel model)
        {
            if (model == null)
            {
                // Si el modelo es nulo, retorna una vista de error
                return BadRequest("El modelo de valoración es nulo.");
            }

            try
            {
                SessionInitialize();

                var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                UsuarioEN user = _usuarioRepository.GetByCorreo(usuario.Correo);
                model.IdValoracion = 0;
                // Validar que el modelo esté correctamente completado
                
               
               


                // Crear la entidad ValoracionEN a partir del modelo
                ValoracionEN valoracionEN = new ValoracionEN
                {
                    Comentario = model.Comentario,
                    Valoracion = model.Valoracion,
                    TipoValoracion = (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum)model.Tipo,
                    IdDestinatario = model.IdDestinatario,
                    Usuario = user
                };

                // Instanciar la clase de CEN (lógica de negocio)
                ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);

                // Crear nueva valoración y obtener el id de la valoración creada
                int valoracionId = valoracionCEN.NuevaValoracion(valoracionEN.Comentario, valoracionEN.Valoracion, Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoValoracionEnum.coche, valoracionEN.Usuario, valoracionEN.IdDestinatario);

                // Almacenar el mensaje de éxito en TempData
                TempData["VerificationMessage"] = "Valoración creada con éxito.";

                // Redirigir al detalle del coche relacionado con la valoración
                return RedirectToAction("Details", "Coche", new { id = model.IdDestinatario });
            }
            catch (Exception ex)
            {
                // Almacenar el mensaje de error en TempData
                TempData["ErrorMessage"] = "Hubo un problema al crear la valoración. Por favor, inténtalo de nuevo. Detalles del error:  "+ex.Message;

                // Retornar a la página de detalle del coche (o cualquier otra página de tu preferencia)
                return RedirectToAction("Details", "Coche", new { id = TempData["ErrorMessage"] });
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
