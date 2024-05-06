using Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class ResponsableReclamo : CrudEntities
    {
        [Key]
        public long IdResponsableReclamos { get; set; }
        [MaxLength(300)]
        public string NombreResposable { get; set; } = "";
        public int NivelReclamo { get; set; }
        [MaxLength(100)]
        public string? Correo { get; set; }
        [ForeignKey("Territorio")]
        public long IdTerritorio { get; set; }
        [ForeignKey("AreasReclamos")]
        public long? IdAreaReclamo { get; set; }
        public virtual Territorio? Territorio { get; set; }
        public virtual AreasReclamos? AreasReclamos { get; set; }
        public virtual ICollection<AreasResponsables> AreasResponsables { get; set; } = new List<AreasResponsables>();
        public virtual ICollection<Incidencias> IncidenciaIdResponsableNivel1 { get; set; } = new List<Incidencias>();
        public virtual ICollection<Incidencias> IncidenciaIdResponsableNivel2 { get; set; } = new List<Incidencias>();

        public virtual ICollection<Matriz> MatrizIdResponsableReclamos1 { get; set; } = new List<Matriz>();

        public virtual ICollection<Matriz> MatrizIdResponsableReclamos2 { get; set; } = new List<Matriz>();
        [InverseProperty("ResponsableNivel1")]
        public virtual ICollection<TemporalIncidencias> TemporalIncidenciasIdResponsableNivel1 { get; set; } = new List<TemporalIncidencias>();
        [InverseProperty("ResponsableNivel2")]
        public virtual ICollection<TemporalIncidencias> TemporalIncidenciasIdResponsableNivel2 { get; set; } = new List<TemporalIncidencias>();


    }
}
