using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class SeguimientoIncidenciasDto
    {      
        public decimal? diasPlazo1 { get; set; }
        public decimal? diasPlazo2 { get; set; }
        public int? diasTotales { get; set; }
        public string numero { get; set; } = "";
        public string NumeroEC { get; set; }= "";
        public string Codigo { get; set; } = "";
        public long IdIncidenncias { get; set; }
        public string TipoSolicitud { get; set; } = "";


        public string FechaReclamo { get; set; }
        public string Clasificacion { get; set; } = "";
        public string SubCodigo { get; set; } = "";
        public string SubMotivo { get; set; } = "";
        public string CodigoMotivo { get; set; } = "";
        public string AreaEvaluado { get; set; } = "";
        public int DiasAnalisis { get; set; }
        public string FechaMaximaCierreMatriz { get; set; } = "";
        public string FechaCierreAnalisis { get; set; } = "";
        
        public int Dias { get; set; }
        public string Status { get; set; } = "";
        public long? IdEstadoProcesoFicha { get; set; }
        public long? IdEstadoIncidencias { get; set; }


        public string CodigoNodo { get; set; } = "";
        public string Nodo { get; set; } = "";
        public string ClienteSolicitante { get; set; } = "";
        public string CodigoCliente { get; set; } = "";
        public string CodigoClienteFinal { get; set; } = "";
        public string COD_GRUPO_CLIENTE_PRE { get; set; } = "";
        public string GRUPO_CLIENTE_PRE { get; set; } = "";
        public string Region { get; set; } = "";
        public string CodSap { get; set; } = "";
        public string NumeroFactura { get; set; } = "";
        public string ReferenciaPedidoDevolucion { get; set; } = "";
        public string DecisorReclamo { get; set; } = "";
        public string Resolucion { get; set; } = "";
        public string DiasCierreEfectivo { get; set; } = "";
        public string Aprobacion { get; set; } = "";
        public string FechaCierreEfectivo { get; set; } = "";
        public string PedidoDevolucion { get; set; } = "";
        public string GestorReclamos { get; set; } = "";
        public string CostoAsociadosTransporteDesinfeccionOtros { get; set; } = "";
        public string Mes { get; set; } = "";
        public string FechaRegistro { get; set; } = "";

    }
}
