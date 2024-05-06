using Data.Entities.Utilities;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Ciudades : CrudEntities
    {
        [Key]
        public long IdCiudad { get; set; }
        [MaxLength(300)]
        public string Codigo { get; set; } = "";
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        [MaxLength(300)]
        public string CodigoPostal { get; set; } = "";
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Latitud { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Longitud { get; set;}
        [ForeignKey("Estados")]
        public long IdEstado { get; set; }
        public virtual Estados? Estados { get; set; }
        public virtual ICollection<ApplicationUser>? Users { get; set; }
    }
}
