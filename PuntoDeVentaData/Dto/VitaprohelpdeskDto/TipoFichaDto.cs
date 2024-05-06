using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class TipoFichaDto
    {
        public long IdTipoFicha { get; set; }
        
        public string? Nombre { get; set; }
        
        public long? IdCaso { get; set; }
        
    }

    public class MostrarTipoFichaDto
    {
        public long IdTipoFicha { get; set; }
        public string? Nombre { get; set; }
        public string? Caso { get; set; }
    }
}
