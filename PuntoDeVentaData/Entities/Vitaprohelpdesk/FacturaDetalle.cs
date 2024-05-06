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
    public class FacturaDetalle : CrudEntities
    {
        [Key]
        public long IdFacturaDetalle { get; set; }
        [ForeignKey("Factura")]
        public long IdFactura { get; set; }
        [ForeignKey("Productos")]
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal IVA { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Total { get; set; } 

        public virtual Factura? Factura { get; set; }
        public virtual Productos? Productos { get; set; }




    }
}
