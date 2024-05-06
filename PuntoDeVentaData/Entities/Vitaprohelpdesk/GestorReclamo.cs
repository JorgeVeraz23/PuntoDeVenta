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
    public class GestorReclamo : CrudEntities
    {
        [Key]
        public long IdGestorReclamo { get; set; }
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        [MaxLength(255)]
        public string Mail { get; set; } = "";
        [MaxLength(50)]
        public string Telefono { get; set; } = "";
        [ForeignKey("Territorio")]
        public long IdTerritorio { get; set; }
        public virtual Territorio? Territorio { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set;}
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set; }   

    }
}
