using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Hoja2
    {
        [Key]
        [MaxLength(100)]
        public string? SubMotivo { get; set; }
        [MaxLength(255)]
        public string? Req { get; set; }
        
    }
}
