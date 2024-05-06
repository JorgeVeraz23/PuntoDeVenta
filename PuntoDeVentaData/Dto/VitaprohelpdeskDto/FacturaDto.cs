using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class FacturaDto
    {
        public long IdFactura { get; set; }
        
        public long IdCliente { get; set; }
        
        public long IdPuntoVenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }

    public class MostrarFacturaDto
    {
        public long IdFactura { get; set; }
        public string ClienteNombre { get; set; }
        public string PuntoVentaNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
    }
}
