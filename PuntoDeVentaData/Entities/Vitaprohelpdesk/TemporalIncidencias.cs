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
    public class TemporalIncidencias : CrudEntities
    {
        [Key]
        public long IdIncidencias { get; set; }
        public DateTime FechaReporteIncidencias { get; set; }
        [MaxLength(900)]
        public string? ReceptorIncidencia { get; set; }
        [ForeignKey("AsesorComercial")]
        public long IdAsesorComercial { get; set; }
        [ForeignKey("AsesorTecnico")]
        public long? IdAsesorTecnico { get; set; }
        [ForeignKey("GestorReclamo")]
        public long? IdGestorReclamo { get; set; }
        public DateTime FechaFicha { get; set; }
        [MaxLength(900)]
        public string? CodigoFicha { get; set; }
        [ForeignKey("Territorio")]
        public long? IdTerritorio { get; set; }
        public Boolean DevolucionProducto { get; set; }
        public Boolean CambioProducto { get; set; }
        public Boolean Compensacion { get; set; }
        public int CantidadDevolucionProducto { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoDevolucionProducto { get; set; }
        public int CantidadCambioProducto { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoCompensacion  { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MontoCambioProducto { get; set; }
        public int CantidadCompensacion { get; set; }
        [ForeignKey("TipoIncidencia")]
        public long IdTipoIncidencias { get; set; }
        [ForeignKey("Solicitante")]
        public long IdSolicitante { get; set; }
        [MaxLength(900)]
        public string? FinalObservacion { get; set; }
        [ForeignKey("EstadosIncidencias")]
        public long IdEstadoIncidencias { get; set; }
        [ForeignKey("ResponsableNivel1")]
        public long? IdResponsableNivel1 { get; set; }
        [ForeignKey("Casos")]
        public long IdCaso { get; set; }
        [ForeignKey("AreasReclamos")]
        public long IdAreaReclamo { get; set; }
        [ForeignKey("Motivo")]
        public long? IdMotivo { get; set; }
        [ForeignKey("SubMotivo")]
        public long IdSubMotivo { get; set; }
        [ForeignKey("ResponsableNivel2")]
        public long? IdResponsableNivel2 { get; set; }
        [ForeignKey("EstadoProcesoFicha")]
        public long IdEstadoProcesoFicha { get; set; }
        public Boolean EvNivel1 { get; set; }
        public DateTime FechaEvNivel1 { get; set; }
        public Boolean EvNivel2 { get; set; }
        public DateTime FechaEvNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostoAsociado { get; set; }
        public string? ObservacionesCostoAsociado { get; set; }
        public Boolean AnalisisConcluido { get; set; }
        public DateTime FechaAnalisisConcluido { get; set; }
        public Boolean EvComercial { get; set; }
        public DateTime FechaEvComercial { get; set; }
        public Boolean CierreEfectivo { get; set; }
        public DateTime FechaCierreEfectivo { get; set; }
        public Boolean Generada { get; set; }
        public DateTime FechaMaximaCierreAnalisis { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiasCierreEfectivo { get; set; }
        [MaxLength(1200)]
        public string? CodigoSAP { get; set; }
        [MaxLength(1200)]
        public string? Resolucion { get; set; }
        [MaxLength(1200)]
        public string? SubCodigo { get; set; }
        [MaxLength(1200)]
        public string? Codigo { get; set; }
        [ForeignKey("TipoFicha")]
        public long? IdTipoFicha { get; set; }
        public Boolean DecisoNivel1 { get; set; }
        public Boolean DecisorNivel2 { get; set; }
        public Boolean ProcedeAnalisisConcluido { get; set; }
        public Boolean NoProcedeAnalisisConcluido { get; set; }
        [MaxLength(900)]
        public string? OtroComentario { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PlazoNivel1 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PlazoNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PlazoTotal { get; set; }
        public DateTime FehaProcedeIncidencia { get; set; }
        [MaxLength(900)]
        public string? ComentarioProcede { get; set; }
        [MaxLength(300)]
        public string? NombrePersonaProcede { get; set; }
        [MaxLength(900)]
        public string? ComentarioEvComercial { get; set; }
        [MaxLength(300)]
        public string? PersonaEvComercial { get; set; }
        public Boolean ProcedeEvComercial { get; set; }
        public Boolean NoProcedeEvComercial { get; set; }
        public DateTime FechaEvComercialAccion { get; set; }
        [MaxLength(300)]
        public string? NombreEvComercial { get; set; }
        public DateTime FechaEnvioCorreoEvComercial { get; set; }
        public Boolean NotificacionNivel2Enviado { get; set; }
        public virtual AsesorComercial? AsesorComercial { get; set; }
        public virtual AsesorTecnico? AsesorTecnico { get; set; }
        public virtual GestorReclamo? GestorReclamo { get; set; }
        public virtual Territorio? Territorio { get; set; }
        public virtual TipoIncidencia? TipoIncidencia { get; set; }
        public virtual Solicitante? Solicitante { get; set; }
        public virtual EstadosIncidencias? EstadosIncidencias { get; set; }
        public virtual Casos? Casos { get; set; }
        public virtual AreasReclamos? AreasReclamos { get; set; }
        public virtual Motivo? Motivo { get; set; }
        public virtual SubMotivo? SubMotivo { get; set; }
        public virtual EstadoProcesoFicha? EstadoProcesoFicha { get; set; }
        public virtual TipoFicha? TipoFicha { get; set; }
        public virtual ResponsableReclamo? ResponsableNivel1 { get; set; }
        public virtual ResponsableReclamo? ResponsableNivel2 { get; set; }


    
    }


        


}
