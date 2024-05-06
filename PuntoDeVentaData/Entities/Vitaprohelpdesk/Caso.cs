using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Caso : CrudEntities
    {
        [Key]
        public long IdCaso {  get; set; }
        [MaxLength(255)]
        public string NombreCasos { get; set; } = "";
        [ForeignKey("TipoFicha")]
        public long IdTipoFicha { get; set; }
        public virtual TipoFicha? TipoFicha { get; set;}
        public virtual ICollection<Incidencias>? Incidencias { get; set; }
        public virtual ICollection<Matriz>? Matriz { get; set; }
        public virtual ICollection<Motivo>? Motivo { get; set; }
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set; }
        public virtual ICollection<TipoFicha>? TipoFichas { get; set; }

    }
}
