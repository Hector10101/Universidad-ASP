using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universidad_ASP.Models;

namespace Universidad_ASP.Controllers
{
    public class MaestriasController : Controller
    {
        public IActionResult IndexMaestrias()
        {
            return View();
        }

        public IActionResult AgregarMaestria()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarMaestria(DatosMaestrias datosMaestrias, MaestriaM maestria)
        {
            var X = "Hola";
            if (ModelState.IsValid)
            {
                foreach (var data in datosMaestrias.Maestrias)
                {
                    if (data.ID_Maestria == maestria.ID_Maestria) 
                    {
                        X = data.ID_Maestria;
                        break;
                    }
                }

                if (X != maestria.ID_Maestria)
                {
                    datosMaestrias.Maestrias.Add(maestria);

                    return RedirectToAction("VerMaestrias", maestria);
                }
                else
                {
                    ViewData["IDInValido"] = "Este ID ya existe!";
                }


            }

            return View(maestria);
        }


        public IActionResult VerMaestrias(DatosMaestrias datosMaestrias)
        {

            return View(datosMaestrias);
        }

        public IActionResult ModificarMaestria(MaestriaM maestria)
        {


            return View(maestria);
        }

        [HttpPost]
        public IActionResult ModificarMaestria(DatosMaestrias datosMaestrias,MaestriaM  maestria)
        {

            var PosicionSelect = Request.Form["posicion"];

            foreach (var data in datosMaestrias.Maestrias)
            {

                if (data.ID_Maestria == PosicionSelect)
                {
                    ViewData["ID"] = data.ID_Maestria;
                    ViewData["Nombre"] = data.Nombre_Maestria;
                    ViewData["Duracion"] = data.Duracion;
                    ViewData["ID_Docente"] = data.ID_Docente;

                    break;
                }
            }
            var ValorBotonEdit = Request.Form["Editar"];

            if (ValorBotonEdit == "0")
            {
                var IdMaestria = maestria.ID_Maestria;
                return RedirectToAction("EditarMaestria", new { MaestriaID = IdMaestria });

            }
            var ValorBotonEliminar = Request.Form["Eliminar"];

            if (ValorBotonEliminar == "1")
            {
                var IdMaestria = maestria.ID_Maestria;
                return RedirectToAction("EliminarMaestria", new { MaestriaID = IdMaestria });
            }

            return View(maestria);
        }


        public IActionResult EditarMaestria(DatosMaestrias datosMaestrias, string MaestriaID)
        {
            foreach (var data in datosMaestrias.Maestrias)
            {

                if (data.ID_Maestria == MaestriaID)
                {
                    ViewData["ID"] = data.ID_Maestria;
                    ViewData["Nombre"] = data.Nombre_Maestria;
                    ViewData["Duracion"] = data.Duracion;
                    ViewData["ID_Docente"] = data.ID_Docente;
                    break;
                }
            }
            ViewBag.IDMaestria = MaestriaID;

            return View();
        }
        [HttpPost]
        public IActionResult EditarMaestria(string MaestriaID, DatosMaestrias datosMaestrias, MaestriaM maestria)
        {
            ViewBag.IDMaestria = MaestriaID;

            if (ModelState.IsValid)
            {
                int Y = 0;
                foreach (var data in datosMaestrias.Maestrias)
                {
                    if (data.ID_Maestria == MaestriaID)
                    {

                        break;
                    }
                    Y++;
                }
                datosMaestrias.Maestrias.RemoveAt(Y);
                datosMaestrias.Maestrias.Add(maestria);

                return RedirectToAction("ModificarMaestria");
            }
            return View(maestria);

        }
        public IActionResult EliminarMaestria(DatosMaestrias datosMaestrias, string MaestriaID)
        {
            foreach (var data in datosMaestrias.Maestrias)
            {

                if (data.ID_Maestria == MaestriaID)
                {
                    ViewData["ID"] = data.ID_Maestria;
                    ViewData["Nombre"] = data.Nombre_Maestria;
                    ViewData["Duracion"] = data.Duracion;
                    ViewData["ID_Docente"] = data.ID_Docente;

                    break;
                }
            }
            ViewBag.IDMaestria = MaestriaID;
            return View(datosMaestrias);
        }

        [HttpPost]
        public IActionResult EliminarMaestria(string MaestriaID)
        {
            DatosMaestrias datosMaestrias = new DatosMaestrias();
            int Y = 0;

            foreach (var maestria in datosMaestrias.Maestrias)
            {
                if (MaestriaID == maestria.ID_Maestria)
                {

                    break;
                }
                Y++;
            }

            datosMaestrias.Maestrias.RemoveAt(Y);
            return RedirectToAction("ModificarMaestria");
        }
    }
}