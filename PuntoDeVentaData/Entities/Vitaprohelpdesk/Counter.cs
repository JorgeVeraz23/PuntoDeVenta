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
    public class Counter : CrudEntities
    {
        [Key]
        public string? Key { get; set; }
        public int Value { get; set; }
        public DateTime ExpiraAt { get; set; }  
    }
}
