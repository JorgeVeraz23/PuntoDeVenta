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
    public class CorreoNotification : CrudEntities
    {
        [Key]
        public long IdCorreoNotification { get; set; }
        [MaxLength(300)]
        public string NombreCorreoNotification { get; set; } = "";
        public long IdIncidencia { get; set; }
        public Boolean isSac { get; set; }
        public Boolean isEvaluacion { get; set; }
        public Boolean isResponsable { get; set; }
        public Boolean isExterno { get; set; }
    }
}
