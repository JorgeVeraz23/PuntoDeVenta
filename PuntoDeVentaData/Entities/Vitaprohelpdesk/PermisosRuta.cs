using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class PermisosRuta
    {
        [Key]
        public int IdApplicationRoutePermission { get; set; }
        [ForeignKey("Rutas")]
        public long IdApplicationRoute { get; set; }
        public virtual Rutas Rutas { get; set; } = null!;
    }
}
