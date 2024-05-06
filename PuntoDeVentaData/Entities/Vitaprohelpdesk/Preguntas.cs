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
    public class Preguntas : CrudEntities
    {
        [Key]
        public long IdPreguntas { get; set; }
        [MaxLength(1200)]
        public string? Pregunta { get; set; }
        [ForeignKey("GrupoDePreguntas")]
        public long? IdGrupoDePreguntas { get; set;}
        public virtual GrupoDePreguntas? GrupoDePreguntas { get; set; }
        public virtual ICollection<Respuestas>? Respuestas { get; set; } 


    }
}
