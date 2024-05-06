using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class RegionesDto
    {
        public long IdRegiones { get; set; }
        
        public string Codigo { get; set; }
        
        public string Nombre { get; set; }
        
        public long IdPais { get; set; }
    }
}
