using Data.Entities.Utilities;
using Microsoft.EntityFrameworkCore;
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
    public class Casos : CrudEntities
    {
        [Key]
        public long IdCasos { get; set; }
        [MaxLength(300)]
        [Unicode(false)]
        public string? Caso { get; set; }
        [MaxLength(300)]
        [Unicode(false)]
        public string? Motivo { get; set; }

        [MaxLength(300)]
        [Unicode(false)]
        public string? SubMotivo { get; set; }

        [MaxLength(300)]
        public long? TipoFicha { get; set; }

        
   
        



    }
}
