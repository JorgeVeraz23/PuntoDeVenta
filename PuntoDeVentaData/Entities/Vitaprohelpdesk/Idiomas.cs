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
    public class Idiomas : CrudEntities
    {
        [Key]
        public long IdIdiomas { get; set; }
        [MaxLength(300)]
        public string? Codigo { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        [MaxLength(300)]
        public string WebLang { get; set; } = "";
        [MaxLength(300)]
        public string AspCulture { get; set; } = "";
        [MaxLength(300)]
        public string CodigoISO { get; set; } = "";
        public Boolean Defecto { get; set; }
        public Boolean Disponible { get; set; }
        public virtual ICollection<Paises>? Paises { get; set; } = new List<Paises>();
    }
}
