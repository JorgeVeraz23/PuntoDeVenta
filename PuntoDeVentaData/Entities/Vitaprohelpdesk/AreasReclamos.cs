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
    public class AreasReclamos : CrudEntities
    {
        [Key]
        public long IdAreaReclamos { get; set; }
        [MaxLength(300)]
        public string? AreaReclamo { get; set; }
        [MaxLength(900)]
        public string? ResponsableNivel1 { get; set; }
        [MaxLength(900)]
        public string? Plazo1 { get; set; }
        public string? ResponsableNivel2 { get; set; }
        public string? Plazo2 { get; set; }
        public string? TipoReconocimiento { get; set; }
        public string? Codrcsap { get; set; }
        public string? CasualSap { get; set; }


    
    
    }
}
