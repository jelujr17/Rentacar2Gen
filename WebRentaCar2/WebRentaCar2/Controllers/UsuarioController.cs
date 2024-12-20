﻿using Rentacar2Gen.ApplicationCore.CEN.RentaCar2;
using Rentacar2Gen.ApplicationCore.EN.RentaCar2;
using Rentacar2Gen.Infraestructure.Repository.RentaCar2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebRentaCar2.Assemblers;
using WebRentaCar2.Models;
using System.Diagnostics;

namespace WebRentaCar2.Controllers
{
    public class UsuarioController : BasicController
    {
        public class FavoritoRequest
        {
            public int usuarioId { get; set; }
            public int cocheId { get; set; }
        }

        // GET: UsuarioController/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: UsuarioController/Login
        [HttpPost]
        public ActionResult Login(LoginUsuarioViewModel login)
        {
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

            if (usuCEN.Login(login.Correo, login.Password) == null)
            {
                ModelState.AddModelError("", "Error al introducir los datos del correo o password");
                return View();
            }
            else
            {
                SessionInitialize();
                UsuarioEN usuEN = usuCEN.GetByCorreo(login.Correo);
                UsuarioViewModel usuVM = new UsuarioAssembler().ConvertirENToViewModel(usuEN);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuVM);
                SessionClose();
                return RedirectToAction("Index", "Coche");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Coche");
        }
        public IActionResult Error()
        {
            ViewData["ErrorMessage"] = "Debe iniciar sesión para acceder a esta página.";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Perfil()
        {
            var usuario = HttpContext.Session.Get<UsuarioViewModel>("usuario");
            if (usuario == null)
            {
                return RedirectToAction("Error", "Usuario");
            }

            SessionInitialize();
            UsuarioRepository usuRepo = new UsuarioRepository();
            UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
            var usuarioEN = usuCEN.GetByCorreo(usuario.Correo);

            if (usuarioEN != null)
            {
                CocheRepository cocheRepo = new CocheRepository();
                CocheCEN cocheCEN = new CocheCEN(cocheRepo);
                var cochesUsuario = cocheCEN.ObtenerCoches(0, -1)
                                            .Where(coche => coche.Propietario.IdUsuario == usuarioEN.IdUsuario)
                                            .ToList();

                ViewData["CochesUsuario"] = cochesUsuario;
            }

            SessionClose();
            return View(usuario);
        }


        [HttpPost]
        public IActionResult AddFavorito([FromBody] FavoritoRequest request)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
                usuCEN.AddFavorito(request.usuarioId, request.cocheId);

                // Recargar datos del usuario
                UsuarioEN usuario = usuCEN.ObtenUsuarioId(request.usuarioId);
                UsuarioViewModel usuarioVM = new UsuarioAssembler().ConvertirENToViewModel(usuario);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioVM);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message + " Añadir favoritos" });
            }
        }

        [HttpPost]
        public IActionResult EliminarFavorito([FromBody] FavoritoRequest request)
        {
            try
            {
                UsuarioRepository usuRepo = new UsuarioRepository();
                UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);
                usuCEN.EliminarFavorito(request.usuarioId, request.cocheId);

                // Recargar datos del usuario
                UsuarioEN usuario = usuCEN.ObtenUsuarioId(request.usuarioId);
                UsuarioViewModel usuarioVM = new UsuarioAssembler().ConvertirENToViewModel(usuario);
                HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioVM);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message + " Quitar favoritos" });
            }
        }

        // GET: UsuarioController/Create
        public ActionResult Registro()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioRepository usuRepo = new UsuarioRepository();
                    UsuarioCEN usuCEN = new UsuarioCEN(usuRepo);

                    // Crear el nuevo usuario
                    usuCEN.NuevoUsuario(model.Correo, model.Password, "foto1", model.FechaNacimiento, model.Telefono, model.Direccion, "favoritos1");

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el usuario: " + ex.Message);
                }
            }
            return View(model);
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
