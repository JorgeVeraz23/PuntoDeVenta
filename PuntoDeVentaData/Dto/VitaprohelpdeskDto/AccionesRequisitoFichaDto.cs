using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class AccionesRequisitoFichaDto
    {
        public long IdAccionRequisitosFicha { get; set; }

        public string NombreAccion { get; set; }
        
        public long? IdRequisitoTipoFicha { get; set; }

        
        public long? IdAreaReclamo { get; set; }
    }
    
    public class MostrarAccionesRequisitoFichaDto
    {
        public long IdAccionesRequisitoFicha { get; set; }
        public string NombreAccion { get; set; }
        public string? NombreRequisitoTipoFicha { get; set; }
        public string? NombreAreaReclamo { get; set; }
    }
}
