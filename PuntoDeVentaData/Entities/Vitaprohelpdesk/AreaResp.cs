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
    public class AreaResp : CrudEntities
    {
        [Key]
        public long IdAreaResp { get; set; }
        [MaxLength(255)]
        public string? Nombre { get; set; }
        [MaxLength(255)]
        public string Area { get; set; } = "";
        public double Nivel { get; set; }
        [MaxLength(255)]
        public string? Mail { get; set; }   
        public string? Region { get; set; } 
        public long? IdAreaReclamo { get; set; }

    }
}
