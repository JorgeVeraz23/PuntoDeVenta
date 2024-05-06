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
    public class RespuestaEncuestaIncidencia : CrudEntities
    {
        [Key]
        public long IdRespuestaEncuestaIncidencia { get; set; }
        [ForeignKey("EncuestaIncidencia")]
        public long IdEncuesta { get; set; }
        [ForeignKey("PreguntaCatalogo")]
        public long IdPregunta { get; set; }
        [MaxLength(300)]
        public string? Respuesta { get; set;}
        public virtual  EncuestaIncidencia? EncuestaIncidencia { get; set; }
        public virtual PreguntaCatalogo? PreguntaCatalogo { get; set; }
    }
}
