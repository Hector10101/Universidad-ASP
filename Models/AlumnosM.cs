using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad_ASP.Models
{
    public class AlumnosM
    {
        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Boleta_Alumno { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Nombre_Alumno { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string CURP_Alumno { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Maestria{ get; set; }
    }

    public class DatosAlumnos
    {
        private static List<AlumnosM> Alumno;

        public List<AlumnosM> Alumnos
        {
            get
            {
                if (Alumno == null)
                {
                    Alumno = new List<AlumnosM>();
                }
                return Alumno;
            }
        }
    }
}
