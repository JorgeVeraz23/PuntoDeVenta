using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class Job
    {
        [Key]
        public long Id { get; set; }
        public long? StateId { get; set; }
        [MaxLength(20)]
        public string? StateName { get; set; }  
        public string InvocationData { get; set; } = "";
        public string Arguments { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime ExpireAt { get; set; }
        
        //public virtual ICollection<JobParameter> JobParameters { get; set; } = new List<JobParameter>();

        
        //public virtual ICollection<State> States { get; set; } = new List<State>();
    }
}
