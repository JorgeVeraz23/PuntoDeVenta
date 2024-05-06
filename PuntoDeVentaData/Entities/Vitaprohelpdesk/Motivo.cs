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
    public class Motivo : CrudEntities
    {
        [Key]
        public long IdMotivo { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        [ForeignKey("Casos")]
        public long? IdCaso { get; set; }
        [MaxLength(1200)]
        public string? CodigoMotivo { get; set; }
        
        public virtual Casos? Casos { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set;}
        public virtual ICollection<Matriz>? Matrizs { get; set;}
        public virtual ICollection<SubMotivo>? SubMotivos { get; set;}
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set;}

    }
}
