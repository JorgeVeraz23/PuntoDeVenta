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
    public class CargaCorreo : CrudEntities
    {
        [Key]
        [MaxLength(25)]
        public string? NombreResponsable { get; set; }
        [MaxLength(255)]
        public string? Correo { get; set; }
    }
}
