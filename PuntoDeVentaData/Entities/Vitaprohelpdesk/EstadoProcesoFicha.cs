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
    public class EstadoProcesoFicha : CrudEntities
    {
        [Key]
        public long IdEstadoProcesoFicha { get; set; }
        [MaxLength(300)]
        public string? Nombre { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set;}
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set; }
        

    }
}
