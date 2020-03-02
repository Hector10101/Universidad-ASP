using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad_ASP.Models
{
    public class UniversidadM
    {
        [Required (ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Universidad { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Nombre_Universidad { get; set; }

       
    }
    public class DatosUniversidades
    {
        private static List<UniversidadM> Universidad;

        public List<UniversidadM> Universidades
        {
            get
            {
                if (Universidad == null)
                {
                    Universidad = new List<UniversidadM>();
                }
                return Universidad;
            }
        }
    }
}
