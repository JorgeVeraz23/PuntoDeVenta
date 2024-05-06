using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Server
    {
        [Key]
        [MaxLength(200)]
        public string Id { get; set; }
        [MaxLength(1200)]
        public string Data { get; set; } = "";
        public DateTime LastHeartbeat { get; set; }
    }
}
