using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;





using NicoAssistRemake.Data.Entities;
using NicoAssistRemake.Data.Interfaces;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository;

using PuntoDeVentaData.Entities.Security;
using Data.Interfaces.SecurityInterfaces;
using Data.Repository.UtilitiesRepository;
using Data.Interfaces.UserInterfaces;
using LinkQuality.Data.Repository.UserRepository;
using LinkQuality.Data.Repository.SecurityRepository;
using LinkQuality.Data.Repository.SeguridadRepository;
using Data.Interfaces.TemplateInterfaces;
using Data.Repository.TemplateRepository;
using Data;
namespace NicoAssistRemake.Data;

public static class DependencyContainer
    {

    public static IServiceCollection DependencyEF(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IdentityDbContext<ApplicationUser, ApplicationRole, string>, ApplicationDbContext>();

        //services.AddDbContext<ApplicationDbContext>();
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        //services.AddScoped<UsersInterface, UsersRepository>();


        //Vitaprohelpdesk
        services.AddScoped<CasosInterface, CasosRepository>();
        services.AddScoped<TerritorioInterface, TerritorioRepository>();
        services.AddScoped<ProductoInterface, ProductoRepository>();
        services.AddScoped<CategoriasInterface, CategoriasRepository>();
        services.AddScoped<CategoriasInterface, CategoriasRepository>();
        services.AddScoped<ClienteInterface, ClienteRepository>();
        services.AddScoped<ArchivosCargaInterface, ArchivosCargaRepository>();
        services.AddScoped<SolicitanteInterface, SolicitanteRepository>();
        services.AddScoped<PreguntaCatalogoInterface, PreguntaCatalogoRepository>();
        services.AddScoped<AreasReclamosInterface, AreasReclamosRepository>();
        services.AddScoped<TipoReconocimientoInterface, TipoReconocimientoRepository>();
        services.AddScoped<EstadoIncidenciaInterface, EstadoIncidenciaRepository>();
        services.AddScoped<EstadoProcesoFichaInterface, EstadoProcesoFichaRepository>();
        services.AddScoped<MotivoInterface, MotivoRepository>();
        services.AddScoped<AsesorTecnicoInterface, AsesorTecnicoRepository>();
        services.AddScoped<PuntoDeVentaInterface, PuntoDeVentaRepository>();
        services.AddScoped<CorreoNotificationInterface, CorreoNotificationRepository>();
        services.AddScoped<IdiomaInterface, IdiomaRepository>();
        services.AddScoped<PaisesInterface, PaisesRepository>();
        services.AddScoped<RegionesInterface, RegionesRepository>();
        services.AddScoped<CargaCorreoInterface, CargaCorreoRepository>();
        services.AddScoped<CiudadesInterface, CiudadesRepository>();
        services.AddScoped<TipoIncidenciaInterface, TipoIncidenciaRepository>();
        services.AddScoped<GestorReclamoInterface, GestorReclamoRepository>();
        services.AddScoped<RequisitosTipoFichaInterface, RequisitosTipoFichaRepository>();
        services.AddScoped<ResponsableReclamoInterface, ResponsableReclamoRepository>();
        services.AddScoped<SubMotivoInterfaces, SubMotivoRepository>();
        services.AddScoped<TemporalMatrizCausalesInterface, TemporalMatrizCausalesRepository>();
        services.AddScoped<ArchivosInterface, ArchivosRepository>();
        services.AddScoped<AreasResponsablesInterface, AreasResponsablesRepository>();
        services.AddScoped<AsesorComercialInterface, AsesorComercialRepository>();
        services.AddScoped<FacturaInterface, FacturaRepository>();
        services.AddScoped<FacturaDetalleInterface, FacturaDetalleRepository>();
        services.AddScoped<RutasInterface, RutasRepository>();
        services.AddScoped<TablaMatrizInterface, TablaMatrizRepository>();
        services.AddScoped<MatrizInterface, MatrizRepository>();
        services.AddScoped<IncidenciaInterface, IncidenciaRepository>();
        services.AddScoped<EncuestaIncidenciaInterface, EncuestaIncidenciaRepository>();
        services.AddScoped<LogAccionesIncidenciasInterface, LogAccionesIncidenciaRepository>();
        services.AddScoped<RespuestaEncuestaIncidenciaInterface, RespuestaEncuestaIncidenciaRepository>();
        services.AddScoped<TemporalIncidenciasInterface, TemporalIncidenciasRepository>();
        services.AddScoped<CategoriaSeleccionadaInterface, CategoriaSeleccionadaRepository>();
        services.AddScoped<ProductosIncidenciasInterface, ProductosIncidenciasRepository>();
        services.AddScoped<TipoFichaInterface, TipoFichaRepository>();
        services.AddScoped<AccionesRequisitosFichaInterface, AccionesRequisitosFichaRepository>();
        services.AddScoped<UserInterface, UserRepository>();
        services.AddScoped<SeguimentoIncideciasInterface, SeguimientoIncideciaRepository>();

            services.AddScoped<IMenuRolRepository, MenuRoleRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IAuditoriaAccesosRepository, AuditoriaAccesosRepository>();
            //services.AddScoped<IEmailTemplate, T>
            services.AddScoped<IEmailTemplate, TemplateRepository>();
            

            return services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
        }
    }

