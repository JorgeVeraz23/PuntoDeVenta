using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class MotivoDto
    {
        public long IdMotivo { get; set; }
        public string? Nombre { get; set; }
        public long? IdCaso { get; set; }
    }

    public class MostrarMotivoDto
    {
        public long IdMotivo { get; set; }
        public string? Nombre { get; set; }
        public string Caso { get; set; }
    }
        

}
