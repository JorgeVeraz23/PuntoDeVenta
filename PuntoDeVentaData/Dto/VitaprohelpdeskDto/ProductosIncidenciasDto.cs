using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class ProductosIncidenciasDto
    {
        public long IdProductosIncidencias { get; set; }
       
        public long IdIncidencias { get; set; }
        
        public long IdProducto { get; set; }
        public string Lote { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string NoFactura { get; set; }
        public string NoGuiaRemision { get; set; }
        public decimal CantidadComprada { get; set; }
        public decimal? CantidadReclamo { get; set; }
        public string? DetalleProblema { get; set; }
        public string Observacion { get; set; }
    }

    //public class MostrarProductosIncidenciasDto
    //{
    //    public long IdProductosIncidencias { get; set; }

    //    public long IdIncidencias { get; set; }

    //    public long IdProducto { get; set; }
    //    public string Lote { get; set; }
    //    public DateTime FechaEntrega { get; set; }
    //    public string NoFactura { get; set; }
    //    public string NoGuiaRemision { get; set; }
    //    public decimal CantidadComprada { get; set; }
    //    public decimal? CantidadReclamo { get; set; }
    //    public string? DetalleProblema { get; set; }
    //    public string Observacion { get; set; }
    //}
}
