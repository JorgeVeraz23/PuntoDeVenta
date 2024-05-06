using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class RequisitosTipoFichaDto
    {
        public long IdRequisitoTipoFicha { get; set; }
        
        public string Requisito { get; set; }
        
        public long IdTipoFicha { get; set; }
    }
}
