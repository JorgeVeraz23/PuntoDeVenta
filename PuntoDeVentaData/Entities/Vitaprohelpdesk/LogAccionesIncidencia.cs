using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class LogAccionesIncidencia : CrudEntities
    {
        [Key]
        public long IdLogAccionesInciencia { get; set; }
        [ForeignKey("Incidencias")]
        public long IdIncidencia { get; set; }
        [MaxLength(900)]
        public string? Acciones { get; set; }
        [MaxLength(1000)]
        public string? DescripcionAccion { get; set; }
        [ForeignKey("Archivos")]
        public long IdArchivo { get; set; }
        [MaxLength(300)]
        public string? CorreoEnvioLog {get; set;}
        [MaxLength(1000)]
        public string? CorreoEnviado { get; set;}
        public DateTime FechaEnvioCorreo { get; set; }
        [MaxLength(1000)]
        public string? Observacion { get; set; }
        [MaxLength(1000)]
        public string? CorreoDerivado { get; set; }
        public virtual Archivos? Archivos { get; set; } 
        public virtual Incidencias? Incidencias { get; set; }




    }
}
