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

        public CocheController(IWebHostEnvironment webHost, ICocheRepository cocheRepository, IValoracionRepository valoracionRepository, IUsuarioRepository usuarioRepository)
        {
            _webHost = webHost;
            _cocheRepository = cocheRepository;
            _valoracionRepository = valoracionRepository;
            _usuarioRepository = usuarioRepository;
        }

        // GET: CocheController
        public ActionResult Index()
        {
            SessionInitialize();
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            IList<CocheEN> listEN = cocheCEN.ObtenerCoches(0, -1);

            IEnumerable<CocheViewModel> listArts = new CocheAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listArts);
        }

        // GET: CocheController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("El ID debe ser un número positivo.");
            }

            try
            {
                // Comprobar si el usuario está en la sesión
                var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
                if (usuario == null)
                {
                    return Unauthorized("Usuario no autenticado.");
                }

                SessionInitialize();
                CocheCEN cocheCEN = new CocheCEN(_cocheRepository);
                ValoracionCEN valoracionCEN = new ValoracionCEN(_valoracionRepository);
                UsuarioCEN usuarioCEN = new UsuarioCEN(_usuarioRepository);

                // Obtener el coche por ID
                CocheEN cocheEN = _cocheRepository.ReadOIDDefault(id);
                if (cocheEN == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Coche no encontrado.");
                }
                IList<ValoracionEN> valoracionEN = valoracionCEN.ValoracionesCocheId(id) ?? new List<ValoracionEN>();
                cocheEN.Valoracion = valoracionEN;

                // Convertir el coche a ViewModel
                CocheViewModel cocheView = new CocheAssembler().ConvertirENToViewModel(cocheEN);

                return View(cocheView);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("El ID proporcionado no es válido.");
            }
            catch (Exception ex)
            {
                // Podrías registrar el error aquí
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor");
            }
            finally
            {
                SessionClose();
            }
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
