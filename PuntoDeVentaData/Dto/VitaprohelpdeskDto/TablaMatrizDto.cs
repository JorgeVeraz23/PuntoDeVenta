using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class TablaMatrizDto
    {
        public long IdTablaMatriz { get; set; }
        public string Caso { get; set; }
        public string Motivo { get; set; }
        public string SubMotivo { get; set; }
        public string TipoFicha { get; set; }
        public string RequisitosBasico { get; set; }
        public string AccionInmediata { get; set; }
        public string AreaReclamo { get; set; }
        public string ResponsableNivel1Ecuador { get; set; }
        public string Plazo1 { get; set; }
        public string Plazo2 { get; set; }
        public string ResponsableNivel1 { get; set; }
        public string TipoReconocimiento { get; set; }
        public string CODRSAP { get; set; }
        public string CasualSAP { get; set; }
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
