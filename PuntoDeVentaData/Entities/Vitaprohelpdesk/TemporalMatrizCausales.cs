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
    public class TemporalMatrizCausales : CrudEntities
    {
        [Key]
        public long IdTemporalMatrizCausales { get; set; }
        [MaxLength(300)]
        public string Caso { get; set; } = "";
        [MaxLength(500)]
        public string SubCodigo { get; set; } = "";
        [MaxLength(500)]
        public string AreaResponsable { get; set; } = "";
        [MaxLength(500)]
        public string Codigo { get; set; } = "";
        [MaxLength(500)]
        public string Motivo { get; set; } = "";
        [MaxLength(500)]
        public string SubCodigoSubMot { get; set; } = "";
        [MaxLength(500)]
        public string SubMotivo { get; set; } = "";
        [MaxLength(500)]
        public string Clasificacion { get; set; } = "";
        [MaxLength(500)]
        public string RequisitosBasicos { get; set; } = "";
        [MaxLength(900)]
        public string AccionInmediata { get; set; } = "";
        [MaxLength(900)]
        public string ResponsableNivel1Ecuador { get; set; } = "";
        [MaxLength(900)]
        public string ResponsableNivel2Ecuador { get; set; } = "";
        [MaxLength(900)]
        public string ResponsableNivel1Peru { get; set; } = "";
        [MaxLength(900)]
        public string Plazo1 { get; set; } = "";
        [MaxLength(900)]
        public string ResponsableNivel2Peru { get; set; } = "";
        [MaxLength(900)]
        public string Plazo2 { get; set; } = "";
        [MaxLength(900)]
        public string TipoReconocimientp { get; set; } = "";
        [MaxLength(900)]
        public string CodRCSAP { get; set; } = "";
        [MaxLength(900)]
        public string CasualSAP { get; set; } = "";


    }
}
