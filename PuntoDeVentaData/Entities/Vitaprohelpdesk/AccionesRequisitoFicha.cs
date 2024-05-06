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
    public class AccionesRequisitoFicha : CrudEntities
    {
        [Key]
        public long IdAccionRequisitosFicha { get; set; }
        [MaxLength(300)]
        public string? NombreAccion { get; set; }
        [ForeignKey("RequisitosTipoFicha")]
        public long? IdRequisitoTipoFicha { get; set; }

        [ForeignKey("AreasReclamos")] 
        public long? IdAreaReclamo { get; set; }
        public virtual RequisitosTipoFicha? RequisitosTipoFicha { get; set; }
        public virtual AreasReclamos? AreasReclamos { get; set; }
        public virtual ICollection<Matriz> Matrizs { get; set; } = new List<Matriz>();

    }
}
