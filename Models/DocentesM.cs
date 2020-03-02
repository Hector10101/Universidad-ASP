using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad_ASP.Models
{
    public class DocentesM
    {
        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Docente { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Nombre_Docente{ get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Universidad { get; set; }
    }
    public class DatosDocentes
    {
        private static List<DocentesM> Docente;

        public List<DocentesM> Docentes
        {
            get
            {
                if (Docente == null)
                {
                    Docente = new List<DocentesM>();
                }
                return Docente;
            }
        }
    }
}
