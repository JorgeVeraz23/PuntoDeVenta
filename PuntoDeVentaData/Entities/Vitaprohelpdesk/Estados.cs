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
    public class Estados : CrudEntities
    {
        [Key]
        public long IdEstado { get; set; }
        [MaxLength(300)]
        public string Codigo { get; set; } = "";
        [MaxLength(300)]
        public string Nombre { get; set; } = "";
        [ForeignKey("Paises")]
        public long IdPais { get; set; }
        [ForeignKey("Regiones")]
        public long? IdRegion { get; set; }
        public virtual ICollection<Ciudades>? Ciudades { get; set; }
        public virtual Paises? Paises { get; set; }
        public virtual Regiones? Regiones { get; set; }

    }
}
