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
    public class Factura : CrudEntities
    {
        [Key]
        public long IdFactura { get; set; }
        [ForeignKey("Cliente")]
        public long IdCliente { get; set; }
        [ForeignKey("PuntoVenta")]
        public long IdPuntoVenta { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal  Iva { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; }


        public virtual Cliente? Cliente { get; set; }
        public virtual PuntoVenta? PuntoVenta { get; set; }

        public ICollection<FacturaDetalle>? FacturaDetalle { get; set; }
    }
}
