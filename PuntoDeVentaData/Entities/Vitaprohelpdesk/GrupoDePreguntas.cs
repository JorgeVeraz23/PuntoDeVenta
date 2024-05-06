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
    public class GrupoDePreguntas : CrudEntities
    {
        [Key]
        public long IdGrupoPreguntas { get; set; }
        [Required]
        [MaxLength(100)]
        public string? NombreGrupoDePreguntas { get; set; }
        public virtual ICollection<Preguntas> Preguntas { get; set; }
        public virtual EncuestaDetalle EncuestaDetalle { get; set; }

        public GrupoDePreguntas()
        {
            Preguntas = [];
        }
    }
}
