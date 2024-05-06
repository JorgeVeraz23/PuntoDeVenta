using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class RespuestaEncuestaIncidenciaDto
    {
        public long IdRespuestaEncuestaIncidencia { get; set; }
        
        public long IdEncuesta { get; set; }
        
        public long IdPregunta { get; set; }
        public string? Respuesta { get; set; }
    }
}
