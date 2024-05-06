﻿using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class PreguntaCatalogo : CrudEntities
    {
        [Key]
        public long IdPreguntaCatalogo { get; set; }
        [MaxLength(300)]
        public string? Pregunta { get; set;  }
        
        public virtual ICollection<RespuestaEncuestaIncidencia>? RespuestaEncuestaIncidencias { get; set; }  

    }
}
