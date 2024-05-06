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
    public class ArchivosCarga : CrudEntities
    {
        [Key]
        public long idArchivosCarga { get; set; }
        [MaxLength(300)]
        public string NombreOriginal { get; set; } = "";
        [MaxLength(300)]
        public string NombreSistema { get; set; } = "";
        [MaxLength(900)]
        public string RutaDescarga { get; set; } = "";
        public virtual ICollection<ArchivosCargaIncidencia>? ArchivosCargaIncidencias { get; set; }  
    }
}
