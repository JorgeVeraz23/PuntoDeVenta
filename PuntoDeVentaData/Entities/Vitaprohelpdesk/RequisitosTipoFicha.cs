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
    public class RequisitosTipoFicha : CrudEntities
    {
        [Key]
        public long IdRequisitoTipoFicha { get; set; }
        [MaxLength(300)]
        public string Requisito { get; set; } = "";
        [ForeignKey("TipoFicha")]
        public long IdTipoFicha { get; set; }
        public virtual TipoFicha? TipoFicha { get; set; }
        public virtual ICollection<AccionesRequisitoFicha>? AccionesRequisitoFicha { get; set; }
        public virtual ICollection<Matriz> Matrizs { get; set; } = new List<Matriz>();
        public virtual ICollection<SubMotivo> SubMotivos { get; set; } = new List<SubMotivo>();
    }
}
