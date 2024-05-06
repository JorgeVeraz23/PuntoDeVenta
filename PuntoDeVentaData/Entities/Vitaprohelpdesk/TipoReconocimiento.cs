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
    public class TipoReconocimiento : CrudEntities
    {
        [Key]
        public long IdTipoReconocimiento { get; set; }
        [MaxLength(300)]
        public string NombreTipoReconocimiento { get; set; } = "";
        
        public long IdSubMotivo { get; set; }
        public virtual ICollection<Matriz>? Matrizs { get; set; }
        public virtual ICollection<SubMotivo>? SubMotivos { get; set; }
    }
}
