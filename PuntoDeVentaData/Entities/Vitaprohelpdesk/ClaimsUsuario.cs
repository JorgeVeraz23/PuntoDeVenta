using Data.Entities.Utilities;

using NicoAssistRemake.Data.Entities.Utilities;
using PuntoDeVentaData.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    public class ClaimsUsuario : CrudEntities
    {
        [Key]
        public long IdClaim { get; set; }
        [ForeignKey("ApplicationUser")]
        public string IdUsuario { get; set; } = "";
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}
