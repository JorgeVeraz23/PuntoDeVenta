using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class TemporalMatrizCausalesDto
    {
        public long IdTemporalMatrizCausales { get; set; }
        public string Caso { get; set; }
        public string SubCodigo { get; set; }
        public string AreaResponsable { get; set; }
        public string Codigo { get; set; }
        public string Motivo { get; set; }
        public string SubCodigoSubMot { get; set; }
        public string SubMotivo { get; set; }
        public string Clasificacion { get; set; }
        public string RequisitosBasicos { get; set; }
        public string AccionInmediata { get; set; }
        public string ResponsableNivel1Ecuador { get; set; }
        public string ResponsableNivel2Ecuador { get; set; }
        public string ResponsableNivel1Peru { get; set; }
        public string Plazo { get; set; }
        public string ResponsableNivel2 { get; set; }
        public string Plazo2 { get; set; }
        public string TipoReconocimientp { get; set; }
        public string CodRCSAP { get; set; }
        public string CasualSAP { get; set; }
    }
}
