using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class State
    {
        [Key]
        public long IdState { get; set; }
        [ForeignKey("Job")]
        public long JoId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Reason { get; set; } = "";
        public DateTime CreateAt { get; set; }
        public string? Data { get; set; }
        public virtual Job? Job { get; set; }
    }
}
