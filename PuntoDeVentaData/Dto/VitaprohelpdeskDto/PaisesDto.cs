using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class PaisesDto
    {
        
        public long IdPais { get; set; }
        public string Codigo { get; set; }
        public string Aplha2 { get; set; }
        public string Alpha3 { get; set; }
        
        public string NombreCS { get; set; }
        
        public string NombreDE { get; set; }
        
        public string NombreEN { get; set; }
        
        public string NombreES { get; set; }
        
        public string NombreFR { get; set; }
       
        public string NombreIT { get; set; }
        
        public string NombreNl { get; set; }
        
        public string DenominacionEstado { get; set; }
        
        public string CodigoTelefonico { get; set; }
        public Boolean Defecto { get; set; }
        public Boolean Disponible { get; set; }
        
        public long IdContinente { get; set; }
        
        public long IdIdioma { get; set; }
    }
}
