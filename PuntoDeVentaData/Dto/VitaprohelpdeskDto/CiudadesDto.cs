using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class CiudadesDto
    {
        public long IdCiudad { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        
        public long IdEstado { get; set; }
    }
}
