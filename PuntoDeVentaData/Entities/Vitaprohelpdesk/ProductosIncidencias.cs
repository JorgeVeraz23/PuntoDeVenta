using Data.Entities.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class ProductosIncidencias : CrudEntities
    {
        [Key]
        public long IdProductosIncidencias { get; set; }
        [ForeignKey("Incidencias")]
        public long IdIncidencias { get; set; }
        [ForeignKey("Producto")]
        public long IdProducto { get; set; }
        [MaxLength(500)]
        public string Lote { get; set; } = "";
        public DateTime FechaEntrega { get; set; }
        [MaxLength(1200)]
        public string NoFactura { get; set; } = "";
        [MaxLength(500)]
        public string NoGuiaRemision { get; set; } = "";
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CantidadComprada { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CantidadReclamo { get; set; }
        [MaxLength(500)]
        public string? DetalleProblema { get; set; }
        [MaxLength(500)]
        public string Observacion { get; set; } = "";
        public virtual Incidencias? Incidencias { get; set; }
        public virtual Producto? Producto { get; set; }
    }
}
