using Data.Entities.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class Matriz : CrudEntities
    {
        [Key]
        public long IdMatriz { get; set; }
        [ForeignKey("Casos")]
        public long IdCasos { get; set; }
        [ForeignKey("Motivos")]
        public long IdMotivos { get; set; }
        [ForeignKey("SubMotivo")]
        public long? IdSubMotivo { get; set; }
        [ForeignKey("TipoReconocimiento")]
        public long IdTipoReconocimiento { get; set; }
        [ForeignKey("TipoFicha")]
        public long? IdTipoFicha { get; set; }
        [ForeignKey("AreasReclamos")]
        public long IdAreaReclamos { get; set; }
        [ForeignKey("RequisitosTipoFicha")]
        public long IdRequisitoFicha { get; set; }
        [ForeignKey("AccionesRequisitoFicha")]
        public long IdAccionesRequisitoFicha { get; set; }
        [ForeignKey("ResponsableReclamo1")]
        public long? IdResponsableReclamo1 { get; set; }
        [ForeignKey("ResponsableReclamo2")]
        public long? IdResponsableReclamo2 { get; set; }
        [MaxLength(1200)]
        public string Plazo1 { get; set; } = "";
        [MaxLength(1200)]
        public string Plazo2 { get; set; } = "";
        [MaxLength(300)]
        public string CODRCSAP { get; set; } = "";
        [MaxLength(1200)]
        public string CausalSAP { get; set; } = "";
        [MaxLength(1200)]
        public string CodigoMotivo { get; set; } = "";
        [MaxLength(1200)]
        public string CodigoSubMotivo { get; set; } = "";



        public virtual Casos? Casos { get; set; }
        public virtual Motivo? Motivos { get; set; }
        public virtual SubMotivo? SubMotivo { get; set; }
        public virtual TipoReconocimiento? TipoReconocimiento { get; set; }
        public virtual TipoFicha? TipoFicha { get; set; }
        public virtual AreasReclamos? AreasReclamos { get; set; }
        public virtual RequisitosTipoFicha? RequisitosTipoFicha { get; set; }
        public virtual AccionesRequisitoFicha? AccionesRequisitoFicha { get; set; }
        [InverseProperty("MatrizIdResponsableReclamos1")]
        public virtual ResponsableReclamo? ResponsableReclamo1 { get; set; }
        [InverseProperty("MatrizIdResponsableReclamos2")]
        public virtual ResponsableReclamo? ResponsableReclamo2 { get; set; }




    }
}
