using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class IdiomasDto
    {
        public long IdIdiomas { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string WebLang { get; set; }
        public string AspCulture { get; set; }
        public string CodigoISO { get; set; }
        public Boolean Defecto { get; set; }
        public Boolean Disponible { get; set; }
    }
}
