using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Dto.VitaprohelpdeskDto
{
    public class TemporalIncidenciasDto
    {
        public long IdIncidencias { get; set; }
        public DateTime FechaReporteIncidencias { get; set; }
        public string? ReceptorIncidencia { get; set; }
        
        public long IdAsesorComercial { get; set; }
       
        public long IdAsesorTecnico { get; set; }
        
        public long IdGestorReclamo { get; set; }
        public DateTime FechaFicha { get; set; }
        public string? CodigoFicha { get; set; }
        
        public long IdTerritorio { get; set; }
        public Boolean DevolucionProducto { get; set; }
        public Boolean CambioProducto { get; set; }
        public Boolean Compensacion { get; set; }
        public int CantidadDevolucionProducto { get; set; }
        public Double MontoDevolucionProducto { get; set; }
        public int CantidadCambioProducto { get; set; }
        public Double MontoCambioProducto { get; set; }
        public int CantidadCopensacion { get; set; }
        
        public long IdTipoIncidencias { get; set; }
        
        public long IdSolicitante { get; set; }
        public string? FinalObservacion { get; set; }
        
        public long IdEstadoIncidencias { get; set; }
        
        public long IdResponsableNivel1 { get; set; }
        
        public long IdCaso { get; set; }
        
        public long IdAreaReclamo { get; set; }
        
        public long IdMotivo { get; set; }
        
        public long IdSubMotivo { get; set; }
        
        public long IdResponsableNivel2 { get; set; }
        
        public long IdEstadoProcesoFicha { get; set; }
        public Boolean EvNivel1 { get; set; }
        public DateTime FechaEvNivel1 { get; set; }
        public Boolean EvNivel2 { get; set; }
        public DateTime FechaEvNivel2 { get; set; }
        public Double CostoAsociado { get; set; }
        public string? ObservacionesCostoAsociado { get; set; }
        public Boolean AnalisisConcluido { get; set; }
        public DateTime FechaAnalisisConcluido { get; set; }
        public Boolean EvComercial { get; set; }
        public DateTime FechaEvComercial { get; set; }
        public Boolean CierreEfectivo { get; set; }
        public DateTime FechaCierreEfectivo { get; set; }
        public Boolean Generada { get; set; }
        public DateTime FechaMaximaCierreAnalisis { get; set; }
        public Double DiasCierreEfectivo { get; set; }
        public string? CodigoSAP { get; set; }
        public string? Resolucion { get; set; }
        public string? SubCodigo { get; set; }
        public string? Codigo { get; set; }
        
        public long IdTipoFicha { get; set; }
        public Boolean DecisoNivel1 { get; set; }
        public Boolean DecisorNivel2 { get; set; }
        public Boolean ProcedeAnalisisConcluido { get; set; }
        public Boolean NoProcedeAnalisisConcluido { get; set; }
        public string? OtroComentario { get; set; }
        public Double PlazoNivel1 { get; set; }
        public Double PlazoNivel2 { get; set; }
        public Double PlazoTotal { get; set; }
        public DateTime FehaProcedeIncidencia { get; set; }
        public string? ComentarioProcede { get; set; }
        public string? NombrePersonaProcede { get; set; }
        public string? ComentarioEvComercial { get; set; }
        public string? PersonaEvComercial { get; set; }
        public Boolean ProcedeEvComercial { get; set; }
        public Boolean NoProcedeEvComercial { get; set; }
        public DateTime FechaEvComercialAccion { get; set; }
        public string? NombreEvComercial { get; set; }
        public DateTime FechaEnvioCorreoEvComercial { get; set; }
        public Boolean NotificacionNivel2Enviado { get; set; }
    }
}
