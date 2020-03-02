using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universidad_ASP.Models;

namespace Universidad_ASP.Controllers
{
    public class UniversidadesController : Controller
    {
        public IActionResult IndexUniversidades()
        {
            return View();
        }

        public IActionResult AgregarUniversidad()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarUniversidad(DatosUniversidades datosUniversidades, UniversidadM universidadM)
        {
            var X = "Hola";
            if (ModelState.IsValid)
            {
                foreach (var data in datosUniversidades.Universidades)
                {
                    if (data.ID_Universidad == universidadM.ID_Universidad)
                    {
                        X = data.ID_Universidad;
                        break;
                    }
                }

                if (X != universidadM.ID_Universidad)
                {
                    datosUniversidades.Universidades.Add(universidadM);

                    return RedirectToAction("VerUniversidad", universidadM);
                }
                else
                {
                    ViewData["IDInValido"] = "Este ID ya existe!";
                }


            }
            return View(universidadM);
        }

        public IActionResult VerUniversidad(DatosUniversidades datosUniversidades)
        {

            return View(datosUniversidades);
        }

        public IActionResult ModificarUniversidad(UniversidadM universidad)
        {

            return View(universidad);
        }

        [HttpPost]
        public IActionResult ModificarUniversidad(DatosUniversidades datosUniversidades, UniversidadM universidad)
        {
            var PosicionSelect = Request.Form["posicion"];

            foreach (var data in datosUniversidades.Universidades)
            {

                if (data.ID_Universidad == PosicionSelect)
                {
                    ViewData["ID"] = data.ID_Universidad;
                    ViewData["Nombre"] = data.Nombre_Universidad;
                   

                    break;
                }
            }
            var ValorBotonEdit = Request.Form["Editar"];

            if (ValorBotonEdit == "0")
            {
                var IdUniversidad = universidad.ID_Universidad;
                return RedirectToAction("EditarUniversidad", new { UniversidadID = IdUniversidad });

            }

            var ValorBotonEliminar = Request.Form["Eliminar"];

            if (ValorBotonEliminar == "1")
            {
                var IdUniversidad = universidad.ID_Universidad;
                return RedirectToAction("EliminarUniversidad", new { UniversidadID = IdUniversidad });
            }
            return View(universidad);
        }



        public IActionResult EditarUniversidad(DatosUniversidades datosUniversidades, string UniversidadID)
        {
            foreach (var universidad1 in datosUniversidades.Universidades)
            {

                if (universidad1.ID_Universidad == UniversidadID)
                {
                    ViewData["ID"] = universidad1.ID_Universidad;
                    ViewData["Nombre"] = universidad1.Nombre_Universidad;
                    break;
                }
            }
            ViewBag.IDUniversidad = UniversidadID;

            return View();
        }

        [HttpPost]
        public IActionResult EditarUniversidad(string UniversidadID, DatosUniversidades datosUniversidades, UniversidadM universidad)
        {
            ViewBag.IDUniversidad = UniversidadID;

            if (ModelState.IsValid)
            {
                int Y = 0;
                foreach (var data in datosUniversidades.Universidades)
                {
                    if (data.ID_Universidad == UniversidadID)
                    {

                        break;
                    }
                    Y++;
                }
                datosUniversidades.Universidades.RemoveAt(Y);
                datosUniversidades.Universidades.Add(universidad);

                return RedirectToAction("ModificarUniversidad");
            }
            return View(universidad);

        }

        public IActionResult EliminarUniversidad(DatosUniversidades datosUniversidades, string UniversidadID)
        {
            foreach (var Universidad in datosUniversidades.Universidades)
            {

                if (Universidad.ID_Universidad == UniversidadID)
                {
                    ViewData["ID"] = Universidad.ID_Universidad;
                    ViewData["Nombre"] = Universidad.Nombre_Universidad;
                    
                    break;
                }
            }
            ViewBag.IDUniversidad = UniversidadID;
            return View(datosUniversidades);
        }
        [HttpPost]
        public IActionResult EliminarUniversidad(string UniversidadID)
        {
            DatosUniversidades datosUniversidades = new DatosUniversidades();
            int Y = 0;

            foreach (var Universidad in datosUniversidades.Universidades)
            {
                if (UniversidadID == Universidad.ID_Universidad)
                {

                    break;
                }
                Y++;
            }

            datosUniversidades.Universidades.RemoveAt(Y);
            return RedirectToAction("ModificarUniversidad");
        }

    }
}