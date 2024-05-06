using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class IncideniaDto
    {
        public long IdIncidencias { get; set; }
        public DateTime? FechaReporteIncidencia { get; set; }
        public string ReceptorIncidencia { get; set; }
        public bool NotificacionNivel2Enviada { get; set; }
        
        public long? IdAsesorComercial { get; set; }
        
        public long? IdAsesorTecnico { get; set; }
        
        public long? IdGestorReclamo { get; set; }
        public DateTime? FechaProcedeIncidencia { get; set; }
        public string ComentarioProcede { get; set; }
        public string ComnetarioEvComercial { get; set; }
        public string PersonaEvComercial { get; set; }
        public DateTime? FechaFicha { get; set; }
        public string CodigoFicha { get; set; }

        public long? IdTerritorio { get; set; }
        public bool DevolucionProducto { get; set; }
        public bool CambioProducto { get; set; }
        public bool Otros { get; set; }
        public bool Compensacion { get; set; }
        public int? CantidadDevolucionProducto { get; set; }
        public decimal? MontoDevolucionProducto { get; set; }
        public int? CantidadCambioProducto { get; set; }
        public string OtrosMotivosProductos { get; set; }
        public decimal? MontoCambioProducto { get; set; }
        public int? CantidadCompensacion { get; set; }
        public decimal? MontoCompensacion { get; set; }
        
        public long? IdTipoIncidencias { get; set; }
        
        public long? IdSolicitante { get; set; }
        public string FinalObservacion { get; set; }
        public long? IdEstadoIncidencias { get; set; }
        
        public long? IdResponsableNivel1 { get; set; }
        
        public long? IdResponsableNivel2 { get; set; }
        
        public long? IdCaso { get; set; }
        
        public long? IdAreaReclamo { get; set; }
        
        public long? IdMotivo { get; set; }
        
        public long? IdSubmotivo { get; set; }
        //public long? IdCorreoNotificacion { get; set; }
        
        public long? IdEstadoProcesoFicha { get; set; }
        public bool EvNivel1 { get; set; }
        public bool Generada { get; set; }
        public DateTime? FechaEvNivel1 { get; set; }
        public bool EvNivel2 { get; set; }
        public DateTime? FechaEvNivel2 { get; set; }
        public decimal? CostoAsociado { get; set; }
        public string ObservacionesCostoAsociado { get; set; }
        public bool AnalisisConcluido { get; set; }
        public bool ProcedeAnalisisConcluido { get; set; }
        public bool NoProcedeAnalisisConcluido { get; set; }
        public bool ProcedeEvComercial { get; set; }
        public bool NoProcedeEvComercial { get; set; }
        public string OtroComentario { get; set; }
        public DateTime? FechaAnalisisConcluido { get; set; }
        public DateTime? FechaMaximaCierreAnalisis { get; set; }
        public DateTime? FechaEvComercialAccion { get; set; }

        public decimal? DiasCierreEfectivo { get; set; }
        public decimal? DiasCierreAnalisis { get; set; }
        public string NumeroFactura { get; set; }
        public string Aprobacion { get; set; }
        public bool EvComercial { get; set; }
        public DateTime? FechaEvComercial { get; set; }
        public string CodigoSAP { get; set; }
        public bool CierreEfectivo { get; set; }
        public DateTime? FechaCierreEfectivo { get; set; }
        public string Resolucion { get; set; }
        public string SubCodigo { get; set; }
        public string Codigo { get; set; }
        public long? IdTipoFicha { get; set; }
        public bool DecisorNivel1 { get; set; }
        public bool DecisorNivel2 { get; set; }
        public decimal? PlazoNivel1 { get; set; }
        public decimal? PlazoNivel2 { get; set; }
        public decimal? PlazoTotal { get; set; }
        public string NombrePersonaProcede { get; set; }
        public string NombreEvComercial { get; set; }
        public string ComentarioVistaEvComercial { get; set; }
        public string ReferenciaPedidoDevolucion { get; set; }

        public DateTime? FechaEnvioCorreoEvComercial { get; set; }
    }

    


    public class MostrarIncidenciaDto
    {
        public long IdIncidencias { get; set; }
        public string CodigoIncidencia { get; set; }
        public string TipoIncidencia { get; set; }
        public DateTime? FechaFicha { get; set; }
        public string Motivo { get; set; }
        public string Submovito { get; set; }
        public string AreaResponsable { get; set; }
        public decimal? PlazoEvaluacion { get; set; }
        public DateTime? FechaRealCierreAnalisis { get; set; }
        public string EstadoIncidencia { get; set; }
        public string TerritorioNombre { get; set; }
        public DateTime? FechaCierreEfectivo { get; set; }
        public string ClienteFinal { get; set; }
        public string Solicitante { get; set; }
        public string CodigoSap { get; set; }
    }
}

    

    


