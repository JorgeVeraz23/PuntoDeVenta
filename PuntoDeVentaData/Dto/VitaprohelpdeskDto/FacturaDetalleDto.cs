using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class FacturaDetalleDto
    {
        public long IdFacturaDetalle { get; set; }
        
        public long IdFactura { get; set; }
        
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
    }

    public class MostrrarFacturaDetalleDto
    {
        public long IdFacturaDetalle { get; set; }

        public long IdFactura { get; set; }

        public long IdProducto { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
    }
}
