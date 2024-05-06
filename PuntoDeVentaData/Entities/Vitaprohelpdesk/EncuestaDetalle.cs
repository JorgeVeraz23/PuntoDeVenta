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
    public class EncuestaDetalle : CrudEntities
    {
        [Key]
        public long IdEncuestaDetalle { get; set; }
        [ForeignKey("Encuesta")]
        public long IdEncuesta { get; set; }
        public virtual Encuesta? Encuesta { get; set; }
        public virtual ICollection<GrupoDePreguntas>? GrupoDePreguntas { get; set; }
        public virtual ICollection<Respuestas>? Respuestas { get; set; }

    }
}
