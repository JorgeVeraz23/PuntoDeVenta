using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class CorreoNotificationDto
    {
        public long IdCorreoNotification { get; set; }
        public string NombreCorreoNotification { get; set; }
        public long IdIncidencia { get; set; }
        public Boolean isSac { get; set; }
        public Boolean isEvaluacion { get; set; }
        public Boolean isResponsable { get; set; }
        public Boolean isExterno { get; set; }
    }
}
