using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Encuesta : CrudEntities
    {
        [Key]
        public long IdEncuesta { get; set; }
        public virtual ICollection<EncuestaDetalle>? EncuestaDetalles { get; set; }
    }
}
