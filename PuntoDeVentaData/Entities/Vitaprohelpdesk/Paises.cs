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
    public class Paises : CrudEntities
    {
        [Key]
        public long IdPais { get; set; }
        [MaxLength(300)]
        public int Codigo { get; set; }
        [MaxLength(500)]
        public string? Aplha2 { get; set; }
        [MaxLength(500)]
        public string? Alpha3 { get; set; }
        [MaxLength(300)]
        public string? NombreCS { get; set; }
        [MaxLength(300)]
        public string? NombreDE { get; set; }
        [MaxLength(300)]
        public string? NombreEN { get; set; }
        [MaxLength(300)]
        public string? NombreES { get; set; }
        [MaxLength(300)]
        public string? NombreFR { get; set; }
        [MaxLength(300)]
        public string? NombreIT { get; set; }
        [MaxLength(300)]
        public string? NombreNl { get; set; }
        [MaxLength(150)]
        public string? DenominacionEstado { get; set; }
        [MaxLength(50)]
        public string? CodigoTelefonico { get; set; }
        public Boolean Defecto { get; set; }
        public Boolean Disponible { get; set; }
        [ForeignKey("Continente")]
        public long IdContinente { get; set; }
        [ForeignKey("Idiomas")]
        public long IdIdioma { get; set; }

        public virtual Idiomas? Idiomas { get; set; }
        public virtual Continente? Continente { get; set; }
        public virtual ICollection<Estados>? Estados { get; set; }
        public virtual ICollection<Regiones>? Regiones { get; set; } 
    }
}
