using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class SeguridadNivele
    {
        [Key]
        public long IdNivel { get; set; }
        [MaxLength(1200)]
        public string? Guid { get; set; }
        [MaxLength(1200)]
        public string? Nombre { get; set; }
        [MaxLength(1200)]
        public string? Descripcion { get; set; }
        public virtual ICollection<SeguridadArea> SeguridadArea { get; set; } = new List<SeguridadArea>();
    }
}
