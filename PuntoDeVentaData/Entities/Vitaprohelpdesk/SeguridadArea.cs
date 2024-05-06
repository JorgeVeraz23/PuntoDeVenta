using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class SeguridadArea : CrudEntities
    {
        [Key]
        public long IdArea { get; set; }
        [MaxLength(1200)]
        public string? Guid { get; set; }
        [MaxLength(1200)]
        public string? Nombre { get; set; }
        [MaxLength(1200)]
        public string? Descripcion { get; set; }
        public int? SecurityLevelIdNivel { get; set; }
        public virtual ICollection<Permiso>? Permisos { get; set; }
        public virtual SeguridadNivele? SeguridadNivele { get; set; }
    }
}
