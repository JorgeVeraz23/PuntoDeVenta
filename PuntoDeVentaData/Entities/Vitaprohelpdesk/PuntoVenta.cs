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
    public class PuntoVenta : CrudEntities
    {
        [Key]
        public long IdPuntoVenta { get; set; }
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        [MaxLength(500)]
        public string Direccion { get; set; } = "";
        public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
    }
}
