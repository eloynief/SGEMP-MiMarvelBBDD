using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MiMarvelBBDD.Models;
using System.Diagnostics;

namespace MiMarvelBBDD.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {









            return View();
        }




        public IActionResult PuntuarCombate()
        {
            ViewBag.Personajes = ClaseBL.listaPersonajesAzureBL();
            return View();
        }

        [HttpPost]
        public IActionResult PuntuarCombate(int idPersonaje1, int idPersonaje2, int puntuacion1, int puntuacion2)
        {
            if (idPersonaje1 == idPersonaje2)
            {
                ModelState.AddModelError("", "Un personaje no puede luchar contra sí mismo.");
                ViewBag.Personajes = ClaseBL.listaPersonajesAzureBL();
                return View();
            }

            var nuevoCombate = new claseCombate
            {
                Fecha = DateTime.Now,
                IdPersonaje1 = idPersonaje1,
                IdPersonaje2 = idPersonaje2,
                Puntuacion1 = puntuacion1,
                Puntuacion2 = puntuacion2
            };

            ClaseBL.PuntuarCombate(nuevoCombate);

            return RedirectToAction("Index");
        }

        public IActionResult Clasificacion()
        {
            var clasificaciones = ClaseBL.ObtenerTablaClasificacionesBL();
            return View(clasificaciones);
        }

        [HttpPost]
        public IActionResult EliminarCombate(int idPer1,int idPer2)
        {
            try
            {
                ClaseHandlerBL.EliminarCombate(idPer1, idPer2);
                return RedirectToAction("Clasificacion");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al eliminar el combate: {ex.Message}");
                return View("Error");
            }
        }


    }
}