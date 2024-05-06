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
    public class Regiones : CrudEntities
    {
        [Key]
        public long IdRegiones { get; set; }
        [MaxLength(50)]
        public string Codigo { get; set; } = "";
        [MaxLength(200)]
        public string Nombre { get; set; } = "";
        [ForeignKey("Paises")]
        public long IdPais { get; set; }

        public virtual Paises? Paises { get; set; }
        public virtual ICollection<Estados> Estados { get; set; } = new List<Estados>();    

    }
}
