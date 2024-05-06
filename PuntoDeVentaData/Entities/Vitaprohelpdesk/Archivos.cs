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
    public class Archivos : CrudEntities
    {
        [Key] 
        public long IdArchivo { get; set; }
        [MaxLength(1800)]
        public string EnlacePublico { get; set; } = "";
        [MaxLength(1500)]
        public string EnlacePrivado { get; set; } = "";
        [MaxLength(900)]
        public string NombreOriginal { get; set; } = "";
        [MaxLength(1200)]
        public string NombreSistema { get; set; } = "";
        [MaxLength(100)]
        public string Tipo { get; set; } = "";
        public Boolean Lectura { get; set; }
        public Boolean Escritura { get; set; }
        public Boolean Descarga { get; set; }
        public Boolean Sistema { get; set; }
        public Boolean Disponible { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TamanioKb { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TamaniMb { get; set; }
        public Boolean Imagen { get; set; }
        [MaxLength(50)]
        public string? Extension { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Alto { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Ancho { get; set; }
        public DateTime FechaCarga { get; set; }
        public virtual ICollection<LogAccionesIncidencia>? LogAccionesIncidencias { get; set; }  
    }
}
