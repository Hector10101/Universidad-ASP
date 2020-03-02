using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Universidad_ASP.Models;

namespace Universidad_ASP.Controllers
{
    public class AlumnosController : Controller
    {
        public IActionResult IndexAlumnos()
        {
            return View();
        }
        public IActionResult AgregarAlumno()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AgregarAlumno(DatosAlumnos datosAlumnos, AlumnosM alumnos)
        {
            var X = "Hola";
            if (ModelState.IsValid)
            {
                foreach (var data in datosAlumnos.Alumnos)
                {
                    if (data.Boleta_Alumno == alumnos.Boleta_Alumno)
                    {
                        X = data.Boleta_Alumno;
                        break;
                    }
                }

                if (X != alumnos.Boleta_Alumno)
                {
                    datosAlumnos.Alumnos.Add(alumnos);

                    return RedirectToAction("VerAlumnos", alumnos);
                }
                else
                {
                    ViewData["IDInValido"] = "Esta Boleta ya existe!";
                }


            }

            return View(alumnos);
        }

        public IActionResult VerAlumnos(DatosAlumnos datosAlumnos)
        {

            return View(datosAlumnos);
        }

        public IActionResult ModificarAlumno(AlumnosM alumnos)
        {


            return View(alumnos);
        }


        [HttpPost]
        public IActionResult ModificarAlumno(DatosAlumnos datosAlumnos, AlumnosM alumnos)
        {

            var PosicionSelect = Request.Form["posicion"];

            foreach (var data in datosAlumnos.Alumnos)
            {

                if (data.Boleta_Alumno == PosicionSelect)
                {
                    ViewData["ID"] = data.Boleta_Alumno;
                    ViewData["Nombre"] = data.Nombre_Alumno;
                    ViewData["Fecha_Nac"] = data.Fecha_Nacimiento;
                    ViewData["CURP"] = data.CURP_Alumno;
                    ViewData["ID_Maestria"] = data.ID_Maestria;

                    break;
                }
            }
            var ValorBotonEdit = Request.Form["Editar"];

            if (ValorBotonEdit == "0")
            {
                var IdAlumon = alumnos.Boleta_Alumno;
                return RedirectToAction("EditarAlumno", new { AlumnoID = IdAlumon });

            }
            var ValorBotonEliminar = Request.Form["Eliminar"];

            if (ValorBotonEliminar == "1")
            {
                var IdAlumon = alumnos.Boleta_Alumno;
                return RedirectToAction("EliminarAlumno", new { AlumnoID = IdAlumon });
            }

            return View(alumnos);
        }

        public IActionResult EditarAlumno(DatosAlumnos datosAlumnos, string AlumnoID)
        {
            foreach (var data in datosAlumnos.Alumnos)
            {

                if (data.Boleta_Alumno == AlumnoID)
                {
                    ViewData["ID"] = data.Boleta_Alumno;
                    ViewData["Nombre"] = data.Nombre_Alumno;
                    ViewData["Fecha_Nac"] = data.Fecha_Nacimiento;
                    ViewData["CURP"] = data.CURP_Alumno;
                    ViewData["ID_Maestria"] = data.ID_Maestria;
                    break;
                }
            }
            ViewBag.IDAlumno = AlumnoID;

            return View();
        }
        [HttpPost]
        public IActionResult EditarAlumno(string AlumnoID,DatosAlumnos datosAlumnos, AlumnosM alumnosM)
        {
            ViewBag.IDAlumno = AlumnoID;

            if (ModelState.IsValid)
            {
                int Y = 0;
                foreach (var data in datosAlumnos.Alumnos)
                {
                    if (data.Boleta_Alumno == AlumnoID)
                    {

                        break;
                    }
                    Y++;
                }
                datosAlumnos.Alumnos.RemoveAt(Y);
                datosAlumnos.Alumnos.Add(alumnosM);

                return RedirectToAction("ModificarAlumno");
            }
            return View(alumnosM);

        }
        public IActionResult EliminarAlumno(DatosAlumnos datosAlumnos, string AlumnoID)
        {
            foreach (var data in datosAlumnos.Alumnos)
            {

                if (data.Boleta_Alumno == AlumnoID)
                {
                    ViewData["ID"] = data.Boleta_Alumno;
                    ViewData["Nombre"] = data.Nombre_Alumno;
                    ViewData["Fecha_Nac"] = data.Fecha_Nacimiento;
                    ViewData["CURP"] = data.CURP_Alumno;
                    ViewData["ID_Maestria"] = data.ID_Maestria;
                    break;
                }
            }
            ViewBag.IDAlumno = AlumnoID;
            return View(datosAlumnos);
        }
        [HttpPost]
        public IActionResult EliminarAlumno(string AlumnoID)
        {
            DatosAlumnos datosAlumnos = new DatosAlumnos();
            
            int Y = 0;

            foreach (var data in datosAlumnos.Alumnos)
            {
                if (AlumnoID == data.Boleta_Alumno)
                {

                    break;
                }
                Y++;
            }

            datosAlumnos.Alumnos.RemoveAt(Y);
            return RedirectToAction("ModificarAlumno");
        }
    }
}