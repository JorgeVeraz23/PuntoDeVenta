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
    public class CategoriaCamaron : CrudEntities
    {
        [Key]
        public long IdCategoriaCamaron { get; set; }
        [MaxLength(300)]
        public string? NombreCategoriaCamaron { get; set; }
        public virtual ICollection<CategoriaSeleccionada>? CategoriaSeleccionadas { get; set; }  

    }
}
