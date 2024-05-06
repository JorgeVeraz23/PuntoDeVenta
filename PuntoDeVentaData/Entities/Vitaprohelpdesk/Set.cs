using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Set
    {
        [Key]
        [MaxLength(100)]
        public string Key { get; set; } = "";
        public double Score { get; set; }
        [MaxLength(1200)]
        public string Value { get; set; } = "";
        public DateTime? ExpireAt { get; set; }
        
    }
}
