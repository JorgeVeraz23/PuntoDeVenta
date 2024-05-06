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
    public class Continente : CrudEntities
    {
        [Key]
        public long IdContinente { get; set; }
        [MaxLength(300)]
        public string? Codigo { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        public virtual ICollection<Paises>? Paises { get; set; }
    }
}
