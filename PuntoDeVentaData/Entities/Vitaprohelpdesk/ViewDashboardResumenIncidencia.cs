using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Entities.Vitaprohelpdesk
{
    [Keyless]
    public class ViewDashboardResumenIncidencia
    {
        public long IdIncidencias { get; set; }
        public long? IdTipoIncidencias {get; set; }
        [MaxLength(900)]
        public string? CodReclamo { get; set; }
        [MaxLength(900)]
        public string? TipoSolicitud {  get; set; }
        public DateTime? FechaReclamo { get; set; }
        [MaxLength(900)]
        public string? Clasificacion { get; set; }
        [MaxLength(900)]
        public string? SubCodigo { get; set; }
        [MaxLength(900)]
        public string? SubMotivo { get; set; }
        [MaxLength(900)]
        public string? CodigoMotivo { get;set; }
        [MaxLength(900)]
        public string? Motivo { get; set; }
        [MaxLength(900)]
        public string? AreaEvaluado { get; set; }

        public int? DiasAnalisis { get; set; }
        public DateTime FechaMaximaCierreMatriz { get; set; }
        public DateTime FechaCierreAnalisis { get; set; }
        public int? Dias { get; set; }
        [MaxLength(900)]
        public string? Status { get; set; }
        [MaxLength(350)]
        public string? ClienteSolicitante { get; set; }
        [MaxLength(350)]
        public string? ClienteFinal { get; set; }
        [MaxLength(500)]
        public string? Territorio { get; set; }
        [MaxLength(350)]
        public string? Region { get; set; }
        [MaxLength(350)]
        public string? CodSap { get; set; }
        [MaxLength(500)]
        public string? ReferenciaPedidoDevolucion { get; set; }
        [MaxLength(500)]
        public string DecisoReclamo { get; set; } = "";
        [MaxLength(900)]
        public string? Resolucion { get; set; }

        public int? Aprobacion { get; set; }
        public DateTime? FechaCierreEfectivo { get; set; }
        [MaxLength(900)]
        public string? NumeroFactura { get; set; }
        [MaxLength(900)]
        public string? GestorReclamos { get; set; }
        [MaxLength(900)]
        public string? CostoAsociadosTransporteDesinfeccionOtros { get; set; }
        public int? Mes { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double? PromedioSatisfaccion { get; set; }
        public long IdMotivo { get; set; }
        public long IdSubMotivo { get; set; }
        public long IdSolicitante { get; set; }
        public long IdAreaReclamos { get; set; }
        public long IdAsesorComercial { get; set; }
        public long IdGestorReclamo { get; set; }
        public long IdMatriz { get; set; }
        public long IdTipoFicha { get; set; }
        public long IdEstadoProcesoFicha { get; set; }
        public long IdTerritorio { get; set; }  
        public long IdResponsableReclamos { get; set; }
    }
}
