﻿using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
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
    public class CocheController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly ICocheRepository _cocheRepository;
        private readonly IValoracionRepository _valoracionRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMarcaRepository _marcaRepository;

        public CocheController(IWebHostEnvironment webHost, ICocheRepository cocheRepository, IValoracionRepository valoracionRepository, IUsuarioRepository usuarioRepository, IMarcaRepository marcaRepository)
        {
            _webHost = webHost;
            _cocheRepository = cocheRepository;
            _valoracionRepository = valoracionRepository;
            _usuarioRepository = usuarioRepository;
            _marcaRepository = marcaRepository;
        }

        // GET: CocheController
        public ActionResult Index(string query)
        {
            SessionInitialize();
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            IList<CocheEN> listEN = cocheCEN.ObtenerCoches(0, -1);
            if (string.IsNullOrEmpty(query)) {

                listEN = cocheCEN.ObtenerCoches(0, -1);

            }
            else
            {
                listEN = listEN.Where(c => c.Matricula.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            c.Propietario.Correo.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            IEnumerable<CocheViewModel> listArts = new CocheAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listArts);
        }

        [HttpGet]
        public ActionResult Buscar(string query)
        {
            SessionInitialize();
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            IList<CocheEN> listEN = cocheCEN.ObtenerCoches(0, -1)
                .Where(c => c.Matricula.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            c.Propietario.Correo.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            IEnumerable<CocheViewModel> listArts = new CocheAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View("ResultadosBusqueda", listArts);
        }

        // GET: CocheController/Details/5
        public ActionResult Details(int id)
        {
            // Validar el ID
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un número positivo.");
            }

            // Iniciar la sesión
            SessionInitialize();

            // Crear CENs para manejar los datos
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);
            ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);

            // Obtener el coche por ID
            CocheEN cocheEN = _cocheRepository.ObtenCocheId(id);
            if (cocheEN == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Coche no encontrado.");
            }

            // Obtener y asignar las valoraciones
            IList<ValoracionEN> valoracionEN = valoracionCEN.ValoracionesCocheId(id) ?? new List<ValoracionEN>();
            foreach (var valoracion in valoracionEN)
            {
                var usuario = valoracion.Usuario; // Inicializa UsuarioEN
            }
            cocheEN.Valoracion = valoracionEN;

            UsuarioCEN usuarioCEN = new UsuarioCEN(_usuarioRepository);

            // Convertir el coche a ViewModel
            CocheViewModel cocheView = new CocheAssembler().ConvertirENToViewModel(cocheEN);

            var propietario = usuarioCEN.ObtenUsuarioId(cocheView.Propietario);
            string propietarioCorreo = propietario?.Correo ?? "Correo no disponible";
            int? propietarioTelefono = propietario?.Telefono;
            IList<ValoracionEN> valoracionENUsuario = valoracionCEN.ValoracionesUsuarioId(cocheView.Propietario) ?? new List<ValoracionEN>();

            ViewBag.PropietarioCorreo = propietarioCorreo;
            ViewBag.PropietarioTelefono = propietarioTelefono;
            ViewBag.Valoraciones = valoracionENUsuario;
            ViewBag.IdPropietario = propietario?.IdUsuario;



            MarcaCEN marcaCEN = new MarcaCEN(_marcaRepository);

            var marca = _marcaRepository.ReadOIDDefault(cocheView.Marca);
            string marcaNombre = marca?.Nombre ?? "Marca no disponible";

            ViewBag.MarcaNombre = marcaNombre;

            // Asignar el nombre del tipo del coche al ViewBag
            ViewBag.TipoNombre = cocheView.Tipo.ToString();

            // Cerrar la sesión
            SessionClose();

            // Devolver la vista con el modelo
            return View(cocheView);
        }






        // GET: ArticuloController/Create
        public ActionResult CreateConTipo()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync(int id, CocheViewModel coche)
        {
            string fileName = "", path = "";
            if (coche.Imagen != null && coche.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(coche.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await coche.Imagen.CopyToAsync(stream);
                }
            }
            try
            {
                fileName = "/Images/" + fileName;
                CocheCEN cocheCEN = new CocheCEN(_cocheRepository);
                cocheCEN.NuevoCoche(coche.Matricula, fileName, coche.Precio, coche.Plazas, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum)coche.Tipo, coche.Descripcion, id, coche.Marca);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            CocheEN cocheEN = cocheCEN.ObtenCocheId(id);
            CocheViewModel cocheView = new CocheAssembler().ConvertirENToViewModel(cocheEN);

            SessionClose();
            return View(cocheView);
        }

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CocheViewModel coche)
        {
            try
            {
                CocheCEN cocheCEN = new CocheCEN(_cocheRepository);
                cocheCEN.Modificar(id, coche.Matricula, coche.ImagenUrl, coche.Precio, coche.Plazas, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum)coche.Tipo, coche.Descripcion, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum)coche.Disponible, coche.valoracion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: ArticuloController/Delete/5
        public ActionResult Delete(int id)
        {
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);
            cocheCEN.EliminarCoche(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ArticuloController/Delete/5
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
