using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class AreasResponsablesDto
    {
        public long IdAreasResponsables { get; set; }
        
        public long IdResponsableReclamo { get; set; }
        
        public long IdAreaReclamo { get; set; }
    }
}
