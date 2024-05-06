using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class RutasDto
    {
        public long IdApplicationRoute { get; set; }
        public string Area { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Codigo { get; set; }
        public string Modulo { get; set; }
        public string NombrePublico { get; set; }
        public string MetodosPermitidos { get; set; }
    }
}
