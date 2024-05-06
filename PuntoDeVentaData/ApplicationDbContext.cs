using Data.Entities.Configurations;
using LinkQuality.Data.Repository.UtilitiesRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NicoAssistRemake.Data.Entities.Utilities;
using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;
using PuntoDeVentaData.Entities.Parameters;
using PuntoDeVentaData.Entities.Security;
using PuntoDeVentaData.Entities.Templates;
using PuntoDeVentaData.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

        #region Vitaprohelpdesk
        public virtual DbSet<Casos> Casos { get; set; }
        public virtual DbSet<Territorio> Territorios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Productos> Productoss { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CategoriaCamaron> CategoriaCamarons { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ArchivosCarga> ArchivosCargas { get; set; }
        public virtual DbSet<Solicitante> Solicitantes { get; set; }
        public virtual DbSet<PreguntaCatalogo> PreguntaCatalogos { get; set; }
        public virtual DbSet<AreasReclamos> AreasReclamos { get; set; }
        public virtual DbSet<TipoReconocimiento> TipoReconocimientos { get; set; }
        public virtual DbSet<EstadosIncidencias> EstadosIncidencias { get; set; }
        public virtual DbSet<EstadoProcesoFicha> EstadoProcesoFichas { get; set; }
        public virtual DbSet<Motivo> Motivos { get; set; }
        public virtual DbSet<AsesorTecnico> AsesorTecnicos { get; set; }
        public virtual DbSet<PuntoVenta> PuntoVentas { get; set; }
        public virtual DbSet<CorreoNotification> CorreoNotifications { get; set; }
        public virtual DbSet<Idiomas> Idiomas { get; set; }
        public virtual DbSet<Continente> Continentes { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<CargaCorreo> CargaCorreos { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<TipoIncidencia> TipoIncidencias { get; set; }
        public virtual DbSet<GestorReclamo> GestorReclamos { get; set; }
        public virtual DbSet<RequisitosTipoFicha> RequisitosTipoFichas { get; set; }
        public virtual DbSet<ResponsableReclamo> ResponsableReclamos { get; set; }
        public virtual DbSet<SubMotivo> SubMotivos { get; set; }
        public virtual DbSet<TemporalMatrizCausales> TemporalMatrizCausales { get; set; }
        public virtual DbSet<Archivos> Archivos { get; set; }
        public virtual DbSet<AreasResponsables> AreasResponsables { get; set; }
        public virtual DbSet<AsesorComercial> AsesorComercials { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public virtual DbSet<Rutas> Rutass { get; set; }
        public virtual DbSet<TablaMatriz> TablaMatrizs { get; set; }
        public virtual DbSet<Matriz> Matrizs { get; set; }
        public virtual DbSet<Incidencias> Incidencias { get; set; }
        public virtual DbSet<EncuestaIncidencia> EncuestaIncidencias { get; set; }
        public virtual DbSet<LogAccionesIncidencia> LogAccionesIncidencias { get; set; }
        public virtual DbSet<RespuestaEncuestaIncidencia> RespuestaEncuestaIncidencias { get; set; }
        public virtual DbSet<TemporalIncidencias> TemporalIncidencias { get; set; }
        public virtual DbSet<CategoriaSeleccionada> CategoriaSeleccionadas { get; set; }
        public virtual DbSet<ProductosIncidencias> ProductosIncidencias { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }
        public virtual DbSet<ArchivosCargaIncidencia> ArchivosCargaIncidencia { get; set; }
        public virtual DbSet<CargaMatriz> CargaMatrizs { get; set; }
        public virtual DbSet<ClaimsUsuario> ClaimsUsuarios { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Hoja2> Hoja2s { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<SeguridadArea> SeguridadAreas { get; set; }
        public virtual DbSet<SeguridadNivele> SeguridadNiveles { get; set; }
        public virtual DbSet<PermisosRuta> PermisosRutas { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<ViewDashboardResumenIncidencia> ViewDashboardResumenIncidencias { get; set; }
        public virtual DbSet<TipoFicha> TipoFichas { get; set; }
        public virtual DbSet<AccionesRequisitoFicha> AccionesRequisitoFichas { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<ValidacionPreguntas> ValidacionPreguntas { get; set; }
        public virtual DbSet<Encuesta> Encuestas { get; set; }
        public virtual DbSet<EncuestaDetalle> EncuestaDetalles { get; set; }
        public virtual DbSet<GrupoDePreguntas> GrupoDePreguntas { get; set; }
        public virtual DbSet<Preguntas> Preguntas { get; set; }
        public virtual DbSet<Respuestas> Respuestas { get; set; }

        #endregion


        #region RESOURCE
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Parameters> Parameters { get; set; }
        public virtual DbSet<Notificacion> Notificacions { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<BucketFile> BucketFiles { get; set; }

        #endregion

        #region SECURITY
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuRole> MenuRoles { get; set; }
        public virtual DbSet<AuditoryAccess> AuditoryAccesses { get; set; }
        public virtual DbSet<ApplicationVersion> ApplicationVersions { get; set; }
        #endregion

        #region SECURITY CONFIGS
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<IdentityUserRole<string>> UserRoles { get; set;}
        #endregion

        #region CLASIFICATION
        public virtual DbSet<ParameterType> ParameterTypes { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurationDefaultRoles();
            modelBuilder.ConfigurationDefaultDataUsuario();
            modelBuilder.ConfigurationDefaultDataUserRol();
            modelBuilder.ConfigurationTablesUsersAndRols();
            modelBuilder.ConfigurationDefaultDataTipoParametro();
            modelBuilder.ConfigurationDefaultDataParametros();
            modelBuilder.ConfigurationDefaultDataMenu();

            modelBuilder.ConfigurationDefaultDataMenuRole();
            modelBuilder.ConfigurationDefaultDataEmailTemplate();

            
        }

        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries()
                            where entry.State == EntityState.Modified || entry.State == EntityState.Added
                            select entry.Entity);

            var validationResults = new List<ValidationResult>();
            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    // throw new ValidationException() or do whatever you want
                }
            }
            return base.SaveChanges();
        }
    }
}
