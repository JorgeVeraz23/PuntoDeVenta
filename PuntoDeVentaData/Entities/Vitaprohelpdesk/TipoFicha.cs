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
    public class TipoFicha : CrudEntities
    {
        [Key]
        public long IdTipoFicha { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        [ForeignKey("Casos")]
        public long? IdCaso { get; set; }
        public virtual Casos? Casos { get; set; }
        

    }
}
