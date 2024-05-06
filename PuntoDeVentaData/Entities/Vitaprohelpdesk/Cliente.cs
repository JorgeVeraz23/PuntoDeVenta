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
    public class Cliente : CrudEntities
    {
        [Key]
        public long IdCliente { get; set; }
        [MaxLength(20)]
        public string Identificacion { get; set; } = "";
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        public virtual ICollection<Factura>? Factura { get; set; }

    }
}
