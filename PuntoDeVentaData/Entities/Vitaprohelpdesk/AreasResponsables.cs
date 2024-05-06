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
    public class AreasResponsables : CrudEntities
    {
        [Key]
        public long IdAreasResponsables { get; set; }
        [ForeignKey("ResponsableReclamo")]
        public long? IdResponsableReclamo {  get; set; }

        [ForeignKey("AreasReclamos")]
        public long? IdAreaReclamo { get; set; }

        public virtual AreasReclamos? AreasReclamos { get; set; }
        public virtual ResponsableReclamo? ResponsableReclamo { get; set; }
    }
}
