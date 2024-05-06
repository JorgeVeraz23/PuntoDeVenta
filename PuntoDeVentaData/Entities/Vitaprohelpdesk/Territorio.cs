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
    public class Territorio : CrudEntities
    {
        [Key]
        public long IdTerritorio { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        [MaxLength(500)]
        public string? CodigoTerritorio { get; set; }
        public virtual ICollection<AsesorComercial>? AsesorComercial { get; set; }  
        public virtual ICollection<AsesorTecnico>? AsesorTecnicos { get; set; }
        public virtual ICollection<GestorReclamo>? GestorReclamos { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set;}
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get;set; }
        public virtual ICollection<ResponsableReclamo>? ResponsableReclamos { get; set; }    
    }
}
