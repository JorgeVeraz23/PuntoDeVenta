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
    public class TablaMatriz : CrudEntities
    {
        [Key]
        public long IdTablaMatriz { get; set; }
        [MaxLength(300)]
        public string Caso { get; set; } = "";
        [MaxLength(900)]
        public string Motivo { get; set; } = "";
        [MaxLength(900)]
        public string SubMotivo { get; set; } = "";
        [MaxLength(900)]
        public string TipoFicha { get; set; } = "";
        [MaxLength(900)]
        public string? RequisitosBasico { get; set; }
        [MaxLength(900)]
        public string? AccionInmediata { get; set; }
        [MaxLength(900)]
        public string? AreaReclamo { get; set; }
        [MaxLength(900)]
        public string? ResponsableNivel1Ecuador { get; set; }
        [MaxLength(900)]
        public string Plazo1 { get; set; } = "";
        [MaxLength(900)]
        public string Plazo2 { get; set; } = "";
        [MaxLength(900)]
        public string? ResponsableNivel1 { get; set; }
        [MaxLength(900)]
        public string? ResponsableNivel2 { get; set; }
        [MaxLength(900)]
        public string? TipoReconocimiento { get; set; }
        [MaxLength(900)]
        public string CODRSAP { get; set; } = "";
        [MaxLength(900)]
        public string CasualSAP { get; set; } = "";
        public long IdCaso { get; set; }
        public long IdMotivo { get; set; }
        public long IdSubMotivo { get; set; }
        public long IdTipoFicha { get; set; }
        public long IdRequisitoBasico { get; set; }
        public long IdAccionInmediada { get; set; }
        public long IdAreaReclamo { get; set; }
        public long IdResponsableNivel1 { get; set; }
        public long IdResponsableNivel2 { get; set; } 
        public long IdTipoReconocimiento { get; set; }





    }
}
