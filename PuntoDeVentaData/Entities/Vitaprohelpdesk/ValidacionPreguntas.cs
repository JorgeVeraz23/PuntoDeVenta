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
    public class ValidacionPreguntas : CrudEntities
    {
        [Key]
        public long IdValidacionPreguntas { get; set; }
        [MaxLength(250)]
        public string? NombreValidacionPreguntas { get; set; }
        public int? MaxStringLenght {  get; set; }
        public int? MaxDecimals { get; set; }   
        public int? MinDecimals { get; set; }

    }
}
