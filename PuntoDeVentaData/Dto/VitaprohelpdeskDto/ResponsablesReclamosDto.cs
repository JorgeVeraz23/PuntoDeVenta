using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class ResponsablesReclamosDto
    {
        public long IdResponsableReclamos { get; set; }
        public string NombreResposable { get; set; }
        public int NivelReclamo { get; set; }
        public string Correo { get; set; }
        
        public long IdTerritorio { get; set; }
        
        public long? IdAreaReclamo { get; set; }
    }
    public class MostrarResponsableReclamoDto
    {
        public long IdResponsableReclamos { get; set; }
        public long? IdAreaReclamos { get; set; }
        public string NombreResponsable { get; set; }
        public int NivelReclamo { get; set; }
        public string Correo { get; set; }
        public string Territorio { get; set; }
        public string AreaReclamo { get; set; } 
    }
}
