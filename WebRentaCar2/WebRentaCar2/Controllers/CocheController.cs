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
    public class CocheController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly ICocheRepository _cocheRepository;

        public CocheController(IWebHostEnvironment webHost, ICocheRepository cocheRepository)
        {
            _webHost = webHost;
            _cocheRepository = cocheRepository;
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
            SessionInitialize();
            CocheCEN cocheCEN = new CocheCEN(_cocheRepository);

            CocheEN cocheEN = cocheCEN.ObtenCocheId(id);
            CocheViewModel? cocheView = null;
            if (cocheEN != null)
                cocheView = new CocheAssembler().ConvertirENToViewModel(cocheEN);

            SessionClose();
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
                cocheCEN.Modificar(id, coche.Matricula, coche.ImagenUrl, coche.Precio, coche.Plazas, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.TipoEnum)coche.Tipo, coche.Descripcion, (Rentacar2Gen.ApplicationCore.Enumerated.RentaCar2.EstadoEnum)coche.Disponible);
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

        public void CalcularValoracionMedia(CocheViewModel coche)
        {
            if (coche.Valoraciones != null && Valoraciones.Count > 0)
            {
                valoracion = (int)Valoraciones.Average();
            }
            else
            {
                valoracion = 0; // O cualquier valor por defecto que consideres apropiado
            }
        }
    }
}
