using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class LogAccionesIncidenciasDto
    {
        public long IdLogAccionesInciencia { get; set; }
        
        public long IdIncidencia { get; set; }
        public string? Acciones { get; set; }
        public string? DescripcionAccion { get; set; }
        
        public long IdArchivo { get; set; }
        public string? CorreoEnvioLog { get; set; }
        public string? CorreoEnviado { get; set; }
        public DateTime FechaEnvioCorreo { get; set; }
        public string? Observacion { get; set; }
        public string? CorreoDerivado { get; set; }
    }


    public class MostrarLogAccionesIncidenciasDto
    {
        public long IdLogAccionesInciencia { get; set; }

        public long IdIncidencia { get; set; }
        public string? Acciones { get; set; }
        public string? DescripcionAccion { get; set; }

        public long IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string? CorreoEnvioLog { get; set; }
        public string? CorreoEnviado { get; set; }
        public DateTime FechaEnvioCorreo { get; set; }
        public string? Observacion { get; set; }
        public string? CorreoDerivado { get; set; }
    }
}
