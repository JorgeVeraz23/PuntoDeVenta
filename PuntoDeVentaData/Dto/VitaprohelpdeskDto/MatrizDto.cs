using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class MatrizDto
    {
        public long IdMatriz { get; set; }
        
        public long IdCasos { get; set; }
        
        public long IdMotivos { get; set; }
        
        public long? IdSubMotivo { get; set; }
        
        public long IdTipoReconocimiento { get; set; }
        
        public long? IdTipoFicha { get; set; }
        
        public long IdAreaReclamos { get; set; }
        
        public long IdRequisitoFicha { get; set; }
        
        public long IdAccionesRequisitoFicha { get; set; }
        
        public long? IdResponsableReclamos { get; set; }
        public string Plazo1 { get; set; }
        public string Plazo2 { get; set; }
        public string CODRCSAP { get; set; }
        public string CausalSAP { get; set; }
        public string CodigoMotivo { get; set; }
        public string CodigoSubMotivo { get; set; }
    }

    public class MostrarMatrizDto
    {
        public long IdMatriz { get; set; }
        public string CasosNombre { get; set; }
        public string MotivosNombre { get; set; }
        public string SubMotivoNombre { get; set; }
        public string TipoReconocimientoNombre { get; set; }
        public string TipoFichaNombre { get; set; }
        public string AreaReclamosNombre { get; set; }  
        public string RequisitoFichaNombre { get; set; }   
        public string AccionesRequisitoFichaNombre { get; set; }    
        public string ResponsableReclamosNombre { get; set; }
        public string Plazo1 { get; set; }
        public string Plazo2 { get; set; }
        public string CODRCSAP { get; set; }
        public string CausalSAP { get; set; }
        public string CodigoMotivo { get; set; }
        public string CodigoSubMotivo { get; set; }
    }

    public class BuscarEnMatricesMotivosPorIdArea { 
        public long IdMotivo {  get; set; }
        public string? MotivoNombre { get; set; }
    }

    public class ResponseMatrizToReportDTO
    {
        public long IdMatriz { get; set; }
        public string CasosNombre { get; set; }
        public string MotivosNombre { get; set; }
        public string SubMotivoNombre { get; set; }
        public string TipoReconocimientoNombre { get; set; }
        public string TipoFichaNombre { get; set; }
        public string AreaReclamosNombre { get; set; }
        public string RequisitoFichaNombre { get; set; }
        public string AccionesRequisitoFichaNombre { get; set; }
        public string ResponsableReclamosNombre { get; set; }
        public string Plazo1 { get; set; }
        public string Plazo2 { get; set; }
        public string CODRCSAP { get; set; }
        public string CausalSAP { get; set; }
        public string CodigoMotivo { get; set; }
        public string CodigoSubMotivo { get; set; }
    } 

}
