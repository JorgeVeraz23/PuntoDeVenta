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
    public class CargaMatriz : CrudEntities
    {
        [Key]
        public long IdCargaMatriz { get; set; }
        [MaxLength(255)]
        public string? Caso {  get; set; }
        [MaxLength(255)]
        public string? SubCodigo { get; set; }
        [MaxLength(255)]
        public string? AreaResponsable { get; set; }
        [MaxLength(255)]
        public string Codigo { get; set; } = "";
        [MaxLength(255)]
        public string Motivo { get; set; } = "";
        [MaxLength(255)]
        public string? SubMotivo { get; set; }
        [MaxLength(255)]
        public string Clasificacion { get; set; } = "";
        [MaxLength(255)]
        public string RequisitosBasicos { get; set; } = "";
        [MaxLength(255)]
        public string AccionInmediada { get; set; } = ""; 
        [MaxLength(255)]
        public string? ResponsableNivel1Ecuador { get; set; }
        [MaxLength(255)]
        public string? ResponsableNivel1Perú { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Plazo1 { get; set; }
        [MaxLength(255)]
        public string? ResponsableNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Plazo2 { get; set; }
        [MaxLength(255)]
        public string? TipoDeReconocimiento { get; set; }
        public double? CodRcSap { get; set; }
        [MaxLength(255)]
        public string? CausalSap { get; set; }
        public long IdMotivo { get; set; }
        public long IdSubMotivo { get; set; }
        public long IdResponsable1 { get; set; }
        public long IdResponsable2 { get;set; }
        public long IdCaso { get; set; }
        public long IdRequisito { get; set; }
        public long IdTipoReconocimiento { get; set; }
        public long IdAccion { get; set; }  
        public long IdTipoFicha { get; set; }
        public long IdAreaResponsable { get; set; }

    }
}
