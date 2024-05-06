using Data.Entities.Utilities;
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
    public class SubMotivo : CrudEntities
    {
        [Key]
        public long IdSubMotivo { get; set; }
        [MaxLength(300)]
        public string NombreSubMotivo { set; get; } = "";
        [ForeignKey("Motivo")]

        public long IdMotivoss { get; set; }
        [ForeignKey("TipoReconocimiento")]
        public long IdTipoReconocimiento { get; set; }
        [ForeignKey("RequisitosTipoFicha")]
        public long IdRequisitoTipoFicha { get; set; }
        [MaxLength(1200)]
        public string PlazoNivel1 { get; set; } = "";
        [MaxLength(1200)]
        public string PlazoNivel2 { get; set; } = "";
        [MaxLength(500)]
        public string CodigoSubMotivo { get; set; } = "";
        public virtual Motivo? Motivo { get; set; }
        public virtual TipoReconocimiento? TipoReconocimiento { get; set; }
        public virtual RequisitosTipoFicha? RequisitosTipoFicha { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set;}
        public virtual ICollection<Matriz>? Matrizs { get; set;}
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set; }
    }

}
