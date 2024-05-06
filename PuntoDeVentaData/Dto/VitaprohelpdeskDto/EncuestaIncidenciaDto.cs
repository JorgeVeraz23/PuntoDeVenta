using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class EncuestaIncidenciaDto
    {
        public long IdEncuesta { get; set; }
        
        public long IdIncidencia { get; set; }
    }
}
