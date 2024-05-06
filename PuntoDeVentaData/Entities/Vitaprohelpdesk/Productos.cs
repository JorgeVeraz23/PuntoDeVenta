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
    public class Productos : CrudEntities
    {
        [Key]
        public long IdProducto { get; set;}
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        [ForeignKey("Categorias")]
        public long IdCategoria { get; set; }
        [InverseProperty("Productos")]
        public virtual Categorias? Categorias { get; set; }
        [InverseProperty("Productos")]
        public virtual ICollection<FacturaDetalle>? FacturaDetalles { get; set; }
        
    }
}
