using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universidad_ASP.Models;

namespace Universidad_ASP.Controllers
{
    public class DocentesController : Controller
    {
        public IActionResult IndexDocentes()
        {
            return View();
        }
        public IActionResult AgregarDocente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarDocente(DatosDocentes datosDocentes, DocentesM docentes)
        {
            var X = "Hola";
            if (ModelState.IsValid)
            {
                foreach (var DataDocente in datosDocentes.Docentes)
                {
                    if (DataDocente.ID_Docente == docentes.ID_Docente)
                    {
                        X = DataDocente.ID_Docente;
                        break;
                    }
                }

                if (X != docentes.ID_Docente)
                {
                    datosDocentes.Docentes.Add(docentes);

                    return RedirectToAction("VerDocentes", docentes);
                }
                else
                {
                    ViewData["IDInValido"] = "Este ID ya existe!";
                }


            }

            return View(docentes);
        }

        public IActionResult VerDocentes(DatosDocentes datosDocentes)
        {
            return View(datosDocentes);
        }

        public IActionResult ModificarDocente(DocentesM docentes)
        {


            return View(docentes);
        }

        [HttpPost]
        public IActionResult ModificarDocente(DatosDocentes datosDocentes, DocentesM  docentes)
        {

            var PosicionSelect = Request.Form["posicion"];

            foreach (var data in datosDocentes.Docentes)
            {

                if (data.ID_Docente == PosicionSelect)
                {
                    ViewData["ID"] = data.ID_Docente;
                    ViewData["Nombre"] = data.Nombre_Docente;
                    ViewData["Telefono"] = data.Telefono;
                    ViewData["ID_Uni"] = data.ID_Universidad;


                    break;
                }
            }
            var ValorBotonEdit = Request.Form["Editar"];

            if (ValorBotonEdit == "0")
            {
                var IdDocente = docentes.ID_Docente;
                return RedirectToAction("EditarDocente", new { DocenteID = IdDocente });

            }
            var ValorBotonEliminar = Request.Form["Eliminar"];

            if (ValorBotonEliminar == "1")
            {
                var IdDocente = docentes.ID_Docente;
                return RedirectToAction("EliminarDocente", new { DocenteID = IdDocente });
            }

            return View(docentes);
        }

        public IActionResult EditarDocente(DatosDocentes datosDocentes, string DocenteID)
        {
            foreach (var docente in datosDocentes.Docentes)
            {

                if (docente.ID_Docente == DocenteID)
                {
                    ViewData["ID"] = docente.ID_Docente;
                    ViewData["Nombre"] = docente.Nombre_Docente;
                    ViewData["Telefono"] = docente.Telefono;
                    ViewData["ID_Uni"] = docente.ID_Universidad;

                    break;
                }
            }
            ViewBag.IDDocente = DocenteID;

            return View();
        }

        [HttpPost]
        public IActionResult EditarDocente(string DocenteID, DatosDocentes datosDocentes, DocentesM docentesM)
        {
            ViewBag.IDDocente = DocenteID;

            if (ModelState.IsValid)
            {
                int Y = 0;
                foreach (var docente in datosDocentes.Docentes)
                {
                    if (docente.ID_Docente == DocenteID)
                    {

                        break;
                    }
                    Y++;
                }
                datosDocentes.Docentes.RemoveAt(Y);
                datosDocentes.Docentes.Add(docentesM);

                return RedirectToAction("ModificarDocente");
            }
            return View(docentesM);

        }

        public IActionResult EliminarDocente(DatosDocentes datosDocentes, string DocenteID)
        {
            foreach (var docente in datosDocentes.Docentes)
            {

                if (docente.ID_Docente == DocenteID)
                {
                    ViewData["ID"] = docente.ID_Docente;
                    ViewData["Nombre"] = docente.Nombre_Docente;
                    ViewData["Telefono"] = docente.Telefono;
                    ViewData["ID_Uni"] = docente.ID_Universidad;
                    break;
                }
            }
            ViewBag.IDDocente = DocenteID;
            return View(datosDocentes);
        }
        [HttpPost]
        public IActionResult EliminarDocente(string DocenteID)
        {
            DatosDocentes datosDocentes = new DatosDocentes();
            int Y = 0;

            foreach (var docente in datosDocentes.Docentes)
            {
                if (DocenteID == docente.ID_Docente)
                {

                    break;
                }
                Y++;
            }

            datosDocentes.Docentes.RemoveAt(Y);
            return RedirectToAction("ModificarDocente");
        }
    }
}