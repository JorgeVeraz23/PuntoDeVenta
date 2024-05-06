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
    public class Solicitante : CrudEntities
    {
        [Key]
        public long idSolicitante { get; set; }
        [MaxLength(1200)]
        public string? SolicitateSap { get; set; }
        [MaxLength(300)]
        public string? NombreContacto { get; set; }
        [MaxLength(350)]
        public string? Email { get; set; }
        [MaxLength(20)]
        public string? Telefono { get; set; }
        [MaxLength(300)]
        public string? ClienteFinal { get; set; }
        [MaxLength(300)]
        public string? ContactoNombre { get; set; }
        [MaxLength(300)]
        public string? Correo { get; set; }
        [MaxLength(50)]
        public string? Celular { get; set; }
        [MaxLength(1200)]
        public string? CodigoSolicitante { get; set; }
        [MaxLength(1200)]
        public string? CodigoNodo { get; set; }
        [MaxLength(1200)]
        public string? Nodo { get; set; }
        [MaxLength(1200)]
        public string? CodigoDestinatario { get; set; }
        [MaxLength(1200)]
        public string COD_GRUPO_CLIENTE_PRE { get; set; } = "";
        [MaxLength(1200)]
        public string? GRUPO_CLIENTE_PRE { get; set; }
        public virtual ICollection<Incidencias>? Incidencias { get; set; }
        public virtual ICollection<TemporalIncidencias>? TemporalIncidencias { get; set; }
    }
}
