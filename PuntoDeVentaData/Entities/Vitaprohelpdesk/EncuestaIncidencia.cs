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
    public class EncuestaIncidencia : CrudEntities
    {
        [Key]
        public long IdEncuesta { get; set; }
        [ForeignKey("Incidencias")]
        public long IdIncidencia { get; set; }
        public virtual Incidencias? Incidencias { get; set; }
        public virtual ICollection<RespuestaEncuestaIncidencia>? RespuestaEncuestaIncidencias { get; set; }  
        //este de aqui es el que pretendo usar por como esta relacionado lo que quiero hacer en la base de datos el de arriba ya veo que hago con el 
        public virtual ICollection<Respuestas>? Respuestas { get; set; }



    }
}
