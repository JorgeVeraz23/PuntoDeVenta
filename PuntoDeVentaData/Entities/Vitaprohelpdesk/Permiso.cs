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
    public class Permiso : CrudEntities
    {
        [Key]
        public long IdPermiso { get; set; }
        [MaxLength(1200)]
        public string Guid { get; set; } = "";
        [MaxLength(1200)]
        public string Nombre { get; set; } = "";
        [MaxLength(1200)]
        public string Descripcion { get; set; } = "";
        [ForeignKey("SeguridadArea")] 
        public long IdArea { get; set; }
        public virtual SeguridadArea? SeguridadArea { get; set; }    
    }
}
