using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class CasosDto
    {

        public long IdCasos { get; set; }


        
        public string? Caso { get; set; }

        
        public string? Motivo { get; set; }

        
        public string? SubMotivo { get; set; }

        
        public long? IdTipoFicha { get; set; }
    }
}
