using Amazon.S3;
using Data;
using Data.Interfaces.SecurityInterfaces;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NicoAssistRemake.Data.Dto.VitaprohelpdeskDto;

using NicoAssistRemake.Data.Entities.Vitaprohelpdesk;

using NicoAssistRemake.Data.Interfaces.VitaprohelpdesdkInterface;
using PuntoDeVentaData.Dto.UtilitiesDTO;
using PuntoDeVentaData.Entities.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NicoAssistRemake.Data.Repository.VitaprohelpdeskRepository
{
    public class SeguimientoIncideciaRepository : SeguimentoIncideciasInterface
    {
        private readonly ApplicationDbContext _context;

        private readonly IUnitOfWorkRepository _unit;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private MessageInfoDTO infoDTO = new MessageInfoDTO();
        private readonly string _username;
        private readonly string _ip;


        public SeguimientoIncideciaRepository(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IUnitOfWorkRepository unitOfWorkRepository,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _unit = unitOfWorkRepository;

            _ip = httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _username = Task.Run(async () =>
            (
                await userManager.FindByNameAsync(
                    httpContextAccessor?.HttpContext?.User.Claims.FirstOrDefault(c => c.Type.Contains("email", StringComparison.CurrentCultureIgnoreCase))?.Value ?? ""
                )
            )?.UserName ?? "Desconocido").Result;
        }

       
        public async Task<List<SeguimientoIncidenciasDto>> GetAll()
        {

            CultureInfo culture = new CultureInfo("en-US");
            var list = await _context.Incidencias
                .Where(inc => inc.Active)
                .Select(Inc => new SeguimientoIncidenciasDto
                {

                    diasPlazo1 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel1, culture),
                    diasPlazo2 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel2, culture),
                    diasTotales = Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2),
                    numero = Inc.CodigoFicha.Substring(2),
                    NumeroEC = Inc.CodigoFicha.Substring(2).PadLeft(8, '0').Substring(0, 6),
                    Codigo = Inc.CodigoFicha.Substring(2),
                    IdIncidenncias = Inc.IdIncidencias,
                    TipoSolicitud = Inc.TipoIncidencia.Nombre,
                    FechaReclamo = Convert.ToDateTime(Inc.FechaFicha).ToString("dd/MM/yyyy"),
                    
                    Clasificacion = _context.Matrizs.FirstOrDefault(x => x.Active && x.IdSubMotivo == Inc.IdSubmotivo).TipoFicha.Nombre,
                    SubCodigo = Inc.SubMotivo.CodigoSubMotivo,
                    SubMotivo = Inc.SubMotivo.NombreSubMotivo,
                    CodigoMotivo = Inc.Motivo.CodigoMotivo,
                    AreaEvaluado = Inc.AreaReclamos.AreaReclamo,
                    DiasAnalisis = Inc.DiasCierreAnalisis == null ? Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2) : Convert.ToInt32(Inc.DiasCierreAnalisis) ,
                    FechaMaximaCierreMatriz = Convert.ToDateTime(Inc.FechaMaximaCierreAnalisis).ToString("dd/MM/yyyy"),
                    FechaCierreAnalisis = Inc.FechaAnalisisConcluido == null ? "" : Inc.FechaAnalisisConcluido.Value.ToString("dd/MM/yyyy") ,
                    Dias = Convert.ToInt32(Inc.PlazoTotal),
                    Status = Inc.EstadoProcesoFicha.Nombre,
                    IdEstadoProcesoFicha = Inc.IdEstadoProcesoFicha,
                    IdEstadoIncidencias = Inc.IdEstadoProcesoFicha,
                    
                    CodigoNodo = Inc.Solicitante.CodigoNodo,
                    Nodo = Inc.Solicitante.Nodo,
                    ClienteSolicitante = Inc.Solicitante.SolicitateSap,
                    CodigoCliente = Inc.Solicitante.CodigoSolicitante,
                    CodigoClienteFinal = Inc.Solicitante.CodigoDestinatario,
                    COD_GRUPO_CLIENTE_PRE = Inc.Solicitante.COD_GRUPO_CLIENTE_PRE,
                    GRUPO_CLIENTE_PRE = Inc.Solicitante.GRUPO_CLIENTE_PRE,
                    Region = Inc.Territorio.Nombre ?? "´--",
                    CodSap = Inc.CodigoSAP ?? "--",
                    NumeroFactura = Inc.NumeroFactura,
                    GestorReclamos = Inc.ResponsableNivel1.NombreResposable ?? "--",
                    CostoAsociadosTransporteDesinfeccionOtros = Inc.ObservacionesCostoAsociado ?? "--",
                    Mes = Convert.ToDateTime(Inc.FechaReporteIncidencia).Month.ToString(),
                    FechaRegistro = Convert.ToDateTime(Inc.FechaReporteIncidencia).ToString("dd/MM/yyyy"),

                }).ToListAsync();

            return list;
        }

        public async Task<List<SeguimientoIncidenciasDto>> GetSeguimientoIncidenciaByFilter(DateTime FechaDesde, DateTime FechaHasta, long IdTipoIncidencia, long IdAreaReclamo, long IdMotivo, long IdEstadoProceso, long IdGestorReclamo, long IdTerritorio)
        {
            var query = _context.Incidencias.Where(c => c.Active);
            if(FechaDesde != null)
            {
                query = query.Where(x => x.FechaReporteIncidencia == FechaDesde);
            }
            if(FechaHasta != null)
            {
                query = query.Where(x => x.FechaMaximaCierreAnalisis == FechaHasta);
            }
            if(IdTipoIncidencia != 0)
            {
                query = query.Where(x => x.IdTipoIncidencias == IdTipoIncidencia);
            }
            if(IdTerritorio != 0)
            {
                query = query.Where(x => x.IdTerritorio == IdTerritorio);
            }
            if(IdMotivo != 0)
            {
                query = query.Where(x => x.IdMotivo == IdMotivo);
            }
            if(IdEstadoProceso != 0)
            {
                query = query.Where(x => x.IdEstadoProcesoFicha == IdEstadoProceso);
            }
            if(IdGestorReclamo != 0)
            {
                query = query.Where(x => x.IdGestorReclamo == IdGestorReclamo);
            }
            if(IdTerritorio != 0)
            {
                query = query.Where(x => x.IdTerritorio == IdTerritorio);
            }

            //var resultList = await query.Select(c => new SeguimientoIncidenciasDto
            //{

            //}).ToListAsync();

            //return resultList;
            CultureInfo culture = new CultureInfo("en-US");
            var list = await _context.Incidencias
                .Where(inc => inc.Active)
                .Select(Inc => new SeguimientoIncidenciasDto
                {

                    diasPlazo1 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel1, culture),
                    diasPlazo2 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel2, culture),
                    diasTotales = Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2),
                    numero = Inc.CodigoFicha.Substring(2),
                    NumeroEC = Inc.CodigoFicha.Substring(2).PadLeft(8, '0').Substring(0, 6),
                    Codigo = Inc.CodigoFicha.Substring(2),
                    IdIncidenncias = Inc.IdIncidencias,
                    TipoSolicitud = Inc.TipoIncidencia.Nombre,
                    FechaReclamo = Convert.ToDateTime(Inc.FechaFicha).ToString("dd/MM/yyyy"),

                    Clasificacion = _context.Matrizs.FirstOrDefault(x => x.Active && x.IdSubMotivo == Inc.IdSubmotivo).TipoFicha.Nombre,
                    SubCodigo = Inc.SubMotivo.CodigoSubMotivo,
                    SubMotivo = Inc.SubMotivo.NombreSubMotivo,
                    CodigoMotivo = Inc.Motivo.CodigoMotivo,
                    AreaEvaluado = Inc.AreaReclamos.AreaReclamo,
                    DiasAnalisis = Inc.DiasCierreAnalisis == null ? Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2) : Convert.ToInt32(Inc.DiasCierreAnalisis),
                    FechaMaximaCierreMatriz = Convert.ToDateTime(Inc.FechaMaximaCierreAnalisis).ToString("dd/MM/yyyy"),
                    FechaCierreAnalisis = Inc.FechaAnalisisConcluido == null ? "" : Inc.FechaAnalisisConcluido.Value.ToString("dd/MM/yyyy"),
                    Dias = Convert.ToInt32(Inc.PlazoTotal),
                    Status = Inc.EstadoProcesoFicha.Nombre,
                    IdEstadoProcesoFicha = Inc.IdEstadoProcesoFicha,
                    IdEstadoIncidencias = Inc.IdEstadoProcesoFicha,

                    CodigoNodo = Inc.Solicitante.CodigoNodo,
                    Nodo = Inc.Solicitante.Nodo,
                    ClienteSolicitante = Inc.Solicitante.SolicitateSap,
                    CodigoCliente = Inc.Solicitante.CodigoSolicitante,
                    CodigoClienteFinal = Inc.Solicitante.CodigoDestinatario,
                    COD_GRUPO_CLIENTE_PRE = Inc.Solicitante.COD_GRUPO_CLIENTE_PRE,
                    GRUPO_CLIENTE_PRE = Inc.Solicitante.GRUPO_CLIENTE_PRE,
                    Region = Inc.Territorio.Nombre ?? "´--",
                    CodSap = Inc.CodigoSAP ?? "--",
                    NumeroFactura = Inc.NumeroFactura,
                    GestorReclamos = Inc.ResponsableNivel1.NombreResposable ?? "--",
                    CostoAsociadosTransporteDesinfeccionOtros = Inc.ObservacionesCostoAsociado ?? "--",
                    Mes = Convert.ToDateTime(Inc.FechaReporteIncidencia).Month.ToString(),
                    FechaRegistro = Convert.ToDateTime(Inc.FechaReporteIncidencia).ToString("dd/MM/yyyy"),

                }).ToListAsync();

            return list;
        }

        public async Task<List<SeguimientoIncidenciasDto>> Get(string CodigoReclamo)
        {
            CultureInfo culture = new CultureInfo("en-US");
            var list = await _context.Incidencias
                .Where(inc => inc.Active && inc.Codigo == CodigoReclamo)
                .Select(Inc => new SeguimientoIncidenciasDto
                {

                    diasPlazo1 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel1, culture),
                    diasPlazo2 = Convert.ToDecimal(Inc.SubMotivo.PlazoNivel2, culture),
                    diasTotales = Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2),
                    numero = Inc.CodigoFicha.Substring(2),
                    NumeroEC = Inc.CodigoFicha.Substring(2).PadLeft(8, '0').Substring(0, 6),
                    Codigo = Inc.CodigoFicha.Substring(2),
                    IdIncidenncias = Inc.IdIncidencias,
                    TipoSolicitud = Inc.TipoIncidencia.Nombre,
                    FechaReclamo = Convert.ToDateTime(Inc.FechaFicha).ToString("dd/MM/yyyy"),

                    Clasificacion = _context.Matrizs.FirstOrDefault(x => x.Active && x.IdSubMotivo == Inc.IdSubmotivo).TipoFicha.Nombre,
                    SubCodigo = Inc.SubMotivo.CodigoSubMotivo,
                    SubMotivo = Inc.SubMotivo.NombreSubMotivo,
                    CodigoMotivo = Inc.Motivo.CodigoMotivo,
                    AreaEvaluado = Inc.AreaReclamos.AreaReclamo,
                    DiasAnalisis = Inc.DiasCierreAnalisis == null ? Convert.ToInt32(Inc.SubMotivo.PlazoNivel1) + Convert.ToInt32(Inc.SubMotivo.PlazoNivel2) : Convert.ToInt32(Inc.DiasCierreAnalisis),
                    FechaMaximaCierreMatriz = Convert.ToDateTime(Inc.FechaMaximaCierreAnalisis).ToString("dd/MM/yyyy"),
                    FechaCierreAnalisis = Inc.FechaAnalisisConcluido == null ? "" : Inc.FechaAnalisisConcluido.Value.ToString("dd/MM/yyyy"),
                    Dias = Convert.ToInt32(Inc.PlazoTotal),
                    Status = Inc.EstadoProcesoFicha.Nombre,
                    IdEstadoProcesoFicha = Inc.IdEstadoProcesoFicha,
                    IdEstadoIncidencias = Inc.IdEstadoProcesoFicha,

                    CodigoNodo = Inc.Solicitante.CodigoNodo,
                    Nodo = Inc.Solicitante.Nodo,
                    ClienteSolicitante = Inc.Solicitante.SolicitateSap,
                    CodigoCliente = Inc.Solicitante.CodigoSolicitante,
                    CodigoClienteFinal = Inc.Solicitante.CodigoDestinatario,
                    COD_GRUPO_CLIENTE_PRE = Inc.Solicitante.COD_GRUPO_CLIENTE_PRE,
                    GRUPO_CLIENTE_PRE = Inc.Solicitante.GRUPO_CLIENTE_PRE,
                    Region = Inc.Territorio.Nombre ?? "´--",
                    CodSap = Inc.CodigoSAP ?? "--",
                    NumeroFactura = Inc.NumeroFactura,
                    GestorReclamos = Inc.ResponsableNivel1.NombreResposable ?? "--",
                    CostoAsociadosTransporteDesinfeccionOtros = Inc.ObservacionesCostoAsociado ?? "--",
                    Mes = Convert.ToDateTime(Inc.FechaReporteIncidencia).Month.ToString(),
                    FechaRegistro = Convert.ToDateTime(Inc.FechaReporteIncidencia).ToString("dd/MM/yyyy"),

                }).ToListAsync();

            return list;
        }
    }
}
