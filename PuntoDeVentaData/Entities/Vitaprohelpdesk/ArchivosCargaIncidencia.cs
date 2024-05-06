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
    public class ArchivosCargaIncidencia : CrudEntities
    {
        [Key]
        public long IdArchivoCargaIncidencia { get; set; }
        [ForeignKey("Incidencias")]
        public long IdIncidencias { get; set; }
        public string? ProcesoIncidencia { get; set; }
        [ForeignKey("ArchivosCarga")]
        public long IdArchivosCarga { get; set; }
        public virtual ArchivosCarga? ArchivosCarga { get; set; }
        public virtual Incidencias? Incidencias { get; set; }

    }
}
