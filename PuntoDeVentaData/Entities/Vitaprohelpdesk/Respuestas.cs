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
    public class Respuestas : CrudEntities
    {
        [Key]
        public long IdRespuesta { get; set; }
        [ForeignKey("EncuestaDetalle")]
        public long IdEncuesta { get; set; }
        [ForeignKey("Preguntas")]
        public long IdPregunta { get; set; }
        [MaxLength(1200)]
        public string? RespuestaPregunta { get; set; }
        public virtual EncuestaDetalle? EncuestaDetalle { get; set; }
        public virtual Preguntas? Preguntas { get; set;}

    }
}
