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
    public class CategoriaSeleccionada : CrudEntities
    {
        [Key]
        public long IdCategoriaSeleccionada { get; set; }
        [ForeignKey("Incidencias")]
        public long IdIncidencia { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        [ForeignKey("CategoriaCamaron")]
        public long IdCategoriaCamaron { get; set; }
        public virtual Incidencias? Incidencias { get; set; }
        public virtual CategoriaCamaron? CategoriaCamaron { get; set; }
        
    }
}
