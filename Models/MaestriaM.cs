using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universidad_ASP.Models
{
    public class MaestriaM
    {
        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Maestria { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Nombre_Maestria { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string Duracion { get; set; }

        [Required(ErrorMessage = "¡Este Campo debe ser completado!")]
        public string ID_Docente { get; set; }

    }
    public class DatosMaestrias
    {
        private static List<MaestriaM> Maestria;

        public List<MaestriaM> Maestrias
        {
            get
            {
                if (Maestria == null)
                {
                    Maestria = new List<MaestriaM>();
                }
                return Maestria;
            }
        }

    }
}
