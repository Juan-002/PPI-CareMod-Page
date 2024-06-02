using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareMod.Shared
{


    public class Pacientes
    {
        public string       documento_paciente { get; set; }
        public string       tipo_documento { get; set; }
        public string       primer_nombre { get; set; }
        public string?      segundo_nombre { get; set; }
        public string       primer_apellido { get; set; }
        public string?      segundo_apellido { get; set; }
        public DateTime     fecha_de_nacimiento { get; set; }
        public string       RH { get; set; }
        public int          eps { get; set; }
        public string       tipo_de_usuario { get; set; }
        public string       residencia { get; set; }
        public int          religion { get; set; }
        public string       id_acompanniante { get; set; }
        public bool        estatus_ac_noac { get; set; }
        public string?     fecha_creacion { get; set; }
        public string?      fecha_edicion { get; set; }
        public bool         amarillo { get; set; }
        public bool         rojo { get; set; }
        public bool         ciam { get; set; }
        public bool         morado { get; set; }
        public bool         verde { get; set; }
    }
}
