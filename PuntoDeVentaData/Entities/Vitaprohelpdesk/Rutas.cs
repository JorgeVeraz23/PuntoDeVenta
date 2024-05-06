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
    public class Rutas : CrudEntities
    {
        [Key]
        public long IdApplicationRoute { get; set; }
        [MaxLength(300)]
        public string Area { get; set; } = "";
        [MaxLength(1200)]
        public string Controlador { get; set; } = "";
        [MaxLength(1200)]
        public string Accion { get; set; } = "";
        [MaxLength(1200)]
        public string Codigo { get; set; } = "";
        [MaxLength(1200)]
        public string Modulo { get; set; } = "";
        [MaxLength(1200)]
        public string NombrePublico { get; set; } = "";
        [MaxLength(1200)]
        public string MetodosPermitidos { get; set; } = "";
        public virtual ICollection<PermisosRuta> PermisoRutas { get; set; } = new List<PermisosRuta>();

    }
}
