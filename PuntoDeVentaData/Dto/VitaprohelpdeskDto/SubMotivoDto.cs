using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class SubMotivoDto
    {
        public long IdSubMotivo { get; set; }
        public string NombreSubMotivo { set; get; }
        

        public long IdMotivos { get; set; }
        
        public long IdTipoReconocimiento { get; set; }
        
        public long IdRequisitoTipoFicha { get; set; }
        public string PlazoNivel1 { get; set; }
        public string PlazoNivel2 { get; set; }
        public string CodigoSubMotivo { get; set; }
    }

    public class MostrarSubMotivoDto
    {
        public long IdSubMotivo { get; set; }
        public string NombreSubMotivo { set; get; }


        public string MotivoNombre { get; set; }

        public string TipoReconocimientoNombre { get; set; }

        public string RequisitoTipoFicha { get; set; }
        public string PlazoNivel1 { get; set; }
        public string PlazoNivel2 { get; set; }
        public string CodigoSubMotivo { get; set; }
    }


}
