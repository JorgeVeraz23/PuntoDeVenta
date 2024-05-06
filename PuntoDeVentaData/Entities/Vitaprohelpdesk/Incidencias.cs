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
    public class Incidencias : CrudEntities
    {
        [Key]
        public long IdIncidencias { get; set; }
        public DateTime? FechaReporteIncidencia { get; set; }
        [MaxLength(300)]
        public string ReceptorIncidencia { get; set; } = "";
        public bool NotificacionNivel2Enviada { get; set; }
        [ForeignKey("AsesorComercial")]
        public long? IdAsesorComercial { get; set; }
        [ForeignKey("AsesorTecnico")]
        public long? IdAsesorTecnico { get; set; }
        [ForeignKey("GestorReclamo")]
        public long? IdGestorReclamo { get; set; }
        public DateTime? FechaProcedeIncidencia { get; set; }
        [MaxLength(300)]
        public string ComentarioProcede { get; set; } = "";
        [MaxLength(300)]
        public string ComnetarioEvComercial { get; set; } = "";
        [MaxLength(300)]
        public string PersonaEvComercial { get; set; } = "";
        public DateTime? FechaFicha { get; set; }
        public string CodigoFicha { get; set; } = "";
        [ForeignKey("Territorio")]

        public long? IdTerritorio { get; set; }
        public bool DevolucionProducto { get; set; }
        public bool CambioProducto { get; set; }
        public bool Otros { get; set; }
        public bool Compensacion { get; set; }
        public int? CantidadDevolucionProducto { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MontoDevolucionProducto { get; set; }
        public int? CantidadCambioProducto { get; set; }
        [MaxLength(300)]
        public string? OtrosMotivosProductos { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MontoCambioProducto { get; set; }
        public int? CantidadCompensacion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MontoCompensacion { get; set; }
        [ForeignKey("TipoIncidencia")]
        public long? IdTipoIncidencias { get; set; }
        [ForeignKey("Solicitante")]
        public long? IdSolicitante { get; set; }
        [MaxLength(300)]
        public string? FinalObservacion { get; set; }
        public long? IdEstadoIncidencias { get; set; }
        [ForeignKey("ResponsableNivel1")]
        public long? IdResponsableNivel1 { get; set; }
        [ForeignKey("ResponsableNivel2")]
        public long? IdResponsableNivel2 { get; set; }
        [ForeignKey("Casos")]
        public long? IdCaso { get; set; }
        [ForeignKey("AreaReclamos")]
        public long? IdAreaReclamo { get; set; }
        [ForeignKey("Motivo")]
        public long? IdMotivo { get; set; }
        [ForeignKey("SubMotivo")]
        public long? IdSubmotivo { get; set; }
        [ForeignKey("CorreoNotification")]
        public long? IdCorreoNotificacion { get; set; }
        [ForeignKey("EstadoProcesoFicha")]
        public long? IdEstadoProcesoFicha { get; set; }
        public bool EvNivel1 { get; set; }
        public bool Generada { get; set; }
        public DateTime? FechaEvNivel1 { get; set; }
        public bool EvNivel2 { get; set; }
        public DateTime? FechaEvNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? CostoAsociado { get; set; }
        [MaxLength(1000)]
        public string? ObservacionesCostoAsociado { get; set; }
        public bool AnalisisConcluido { get; set; }
        public bool ProcedeAnalisisConcluido { get; set; }
        public bool NoProcedeAnalisisConcluido { get; set; }
        public bool ProcedeEvComercial { get; set; }
        public bool NoProcedeEvComercial { get; set; }
        [MaxLength(900)]
        public string? OtroComentario { get; set; }
        public DateTime? FechaAnalisisConcluido { get; set; }
        public DateTime? FechaMaximaCierreAnalisis { get; set; }
        public DateTime? FechaEvComercialAccion { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiasCierreEfectivo { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? DiasCierreAnalisis { get; set; }
        [MaxLength(300)]
        public string NumeroFactura { get; set; } = "";
        [MaxLength(500)]
        public string? Aprobacion { get; set; }
        public bool EvComercial { get; set; }
        public DateTime? FechaEvComercial { get; set; }
        [MaxLength(300)]
        public string? CodigoSAP { get; set; }
        public bool CierreEfectivo { get; set; }
        public DateTime? FechaCierreEfectivo { get; set; }
        [MaxLength(300)]
        public string? Resolucion { get; set; }
        [MaxLength(300)]
        public string? SubCodigo { get; set; }
        [MaxLength(300)]
        public string? Codigo { get; set; }
        public long? IdTipoFicha { get; set; }
        public bool DecisorNivel1 { get; set; }
        public bool DecisorNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PlazoNivel1 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PlazoNivel2 { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PlazoTotal { get; set; }
        [MaxLength(300)]
        public string? NombrePersonaProcede { get; set; }
        [MaxLength(300)]
        public string? NombreEvComercial { get; set; }
        [MaxLength(900)]
        public string? ComentarioVistaEvComercial { get; set; }
        [MaxLength(900)]
        public string? ReferenciaPedidoDevolucion { get; set; }

        public DateTime? FechaEnvioCorreoEvComercial { get; set; }
        public virtual Motivo? Motivo { get; set; }
        public virtual TipoFicha? TipoFicha { get; set; }
        public virtual SubMotivo? SubMotivo { get; set; }
        public virtual AreasReclamos? AreaReclamos { get; set; }
        [InverseProperty("IncidenciaIdResponsableNivel1")]
        public virtual ResponsableReclamo? ResponsableNivel1 { get; set; }
        [InverseProperty("IncidenciaIdResponsableNivel2")]
        public virtual ResponsableReclamo? ResponsableNivel2 { get; set; }
        public virtual Casos? Casos { get; set; }
        public virtual CorreoNotification? CorreoNotification { get; set; }
        public virtual TipoIncidencia? TipoIncidencia { get; set; }
        public virtual AsesorComercial? AsesorComercial { get; set; }
        public virtual AsesorTecnico? AsesorTecnico { get; set; }
        public virtual Territorio? Territorio { get; set; }
        public virtual GestorReclamo? GestorReclamo { get; set; }
        public virtual Solicitante? Solicitante { get; set; }
        public virtual EstadosIncidencias? EstadosIncidencias { get; set; }
        public virtual EstadoProcesoFicha? EstadoProcesoFicha { get; set; }
        public ICollection<LogAccionesIncidencia>? LogAccionesIncidencia { get; set; }

        public ICollection<ProductosIncidencias>? ProductosIncidencias { get; set; }
        public ICollection<CategoriaSeleccionada>? categoriaSeleccionadas { get; set; }
        public ICollection<EncuestaIncidencia>? encuestaIncidencias { get; set; }
        public ICollection<ArchivosCargaIncidencia>? archivosCargaIncidencias { get; set; }

    }
}
